// Defines & Includes
// Note: F_CPU defined in UART.h
#include "UART.h"
#include "Peripherals.h"
#include <avr/io.h>
#include <avr/interrupt.h>
#include <string.h>	// memcpy/memset
// Function Declarations
void setup(void);
// Volatile variables accessed within interrupts
volatile uart rxData;	// Received data
volatile enum comms COMM_STATE;	// Communications state machine
volatile unsigned char dataStatus;	// Flag: Data ready to be processed
// Variables
uart data; // Holds data received from PC Application
peripherals measurements; // Holds latest readings from various peripherals
// Main function
int main(void)
{
	setup();

	while(1)
    {
		if(dataStatus)
		{
			dataStatus = 0;	// Reset Flag

			memcpy(&data, &rxData, sizeof(rxData));	// Make a copy of received data.

			// Perform action based on received instruction
			switch(data.INS)
			{
				case TXCHECK:
					UARTSendByte(TX_VALID);
				break;
				case READ_PINA:
					UARTSendByte(PINA);
				break;
				case READ_POT1:
					measurements.pot1 = readADC(POT1);
					UARTSendByte(measurements.pot1);
				break;
				case READ_POT2:
					measurements.pot2 = readADC(POT2);
					UARTSendByte(measurements.pot2);
				break;
				case READ_TEMP:
					measurements.temp = readADC(TEMP);
					UARTSendByte(measurements.temp);
				break;
				case READ_LIGHT:
					measurements.light = readADC(LIGHT);
					UARTSendByte(measurements.light);
				break;
				case SET_PORTC:
					PORTC = data.LSB;
					UARTSendByte(data.INS);
				break;
				case SET_HEATER:
					heaterSetOnFire(UARTExtractU16(&data));
					UARTSendByte(data.INS);
				break;
				case SET_LIGHT:
					lightSetBrightness(UARTExtractU16(&data));
					UARTSendByte(data.INS);
				break;
				case SET_MOTOR:
					motorSetSpeed(UARTExtractU16(&data));
					UARTSendByte(data.INS);
				break;
				default:
					UARTSendByte(0xFF);	// C# program expects something back.
				break;
			}
		}
	}
}
// Setup. Keeps main function relatively clean.
void setup(void)
{
	// Setup IO
	DDRE = 0x03;	// Multiplexer: Buttons
	PORTE = 0x00;	// MUX (See above)
	DDRC = 0xFF;	// PORTC - Output
	DDRA = 0x00;	// PORTA - Input

	UARTSetup();	// Setup UART
	peripheralInit();	// Setup peripherals (ADC, light, motor, heater)

	sei();	// Enable global interrupts (UART + Peripherals)
}
// Interrupt: UART RX Complete
ISR(USART1_RX_vect)
{
	// Receive Byte
	char rxByte;
	rxByte = UDR1;

	// State machine: Received communications
	switch(COMM_STATE)
	{
		// Start Byte
		case COMM_START:
			if(rxByte == START_BYTE)
			{
				COMM_STATE = COMM_INS;	// Change state to INS
			}
			break;
		// Instruction Byte
		case COMM_INS:
			if(rxByte >= TXCHECK && rxByte <= READ_LIGHT)	// Change state to STOP
			{
				rxData.INS = rxByte;
				COMM_STATE = COMM_STOP;
			}
			else if(rxByte >= SET_PORTC && rxByte <= SET_MOTOR)	// Change state to LSB
			{
				rxData.INS = rxByte;
				COMM_STATE = COMM_LSB;
			}
			else	// Invalid INS. Back to START
			{
				COMM_STATE = COMM_START;
			}
		break;
		// Data (LSB) Byte
		case COMM_LSB:
			rxData.LSB = rxByte;
			COMM_STATE = COMM_MSB;
		break;
		// Data (MSB) Byte
		case COMM_MSB:
			rxData.MSB = rxByte;
			COMM_STATE = COMM_STOP;
		break;
		// Stop Byte
		case COMM_STOP:
			// If message correctly terminated, set data ready flag
			if(rxByte == STOP_BYTE)
			{
				dataStatus = 1;	// Flag: Data Ready
			}
			// No matter what, go back to START
			COMM_STATE = COMM_START;
		break;
	}
}
