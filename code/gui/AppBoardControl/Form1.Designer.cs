namespace AppBoardControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.appTabs = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.cbCOMPort = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lbTXStatus = new System.Windows.Forms.Label();
            this.ledTXStatus = new Bulb.LedBulb();
            this.btConnect = new System.Windows.Forms.Button();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.lbComPort = new System.Windows.Forms.Label();
            this.tabDigital = new System.Windows.Forms.TabPage();
            this.sevenSegLowNibble = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegHighNibble = new DmitryBrant.CustomControls.SevenSegment();
            this.ckPC1 = new System.Windows.Forms.CheckBox();
            this.ckPC2 = new System.Windows.Forms.CheckBox();
            this.ckPC3 = new System.Windows.Forms.CheckBox();
            this.ckPC4 = new System.Windows.Forms.CheckBox();
            this.ckPC5 = new System.Windows.Forms.CheckBox();
            this.ckPC6 = new System.Windows.Forms.CheckBox();
            this.ckPC7 = new System.Windows.Forms.CheckBox();
            this.ckPC0 = new System.Windows.Forms.CheckBox();
            this.lbPORTC = new System.Windows.Forms.Label();
            this.lbPA2 = new System.Windows.Forms.Label();
            this.lbPA7 = new System.Windows.Forms.Label();
            this.lbPA6 = new System.Windows.Forms.Label();
            this.lbPA5 = new System.Windows.Forms.Label();
            this.lbPA4 = new System.Windows.Forms.Label();
            this.lbPA3 = new System.Windows.Forms.Label();
            this.lbPA1 = new System.Windows.Forms.Label();
            this.lbPA0 = new System.Windows.Forms.Label();
            this.lbPINA = new System.Windows.Forms.Label();
            this.ledPA1 = new Bulb.LedBulb();
            this.ledPA2 = new Bulb.LedBulb();
            this.ledPA3 = new Bulb.LedBulb();
            this.ledPA4 = new Bulb.LedBulb();
            this.ledPA5 = new Bulb.LedBulb();
            this.ledPA6 = new Bulb.LedBulb();
            this.ledPA7 = new Bulb.LedBulb();
            this.ledPA0 = new Bulb.LedBulb();
            this.tabPots = new System.Windows.Forms.TabPage();
            this.agPot2 = new AquaControls.AquaGauge();
            this.agPot1 = new AquaControls.AquaGauge();
            this.lbPot2V = new System.Windows.Forms.Label();
            this.lbPot1V = new System.Windows.Forms.Label();
            this.tabLight = new System.Windows.Forms.TabPage();
            this.tbLightBrightness = new System.Windows.Forms.TextBox();
            this.lbLightBrightness = new System.Windows.Forms.Label();
            this.vsbLightBrightness = new System.Windows.Forms.VScrollBar();
            this.agLightBrightness = new AquaControls.AquaGauge();
            this.tabTempControl = new System.Windows.Forms.TabPage();
            this.lbTempSetpoint = new System.Windows.Forms.Label();
            this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nudKp = new System.Windows.Forms.NumericUpDown();
            this.nudKi = new System.Windows.Forms.NumericUpDown();
            this.nudTempSetpoint = new System.Windows.Forms.NumericUpDown();
            this.tbMotorSpeed = new System.Windows.Forms.TextBox();
            this.tbActualTemp = new System.Windows.Forms.TextBox();
            this.lbMotorSpeed = new System.Windows.Forms.Label();
            this.lbActualTemp = new System.Windows.Forms.Label();
            this.lbKi = new System.Windows.Forms.Label();
            this.lbKp = new System.Windows.Forms.Label();
            this.lbTuning = new System.Windows.Forms.Label();
            this.appTimer = new System.Windows.Forms.Timer(this.components);
            this.appTabs.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabDigital.SuspendLayout();
            this.tabPots.SuspendLayout();
            this.tabLight.SuspendLayout();
            this.tabTempControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempSetpoint)).BeginInit();
            this.SuspendLayout();
            // 
            // appTabs
            // 
            this.appTabs.Controls.Add(this.tabSetup);
            this.appTabs.Controls.Add(this.tabDigital);
            this.appTabs.Controls.Add(this.tabPots);
            this.appTabs.Controls.Add(this.tabLight);
            this.appTabs.Controls.Add(this.tabTempControl);
            this.appTabs.Location = new System.Drawing.Point(12, 12);
            this.appTabs.Name = "appTabs";
            this.appTabs.SelectedIndex = 0;
            this.appTabs.Size = new System.Drawing.Size(559, 352);
            this.appTabs.TabIndex = 0;
            this.appTabs.SelectedIndexChanged += new System.EventHandler(this.appTabs_SelectedIndexChanged);
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.cbCOMPort);
            this.tabSetup.Controls.Add(this.cbBaudRate);
            this.tabSetup.Controls.Add(this.lbTXStatus);
            this.tabSetup.Controls.Add(this.ledTXStatus);
            this.tabSetup.Controls.Add(this.btConnect);
            this.tabSetup.Controls.Add(this.lbBaudRate);
            this.tabSetup.Controls.Add(this.lbComPort);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(551, 326);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // cbCOMPort
            // 
            this.cbCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOMPort.FormattingEnabled = true;
            this.cbCOMPort.Location = new System.Drawing.Point(216, 106);
            this.cbCOMPort.Name = "cbCOMPort";
            this.cbCOMPort.Size = new System.Drawing.Size(121, 21);
            this.cbCOMPort.TabIndex = 6;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(216, 158);
            this.cbBaudRate.MaxDropDownItems = 6;
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudRate.TabIndex = 5;
            // 
            // lbTXStatus
            // 
            this.lbTXStatus.AutoSize = true;
            this.lbTXStatus.Location = new System.Drawing.Point(335, 217);
            this.lbTXStatus.Name = "lbTXStatus";
            this.lbTXStatus.Size = new System.Drawing.Size(90, 13);
            this.lbTXStatus.TabIndex = 4;
            this.lbTXStatus.Text = "TX Disconnected";
            // 
            // ledTXStatus
            // 
            this.ledTXStatus.Location = new System.Drawing.Point(294, 212);
            this.ledTXStatus.Name = "ledTXStatus";
            this.ledTXStatus.On = false;
            this.ledTXStatus.Size = new System.Drawing.Size(75, 23);
            this.ledTXStatus.TabIndex = 3;
            this.ledTXStatus.Text = "ledBulb1";
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(183, 212);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 2;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.ConnectClick);
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaudRate.Location = new System.Drawing.Point(143, 161);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(67, 13);
            this.lbBaudRate.TabIndex = 1;
            this.lbBaudRate.Text = "Baud Rate";
            // 
            // lbComPort
            // 
            this.lbComPort.AutoSize = true;
            this.lbComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComPort.Location = new System.Drawing.Point(149, 109);
            this.lbComPort.Name = "lbComPort";
            this.lbComPort.Size = new System.Drawing.Size(61, 13);
            this.lbComPort.TabIndex = 0;
            this.lbComPort.Text = "COM Port";
            // 
            // tabDigital
            // 
            this.tabDigital.Controls.Add(this.sevenSegLowNibble);
            this.tabDigital.Controls.Add(this.sevenSegHighNibble);
            this.tabDigital.Controls.Add(this.ckPC1);
            this.tabDigital.Controls.Add(this.ckPC2);
            this.tabDigital.Controls.Add(this.ckPC3);
            this.tabDigital.Controls.Add(this.ckPC4);
            this.tabDigital.Controls.Add(this.ckPC5);
            this.tabDigital.Controls.Add(this.ckPC6);
            this.tabDigital.Controls.Add(this.ckPC7);
            this.tabDigital.Controls.Add(this.ckPC0);
            this.tabDigital.Controls.Add(this.lbPORTC);
            this.tabDigital.Controls.Add(this.lbPA2);
            this.tabDigital.Controls.Add(this.lbPA7);
            this.tabDigital.Controls.Add(this.lbPA6);
            this.tabDigital.Controls.Add(this.lbPA5);
            this.tabDigital.Controls.Add(this.lbPA4);
            this.tabDigital.Controls.Add(this.lbPA3);
            this.tabDigital.Controls.Add(this.lbPA1);
            this.tabDigital.Controls.Add(this.lbPA0);
            this.tabDigital.Controls.Add(this.lbPINA);
            this.tabDigital.Controls.Add(this.ledPA1);
            this.tabDigital.Controls.Add(this.ledPA2);
            this.tabDigital.Controls.Add(this.ledPA3);
            this.tabDigital.Controls.Add(this.ledPA4);
            this.tabDigital.Controls.Add(this.ledPA5);
            this.tabDigital.Controls.Add(this.ledPA6);
            this.tabDigital.Controls.Add(this.ledPA7);
            this.tabDigital.Controls.Add(this.ledPA0);
            this.tabDigital.Location = new System.Drawing.Point(4, 22);
            this.tabDigital.Name = "tabDigital";
            this.tabDigital.Padding = new System.Windows.Forms.Padding(3);
            this.tabDigital.Size = new System.Drawing.Size(551, 326);
            this.tabDigital.TabIndex = 1;
            this.tabDigital.Text = "Digital I/O";
            this.tabDigital.UseVisualStyleBackColor = true;
            // 
            // sevenSegLowNibble
            // 
            this.sevenSegLowNibble.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegLowNibble.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegLowNibble.ColorLight = System.Drawing.Color.Red;
            this.sevenSegLowNibble.CustomPattern = 0;
            this.sevenSegLowNibble.DecimalOn = false;
            this.sevenSegLowNibble.DecimalShow = false;
            this.sevenSegLowNibble.ElementWidth = 10;
            this.sevenSegLowNibble.ItalicFactor = 0F;
            this.sevenSegLowNibble.Location = new System.Drawing.Point(407, 135);
            this.sevenSegLowNibble.Name = "sevenSegLowNibble";
            this.sevenSegLowNibble.Padding = new System.Windows.Forms.Padding(4);
            this.sevenSegLowNibble.Size = new System.Drawing.Size(40, 64);
            this.sevenSegLowNibble.TabIndex = 37;
            this.sevenSegLowNibble.TabStop = false;
            this.sevenSegLowNibble.Value = null;
            // 
            // sevenSegHighNibble
            // 
            this.sevenSegHighNibble.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegHighNibble.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegHighNibble.ColorLight = System.Drawing.Color.Red;
            this.sevenSegHighNibble.CustomPattern = 0;
            this.sevenSegHighNibble.DecimalOn = false;
            this.sevenSegHighNibble.DecimalShow = false;
            this.sevenSegHighNibble.ElementWidth = 10;
            this.sevenSegHighNibble.ItalicFactor = 0F;
            this.sevenSegHighNibble.Location = new System.Drawing.Point(367, 135);
            this.sevenSegHighNibble.Name = "sevenSegHighNibble";
            this.sevenSegHighNibble.Padding = new System.Windows.Forms.Padding(4);
            this.sevenSegHighNibble.Size = new System.Drawing.Size(40, 64);
            this.sevenSegHighNibble.TabIndex = 36;
            this.sevenSegHighNibble.TabStop = false;
            this.sevenSegHighNibble.Value = null;
            // 
            // ckPC1
            // 
            this.ckPC1.AutoSize = true;
            this.ckPC1.Location = new System.Drawing.Point(292, 93);
            this.ckPC1.Name = "ckPC1";
            this.ckPC1.Size = new System.Drawing.Size(46, 17);
            this.ckPC1.TabIndex = 35;
            this.ckPC1.Text = "PC1";
            this.ckPC1.UseVisualStyleBackColor = true;
            // 
            // ckPC2
            // 
            this.ckPC2.AutoSize = true;
            this.ckPC2.Location = new System.Drawing.Point(292, 122);
            this.ckPC2.Name = "ckPC2";
            this.ckPC2.Size = new System.Drawing.Size(46, 17);
            this.ckPC2.TabIndex = 34;
            this.ckPC2.Text = "PC2";
            this.ckPC2.UseVisualStyleBackColor = true;
            // 
            // ckPC3
            // 
            this.ckPC3.AutoSize = true;
            this.ckPC3.Location = new System.Drawing.Point(292, 151);
            this.ckPC3.Name = "ckPC3";
            this.ckPC3.Size = new System.Drawing.Size(46, 17);
            this.ckPC3.TabIndex = 33;
            this.ckPC3.Text = "PC3";
            this.ckPC3.UseVisualStyleBackColor = true;
            // 
            // ckPC4
            // 
            this.ckPC4.AutoSize = true;
            this.ckPC4.Location = new System.Drawing.Point(292, 180);
            this.ckPC4.Name = "ckPC4";
            this.ckPC4.Size = new System.Drawing.Size(46, 17);
            this.ckPC4.TabIndex = 32;
            this.ckPC4.Text = "PC4";
            this.ckPC4.UseVisualStyleBackColor = true;
            // 
            // ckPC5
            // 
            this.ckPC5.AutoSize = true;
            this.ckPC5.Location = new System.Drawing.Point(292, 209);
            this.ckPC5.Name = "ckPC5";
            this.ckPC5.Size = new System.Drawing.Size(46, 17);
            this.ckPC5.TabIndex = 31;
            this.ckPC5.Text = "PC5";
            this.ckPC5.UseVisualStyleBackColor = true;
            // 
            // ckPC6
            // 
            this.ckPC6.AutoSize = true;
            this.ckPC6.Location = new System.Drawing.Point(292, 238);
            this.ckPC6.Name = "ckPC6";
            this.ckPC6.Size = new System.Drawing.Size(46, 17);
            this.ckPC6.TabIndex = 30;
            this.ckPC6.Text = "PC6";
            this.ckPC6.UseVisualStyleBackColor = true;
            // 
            // ckPC7
            // 
            this.ckPC7.AutoSize = true;
            this.ckPC7.Location = new System.Drawing.Point(292, 267);
            this.ckPC7.Name = "ckPC7";
            this.ckPC7.Size = new System.Drawing.Size(46, 17);
            this.ckPC7.TabIndex = 29;
            this.ckPC7.Text = "PC7";
            this.ckPC7.UseVisualStyleBackColor = true;
            // 
            // ckPC0
            // 
            this.ckPC0.AutoSize = true;
            this.ckPC0.Location = new System.Drawing.Point(292, 64);
            this.ckPC0.Name = "ckPC0";
            this.ckPC0.Size = new System.Drawing.Size(46, 17);
            this.ckPC0.TabIndex = 28;
            this.ckPC0.Text = "PC0";
            this.ckPC0.UseVisualStyleBackColor = true;
            // 
            // lbPORTC
            // 
            this.lbPORTC.AutoSize = true;
            this.lbPORTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPORTC.Location = new System.Drawing.Point(374, 20);
            this.lbPORTC.Name = "lbPORTC";
            this.lbPORTC.Size = new System.Drawing.Size(49, 13);
            this.lbPORTC.TabIndex = 19;
            this.lbPORTC.Text = "PORTC";
            // 
            // lbPA2
            // 
            this.lbPA2.AutoSize = true;
            this.lbPA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA2.Location = new System.Drawing.Point(145, 123);
            this.lbPA2.Name = "lbPA2";
            this.lbPA2.Size = new System.Drawing.Size(27, 13);
            this.lbPA2.TabIndex = 18;
            this.lbPA2.Text = "PA2";
            // 
            // lbPA7
            // 
            this.lbPA7.AutoSize = true;
            this.lbPA7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA7.Location = new System.Drawing.Point(145, 268);
            this.lbPA7.Name = "lbPA7";
            this.lbPA7.Size = new System.Drawing.Size(27, 13);
            this.lbPA7.TabIndex = 16;
            this.lbPA7.Text = "PA7";
            // 
            // lbPA6
            // 
            this.lbPA6.AutoSize = true;
            this.lbPA6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA6.Location = new System.Drawing.Point(145, 239);
            this.lbPA6.Name = "lbPA6";
            this.lbPA6.Size = new System.Drawing.Size(27, 13);
            this.lbPA6.TabIndex = 15;
            this.lbPA6.Text = "PA6";
            // 
            // lbPA5
            // 
            this.lbPA5.AutoSize = true;
            this.lbPA5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA5.Location = new System.Drawing.Point(145, 210);
            this.lbPA5.Name = "lbPA5";
            this.lbPA5.Size = new System.Drawing.Size(27, 13);
            this.lbPA5.TabIndex = 14;
            this.lbPA5.Text = "PA5";
            // 
            // lbPA4
            // 
            this.lbPA4.AutoSize = true;
            this.lbPA4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA4.Location = new System.Drawing.Point(145, 181);
            this.lbPA4.Name = "lbPA4";
            this.lbPA4.Size = new System.Drawing.Size(27, 13);
            this.lbPA4.TabIndex = 13;
            this.lbPA4.Text = "PA4";
            // 
            // lbPA3
            // 
            this.lbPA3.AutoSize = true;
            this.lbPA3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA3.Location = new System.Drawing.Point(145, 152);
            this.lbPA3.Name = "lbPA3";
            this.lbPA3.Size = new System.Drawing.Size(27, 13);
            this.lbPA3.TabIndex = 12;
            this.lbPA3.Text = "PA3";
            // 
            // lbPA1
            // 
            this.lbPA1.AutoSize = true;
            this.lbPA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA1.Location = new System.Drawing.Point(145, 94);
            this.lbPA1.Name = "lbPA1";
            this.lbPA1.Size = new System.Drawing.Size(27, 13);
            this.lbPA1.TabIndex = 11;
            this.lbPA1.Text = "PA1";
            // 
            // lbPA0
            // 
            this.lbPA0.AutoSize = true;
            this.lbPA0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPA0.Location = new System.Drawing.Point(145, 65);
            this.lbPA0.Name = "lbPA0";
            this.lbPA0.Size = new System.Drawing.Size(27, 13);
            this.lbPA0.TabIndex = 10;
            this.lbPA0.Text = "PA0";
            // 
            // lbPINA
            // 
            this.lbPINA.AutoSize = true;
            this.lbPINA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPINA.Location = new System.Drawing.Point(119, 20);
            this.lbPINA.Name = "lbPINA";
            this.lbPINA.Size = new System.Drawing.Size(36, 13);
            this.lbPINA.TabIndex = 9;
            this.lbPINA.Text = "PINA";
            // 
            // ledPA1
            // 
            this.ledPA1.Color = System.Drawing.Color.Red;
            this.ledPA1.Location = new System.Drawing.Point(100, 89);
            this.ledPA1.Name = "ledPA1";
            this.ledPA1.On = false;
            this.ledPA1.Size = new System.Drawing.Size(75, 23);
            this.ledPA1.TabIndex = 8;
            this.ledPA1.Text = "ledBulb9";
            // 
            // ledPA2
            // 
            this.ledPA2.Color = System.Drawing.Color.Red;
            this.ledPA2.Location = new System.Drawing.Point(100, 118);
            this.ledPA2.Name = "ledPA2";
            this.ledPA2.On = false;
            this.ledPA2.Size = new System.Drawing.Size(75, 23);
            this.ledPA2.TabIndex = 7;
            this.ledPA2.Text = "ledBulb8";
            // 
            // ledPA3
            // 
            this.ledPA3.Color = System.Drawing.Color.Red;
            this.ledPA3.Location = new System.Drawing.Point(100, 147);
            this.ledPA3.Name = "ledPA3";
            this.ledPA3.On = false;
            this.ledPA3.Size = new System.Drawing.Size(75, 23);
            this.ledPA3.TabIndex = 6;
            this.ledPA3.Text = "ledBulb7";
            // 
            // ledPA4
            // 
            this.ledPA4.Color = System.Drawing.Color.Red;
            this.ledPA4.Location = new System.Drawing.Point(100, 176);
            this.ledPA4.Name = "ledPA4";
            this.ledPA4.On = false;
            this.ledPA4.Size = new System.Drawing.Size(75, 23);
            this.ledPA4.TabIndex = 5;
            this.ledPA4.Text = "ledBulb6";
            // 
            // ledPA5
            // 
            this.ledPA5.Color = System.Drawing.Color.Red;
            this.ledPA5.Location = new System.Drawing.Point(100, 205);
            this.ledPA5.Name = "ledPA5";
            this.ledPA5.On = false;
            this.ledPA5.Size = new System.Drawing.Size(75, 23);
            this.ledPA5.TabIndex = 4;
            this.ledPA5.Text = "ledBulb5";
            // 
            // ledPA6
            // 
            this.ledPA6.Color = System.Drawing.Color.Red;
            this.ledPA6.Location = new System.Drawing.Point(100, 234);
            this.ledPA6.Name = "ledPA6";
            this.ledPA6.On = false;
            this.ledPA6.Size = new System.Drawing.Size(75, 23);
            this.ledPA6.TabIndex = 3;
            this.ledPA6.Text = "ledBulb4";
            // 
            // ledPA7
            // 
            this.ledPA7.Color = System.Drawing.Color.Red;
            this.ledPA7.Location = new System.Drawing.Point(100, 263);
            this.ledPA7.Name = "ledPA7";
            this.ledPA7.On = false;
            this.ledPA7.Size = new System.Drawing.Size(75, 23);
            this.ledPA7.TabIndex = 2;
            this.ledPA7.Text = "ledBulb3";
            // 
            // ledPA0
            // 
            this.ledPA0.Color = System.Drawing.Color.Red;
            this.ledPA0.Location = new System.Drawing.Point(100, 60);
            this.ledPA0.Name = "ledPA0";
            this.ledPA0.On = false;
            this.ledPA0.Size = new System.Drawing.Size(75, 23);
            this.ledPA0.TabIndex = 0;
            this.ledPA0.Text = "ledBulb1";
            // 
            // tabPots
            // 
            this.tabPots.Controls.Add(this.agPot2);
            this.tabPots.Controls.Add(this.agPot1);
            this.tabPots.Controls.Add(this.lbPot2V);
            this.tabPots.Controls.Add(this.lbPot1V);
            this.tabPots.Location = new System.Drawing.Point(4, 22);
            this.tabPots.Name = "tabPots";
            this.tabPots.Size = new System.Drawing.Size(551, 326);
            this.tabPots.TabIndex = 2;
            this.tabPots.Text = "Pots";
            this.tabPots.UseVisualStyleBackColor = true;
            // 
            // agPot2
            // 
            this.agPot2.BackColor = System.Drawing.Color.Transparent;
            this.agPot2.DialColor = System.Drawing.Color.Lavender;
            this.agPot2.DialText = null;
            this.agPot2.Glossiness = 11.36364F;
            this.agPot2.Location = new System.Drawing.Point(283, 41);
            this.agPot2.MaxValue = 5F;
            this.agPot2.MinValue = 0F;
            this.agPot2.Name = "agPot2";
            this.agPot2.RecommendedValue = 0F;
            this.agPot2.Size = new System.Drawing.Size(250, 250);
            this.agPot2.TabIndex = 3;
            this.agPot2.ThresholdPercent = 0F;
            this.agPot2.Value = 0F;
            // 
            // agPot1
            // 
            this.agPot1.BackColor = System.Drawing.Color.Transparent;
            this.agPot1.DialColor = System.Drawing.Color.Lavender;
            this.agPot1.DialText = "";
            this.agPot1.Glossiness = 11.36364F;
            this.agPot1.Location = new System.Drawing.Point(18, 41);
            this.agPot1.MaxValue = 5F;
            this.agPot1.MinValue = 0F;
            this.agPot1.Name = "agPot1";
            this.agPot1.RecommendedValue = 0F;
            this.agPot1.Size = new System.Drawing.Size(250, 250);
            this.agPot1.TabIndex = 2;
            this.agPot1.ThresholdPercent = 0F;
            this.agPot1.Value = 0F;
            // 
            // lbPot2V
            // 
            this.lbPot2V.AutoSize = true;
            this.lbPot2V.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPot2V.Location = new System.Drawing.Point(366, 25);
            this.lbPot2V.Name = "lbPot2V";
            this.lbPot2V.Size = new System.Drawing.Size(84, 13);
            this.lbPot2V.TabIndex = 1;
            this.lbPot2V.Text = "Pot 2 Voltage";
            // 
            // lbPot1V
            // 
            this.lbPot1V.AutoSize = true;
            this.lbPot1V.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPot1V.Location = new System.Drawing.Point(101, 25);
            this.lbPot1V.Name = "lbPot1V";
            this.lbPot1V.Size = new System.Drawing.Size(84, 13);
            this.lbPot1V.TabIndex = 0;
            this.lbPot1V.Text = "Pot 1 Voltage";
            // 
            // tabLight
            // 
            this.tabLight.Controls.Add(this.tbLightBrightness);
            this.tabLight.Controls.Add(this.lbLightBrightness);
            this.tabLight.Controls.Add(this.vsbLightBrightness);
            this.tabLight.Controls.Add(this.agLightBrightness);
            this.tabLight.Location = new System.Drawing.Point(4, 22);
            this.tabLight.Name = "tabLight";
            this.tabLight.Size = new System.Drawing.Size(551, 326);
            this.tabLight.TabIndex = 3;
            this.tabLight.Text = "Light";
            this.tabLight.UseVisualStyleBackColor = true;
            // 
            // tbLightBrightness
            // 
            this.tbLightBrightness.Enabled = false;
            this.tbLightBrightness.Location = new System.Drawing.Point(151, 242);
            this.tbLightBrightness.Name = "tbLightBrightness";
            this.tbLightBrightness.ReadOnly = true;
            this.tbLightBrightness.Size = new System.Drawing.Size(49, 20);
            this.tbLightBrightness.TabIndex = 3;
            // 
            // lbLightBrightness
            // 
            this.lbLightBrightness.AutoSize = true;
            this.lbLightBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLightBrightness.Location = new System.Drawing.Point(249, 31);
            this.lbLightBrightness.Name = "lbLightBrightness";
            this.lbLightBrightness.Size = new System.Drawing.Size(98, 13);
            this.lbLightBrightness.TabIndex = 1;
            this.lbLightBrightness.Text = "Light Brightness";
            // 
            // vsbLightBrightness
            // 
            this.vsbLightBrightness.Location = new System.Drawing.Point(115, 47);
            this.vsbLightBrightness.Maximum = 109;
            this.vsbLightBrightness.Name = "vsbLightBrightness";
            this.vsbLightBrightness.Size = new System.Drawing.Size(17, 250);
            this.vsbLightBrightness.TabIndex = 0;
            this.vsbLightBrightness.Value = 100;
            // 
            // agLightBrightness
            // 
            this.agLightBrightness.AutoSize = true;
            this.agLightBrightness.BackColor = System.Drawing.Color.Transparent;
            this.agLightBrightness.DialColor = System.Drawing.Color.Lavender;
            this.agLightBrightness.DialText = "Measured";
            this.agLightBrightness.Glossiness = 11.36364F;
            this.agLightBrightness.Location = new System.Drawing.Point(188, 47);
            this.agLightBrightness.MaxValue = 255F;
            this.agLightBrightness.MinValue = 0F;
            this.agLightBrightness.Name = "agLightBrightness";
            this.agLightBrightness.NoOfDivisions = 5;
            this.agLightBrightness.RecommendedValue = 0F;
            this.agLightBrightness.Size = new System.Drawing.Size(250, 250);
            this.agLightBrightness.TabIndex = 2;
            this.agLightBrightness.ThresholdPercent = 0F;
            this.agLightBrightness.Value = 0F;
            // 
            // tabTempControl
            // 
            this.tabTempControl.Controls.Add(this.lbTempSetpoint);
            this.tabTempControl.Controls.Add(this.chartTemp);
            this.tabTempControl.Controls.Add(this.nudKp);
            this.tabTempControl.Controls.Add(this.nudKi);
            this.tabTempControl.Controls.Add(this.nudTempSetpoint);
            this.tabTempControl.Controls.Add(this.tbMotorSpeed);
            this.tabTempControl.Controls.Add(this.tbActualTemp);
            this.tabTempControl.Controls.Add(this.lbMotorSpeed);
            this.tabTempControl.Controls.Add(this.lbActualTemp);
            this.tabTempControl.Controls.Add(this.lbKi);
            this.tabTempControl.Controls.Add(this.lbKp);
            this.tabTempControl.Controls.Add(this.lbTuning);
            this.tabTempControl.Location = new System.Drawing.Point(4, 22);
            this.tabTempControl.Name = "tabTempControl";
            this.tabTempControl.Size = new System.Drawing.Size(551, 326);
            this.tabTempControl.TabIndex = 4;
            this.tabTempControl.Text = "Temp Control";
            this.tabTempControl.UseVisualStyleBackColor = true;
            // 
            // lbTempSetpoint
            // 
            this.lbTempSetpoint.AutoSize = true;
            this.lbTempSetpoint.Location = new System.Drawing.Point(34, 20);
            this.lbTempSetpoint.Name = "lbTempSetpoint";
            this.lbTempSetpoint.Size = new System.Drawing.Size(92, 13);
            this.lbTempSetpoint.TabIndex = 0;
            this.lbTempSetpoint.Text = "Setpoint Temp [C]";
            // 
            // chartTemp
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Samples";
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Temp [C] +Speed [%]";
            chartArea1.Name = "ChartArea1";
            this.chartTemp.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            this.chartTemp.Legends.Add(legend1);
            this.chartTemp.Location = new System.Drawing.Point(119, 3);
            this.chartTemp.Name = "chartTemp";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "Motor Speed";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Orange;
            series3.Legend = "Legend1";
            series3.Name = "Setpoint";
            this.chartTemp.Series.Add(series1);
            this.chartTemp.Series.Add(series2);
            this.chartTemp.Series.Add(series3);
            this.chartTemp.Size = new System.Drawing.Size(432, 320);
            this.chartTemp.TabIndex = 14;
            this.chartTemp.Text = "chart1";
            // 
            // nudKp
            // 
            this.nudKp.DecimalPlaces = 1;
            this.nudKp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudKp.Location = new System.Drawing.Point(48, 95);
            this.nudKp.Name = "nudKp";
            this.nudKp.Size = new System.Drawing.Size(65, 20);
            this.nudKp.TabIndex = 13;
            this.nudKp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudKi
            // 
            this.nudKi.DecimalPlaces = 1;
            this.nudKi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudKi.Location = new System.Drawing.Point(48, 121);
            this.nudKi.Name = "nudKi";
            this.nudKi.Size = new System.Drawing.Size(65, 20);
            this.nudKi.TabIndex = 12;
            this.nudKi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTempSetpoint
            // 
            this.nudTempSetpoint.Location = new System.Drawing.Point(48, 40);
            this.nudTempSetpoint.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudTempSetpoint.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudTempSetpoint.Name = "nudTempSetpoint";
            this.nudTempSetpoint.Size = new System.Drawing.Size(65, 20);
            this.nudTempSetpoint.TabIndex = 11;
            this.nudTempSetpoint.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // tbMotorSpeed
            // 
            this.tbMotorSpeed.Enabled = false;
            this.tbMotorSpeed.Location = new System.Drawing.Point(48, 248);
            this.tbMotorSpeed.Name = "tbMotorSpeed";
            this.tbMotorSpeed.ReadOnly = true;
            this.tbMotorSpeed.Size = new System.Drawing.Size(65, 20);
            this.tbMotorSpeed.TabIndex = 10;
            // 
            // tbActualTemp
            // 
            this.tbActualTemp.Enabled = false;
            this.tbActualTemp.Location = new System.Drawing.Point(48, 205);
            this.tbActualTemp.Name = "tbActualTemp";
            this.tbActualTemp.ReadOnly = true;
            this.tbActualTemp.Size = new System.Drawing.Size(65, 20);
            this.tbActualTemp.TabIndex = 9;
            // 
            // lbMotorSpeed
            // 
            this.lbMotorSpeed.AutoSize = true;
            this.lbMotorSpeed.Location = new System.Drawing.Point(38, 228);
            this.lbMotorSpeed.Name = "lbMotorSpeed";
            this.lbMotorSpeed.Size = new System.Drawing.Size(85, 13);
            this.lbMotorSpeed.TabIndex = 5;
            this.lbMotorSpeed.Text = "Motor Speed [%]";
            // 
            // lbActualTemp
            // 
            this.lbActualTemp.AutoSize = true;
            this.lbActualTemp.Location = new System.Drawing.Point(39, 185);
            this.lbActualTemp.Name = "lbActualTemp";
            this.lbActualTemp.Size = new System.Drawing.Size(83, 13);
            this.lbActualTemp.TabIndex = 4;
            this.lbActualTemp.Text = "Actual Temp [C]";
            // 
            // lbKi
            // 
            this.lbKi.AutoSize = true;
            this.lbKi.Location = new System.Drawing.Point(26, 123);
            this.lbKi.Name = "lbKi";
            this.lbKi.Size = new System.Drawing.Size(16, 13);
            this.lbKi.TabIndex = 3;
            this.lbKi.Text = "Ki";
            // 
            // lbKp
            // 
            this.lbKp.AutoSize = true;
            this.lbKp.Location = new System.Drawing.Point(26, 97);
            this.lbKp.Name = "lbKp";
            this.lbKp.Size = new System.Drawing.Size(20, 13);
            this.lbKp.TabIndex = 2;
            this.lbKp.Text = "Kp";
            // 
            // lbTuning
            // 
            this.lbTuning.AutoSize = true;
            this.lbTuning.Location = new System.Drawing.Point(54, 75);
            this.lbTuning.Name = "lbTuning";
            this.lbTuning.Size = new System.Drawing.Size(53, 13);
            this.lbTuning.TabIndex = 1;
            this.lbTuning.Text = "PI Tuning";
            // 
            // appTimer
            // 
            this.appTimer.Interval = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 377);
            this.Controls.Add(this.appTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "AUT Application Board Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_FormClosing);
            this.appTabs.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            this.tabDigital.ResumeLayout(false);
            this.tabDigital.PerformLayout();
            this.tabPots.ResumeLayout(false);
            this.tabPots.PerformLayout();
            this.tabLight.ResumeLayout(false);
            this.tabLight.PerformLayout();
            this.tabTempControl.ResumeLayout(false);
            this.tabTempControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempSetpoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl appTabs;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabDigital;
        private System.Windows.Forms.TabPage tabPots;
        private System.Windows.Forms.TabPage tabLight;
        private System.Windows.Forms.TabPage tabTempControl;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label lbBaudRate;
        private System.Windows.Forms.Label lbComPort;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label lbTXStatus;
        private Bulb.LedBulb ledTXStatus;
        private System.Windows.Forms.ComboBox cbCOMPort;
        private System.Windows.Forms.Label lbPA2;
        private System.Windows.Forms.Label lbPA7;
        private System.Windows.Forms.Label lbPA6;
        private System.Windows.Forms.Label lbPA5;
        private System.Windows.Forms.Label lbPA4;
        private System.Windows.Forms.Label lbPA3;
        private System.Windows.Forms.Label lbPA1;
        private System.Windows.Forms.Label lbPA0;
        private System.Windows.Forms.Label lbPINA;
        private Bulb.LedBulb ledPA1;
        private Bulb.LedBulb ledPA2;
        private Bulb.LedBulb ledPA3;
        private Bulb.LedBulb ledPA4;
        private Bulb.LedBulb ledPA5;
        private Bulb.LedBulb ledPA6;
        private Bulb.LedBulb ledPA7;
        private Bulb.LedBulb ledPA0;
        private DmitryBrant.CustomControls.SevenSegment sevenSegLowNibble;
        private DmitryBrant.CustomControls.SevenSegment sevenSegHighNibble;
        private System.Windows.Forms.CheckBox ckPC1;
        private System.Windows.Forms.CheckBox ckPC2;
        private System.Windows.Forms.CheckBox ckPC3;
        private System.Windows.Forms.CheckBox ckPC4;
        private System.Windows.Forms.CheckBox ckPC5;
        private System.Windows.Forms.CheckBox ckPC6;
        private System.Windows.Forms.CheckBox ckPC7;
        private System.Windows.Forms.CheckBox ckPC0;
        private System.Windows.Forms.Label lbPORTC;
        private System.Windows.Forms.Timer appTimer;
        private AquaControls.AquaGauge agPot2;
        private AquaControls.AquaGauge agPot1;
        private System.Windows.Forms.Label lbPot2V;
        private System.Windows.Forms.Label lbPot1V;
        private System.Windows.Forms.Label lbLightBrightness;
        private System.Windows.Forms.VScrollBar vsbLightBrightness;
        private AquaControls.AquaGauge agLightBrightness;
        private System.Windows.Forms.TextBox tbLightBrightness;
        private System.Windows.Forms.TextBox tbMotorSpeed;
        private System.Windows.Forms.TextBox tbActualTemp;
        private System.Windows.Forms.Label lbMotorSpeed;
        private System.Windows.Forms.Label lbActualTemp;
        private System.Windows.Forms.Label lbKi;
        private System.Windows.Forms.Label lbKp;
        private System.Windows.Forms.Label lbTuning;
        private System.Windows.Forms.Label lbTempSetpoint;
        private System.Windows.Forms.NumericUpDown nudKp;
        private System.Windows.Forms.NumericUpDown nudKi;
        private System.Windows.Forms.NumericUpDown nudTempSetpoint;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
    }
}

