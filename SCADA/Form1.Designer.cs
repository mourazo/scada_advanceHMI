namespace SCADA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.basicLabel2 = new AdvancedHMIControls.BasicLabel();
            this.gauge1 = new AdvancedHMIControls.Gauge();
            this.modbusTCPCom1 = new AdvancedHMIDrivers.ModbusTCPCom(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.modbusTCPCom1)).BeginInit();
            this.SuspendLayout();
            // 
            // basicLabel2
            // 
            this.basicLabel2.AutoSize = true;
            this.basicLabel2.BackColor = System.Drawing.Color.Black;
            this.basicLabel2.BooleanDisplay = AdvancedHMIControls.BasicLabel.BooleanDisplayOption.TrueFalse;
            this.basicLabel2.ComComponent = this.modbusTCPCom1;
            this.basicLabel2.DisplayAsTime = false;
            this.basicLabel2.ForeColor = System.Drawing.Color.White;
            this.basicLabel2.Highlight = false;
            this.basicLabel2.HighlightColor = System.Drawing.Color.Red;
            this.basicLabel2.HighlightForeColor = System.Drawing.Color.White;
            this.basicLabel2.HighlightKeyCharacter = "!";
            this.basicLabel2.InterpretValueAsBCD = false;
            this.basicLabel2.KeypadAlphaNumeric = false;
            this.basicLabel2.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.basicLabel2.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.basicLabel2.KeypadMaxValue = 0D;
            this.basicLabel2.KeypadMinValue = 0D;
            this.basicLabel2.KeypadScaleFactor = 1D;
            this.basicLabel2.KeypadShowCurrentValue = false;
            this.basicLabel2.KeypadText = null;
            this.basicLabel2.KeypadWidth = 300;
            this.basicLabel2.Location = new System.Drawing.Point(84, 201);
            this.basicLabel2.Name = "basicLabel2";
            this.basicLabel2.NumericFormat = null;
            this.basicLabel2.PLCAddressKeypad = "";
            this.basicLabel2.PLCAddressValue = "40001";
            this.basicLabel2.PollRate = 0;
            this.basicLabel2.Size = new System.Drawing.Size(77, 17);
            this.basicLabel2.TabIndex = 1;
            this.basicLabel2.Text = "BasicLabel";
            this.basicLabel2.Value = "BasicLabel";
            this.basicLabel2.ValueLeftPadCharacter = ' ';
            this.basicLabel2.ValueLeftPadLength = 0;
            this.basicLabel2.ValuePrefix = null;
            this.basicLabel2.ValueScaleFactor = 1D;
            this.basicLabel2.ValueSuffix = null;
            this.basicLabel2.ValueToSubtractFrom = 0F;
            // 
            // gauge1
            // 
            this.gauge1.AllowDragging = false;
            this.gauge1.BackColor = System.Drawing.Color.Transparent;
            this.gauge1.ComComponent = this.modbusTCPCom1;
            this.gauge1.HighlightColor = System.Drawing.Color.Red;
            this.gauge1.Location = new System.Drawing.Point(397, 76);
            this.gauge1.Maximum = 100;
            this.gauge1.Minimum = 0;
            this.gauge1.Name = "gauge1";
            this.gauge1.NumericFormat = null;
            this.gauge1.PLCAddressText = "";
            this.gauge1.PLCAddressValue = "40002";
            this.gauge1.PLCAddressVisible = "";
            this.gauge1.Size = new System.Drawing.Size(278, 278);
            this.gauge1.TabIndex = 3;
            this.gauge1.Text = "gauge1";
            this.gauge1.Value = 0D;
            this.gauge1.ValueScaleFactor = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // modbusTCPCom1
            // 
            this.modbusTCPCom1.DisableSubscriptions = false;
            this.modbusTCPCom1.IniFileName = "";
            this.modbusTCPCom1.IniFileSection = null;
            this.modbusTCPCom1.IPAddress = "192.168.1.49";
            this.modbusTCPCom1.MaxReadGroupSize = 20;
            this.modbusTCPCom1.PollRateOverride = 500;
            this.modbusTCPCom1.SwapBytes = true;
            this.modbusTCPCom1.SwapWords = false;
            this.modbusTCPCom1.TcpipPort = ((ushort)(502));
            this.modbusTCPCom1.TimeOut = 3000;
            this.modbusTCPCom1.UnitId = ((byte)(1));
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timerTick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 477);
            this.Controls.Add(this.gauge1);
            this.Controls.Add(this.basicLabel2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.modbusTCPCom1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdvancedHMIControls.BasicLabel basicLabel2;
        private AdvancedHMIControls.Gauge gauge1;
        private AdvancedHMIDrivers.ModbusTCPCom modbusTCPCom1;
        private System.Windows.Forms.Timer timer1;
    }
}

