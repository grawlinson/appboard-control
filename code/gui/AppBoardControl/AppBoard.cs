using System;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AppBoardControl
{
    class AppBoard
    {
        // CONSTANTS
        private const byte TXCHECK = 0x00;
        private const byte READ_PINA = 0x01;
        private const byte READ_POT1 = 0x02;
        private const byte READ_POT2 = 0x03;
        private const byte READ_TEMP = 0x04;
        private const byte READ_LIGHT = 0x05;
        private const byte SET_PORTC = 0x0A;
        private const byte SET_HEATER = 0x0B;
        private const byte SET_LIGHT = 0x0C;
        private const byte SET_MOTOR = 0x0D;
        private const byte START_BYTE = 0x53;
        private const byte STOP_BYTE = 0xAA;
        private const byte TX_VALID = 0x0F;

        // Private Member Values
        private SerialPort _serialPort;

        // Public Member Values
        public bool isConnected;
        public float VoltagePot1, VoltagePot2, Temp;
        public byte PINA, Light;

        // Class Constructor
        public AppBoard()
        {
            isConnected = false;

            // Serial Port - 8N1 with 500 mS timeout
            _serialPort = new SerialPort();
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
        }
        // Connect to Serial Port
        public void Connect()
        {
            //if (_serialPort.BaudRate.ToString().Length == 0)
            //{
            //    throw new Exception("Baud rate not set.");
            //}
            
            //if (_serialPort.PortName.Length == 0)
            //{
            //    throw  new Exception("Port name not set.");
            //}

            //if (isConnected)
            //{
            //    throw new Exception("Serial Port is already connected.");
            //}

            _serialPort.Open();
        }
        // Disconnect from Serial Port
        public void Disconnect()
        {
            //if (!isConnected)
            //{
            //    throw new Exception("Board isn't even connected.");
            //}

            _serialPort.Close();
        }
        // Return available COM Ports
        public string[] GetCOMPorts()
        {
            // Sort portnames in ascending order before returning
            ArrayList portList = new ArrayList(SerialPort.GetPortNames());
            portList.Sort();
            return (string[])portList.ToArray(typeof(string));
        }
        // Set COM Port
        public void SetCOMPort(string comPort)
        {
            _serialPort.PortName = comPort;
        }
        // Set Baud Rate
        public void SetBaudRate(int baudRate)
        {
            _serialPort.BaudRate = baudRate;
        }
        // Check communications with AppBoard
        public bool CheckTx()
        {
            byte txResult = ReadUInt8(TXCHECK);

            Debug.WriteLine("AppBoard.CheckTX() 0x" + txResult.ToString("X2"));

            if (txResult == TX_VALID)
            {
                return true;
            }
            
            return false;
        }
        // Read PINA & save result
        public void ReadPINA()
        {
            PINA = ReadUInt8(READ_PINA);
            Debug.WriteLine("AppBoard.ReadPINA() 0x" + PINA.ToString("X2"));
        }
        // Read potentiometer voltages & save result
        public void ReadPotV()
        {
            // Formula: Voltage = byte/255 * 5 [V]
            VoltagePot1 = ReadUInt8(READ_POT1)/255f * 5;
            VoltagePot2 = ReadUInt8(READ_POT2)/255f * 5;
            Debug.WriteLine("AppBoard.ReadPotV() " + VoltagePot1.ToString("F") + "V, " + VoltagePot2.ToString("F") + "V");
        }
        // Read LDR level & save result
        public void ReadLight()
        {
            Light = ReadUInt8(READ_LIGHT);
            Debug.WriteLine("AppBoard.ReadLight() " + Light.ToString() + " (" + (Light/255f*100).ToString("F") + "%)");
        }
        // Read current temperature & save result
        public void ReadTemp()
        {
            // Formula: Temperature = (byte/255) * 5 [V] / 0.05 [mV/degC]
            Temp = ReadUInt8(READ_TEMP)/255f * 5 / 0.05f;
            Debug.WriteLine("Appboard.ReadTemp() " + Temp.ToString("F"));
        }
        // Write to PORTC
        public byte WritePORTC(byte PORTC)
        {
            byte returnValue = WriteUInt16(SET_PORTC, Convert.ToUInt16(PORTC));

            Debug.WriteLine("AppBoard.WritePORTC() 0x" + PORTC.ToString("X2") + " [0x" + returnValue.ToString("X2") + "]");

            return returnValue;
        }
        // Write to light (input: 0-100 [%])
        public byte WriteLight(byte brightness)
        {
            // brightness = 0-100%, scaledBrightness converts it to uint16_t while factoring in 0-399 PWM input to MCU.
            ushort scaledBrightness = Convert.ToUInt16(brightness * (399f / 100));
            byte returnValue = WriteUInt16(SET_LIGHT, scaledBrightness);

            Debug.WriteLine("AppBoard.WriteLight() " + brightness.ToString() + "% (0x" + scaledBrightness.ToString("X3") + ") [0x" + returnValue.ToString("X2") + "]");

            return returnValue;
        }
        // Write to heater (input: 0-100 [%])
        public byte WriteHeater(byte fire)
        {
            // fire = 0-100%, scaledFire converts it to uint16_t while factoring in 0-399 PWM input to MCU.
            ushort scaledFire = Convert.ToUInt16(fire * (399f / 100));
            byte returnValue = WriteUInt16(SET_HEATER, scaledFire);

            Debug.WriteLine("AppBoard.WriteHeater() " + fire.ToString() + "% (0x" + scaledFire.ToString("X3") + ") [0x" + returnValue.ToString("X2") + "]");

            return returnValue;
        }
        // Write to motor (input: 0-100 [%])
        public byte WriteMotor(byte speed)
        {
            // speed = 0-100%, scaledSpeed converts it to uint16_t while factoring in 0-399 PWM input to MCU.
            ushort scaledSpeed = Convert.ToUInt16(speed * (399f / 100));
            byte returnValue = WriteUInt16(SET_MOTOR, scaledSpeed);

            Debug.WriteLine("AppBoard.WriteMotor() " + speed.ToString() + "% (0x" + scaledSpeed.ToString("X3") + ") [0x" + returnValue.ToString("X2") + "]");

            return returnValue;
        }
        // Sends instruction & returns received byte
        private byte ReadUInt8(byte instruction)
        {
            byte[] message = {START_BYTE, instruction, STOP_BYTE};
            _serialPort.Write(message, 0, message.Length);

            return Convert.ToByte(_serialPort.ReadByte());
        }
        // Sends instruction + data to write, returns received byte
        private byte WriteUInt16(byte instruction, UInt16 data)
        {
            byte[] message = { START_BYTE, instruction, (byte)(data & 0xFF), (byte)(data >> 8), STOP_BYTE };
            _serialPort.Write(message, 0, message.Length);

            return Convert.ToByte(_serialPort.ReadByte());
        }
    }
}
