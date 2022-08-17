using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace Client
{
    public partial class ConsultarReservas : Form
    {
        private string _clientId;
        public ConsultarReservas(string pClientId)
        {
            InitializeComponent();
            _clientId = pClientId;
            populateClientInfo(_clientId);
            populateConsultaReservas();
        }
        private void populateClientInfo(string clientId)
        {
            Cliente client = ClientTCP.ObtenerCliente(clientId);

            label1.Text = $"Bienvenido {client.Nombre} {client.PrimerApellido} {client.SegundoApellido}!";

        }

        private void populateConsultaReservas(int reservaId)
        {
            try
            {
                dataGridViewReservas.DataSource = ClientTCP.ConsultarReservasPorCliente(_clientId).Where(x => x != null && x.Id == reservaId).Select((x) =>
                    new
                    {
                        ID = x.Id,
                        VEHICULO = x.IdVehiculo,
                        FECHA_RESERVA = x.FechaReserva,
                        FECHA_INICIO = x.FechaInicio,
                        FECHA_FIN = x.FechaFin,
                        MONTO = x.Monto
                    }).ToList();

                labelInfo.Text = "";
            }
            catch (Exception ex)
            {
                labelInfo.Text = "Reserva con el ID {reservaId} no encontrada";
            }
        }
        private void populateConsultaReservas()
        {
            try
            {
                dataGridViewReservas.DataSource = ClientTCP.ConsultarReservasPorCliente(_clientId).Where(x => x != null).Select((x) =>
                    new
                    {
                        ID = x.Id,
                        VEHICULO = x.IdVehiculo,
                        FECHA_RESERVA = x.FechaReserva,
                        FECHA_INICIO = x.FechaInicio,
                        FECHA_FIN = x.FechaFin,
                        MONTO = x.Monto
                    }).ToList();
                labelInfo.Text = "";
            }
            catch (Exception ex)
            {
                labelInfo.Text = "Usted no posee reservas";
            }

        }

        private void buttonFiltrarResultados_Click(object sender, EventArgs e)
        {
            try
            {
                int reservaId = Int32.Parse(textBoxReservaId.Text);
                populateConsultaReservas(reservaId);

            } catch (Exception ex)
            {
                labelInfo.Text = "El ID de la reserva debe ser un numero valido";
                populateConsultaReservas();
            }
        }
    }
}
