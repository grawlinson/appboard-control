// Includes
#include "UART.h"
#include <avr/io.h>
#include <avr/interrupt.h>
#include <string.h>
// Setup UART
void UARTSetup(void)
{
	// USART
	UCSR1A = 0x00;
	UCSR1B |= (_BV(RXEN1) | _BV(TXEN1)) | _BV(RXCIE1);	// Enable TX/RX + RX Interrupt
	UCSR1C |= (_BV(UCSZ10) | _BV(UCSZ11));	// Async UART, No Parity, 1-bit Stop, 8-bit Data
	UBRR1H = (BAUD_PRESCALE >> 8);	// High Byte (38400 bps)
	UBRR1L = BAUD_PRESCALE;	// Low Byte (38400 bps)
	
	sei();	// Enable global interrupts
}
// Safely send a byte
void UARTSendByte(unsigned char data)
{
	while (!(UCSR1A & _BV(UDRE1)));	// Wait until TX is ready
	UDR1 = data;
	while (!(UCSR1A & _BV(TXC1)));	// Wait until data transmitted
	UCSR1A |= _BV(TXC1);	// Clear TX complete bit
}

uint16_t UARTExtractU16(uart *data)
{
	return ((data->MSB << 8) | (data->LSB & 0xFF));	// LSB bit masking not required, leaving it in for future reference.
}