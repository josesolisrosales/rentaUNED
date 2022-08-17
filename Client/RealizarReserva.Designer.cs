namespace Client
{
    partial class RealizarReserva
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSucursales = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewVehiculosSucursal = new System.Windows.Forms.DataGridView();
            this.buttonComprobarDisponibilidad = new System.Windows.Forms.Button();
            this.fechaReserva = new System.Windows.Forms.MonthCalendar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBoxSeleccionCobertura = new System.Windows.Forms.GroupBox();
            this.dataGridViewCoberturas = new System.Windows.Forms.DataGridView();
            this.buttonClearCoberturaSelection = new System.Windows.Forms.Button();
            this.textBoxCotizacion = new System.Windows.Forms.TextBox();
            this.buttonCompletarReserva = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSucursales)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehiculosSucursal)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBoxSeleccionCobertura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoberturas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSucursales);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione una Sucursal";
            // 
            // dataGridViewSucursales
            // 
            this.dataGridViewSucursales.AllowUserToAddRows = false;
            this.dataGridViewSucursales.AllowUserToDeleteRows = false;
            this.dataGridViewSucursales.AllowUserToResizeColumns = false;
            this.dataGridViewSucursales.AllowUserToResizeRows = false;
            this.dataGridViewSucursales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSucursales.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSucursales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSucursales.Location = new System.Drawing.Point(6, 23);
            this.dataGridViewSucursales.MultiSelect = false;
            this.dataGridViewSucursales.Name = "dataGridViewSucursales";
            this.dataGridViewSucursales.ReadOnly = true;
            this.dataGridViewSucursales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSucursales.Size = new System.Drawing.Size(296, 381);
            this.dataGridViewSucursales.TabIndex = 0;
            this.dataGridViewSucursales.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSucursales_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewVehiculosSucursal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(326, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 410);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vehiculos disponibles en esta sucursal";
            // 
            // dataGridViewVehiculosSucursal
            // 
            this.dataGridViewVehiculosSucursal.AllowUserToAddRows = false;
            this.dataGridViewVehiculosSucursal.AllowUserToDeleteRows = false;
            this.dataGridViewVehiculosSucursal.AllowUserToResizeColumns = false;
            this.dataGridViewVehiculosSucursal.AllowUserToResizeRows = false;
            this.dataGridViewVehiculosSucursal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewVehiculosSucursal.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewVehiculosSucursal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewVehiculosSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVehiculosSucursal.Location = new System.Drawing.Point(12, 23);
            this.dataGridViewVehiculosSucursal.MultiSelect = false;
            this.dataGridViewVehiculosSucursal.Name = "dataGridViewVehiculosSucursal";
            this.dataGridViewVehiculosSucursal.ReadOnly = true;
            this.dataGridViewVehiculosSucursal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVehiculosSucursal.Size = new System.Drawing.Size(837, 381);
            this.dataGridViewVehiculosSucursal.TabIndex = 0;
            // 
            // buttonComprobarDisponibilidad
            // 
            this.buttonComprobarDisponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComprobarDisponibilidad.Location = new System.Drawing.Point(442, 428);
            this.buttonComprobarDisponibilidad.Name = "buttonComprobarDisponibilidad";
            this.buttonComprobarDisponibilidad.Size = new System.Drawing.Size(342, 53);
            this.buttonComprobarDisponibilidad.TabIndex = 2;
            this.buttonComprobarDisponibilidad.Text = "Comprobar Disponibilidad";
            this.buttonComprobarDisponibilidad.UseVisualStyleBackColor = true;
            this.buttonComprobarDisponibilidad.Click += new System.EventHandler(this.buttonComprobarDisponibilidad_Click);
            // 
            // fechaReserva
            // 
            this.fechaReserva.Location = new System.Drawing.Point(12, 30);
            this.fechaReserva.MaxSelectionCount = 14;
            this.fechaReserva.MinDate = new System.DateTime(2022, 8, 16, 0, 0, 0, 0);
            this.fechaReserva.Name = "fechaReserva";
            this.fechaReserva.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fechaReserva);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 428);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 204);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccione una rango de fechas para su reservacion";
            // 
            // groupBoxSeleccionCobertura
            // 
            this.groupBoxSeleccionCobertura.Controls.Add(this.buttonClearCoberturaSelection);
            this.groupBoxSeleccionCobertura.Controls.Add(this.dataGridViewCoberturas);
            this.groupBoxSeleccionCobertura.Enabled = false;
            this.groupBoxSeleccionCobertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSeleccionCobertura.Location = new System.Drawing.Point(18, 638);
            this.groupBoxSeleccionCobertura.Name = "groupBoxSeleccionCobertura";
            this.groupBoxSeleccionCobertura.Size = new System.Drawing.Size(521, 280);
            this.groupBoxSeleccionCobertura.TabIndex = 3;
            this.groupBoxSeleccionCobertura.TabStop = false;
            this.groupBoxSeleccionCobertura.Text = "Seleccione una Cobertura";
            this.groupBoxSeleccionCobertura.Visible = false;
            // 
            // dataGridViewCoberturas
            // 
            this.dataGridViewCoberturas.AllowUserToAddRows = false;
            this.dataGridViewCoberturas.AllowUserToDeleteRows = false;
            this.dataGridViewCoberturas.AllowUserToResizeColumns = false;
            this.dataGridViewCoberturas.AllowUserToResizeRows = false;
            this.dataGridViewCoberturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCoberturas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewCoberturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCoberturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoberturas.Enabled = false;
            this.dataGridViewCoberturas.Location = new System.Drawing.Point(6, 23);
            this.dataGridViewCoberturas.Name = "dataGridViewCoberturas";
            this.dataGridViewCoberturas.ReadOnly = true;
            this.dataGridViewCoberturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCoberturas.Size = new System.Drawing.Size(509, 187);
            this.dataGridViewCoberturas.TabIndex = 0;
            this.dataGridViewCoberturas.Visible = false;
            this.dataGridViewCoberturas.SelectionChanged += new System.EventHandler(this.dataGridViewCoberturas_SelectionChanged);
            // 
            // buttonClearCoberturaSelection
            // 
            this.buttonClearCoberturaSelection.Enabled = false;
            this.buttonClearCoberturaSelection.Location = new System.Drawing.Point(6, 216);
            this.buttonClearCoberturaSelection.Name = "buttonClearCoberturaSelection";
            this.buttonClearCoberturaSelection.Size = new System.Drawing.Size(156, 58);
            this.buttonClearCoberturaSelection.TabIndex = 1;
            this.buttonClearCoberturaSelection.Text = "NINGUNA";
            this.buttonClearCoberturaSelection.UseVisualStyleBackColor = true;
            this.buttonClearCoberturaSelection.Visible = false;
            this.buttonClearCoberturaSelection.Click += new System.EventHandler(this.buttonClearCoberturaSelection_Click);
            // 
            // textBoxCotizacion
            // 
            this.textBoxCotizacion.Enabled = false;
            this.textBoxCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxCotizacion.Location = new System.Drawing.Point(545, 487);
            this.textBoxCotizacion.Multiline = true;
            this.textBoxCotizacion.Name = "textBoxCotizacion";
            this.textBoxCotizacion.ReadOnly = true;
            this.textBoxCotizacion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCotizacion.Size = new System.Drawing.Size(639, 353);
            this.textBoxCotizacion.TabIndex = 4;
            this.textBoxCotizacion.Visible = false;
            // 
            // buttonCompletarReserva
            // 
            this.buttonCompletarReserva.Enabled = false;
            this.buttonCompletarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.buttonCompletarReserva.Location = new System.Drawing.Point(545, 846);
            this.buttonCompletarReserva.Name = "buttonCompletarReserva";
            this.buttonCompletarReserva.Size = new System.Drawing.Size(239, 66);
            this.buttonCompletarReserva.TabIndex = 2;
            this.buttonCompletarReserva.Text = "COMPLETAR RESERVA";
            this.buttonCompletarReserva.UseVisualStyleBackColor = true;
            this.buttonCompletarReserva.Visible = false;
            this.buttonCompletarReserva.Click += new System.EventHandler(this.buttonCompletarReserva_Click);
            // 
            // RealizarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 963);
            this.Controls.Add(this.buttonCompletarReserva);
            this.Controls.Add(this.textBoxCotizacion);
            this.Controls.Add(this.groupBoxSeleccionCobertura);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonComprobarDisponibilidad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RealizarReserva";
            this.Text = "RealizarReserva";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSucursales)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehiculosSucursal)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBoxSeleccionCobertura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoberturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewSucursales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewVehiculosSucursal;
        private System.Windows.Forms.Button buttonComprobarDisponibilidad;
        private System.Windows.Forms.MonthCalendar fechaReserva;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBoxSeleccionCobertura;
        private System.Windows.Forms.DataGridView dataGridViewCoberturas;
        private System.Windows.Forms.Button buttonClearCoberturaSelection;
        private System.Windows.Forms.TextBox textBoxCotizacion;
        private System.Windows.Forms.Button buttonCompletarReserva;
    }
}