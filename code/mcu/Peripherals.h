#ifndef PERIPHERALS_H_
#define PERIPHERALS_H_
// Defines: ADC Channels
// Settings: Left-shifted, ADC start conversion
#define LIGHT 0b01100000
#define POT1 0b01100010
#define POT2 0b01100001
#define TEMP 0b01100011
// Struct: Holds latest readings from various peripherals
typedef struct  
{
	unsigned char pot1;
	unsigned char pot2;
	unsigned char light;
	unsigned char temp;
}peripherals;
// Function Declarations
void peripheralInit(void);
char readADC(char channel);
void lightSetBrightness(uint16_t brightness);
void motorSetSpeed(uint16_t speed);
void heaterSetOnFire(uint16_t fire);
#endif /* PERIPHERALS_H_ */