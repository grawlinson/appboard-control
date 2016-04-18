using System;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBoardControl
{
    public partial class Form1 : Form
    {
        private EventHandler ev;

        // Appboard Class
        private AppBoard board = new AppBoard();
        
        // PID values
        private const float dt = 0.05f; // 20 Hz
        private float pi_intError;

        public Form1()
        {
            InitializeComponent();

            // Default value of 38400 bps
            cbBaudRate.SelectedIndex = cbBaudRate.FindStringExact("38400");

            // Try & get available COM ports
            try
            {
                string[] ports = board.GetCOMPorts();

                if (ports.Length == 0)
                {
                    lbTXStatus.Text = "No COM ports available!";
                    appTabs.Enabled = false;
                    throw new Exception("No COM ports available!");
                }
                else
                {
                    // Add available COM ports to ComboBox & select first one
                    cbCOMPort.DataSource = ports;
                    cbCOMPort.SelectedIndex = 0;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Connect Click: Connect/Disconnect from AppBoard
        private void ConnectClick(object sender, EventArgs e)
        {
            try
            {
                if (board.isConnected)
                {
                    // Turn off all peripherals before disconnecting (Remove board.WriteX if this breaks)
                    board.WritePORTC(0);
                    board.WriteLight(0);
                    board.WriteMotor(0);
                    board.WriteHeater(0);
                    DisconnectBoard();
                }
                else
                {
                    ConnectBoard();
                }
                
            }
            catch(Exception ex)
            {
                DisconnectBoard();
                MessageBox.Show("ERROR: " + ex.Message, "Error connecting to board.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Tab Index Changed: Update Timer Event
        private void appTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Update Timer Event based on selected tab
                switch (appTabs.SelectedIndex)
                {
                    case 0: // Setup
                        appTimer.Stop();
                        Debug.WriteLine("Setup tab.");
                        break;
                    case 1: // Digital I/O
                        if (board.isConnected)
                        {
                            UpdateTimerEvent(digIO_Tick);
                        }
                        else
                        {
                            appTimer.Stop();
                        }
                        Debug.WriteLine("Digital I/O tab.");
                        break;
                    case 2: // Pots
                        if (board.isConnected)
                        {
                            UpdateTimerEvent(Pot_Tick);
                        }
                        else
                        {
                            appTimer.Stop();
                        }

                        Debug.WriteLine("Pot tab.");
                        break;
                    case 3: // Light
                        if (board.isConnected)
                        {
                            UpdateTimerEvent(Light_Tick);
                        }
                        else
                        {
                            appTimer.Stop();
                        }
                        Debug.WriteLine("Light tab.");
                        break;
                    case 4: // Temp Control
                        if (board.isConnected)
                        {
                            UpdateTimerEvent(Temp_Tick);
                        }
                        else
                        {
                            appTimer.Stop();
                        }
                        Debug.WriteLine("Temp tab.");
                        break;
                }

                // Turn off motor + heater when the temperature tab is deselected
                if (appTabs.SelectedIndex != 4 && board.isConnected)
                {
                    board.WriteHeater(0);
                    board.WriteMotor(0);
                }
            }
            catch (Exception ex)
            {
                appTimer.Stop();
                DisconnectBoard();
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Timer Event Manager
        private void UpdateTimerEvent(EventHandler newEvent)
        {
            appTimer.Stop();    // Stop Timer

            // Update Timer Event
            if (ev != null)
                appTimer.Tick -= ev;
            appTimer.Tick += newEvent;
            ev = newEvent;
            appTimer.Start();   // Start Timer
        }
        // Timer Event: Digital IO Tab
        private void digIO_Tick(object sender, EventArgs e)
        {
            try
            {
                // Read PINA & update GUI
                board.ReadPINA();
                ByteToLEDs(board.PINA);

                // Write PORTC & update GUI
                byte PORTC = CheckboxesToByte();
                ByteToSevenSegment(PORTC);
                board.WritePORTC(PORTC);
            }
            catch(Exception ex)
            {
                appTimer.Stop();
                DisconnectBoard();
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        // Timer Event: Potentiometer Tab
        private void Pot_Tick(object sender, EventArgs e)
        {
            try
            {
                board.ReadPotV();   // Read pot voltages

                // Update GUI
                agPot1.Value = board.VoltagePot1;
                agPot2.Value = board.VoltagePot2;
            }
            catch (Exception ex)
            {
                appTimer.Stop();
                DisconnectBoard();
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Timer Event: Light Tab
        private void Light_Tick(object sender, EventArgs e)
        {
            try
            {
                // Invert vertical scrolling box value
                byte brightness = Convert.ToByte(100 - (vsbLightBrightness.Value - vsbLightBrightness.Minimum));

                // Write & read to Light
                board.WriteLight(brightness);
                board.ReadLight();

                // Update GUI
                tbLightBrightness.Text = brightness.ToString() + "%";
                agLightBrightness.Value = (float)board.Light;
            }
            catch (Exception ex)
            {
                appTimer.Stop();
                DisconnectBoard();
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Timer Event: Temperature Tab
        private void Temp_Tick(object sender, EventArgs e)
        {
            try
            {
                // Turn on heater & read current temp
                board.WriteHeater(100);
                board.ReadTemp();

                // PID Calculations
                float pi_Kp = (float)nudKp.Value;
                float pi_Ki = (float)nudKi.Value;
                float pi_error = board.Temp - (float)nudTempSetpoint.Value;
                pi_intError = pi_intError + pi_error * dt;
                float pi_output = pi_Kp * pi_error + pi_Ki * pi_intError;

                // Clamping integral + output between 0-100
                if(pi_output > 100)
                {
                    pi_intError -= pi_output - 100;
                    pi_output = 100;
                }
                else if(pi_output < 0)
                {
                    pi_intError += - pi_output;
                    pi_output = 0;
                }

                Debug.WriteLine("PID (err/int_err/out): " + pi_error.ToString("F") + "/" + pi_intError.ToString("F") + "/" + pi_output.ToString("F"));

                // Write motor speed to board
                byte speed = Convert.ToByte(pi_output);
                board.WriteMotor(speed);

                // Update GUI
                tbActualTemp.Text = board.Temp.ToString();
                tbMotorSpeed.Text = speed.ToString();

                // Add current temperature, speed & setpoint to chart series
                chartTemp.Series["Temperature"].Points.Add(board.Temp);
                chartTemp.Series["Motor Speed"].Points.Add(speed);
                chartTemp.Series["Setpoint"].Points.Add(Convert.ToUInt16(nudTempSetpoint.Value));
            }
            catch (Exception ex)
            {
                appTimer.Stop();
                DisconnectBoard();
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Reset board & disconnect when applicaton closed
        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Only perform reset if board actually connected
                if (board.isConnected)
                {
                    // Reset board, then disconnect
                    board.WritePORTC(0);
                    board.WriteLight(0);
                    board.WriteMotor(0);
                    board.WriteHeater(0);
                    DisconnectBoard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Helper Functions
        // Disconnect from board
        private void DisconnectBoard()
        {
            // Disconnect from board
            Debug.WriteLine("Disconnecting...");
            board.Disconnect();
            board.isConnected = false;

            // Update GUI
            ledTXStatus.On = false;
            lbTXStatus.Text = "TX Disconnected";
            btConnect.Text = "Connect";
        }
        // Connect to board
        private void ConnectBoard()
        {
            // Set board settings & connect
            Debug.WriteLine("Connecting...");
            Debug.WriteLine("COM Port: " + cbCOMPort.Text.ToString());
            Debug.WriteLine("Baud Rate: " + cbBaudRate.Text.ToString());
            board.SetCOMPort(cbCOMPort.Text);
            board.SetBaudRate(int.Parse(cbBaudRate.Text));
            board.Connect();

            // Ensure communication actually occurs
            if (board.CheckTx())
            {
                // It's alive!
                board.isConnected = true;

                // Update GUI
                ledTXStatus.On = true;
                lbTXStatus.Text = "TX Connected";
                btConnect.Text = "Disconnect";
            }
            else
            {
                throw new Exception("Application failed to communicate with AppBoard.");
            }
        }
        // GUI: Gather PORTC checkboxes & convert into a byte
        private byte CheckboxesToByte()
        {
            byte generatedByte = new byte();

            // Generate byte from checkboxes (LSB to MSB)
            if (ckPC0.Checked)
                generatedByte++;
            if (ckPC1.Checked)
                generatedByte += 2;
            if (ckPC2.Checked)
                generatedByte += 4;
            if (ckPC3.Checked)
                generatedByte += 8;
            if (ckPC4.Checked)
                generatedByte += 16;
            if (ckPC5.Checked)
                generatedByte += 32;
            if (ckPC6.Checked)
                generatedByte += 64;
            if (ckPC7.Checked)
                generatedByte += 128;

            return generatedByte;
        }
        // GUI: Turn on LEDs based on received byte
        private void ByteToLEDs(byte receivedByte)
        {
            // BitMap/Array enables individual bit selection of received byte
            BitArray receivedBitArray = new BitArray(new byte[] { receivedByte });

            // Enable/Disable LEDs
            ledPA0.On = receivedBitArray.Get(0);
            ledPA1.On = receivedBitArray.Get(1);
            ledPA2.On = receivedBitArray.Get(2);
            ledPA3.On = receivedBitArray.Get(3);
            ledPA4.On = receivedBitArray.Get(4);
            ledPA5.On = receivedBitArray.Get(5);
            ledPA6.On = receivedBitArray.Get(6);
            ledPA7.On = receivedBitArray.Get(7);
        }
        // GUI: Update 7 Segment based on received byte
        private void ByteToSevenSegment(byte receivedByte)
        {
            byte lowNibble = (byte)(receivedByte & 0x0F);
            byte highNibble = (byte)(receivedByte >> 4);

            sevenSegLowNibble.Value = lowNibble.ToString("X");
            sevenSegHighNibble.Value = highNibble.ToString("X");
        }
    }
}
