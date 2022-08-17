using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace Client
{
    public partial class UIClient : Form
    {
        public UIClient()
        {
            InitializeComponent();
        }

        private void buttonServerConnect_Click(object sender, EventArgs e)
        {
            if (!(textBoxClientId.Text.Equals(string.Empty)))
            {

                int connectionResult = ClientTCP.Connect(textBoxClientId.Text);
                if (connectionResult == 0)
                {
                    MessageBox.Show("Introduzca un ID valido para conectarse al servidor", "ID INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   
                }
                else if (connectionResult == -1)
                {
                    MessageBox.Show($"Ya existe un cliente con el ID {textBoxClientId.Text} conectado", "ID YA CONECTADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (connectionResult == 1)
                {
                    labelClientStatus.Text = "Conectado al servidor 127.0.0.1 puerto 14100";
                    labelClientStatus.ForeColor = Color.Green;
                    buttonServerConnect.Enabled = false;
                    buttonServerDisconnect.Enabled = true;
                    textBoxClientId.ReadOnly = true;
                    buttonReservar.Enabled = true;
                    buttonReservar.Visible = true;
                    buttonConsultarReservas.Enabled = true;
                    buttonConsultarReservas.Visible = true;
                    populateClientInfo(textBoxClientId.Text);

                } 
                else
                {
                    MessageBox.Show("Verifique que el servidor esté activo", "ERROR DE CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un id de cliente para intentar la conexion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonServerDisconnect_Click(object sender, EventArgs e)
        {
            ClientTCP.Disconnect(textBoxClientId.Text);

            labelClientStatus.Text = "Desconectado";
            labelClientStatus.ForeColor = Color.Red;
            buttonServerDisconnect.Enabled = false;
            buttonServerConnect.Enabled = true;

            buttonConsultarReservas.Enabled = false;
            buttonReservar.Enabled = false;
            buttonConsultarReservas.Visible = false;
            buttonReservar.Visible = false;

            textBoxClientId.ReadOnly = false;

        }

        private void populateClientInfo(string clientId)
        {
            labelClientInfo.Text = $"Bienvenido!";
            Cliente client = ClientTCP.ObtenerCliente(clientId);

            labelClientInfo.Text = $"Bienvenido {client.Nombre} {client.PrimerApellido} {client.SegundoApellido}!";

        }

        private void buttonReservar_Click(object sender, EventArgs e)
        {
            RealizarReserva realizarReservaForm = new RealizarReserva(textBoxClientId.Text);
            realizarReservaForm.StartPosition = FormStartPosition.CenterScreen;
            realizarReservaForm.ShowDialog();
            ClientTCP.UnlockDb(textBoxClientId.Text);
        }

        private void buttonConsultarReservas_Click(object sender, EventArgs e)
        {
            ConsultarReservas consultarReservasForm = new ConsultarReservas(textBoxClientId.Text);
            consultarReservasForm.StartPosition = FormStartPosition.CenterScreen;
            consultarReservasForm.ShowDialog();
        }
    }
}
