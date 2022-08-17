namespace Client
{
    partial class UIClient
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
            this.buttonServerConnect = new System.Windows.Forms.Button();
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonServerDisconnect = new System.Windows.Forms.Button();
            this.labelClientStatus = new System.Windows.Forms.Label();
            this.labelClientInfo = new System.Windows.Forms.Label();
            this.buttonReservar = new System.Windows.Forms.Button();
            this.buttonConsultarReservas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonServerConnect
            // 
            this.buttonServerConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServerConnect.Location = new System.Drawing.Point(12, 155);
            this.buttonServerConnect.Name = "buttonServerConnect";
            this.buttonServerConnect.Size = new System.Drawing.Size(120, 50);
            this.buttonServerConnect.TabIndex = 0;
            this.buttonServerConnect.Text = "Conectar";
            this.buttonServerConnect.UseVisualStyleBackColor = true;
            this.buttonServerConnect.Click += new System.EventHandler(this.buttonServerConnect_Click);
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientId.Location = new System.Drawing.Point(12, 64);
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(165, 26);
            this.textBoxClientId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID de cliente";
            // 
            // buttonServerDisconnect
            // 
            this.buttonServerDisconnect.Enabled = false;
            this.buttonServerDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServerDisconnect.Location = new System.Drawing.Point(138, 155);
            this.buttonServerDisconnect.Name = "buttonServerDisconnect";
            this.buttonServerDisconnect.Size = new System.Drawing.Size(160, 50);
            this.buttonServerDisconnect.TabIndex = 3;
            this.buttonServerDisconnect.Text = "Desconectar";
            this.buttonServerDisconnect.UseVisualStyleBackColor = true;
            this.buttonServerDisconnect.Click += new System.EventHandler(this.buttonServerDisconnect_Click);
            // 
            // labelClientStatus
            // 
            this.labelClientStatus.AutoSize = true;
            this.labelClientStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientStatus.ForeColor = System.Drawing.Color.Red;
            this.labelClientStatus.Location = new System.Drawing.Point(12, 208);
            this.labelClientStatus.Name = "labelClientStatus";
            this.labelClientStatus.Size = new System.Drawing.Size(150, 25);
            this.labelClientStatus.TabIndex = 4;
            this.labelClientStatus.Text = "Desconectado";
            // 
            // labelClientInfo
            // 
            this.labelClientInfo.AutoSize = true;
            this.labelClientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientInfo.Location = new System.Drawing.Point(12, 25);
            this.labelClientInfo.Name = "labelClientInfo";
            this.labelClientInfo.Size = new System.Drawing.Size(331, 25);
            this.labelClientInfo.TabIndex = 5;
            this.labelClientInfo.Text = "Introduzca un ID para conectarse";
            // 
            // buttonReservar
            // 
            this.buttonReservar.Enabled = false;
            this.buttonReservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReservar.Location = new System.Drawing.Point(12, 262);
            this.buttonReservar.Name = "buttonReservar";
            this.buttonReservar.Size = new System.Drawing.Size(145, 78);
            this.buttonReservar.TabIndex = 6;
            this.buttonReservar.Text = "Reservar Vehiculo";
            this.buttonReservar.UseVisualStyleBackColor = true;
            this.buttonReservar.Visible = false;
            this.buttonReservar.Click += new System.EventHandler(this.buttonReservar_Click);
            // 
            // buttonConsultarReservas
            // 
            this.buttonConsultarReservas.Enabled = false;
            this.buttonConsultarReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConsultarReservas.Location = new System.Drawing.Point(163, 262);
            this.buttonConsultarReservas.Name = "buttonConsultarReservas";
            this.buttonConsultarReservas.Size = new System.Drawing.Size(145, 78);
            this.buttonConsultarReservas.TabIndex = 7;
            this.buttonConsultarReservas.Text = "Consultar Reservas";
            this.buttonConsultarReservas.UseVisualStyleBackColor = true;
            this.buttonConsultarReservas.Visible = false;
            this.buttonConsultarReservas.Click += new System.EventHandler(this.buttonConsultarReservas_Click);
            // 
            // UIClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 373);
            this.Controls.Add(this.buttonConsultarReservas);
            this.Controls.Add(this.buttonReservar);
            this.Controls.Add(this.labelClientInfo);
            this.Controls.Add(this.labelClientStatus);
            this.Controls.Add(this.buttonServerDisconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxClientId);
            this.Controls.Add(this.buttonServerConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UIClient";
            this.Text = "Renta UNED Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonServerConnect;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonServerDisconnect;
        private System.Windows.Forms.Label labelClientStatus;
        private System.Windows.Forms.Label labelClientInfo;
        private System.Windows.Forms.Button buttonReservar;
        private System.Windows.Forms.Button buttonConsultarReservas;
    }
}

