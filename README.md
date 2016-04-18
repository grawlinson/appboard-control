# AppBoard Control

This is an old university assignment, the majority of this has been summarised from the assignment handout.

A C# GUI was developed to control the functionality of a pre-made Application Board (AppBoard, aka MCU) from a PC. The GUI has separate tabs that control different aspects of the application board. All communication is done via a USB Serial port to an Serial-UART converter on the AppBoard.

The AppBoard is powered by an Atmel microcontroller (AT90USB1287) and has various peripherals/components on the board.

## C# GUI Specifications

The GUI attempts to refresh in real time via a Timer event handler set to go off every 50 milliseconds. Each tab has it's own event that is made the main event when the specified tab is selected.

A C# class (AppBoard.cs) was created for this application. It is responsible for connecting to the AppBoard via Serial port & reading/writing peripheral values. It has a variety of public/private variables & functions.

The GUI was developed using Visual Studio 2013, but should work with VS 2015.

### Setup Tab

![Image of Setup Tab][tab-setup]

Allows user to specify which Serial COM port & baud rate via two drop-down boxes. The COM ports are automatically populated with available COM ports when the GUI application is initially started. The baud rate options are (9600, 19200, 38400, 57600 & 115200) with a default value of 38400 bps.

When the connect button is pressed, the application will attempt to open the selected port & ensure communication with the AppBoard is working. If connection & communications is OK, the GUI will light up the TX_OK LED & display "CONNECTED" somewhere. The other tabs will then be enabled.
### Digital I/O Tab
![Image of Digital I/O Tab][tab-digital]

The digital I/O tab allows the GUI to read each of the PORTA pins & write to the LEDs on PORTC. When the PINA pins are on, the GUI bulbs will turn on. When the PORTC LEDs are turned on, the 7-Segment GUI will show the LED status as displayed on the board.

The third-party UI controls shown in the image are the [LED Bulb][ledbulb] & [Seven Segment][7seg].
### Potentiometer Tab
![Image of Potentiometer Tab][tab-potentiometer]

This tab allows users to view the current voltage levels (0-5V) of both potentiometers on the board.

The third-party UI control shown is the [Aqua Gauge][aquagauge].
### Light Tab
![Image of Light Tab][tab-light]

The light tab allows the user to adjust the lamp brighness via vertical scroll bar (0-100%), and the light level is read by the on-board photodiode.
### Temperature Control Tab
![Image of Temperature Control Tab][tab-control]

The temperature control tab implements a temperature PI controller with real-time plotting & tuning. On the board, the temperature sensor is below a heater element, which has a fan on top. The PI controller will attempt to control the temperature via fan motor speed.

Note: The picture is not up to date. The graph actually has 3 different lines; measured temperature, desired temperature & motor speed for easier debugging.
## AppBoard Specifications
Written in C using [Atmel Studio][atmelstudio]. It has the following responsibilities/tasks. It will continuously poll to see whether an instruction has been received by the serial port, and will respond accordingly before waiting for the next instruction.
### Digital I/O
* Read the value of PINA
* Write the value of PORTC
### Analog I/O
* Using the on-board analog to digital converter (ADC) to take voltage measurements of the following sensors:
    * Light sensor
    * Temperature sensor (50mV/degree Celsius)
    * Potentiometer 1 (AVCC = 5V)
    * Potentiometer 2 (AVCC = 5V)

* Each  measurement will return the 8-bit MSB of the ADC
* Store measurement as an unsigned char, convertion to voltage will be done in the C# GUI
### Timer
* Using Timer 1 to control the PWM duty-cycle of the following peripherals:
    * Motor (OCR1A)
    * Lamp (OCR1B)
    * Heater (OCR1C)
* Timer1 set to use Fast PWM with a TOP value of ICR1 (399) which provides a PWM frequency of 20 kHz if a prescaler of 1 is used. The peripheral OCR registers will accept a range from 0-399 therefore 16-bit integers are required to set the 3 peripheral registers.
### Serial Port
* UART1 used to receive instructions & data from the C# GUI
* Use an interrupt with state machine to decode the information being received over the serial port. See the communication protocol below for details of the state machine.
* Setup with a baudrate of 38400bps & 8N1 (8 data bits, no parity & 1 stop bit)
## Communications Protocol
To communicate between the PC & MCU, a custom protocol is used on top of the Serial port. It has two forms:

Sending a READ instruction from the PC to the MCU:

![Image of READ Instruction][ins-read]

Sending a WRITE instruction & a 16-bit integer from the PC to the MCU:

![Image of WRITE Instruction][ins-write]

### Examples

In all cases, if the start byte is not received by the MCU ISR while in the start state, then the data received is thrown away. The same applies if the stop byte is not received at the end of a packet of information – if not received, all data and instructions are discarded and no action is taken.

#### Reading PINA (viewed from the PC)

1. 0x53 is sent (start byte)
2. 0x01 is sent (instruction to read PINA, see table below)
3. 0xAA is sent (stop byte)
4. PINA data is received as one byte from the MCU

#### Reading PINA (viewed from the MCU)

1. A byte is received by the UART, if its 0x53, move to the instruction state
2. A byte is received by the UART, if it is a measurement instruction, save it and move to the stop state
3. A byte is received by the UART, if it is 0xAA, indicate to the while(1) that an instruction is ready for processing, and return to the start state
4. The while(1) detects an instruction is ready, processes the instruction, and sends back the required information (e.g. UDR1 = PINA, in this case).

#### Writing the motor speed (viewed from the PC)

1. 0x53 is sent (start byte)
2. 0x0D is sent (instruction to write the motor speed, see below)
3. LS Byte of 16 bit integer containing speed is sent
4. MS Byte of 16 bit integer containing speed is sent
5. 0xAA is sent (stop byte)
6. 0x0D (the same instruction as sent) is received as one byte from the MCU, indicating it was successfully received and understood

#### Writing the motor speed (viewed from the MCU)

1. A byte is received by the UART, if its 0x53, move to the instruction state
2. A byte is received by the UART, if it is a write instruction, save it, and move to the LSB state
3. A byte is received by the UART, shift appropriately into integer storage, move to MSB state
4. A byte is received by the UART, shift appropriately into integer storage, move to stop state
5. A byte is received by the UART, if its 0xAA, indicate to the while(1) that an instruction is ready for processing, and return to the start state
6. The while(1) detects an instruction is ready, processes the instruction (in this case writes the integer to OCR1A), then sends back the received instruction (in this case UDR1 = 0x0D).

### Table of Instructions

Instruction|Code|MCU Action
-|-|-
TXCHECK|0x00|Return 0x0F to indicate communications is working
READ_PINA|0x01|Return contents of PINA
READ_POT1|0x02| Read ADC Channel 2 & return ADCH
READ_POT2|0x03| Read ADC Channel 1 & return ADCH
READ_TEMP|0x04| Read ADC Channel 3 & return ADCH
READ_LIGHT|0x05| Read ADC Channel 0 & return ADCH
SET_PORTC|0x0A| Write the 8-bit LSB of the received integer to PORTC, return 0x0A
SET_HEATER|0x0B| Write the received integer to OCR1C, return 0x0B
SET_LIGHT|0x0C| Write the received integer to OCR1B, return 0x0C
SET_MOTOR|0x0D| Write the received integer to OCR1A, return 0x0D

Note: All write instructions are 0x0A or greater. This is used by the UART_TX_receive interrupt to determine whether to expect the data bytes next, or the stop byte. Start & stop bytes are not required to be transmitted back to the PC, only 1 byte is ever returned.

## LICENSE
The MIT License (MIT)

Copyright (c) 2015 George Rawlinson <mailto:george@rawlinson.net.nz>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

[tab-setup]: images/tabs/Setup.png
[tab-digital]: images/tabs/Digital.png
[tab-potentiometer]: images/tabs/Pots.png
[tab-light]: images/tabs/Lights.png
[tab-control]:images/tabs/Temp.png
[ins-read]: images/diagrams/ins-read.png
[ins-write]: images/diagrams/ins-write.png
[ledbulb]: http://www.codeproject.com/Articles/114122/A-Simple-Vector-Based-LED-User-Control
[7seg]: http://www.codeproject.com/Articles/37800/Seven-segment-LED-Control-for-NET
[aquagauge]: www.codeproject.com/Articles/20341/Aqua-Gauge
[atmelstudio]: http://www.atmel.com/Microsite/atmel-studio/
