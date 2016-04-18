#ifndef UART_H_
#define UART_H_
#include <stdint.h>	// uint16_t (UARTExtractU16 requires this, otherwise header won't compile)
// Defines: F_CPU + Baudrate
#define F_CPU 8000000UL
#define USART_BAUDRATE 38400
#define BAUD_PRESCALE ((( F_CPU / ( USART_BAUDRATE * 16UL ))) - 1)
// Defines: Instruction Bytes
#define TXCHECK 0x00
#define READ_PINA 0x01
#define READ_POT1 0x02
#define READ_POT2 0x03
#define READ_TEMP 0x04
#define READ_LIGHT 0x05
#define SET_PORTC 0x0A
#define SET_HEATER 0x0B
#define SET_LIGHT 0x0C
#define SET_MOTOR 0x0D
#define START_BYTE 0x53
#define STOP_BYTE 0xAA
#define TX_VALID 0x0F
// Struct: Holds data received from PC Application
typedef struct
{
	unsigned char INS;	// Instruction byte
	unsigned char MSB;	// uint16_t - MSB
	unsigned char LSB;	// uint16_t - LSB
}uart;
// Enum: State machine that switches between received UART states.
enum comms {COMM_START, COMM_STOP, COMM_INS, COMM_MSB, COMM_LSB};
// Function Declarations
void UARTSetup(void);
void UARTSendByte(unsigned char data);
uint16_t UARTExtractU16(uart *data);
#endif /* UART_H_ */