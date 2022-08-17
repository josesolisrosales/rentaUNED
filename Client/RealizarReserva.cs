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
    public partial class RealizarReserva : Form
    {
        List<Sucursal> sucursales = new List<Sucursal>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        private int _total = 0;
        private string _clientId;

        private void CargarSucursales()
        {
            List<Sucursal> sucursales = ClientTCP.ObtenerSucursalesActivas();
            dataGridViewSucursales.DataSource = sucursales.Where(x => x != null).Select((x) =>
                new
                {
                    Nombre = x.Nombre
                }).ToList();
        }

        private void CargarVehiculosSucursal()
        {
            string sucursalNombre = dataGridViewSucursales.SelectedRows[0].Cells[0].Value.ToString();
            List<Vehiculo> vehiculos = ClientTCP.ObtenerVehiculosPorSucursal(sucursalNombre);

            dataGridViewVehiculosSucursal.DataSource = vehiculos.Where(x => x != null).Select((x) =>
                new
                {
                    Id = x.Id,
                    Marca = x.Marca,
                    Modelo = x.Modelo,
                    Tipo = x.Tipo.Descripcion,
                    Alqulier_Diario = x.AlquilerDiario,
                    Kilometraje = x.Km
                }).ToList();
        }

        public RealizarReserva(string pClientId)
        {
            InitializeComponent();
            _clientId = pClientId;
            fechaReserva.MinDate = DateTime.Today;
            CargarSucursales();
            
        }

        private void dataGridViewSucursales_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CargarVehiculosSucursal();
        }

        private void buttonComprobarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (!ClientTCP.checkDbLock(_clientId))
            {
                string idVehiculo = dataGridViewVehiculosSucursal.SelectedRows[0].Cells[0].Value.ToString();
                DateTime fechaInicio = fechaReserva.SelectionStart;
                DateTime fechaFin = fechaReserva.SelectionEnd;

                bool disponibilidad = ClientTCP.checkDisponibilidadVehiculo(idVehiculo, fechaInicio, fechaFin);

                if (disponibilidad)
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show($"Reserva disponible, vehiculo: {idVehiculo}, fecha de inicio: {fechaInicio.Date.ToShortDateString()}, fecha de fin {fechaFin.Date.ToShortDateString()}. Desea continuar con la reserva?", 
                        "RESERVA DISPONIBLE",
                        MessageBoxButtons.OKCancel);

                    if (opcion.Equals(DialogResult.OK))
                    {
                        ClientTCP.LockDb(_clientId);
                        dataGridViewSucursales.Enabled = false;
                        dataGridViewVehiculosSucursal.Enabled = false;
                        fechaReserva.Enabled = false;
                        buttonComprobarDisponibilidad.Enabled = false;
                        buttonComprobarDisponibilidad.Visible = false;

                        Vehiculo vehiculoSeleccionado = ClientTCP.ObtenerVehiculoPorId(idVehiculo);

                        List<Cobertura> coberturas = ClientTCP.ObtenerCoberturasPorTipoVehiculo(vehiculoSeleccionado.Tipo.Id);

                        if (coberturas.Count > 0)
                        {
                            groupBoxSeleccionCobertura.Enabled = true;
                            groupBoxSeleccionCobertura.Visible = true;
                            dataGridViewCoberturas.Enabled = true;
                            dataGridViewCoberturas.Visible = true;
                            buttonClearCoberturaSelection.Enabled = true;
                            buttonClearCoberturaSelection.Visible = true;
                            buttonCompletarReserva.Enabled = true;
                            buttonCompletarReserva.Visible = true;
                            textBoxCotizacion.Visible = true;
                            textBoxCotizacion.Enabled = true;
                            cargarCoberturasDisponibles(coberturas);
                            
                        }
                        else
                        {
                            buttonCompletarReserva.Enabled = true;
                            buttonCompletarReserva.Visible = true;
                            textBoxCotizacion.Visible = true;
                            textBoxCotizacion.Enabled = true;
                            calcularReservaFinal(vehiculoSeleccionado, fechaInicio, fechaFin);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Reserva no disponible, seleccione un rango de fechas o un vehiculo diferente");
                }
            } 
            else
            {
                MessageBox.Show("La base da datos esta siendo usada por otro cliente, por favor intentelo mas tarde", "ADVERTENCIA");
            }
        }

        private void cargarCoberturasDisponibles(List<Cobertura> coberturas)
        {
            dataGridViewCoberturas.DataSource = coberturas.Where(x => x != null && x.Estado).Select((x) =>
            new
            {
                NOMBRE = x.Descripcion,
                COSTO_DIARIO = x.Monto
            }).ToList();

            dataGridViewCoberturas.ClearSelection();
        }

        private void buttonClearCoberturaSelection_Click(object sender, EventArgs e)
        {
            dataGridViewCoberturas.ClearSelection();
        }

        private void displayReservaFinal(List<string> lines) 
        {
            textBoxCotizacion.Lines = lines.ToArray();
        }
        private void calcularReservaFinal(Vehiculo vehiculo, DateTime fechaInicio, DateTime fechaFin )
        {
            Vehiculo vehiculoSeleccionado = vehiculo;
            int total = 0;
            List<string> lines = new List<string>();

            int diasReserva = (fechaFin.Date - fechaInicio.Date).Days;

            lines.Add($"Vehiculo seleccionado:");
            lines.Add($"\tID: {vehiculoSeleccionado.Id}");
            lines.Add($"\tMarca: {vehiculoSeleccionado.Marca}");
            lines.Add($"\tModelo: {vehiculoSeleccionado.Modelo}");
            lines.Add($"\tTipo: {vehiculoSeleccionado.Tipo.Descripcion}");
            lines.Add($"\tKilometraje: {vehiculoSeleccionado.Km}");
            lines.Add($"\tCOSTO POR DIA: {vehiculoSeleccionado.AlquilerDiario}");

            lines.Add(Environment.NewLine);

            lines.Add($"TOTAL VEHICULO POR DIA: {vehiculoSeleccionado.AlquilerDiario}");
            total = total + (vehiculoSeleccionado.AlquilerDiario * diasReserva);
            lines.Add(Environment.NewLine);
            lines.Add($"TOTAL (FINAL): {total}");

            _total = total;

            displayReservaFinal(lines);
        }
        private void buttonCompletarReserva_Click(object sender, EventArgs e)
        {
            string idVehiculo = dataGridViewVehiculosSucursal.SelectedRows[0].Cells[0].Value.ToString();
            DateTime fechaInicio = fechaReserva.SelectionStart;
            DateTime fechaFin = fechaReserva.SelectionEnd;

            Reserva reserva = new Reserva(
                id: 0,
                idCliente: _clientId,
                idVehiculo: idVehiculo,
                fechaReserva: DateTime.Today,
                fechaInicio: fechaInicio,
                fechaFin: fechaFin,
                monto:_total);

            ClientTCP.RegistrarReserva(reserva);

            MessageBox.Show("Reserva registrada con exito", "EXITO");

            this.Close();

        }

        private void dataGridViewCoberturas_SelectionChanged(object sender, EventArgs e)
        {
            string idVehiculo = dataGridViewVehiculosSucursal.SelectedRows[0].Cells[0].Value.ToString();
            Vehiculo vehiculoSeleccionado = ClientTCP.ObtenerVehiculoPorId(idVehiculo);
            DateTime fechaInicio = fechaReserva.SelectionStart;
            DateTime fechaFin = fechaReserva.SelectionEnd;
            int total = 0;
            int totalCoberturasPorDia = 0;
            int totalCoberturasPorReserva = 0;
            List<string> lines = new List<string>();

            int diasReserva = (fechaFin.Date - fechaInicio.Date).Days;

            lines.Add($"Dias de la reserva: {diasReserva}");
            lines.Add($"Vehiculo seleccionado:");
            lines.Add($"\tID: {vehiculoSeleccionado.Id}");
            lines.Add($"\tMarca: {vehiculoSeleccionado.Marca}");
            lines.Add($"\tModelo: {vehiculoSeleccionado.Modelo}");
            lines.Add($"\tTipo: {vehiculoSeleccionado.Tipo.Descripcion}");
            lines.Add($"\tKilometraje: {vehiculoSeleccionado.Km}");
            lines.Add($"\tCOSTO POR DIA: {vehiculoSeleccionado.AlquilerDiario}");

            lines.Add(Environment.NewLine);

            lines.Add($"TOTAL VEHICULO POR DIA (SIN COBERTURAS): {vehiculoSeleccionado.AlquilerDiario}");
            lines.Add($"TOTAL VEHICULO POR RESERVA (SIN COBERTURAS): {vehiculoSeleccionado.AlquilerDiario * diasReserva}");

            total = total + (vehiculoSeleccionado.AlquilerDiario * diasReserva);

            lines.Add(Environment.NewLine);

            foreach (DataGridViewRow row in dataGridViewCoberturas.SelectedRows)
            {
                int coberturaMonto = Int32.Parse(row.Cells[1].Value.ToString());
                lines.Add($"Cobertura: {row.Cells[0].Value} cuesta {coberturaMonto} colones por dia");
                totalCoberturasPorDia = totalCoberturasPorDia + coberturaMonto;
            }
            lines.Add(Environment.NewLine);

            lines.Add($"TOTAL COBERTURAS POR DIA: {totalCoberturasPorDia}");
            totalCoberturasPorReserva = totalCoberturasPorDia * diasReserva;
            lines.Add($"TOTAL COBERTURAS: {totalCoberturasPorReserva} ");
            lines.Add($"TOTAL VEHICULO POR DIA (CON COBERTURAS): {vehiculoSeleccionado.AlquilerDiario + totalCoberturasPorDia}");

            total = total + totalCoberturasPorReserva;

            lines.Add(Environment.NewLine);

            lines.Add($"TOTAL (FINAL): {total}");

            _total = total;

            displayReservaFinal(lines);
        }
    }
}
