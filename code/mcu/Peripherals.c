// Includes
#include <avr/io.h>
// Internal function Declarations
void lightInit(void);
void motorInit(void);
void heaterInit(void);
void ADCInit(void);
// Initialise various peripherals
void peripheralInit(void)
{
	lightInit();
	motorInit();
	heaterInit();
	ADCInit();
}
// Initialise Light
void lightInit(void)
{
	TCCR1A |= (_BV(COM1B1) | _BV(WGM11));	// Clear OC1B@Match/Set OC1B@Top; Waveform Mode #14: Fast PWM
	TCCR1B |= (_BV(WGM13) | _BV(WGM12) | _BV(CS10));	// Waveform Mode #14; No prescaler
	ICR1 = 399;	// Set TOP at 400 for a 20kHz PWM wave
	OCR1B = 0;	// Initially set OFF
	DDRB |= _BV(DDB6);	// Output: PB5
	PORTB &= ~_BV(PB6);	// Ensuring output is off
}
// Set light brightness. Input: 0-399
void lightSetBrightness(uint16_t brightness)
{
	OCR1B = brightness;	// PWM % based on TOP value of 399
}
// Initialise motor
void motorInit(void)
{
	TCCR1A |= (_BV(COM1A1) | _BV(WGM11));	// Clear OC1A@Match/Set OC1A@Top; Waveform Mode #14: Fast PWM
	TCCR1B |= (_BV(WGM13) | _BV(WGM12) | _BV(CS10));	// Waveform Mode #14; No prescaler
	ICR1 = 399;	// Set TOP at 400 for a 20kHz PWM wave
	OCR1A = 0;	// Initially set OFF
	DDRB |= _BV(DDB5);	// Output: PB5
	PORTB &= ~_BV(PB5);	// Ensuring output is off
}
// Set motor speed. Input: 0-399
void motorSetSpeed(uint16_t speed)
{
	OCR1A = speed;	// PWM % based on TOP value of 399
}
// Initialise heater
void heaterInit(void)
{
	TCCR1A |= (_BV(COM1C1) | _BV(WGM11));	// Clear OC1A@Match/Set OC1A@Top; Waveform Mode #14: Fast PWM
	TCCR1B |= (_BV(WGM13) | _BV(WGM12) | _BV(CS10));	// Waveform Mode #14; No prescaler
	ICR1 = 399;	// Set TOP at 400 for a 20kHz PWM wave
	OCR1C = 0;	// Initially set OFF
	DDRB |= _BV(DDB7);	// Output: PB7
	PORTB &= ~_BV(PB7);	// Ensuring output is off
}
// Set heater on fire. Input: 0-399
void heaterSetOnFire(uint16_t fire)
{
	OCR1C = fire;
}
// Initialise ADC
void ADCInit(void)
{
	ADCSRA |= (_BV(ADEN) | _BV(ADPS2) | _BV(ADPS1) | _BV(ADPS0));	// Enable ADC & Prescaler of 128 (slowest conversion speed)
}
// Read selected ADC channel & return result
char readADC(char channel)
{
	ADMUX = channel;
	ADCSRA |= _BV(ADSC);	// Start conversion
	while(ADCSRA & _BV(ADSC));	// Wait for conversion to finish
	return ADCH;	// Assuming channel is left-adjusted, return 8-bit MSB.
}