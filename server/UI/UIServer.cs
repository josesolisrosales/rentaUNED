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
using Utils;
using DataAccess;


namespace server
{
    public partial class UIServer : Form
    {
        DBOps accesoDatos = new DBOps();
        public UIServer()
        {
            InitializeComponent();
            actualizarConsultas();
        }

        // Logica registrar y validar sucursal
        private void registrarSucursal()
        {
            Int32.TryParse(textBoxSucursalID.Text, out int id);
            string nombre = textBoxSucursalNombre.Text;
            string telefono = textBoxSucursalTelefono.Text;
            string direccion = textBoxSucursalDireccion.Text;
            bool estado = Helpers.stringToBool(comboBoxSucursalEstado.Text);

            foreach (Sucursal sucursal in accesoDatos.ObtenerSucursales())
            {
                if (sucursal.Id == id)
                {
                    MessageBox.Show($"Ya existe una sucursal con el ID {id}", "ERROR");
                    return;
                }
            }
            Sucursal nuevaSucursal = new Sucursal(
                id: id,
                nombre: nombre,
                direccion: direccion,
                estado: estado,
                telefono: telefono
                );

            if (accesoDatos.Registrar(nuevaSucursal))
            {
                MessageBox.Show($"Sucursal con el ID {id} registrada en la base de datos", "Sucursal Registrada");
                actualizarConsultaSucursal();
            }
            else
            {
                MessageBox.Show($"Hubo un error al registrar la sucursal con el id {id}, revise la consola para encontrar el error completo", "ERROR");
            }
         
            textBoxSucursalID.Clear();
            textBoxSucursalNombre.Clear();
            textBoxSucursalTelefono.Clear();
            textBoxSucursalDireccion.Clear();
            comboBoxSucursalEstado.ResetText(); ;
        }
        private void actualizarConsultaSucursal()
        {
            comboBoxSucursalesDisponibles.Items.Clear();
            List<Sucursal> listaSucursales = accesoDatos.ObtenerSucursales();
            dataGridViewConsultaSucursal.DataSource = listaSucursales.Where(x => x != null).Select((x, index) =>
                new
                {
                    ID = x.Id,
                    NOMBRE = x.Nombre,
                    DIRECCION = x.Direccion,
                    TELEFONO = x.Telefono,
                    ESTADO = Helpers.boolToString(x.Estado)
                }).ToList();
            foreach (Sucursal sucursal in listaSucursales)
            {
                if (sucursal.Estado)
                {
                    SucursalComboBoxItem item = new SucursalComboBoxItem();
                    item.Text = $"ID:{sucursal.Id}, Nombre:{sucursal.Nombre}, Direccion:{sucursal.Direccion}";
                    item.Value = sucursal;

                    comboBoxSucursalesDisponibles.Items.Add(item);
                }
            }
        }
        private void buttonRegistrarSucursal_Click(object sender, EventArgs e)
        {
            string idString = textBoxSucursalID.Text;
            string nombre = textBoxSucursalNombre.Text;
            string telefono = textBoxSucursalTelefono.Text;
            string direccion = textBoxSucursalDireccion.Text;
            bool validacionId = false;
            bool validacionNombre = false;
            bool validacionTelefono = false;
            bool validacionDireccion = false;

            // Validar ID
            if (!string.IsNullOrEmpty(idString))
            {
                try
                {
                    int id = Int32.Parse(idString);
                    errorProviderSucursal.SetError(textBoxSucursalID, "");
                    validacionId = true;
                }
                catch (FormatException)
                {
                    errorProviderSucursal.SetError(textBoxSucursalID, "Lo introducido debe ser un numero valido");
                }
            }
            else
            {
                errorProviderSucursal.SetError(textBoxSucursalID, "No puede estar vacio");
            }

            // Validar nombre
            if (!string.IsNullOrEmpty(nombre))
            {
                errorProviderSucursal.SetError(textBoxSucursalNombre, "");
                validacionNombre = true;
            }
            else
            {
                errorProviderSucursal.SetError(textBoxSucursalNombre, "No puede estar vacio");
            }

            // Validar telefono
            if (!string.IsNullOrEmpty(telefono))
            {
                errorProviderSucursal.SetError(textBoxSucursalTelefono, "");
                validacionTelefono = true;
            }
            else
            {
                errorProviderSucursal.SetError(textBoxSucursalTelefono, "No puede estar vacio");
            }

            // Validar direccion
            if (!string.IsNullOrEmpty(direccion))
            {
                errorProviderSucursal.SetError(textBoxSucursalDireccion, "");
                validacionDireccion = true;
            }
            else
            {
                errorProviderSucursal.SetError(textBoxSucursalDireccion, "No puede estar vacio");
            }

            if (validacionId && validacionNombre && validacionDireccion && validacionTelefono)
            {
                registrarSucursal();
            }
        }

        // Logica registrar y validar cliente
        private void registrarCliente()
        {
            string id = textBoxClienteID.Text;
            string nombre = textBoxClienteNombre.Text;
            string primerApellido = textBoxClientePrimerAp.Text;
            string segundoApellido = textBoxClienteSegundoAp.Text;
            DateTime fechaNacimiento = dateTimeClienteDOB.Value.Date;
            char genero = 'm';

            try
            {
                genero = Helpers.convertirGenero(comboBoxClienteGenero.SelectedItem.ToString());
            }
            catch (System.NullReferenceException)
            {
                genero = 'm';
            }

            foreach (Cliente cliente in accesoDatos.ObtenerClientes())
            {
                if (cliente.Id == id)
                {
                    MessageBox.Show($"Ya existe un cliente con el ID {id}", "ERROR");
                    return;
                }
            }

            Cliente nuevoCliente = new Cliente(
                id: id,
                nombre: nombre,
                primerApellido: primerApellido,
                segundoApellido: segundoApellido,
                fechaNacimiento: fechaNacimiento,
                genero: genero
                );

            if (accesoDatos.Registrar(nuevoCliente))
            {
                MessageBox.Show($"Cliente con el ID {id} registrado en la base de datos", "Cliente Registrado");

                actualizarConsultaCliente();
            }
            else
            {
                MessageBox.Show($"Hubo un error al registrar el cliente con el id {id}, revise la consola para encontrar el error completo", "ERROR");
            }

            textBoxClienteID.Clear();
            textBoxClienteNombre.Clear();
            textBoxClientePrimerAp.Clear();
            textBoxClienteSegundoAp.Clear();
            comboBoxClienteGenero.ResetText();
            dateTimeClienteDOB.Text = "12/12/2000";
        }
        private void actualizarConsultaCliente()
        {
            dataGridViewConsultaCliente.DataSource = accesoDatos.ObtenerClientes().Where(x => x != null).Select((x, index) =>
                new
                {
                    ID = x.Id,
                    NOMBRE = x.Nombre,
                    PRIMER_APELLIDO = x.PrimerApellido,
                    SEGUNDO_APELLIDO = x.SegundoApellido,
                    FECHA_NACIMIENTO = x.FechaNacimiento,
                    GENERO = Helpers.convertirGenero(x.Genero)
                }).ToList();
        }
        private void buttonRegistrarCliente_Click(object sender, EventArgs e)
        {
            string id = textBoxClienteID.Text;
            string nombre = textBoxClienteNombre.Text;
            string primerApellido = textBoxClientePrimerAp.Text;
            string segundoApellido = textBoxClienteSegundoAp.Text;
            bool validacionId = false;
            bool validacionNombre = false;
            bool validacionPrimerApellido = false;
            bool validacionSegundoApellido = false;


            // Validar Id
            if (!string.IsNullOrEmpty(id))
            {
                errorProviderCliente.SetError(textBoxClienteID, "");
                validacionId = true;
            }
            else
            {
                errorProviderCliente.SetError(textBoxClienteID, "Uno o mas campos estan vacios, completelos para continuar");
            }

            // Validar Nombre
            if (!string.IsNullOrEmpty(nombre))
            {
                errorProviderCliente.SetError(textBoxClienteNombre, "");
                validacionNombre = true;
            }
            else
            {
                errorProviderCliente.SetError(textBoxClienteNombre, "Uno o mas campos estan vacios, completelos para continuar");
            }

            // Validar primer apellido
            if (!string.IsNullOrEmpty(primerApellido))
            {
                errorProviderCliente.SetError(textBoxClientePrimerAp, "");
                validacionPrimerApellido = true;
            }
            else
            {
                errorProviderCliente.SetError(textBoxClientePrimerAp, "Uno o mas campos estan vacios, completelos para continuar");
            }

            // Validar segundo apellido
            if (!string.IsNullOrEmpty(segundoApellido))
            {
                errorProviderCliente.SetError(textBoxClienteSegundoAp, "");
                validacionSegundoApellido = true;
            }
            else
            {
                errorProviderCliente.SetError(textBoxClienteSegundoAp, "Uno o mas campos estan vacios, completelos para continuar");
            }

            if (validacionId && validacionNombre && validacionPrimerApellido && validacionSegundoApellido)
            {
                registrarCliente();
            }
        }

        // Logica registrar y validar tipo de vehiculo
        private void registrarTipoVehiculo()
        {
            Int32.TryParse(textBoxTipoVehiculoID.Text, out int id);
            string descripcion = textBoxTipoVehiculoDescripcion.Text;
            bool estado = Helpers.stringToBool(comboBoxTipoVehiculoEstado.Text);

            foreach (TipoVehiculo tipoVehiculo in accesoDatos.ObtenerTipoVehiculos())
            {
                if (tipoVehiculo.Id == id)
                {
                    MessageBox.Show($"Ya existe un tipo de vehiculo con el ID {id}", "ERROR");
                    return;
                }
            }

            TipoVehiculo nuevoTipoVehiculo = new TipoVehiculo(
                id: id,
                descripcion: descripcion,
                estado: estado);

            if (accesoDatos.Registrar(nuevoTipoVehiculo))
            {
                MessageBox.Show($"Tipo de vehiculo con el ID {id} registrado en la base de datos", "Tipo de Vehiculo Registrado");

                actualizarConsultaTipoVehiculo();
            } else
            {
                MessageBox.Show($"Hubo un error al registrar el tipo de vehiculo con el id {id}, revise la consola para encontrar el error completo", "ERROR");
            }

            textBoxTipoVehiculoID.Clear();
            textBoxTipoVehiculoDescripcion.Clear();
            comboBoxTipoVehiculoEstado.ResetText(); ;
        }
        private void actualizarConsultaTipoVehiculo()
        {
            comboBoxVehiculoTipo.Items.Clear();
            comboBoxTipoVehiculoCobertura.Items.Clear();

            List<TipoVehiculo> listaTipoVehiculos = accesoDatos.ObtenerTipoVehiculos();

            dataGridViewConsultaTipoVehiculo.DataSource =listaTipoVehiculos.Where(x => x != null).Select((x, index) =>
                new
                {
                    ID = x.Id,
                    DESCRIPCION = x.Descripcion,
                    ESTADO = Helpers.boolToString(x.Estado)
                }).ToList();

            foreach (TipoVehiculo tipoVehiculo in listaTipoVehiculos)
            {
                if (tipoVehiculo.Estado)
                {
                    comboBoxVehiculoTipo.Items.Add(tipoVehiculo.Id);
                    comboBoxTipoVehiculoCobertura.Items.Add(tipoVehiculo.Id);
                }
            }
        }
        private void buttonRegistrarTipoVehiculo_Click(object sender, EventArgs e)
        {
            string idString = textBoxTipoVehiculoID.Text;
            string descripcion = textBoxTipoVehiculoDescripcion.Text;
            bool validacionId = false;
            bool validacionDesc = false;

            // Validar ID
            if (!string.IsNullOrEmpty(idString))
            {
                try
                {
                    int id = Int32.Parse(idString);
                    errorProviderSucursal.SetError(textBoxTipoVehiculoID, "");
                    validacionId = true;
                }
                catch (FormatException)
                {
                    errorProviderSucursal.SetError(textBoxTipoVehiculoID, "Lo introducido debe ser un numero valido");
                }
            }
            else
            {
                errorProviderSucursal.SetError(textBoxTipoVehiculoID, "No puede estar vacio");
            }

            if (!string.IsNullOrEmpty(descripcion))
            {
                errorProviderTipoVehiculo.SetError(textBoxTipoVehiculoDescripcion, "");
                validacionDesc = true;
            }
            else
            {
                errorProviderTipoVehiculo.SetError(textBoxTipoVehiculoDescripcion, "No puede estar vacio");
            }

            if (validacionId && validacionDesc)
            {
                registrarTipoVehiculo();
            }
        }

        // Logica registrar y validar vehiculo
        private void registrarVehiculo()
        {
            Int32.TryParse(textBoxVehiculoAlquilerDiario.Text, out int alquilerDiario);
            Int32.TryParse(textBoxVehiculoKilometraje.Text, out int kilometraje);
            string id = textBoxVehiculoID.Text;
            string marca = textBoxVehiculoMarca.Text;
            string modelo = textBoxVehiculoModelo.Text;
            int tipoVehiculoId = Int32.Parse(comboBoxVehiculoTipo.SelectedItem.ToString());

            foreach (Vehiculo vehiculo in accesoDatos.ObtenerVehiculos())
            {
                if (vehiculo.Id == id)
                {
                    MessageBox.Show($"Ya existe un vehiculo con el ID {id}", "ERROR");
                    return;
                }
            }

            Vehiculo nuevoVehiculo = new Vehiculo(
                id: id,
                marca: marca,
                modelo: modelo,
                tipo: accesoDatos.ObtenerTipoVehiculoPorId(tipoVehiculoId),
                alquilerDiario: alquilerDiario,
                km: kilometraje);

            if (accesoDatos.Registrar(nuevoVehiculo))
            {
                MessageBox.Show($"Vehiculo con el ID {id} registrado en la base de datos", "Vehiculo Registrado");

                actualizarConsultaVehiculo();
            }
            else
            {
                MessageBox.Show($"Hubo un error al registrar el vehiculo con el id {id}, revise la consola para encontrar el error completo", "ERROR");
            }

            textBoxVehiculoAlquilerDiario.Clear();
            textBoxVehiculoKilometraje.Clear();
            textBoxVehiculoID.Clear();
            textBoxVehiculoMarca.Clear();
            textBoxVehiculoModelo.Clear();
            comboBoxVehiculoTipo.ResetText();
        }
        private void actualizarConsultaVehiculo()
        {
            List<Vehiculo> listaVehiculos = accesoDatos.ObtenerVehiculos();
            List<Vehiculo> listaVehiculosNoAsignados = accesoDatos.ObtenerVehiculosNoAsignados();
            dataGridViewConsultaVehiculo.DataSource = listaVehiculos.Where(x => x != null).Select((x) =>
                new
                {
                    ID = x.Id,
                    MARCA = x.Marca,
                    MODELO = x.Modelo,
                    TIPO = x.Tipo.Id,
                    ALQUILER_DIARIO = x.AlquilerDiario,
                    KILOMETRAJE = x.Km
                }).ToList();

            dataGridViewVehiculoSucursalVehiculos.DataSource = listaVehiculosNoAsignados.Where(x => x != null).Select((x) =>
                new
                {
                    ID = x.Id,
                    MARCA = x.Marca,
                    MODELO = x.Modelo
                }).ToList();
        }
        private void buttonRegistrarVehiculo_Click(object sender, EventArgs e)
        {
            string id = textBoxVehiculoID.Text;
            string marca = textBoxVehiculoMarca.Text;
            string modelo = textBoxVehiculoModelo.Text;
            string tipoVehiculoId = "";
            try
            {
                tipoVehiculoId = comboBoxVehiculoTipo.SelectedItem.ToString();
            }
            catch (System.NullReferenceException)
            {
                tipoVehiculoId = "";
            }
            string alquilerDiarioString = textBoxVehiculoAlquilerDiario.Text;
            string kilometrajeString = textBoxVehiculoKilometraje.Text;
            bool validacionId = false;
            bool validacionMarca = false;
            bool validacionModelo = false;
            bool validacionTipoVehiculoId = false;
            bool validacionAlquilerDiario = false;
            bool validacionKilometraje = false;

            // Validar Id
            if (!string.IsNullOrEmpty(id))
            {
                errorProviderVehiculo.SetError(textBoxVehiculoID, "");
                validacionId = true;
            }
            else
            {
                errorProviderVehiculo.SetError(textBoxVehiculoID, "No puede estar vacio");
            }

            // Validar marca
            if (!string.IsNullOrEmpty(marca))
            {
                errorProviderVehiculo.SetError(textBoxVehiculoMarca, "");
                validacionMarca = true;
            }
            else
            {
                errorProviderVehiculo.SetError(textBoxVehiculoMarca, "No puede estar vacio");
            }
            // Validar Modelo
            if (!string.IsNullOrEmpty(modelo))
            {
                errorProviderVehiculo.SetError(textBoxVehiculoModelo, "");
                validacionModelo = true;
            }
            else
            {
                errorProviderVehiculo.SetError(textBoxVehiculoModelo, "No puede estar vacio");
            }

            // Validar tipo de vehiculo Id
            if (!string.IsNullOrEmpty(tipoVehiculoId))
            {
                errorProviderVehiculo.SetError(comboBoxVehiculoTipo, "");
                validacionTipoVehiculoId = true;
            }
            else
            {
                errorProviderVehiculo.SetError(comboBoxVehiculoTipo, $"Es necesario registrar y seleccionar un tipo de vehiculo para poder registrar un vehiculo");
            }

            // Validar alquiler diario
            if (!string.IsNullOrEmpty(alquilerDiarioString))
            {
                try
                {
                    int alquilerDiario = Int32.Parse(alquilerDiarioString);
                    errorProviderVehiculo.SetError(textBoxVehiculoAlquilerDiario, "");
                    validacionAlquilerDiario = true;
                }
                catch (FormatException)
                {
                    errorProviderVehiculo.SetError(textBoxVehiculoAlquilerDiario, "Lo introducido debe ser un numero valido");
                }
            }
            else
            {
                errorProviderVehiculo.SetError(textBoxVehiculoAlquilerDiario, "No puede estar vacio");
            }


            // Validar kilometraje
            if (!string.IsNullOrEmpty(kilometrajeString))
            {
                try
                {
                    int kilometraje = Int32.Parse(kilometrajeString);
                    errorProviderVehiculo.SetError(textBoxVehiculoKilometraje, "");
                    validacionKilometraje = true;
                }
                catch (FormatException)
                {
                    errorProviderVehiculo.SetError(textBoxVehiculoKilometraje, "Lo introducido debe ser un numero valido");
                }
            }
            else
            {
                errorProviderVehiculo.SetError(textBoxVehiculoKilometraje, "No puede estar vacio");
            }

            if (validacionId && validacionMarca && validacionModelo && validacionTipoVehiculoId && validacionAlquilerDiario && validacionKilometraje)
            {
                registrarVehiculo();
            }
        }

        // Logica registrar y validar Sucursal Vehiculo
        private void registrarVehiculoSucursal()
        {
            Sucursal sucursal = (comboBoxSucursalesDisponibles.SelectedItem as SucursalComboBoxItem).Value as Sucursal;
            int vehiculosSeleccionados = dataGridViewVehiculoSucursalVehiculos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            List<VehiculoSucursal> listaVehiculoSucursal = accesoDatos.ObtenerVehiculoSucursal();

            for (int i = 0; i < vehiculosSeleccionados; i++)
            {
                string vehiculoId = dataGridViewVehiculoSucursalVehiculos.SelectedRows[i].Cells[0].Value.ToString();
                VehiculoSucursal nuevoVehiculoSucursal = new VehiculoSucursal(
                    id: sucursal.Id,
                    fecha: DateTime.Today,
                    sucursal: sucursal,
                    idVehiculo: vehiculoId);

                if (!accesoDatos.Registrar(nuevoVehiculoSucursal))
                {
                    MessageBox.Show($"Hubo un error al registrar la asignacion de vehiculo con el id {sucursal.Id} para el vehiculo {vehiculoId}", "ERROR");
                }
            }

            actualizarConsultaVehiculo();
            agregarAsignacionComboBox();

        }
        private void agregarAsignacionComboBox()
        {

            try
            {
                comboBoxConsultaSucursalVehiculo.Items.Clear();

                List<VehiculoSucursal> listaVehiculoSucursal = accesoDatos.ObtenerVehiculoSucursalUnico();

                foreach (VehiculoSucursal vehiculoSucursal in listaVehiculoSucursal)
                {
                    Sucursal sucursalComboBox = accesoDatos.ObtenerSucursalporId(vehiculoSucursal.Id);
                    SucursalComboBoxItem item = new SucursalComboBoxItem();
                    item.Text = $"ID:{sucursalComboBox.Id}, Nombre:{sucursalComboBox.Nombre}, Direccion:{sucursalComboBox.Direccion}";
                    item.Value = sucursalComboBox;

                    comboBoxConsultaSucursalVehiculo.Items.Add(item);
                }
                comboBoxConsultaSucursalVehiculo.SelectedIndex = 0;

            }
            catch (Exception)
            {
                return;
            }

        }
        private void actualizarConsultaVehiculoSucursal()
        {
            Sucursal sucursal = (comboBoxConsultaSucursalVehiculo.SelectedItem as SucursalComboBoxItem).Value as Sucursal;

            List<VehiculoSucursal> listaVehiculoSucursalPorID = accesoDatos.ObtenerVehiculoSucursalPorId(sucursal.Id);

            dataGridViewConsultaVehiculoSucursalVehiculos.DataSource = listaVehiculoSucursalPorID.Where(x => x != null).Select((x) =>
                new
                {
                    ID = x.Id,
                    FECHA = x.Fecha,
                    ID_VEHICULO = x.IdVehiculo,
                    ID_SUCURSAL = x.Sucursal.Id
                }).ToList();        
        }
        private void buttonAsignarVehiculoSucursal_Click(object sender, EventArgs e)
        {
            bool validacionSeleccionVehiculo = false;
            bool validacionSeleccionSucursal = false;
            Sucursal sucursal = new Sucursal();
            try
            {
                sucursal = (comboBoxSucursalesDisponibles.SelectedItem as SucursalComboBoxItem).Value as Sucursal;
            }
            catch (System.NullReferenceException)
            {
                sucursal = new Sucursal();
            }


            // Validar que haya al menos un vehiculo seleccionado
            int vehiculosSeleccionados = dataGridViewVehiculoSucursalVehiculos.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (vehiculosSeleccionados > 0)
            {
                errorProviderVehiculoSucursal.SetError(dataGridViewVehiculoSucursalVehiculos, "");
                validacionSeleccionVehiculo = true;
            }
            else
            {
                errorProviderVehiculoSucursal.SetError(dataGridViewVehiculoSucursalVehiculos, "Debe seleccionar al menos un vehiculo");
            }

            // Validar que haya una sucursal seleccionada

            if (!string.IsNullOrEmpty(sucursal.Id.ToString()))
            {
                errorProviderVehiculoSucursal.SetError(comboBoxSucursalesDisponibles, "");
                validacionSeleccionSucursal = true;
            }
            else
            {
                errorProviderVehiculoSucursal.SetError(comboBoxSucursalesDisponibles, "Debe seleccionar una sucursal");
            }

            if (validacionSeleccionSucursal && validacionSeleccionVehiculo)
            {
                registrarVehiculoSucursal();
            }
        }
        private void comboBoxConsultaSucursalVehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarConsultaVehiculoSucursal();
        }

        // Logica registrar y validar Cobertura por tipo de vehiculo
        private void registrarCobertura()
        {
            Int32.TryParse(textBoxMontoCobertura.Text, out int monto);
            Int32.TryParse(textBoxIdCobertura.Text, out int id);
            string descripcion = textBoxDescripcionCobertura.Text;
            bool estado = Helpers.stringToBool(comboBoxEstadoCobertura.Text);
            int tipoVehiculoId = Int32.Parse(comboBoxTipoVehiculoCobertura.SelectedItem.ToString());

            foreach (Cobertura cobertura in accesoDatos.ObtenerCoberturas())
            {
                if (cobertura.Id == id)
                {
                    MessageBox.Show($"Ya existe una cobertura con el ID {id}", "ERROR");
                    return;
                }
            }

            Cobertura coberturaNueva = new Cobertura(
                id: id,
                descripcion: descripcion,
                tipoVehiculo: accesoDatos.ObtenerTipoVehiculoPorId(tipoVehiculoId),
                estado: estado,
                monto: monto);

            if (accesoDatos.Registrar(coberturaNueva))
            {
                MessageBox.Show($"Cobertura con el ID {id} registrada en la base de datos", "Cobertura Registrada");
                actualizarConsultaCobertura();
                actualizarConsultaTipoVehiculo();
            }
            else
            {
                MessageBox.Show($"Hubo un error al registrar la cobertura con el id {id}, revise la consola para encontrar el error completo", "ERROR");
            }

            textBoxIdCobertura.Clear();
            textBoxDescripcionCobertura.Clear();
            textBoxMontoCobertura.Clear();
            comboBoxEstadoCobertura.ResetText();
        }
        private void actualizarConsultaCobertura()
        {
            dataGridViewConsultaCoberturas.DataSource = accesoDatos.ObtenerCoberturas().Where(x => x != null).Select((x) =>
                new
                {
                    ID = x.Id,
                    DESCRIPCION = x.Descripcion,
                    MONTO = x.Monto,
                    ESTADO = Helpers.boolToString(x.Estado),
                    TIPO_VEHICULO_ID = x.TipoVehiculo.Id
                }).ToList();
        }
        private void buttonRegistrarCobertura_Click(object sender, EventArgs e)
        {
            string id = textBoxIdCobertura.Text;
            string descripcion = textBoxDescripcionCobertura.Text;
            string montoString = textBoxMontoCobertura.Text;
            string tipoVehiculoId = "";
            try
            {
                tipoVehiculoId = comboBoxTipoVehiculoCobertura.SelectedItem.ToString();
            }
            catch (System.NullReferenceException)
            {
                tipoVehiculoId = "";
            }
            bool validacionId = false;
            bool validacionDescripcion = false;
            bool validacionMonto = false;
            bool validacionTipoVehiculoId = false;

            // Validar Id
            if (!string.IsNullOrEmpty(id))
            {
                errorProviderCobertura.SetError(textBoxIdCobertura, "");
                validacionId = true;
            }
            else
            {
                errorProviderCobertura.SetError(textBoxIdCobertura, "No puede estar vacio");
            }

            // Validar descripcion
            if (!string.IsNullOrEmpty(descripcion))
            {
                errorProviderCobertura.SetError(textBoxDescripcionCobertura, "");
                validacionDescripcion = true;
            }
            else
            {
                errorProviderCobertura.SetError(textBoxDescripcionCobertura, "No puede estar vacio");
            }
            // Validar Monto
            if (!string.IsNullOrEmpty(montoString))
            {
                try
                {
                    int monto = Int32.Parse(montoString);
                    errorProviderCobertura.SetError(textBoxMontoCobertura, "");
                    validacionMonto = true;
                }
                catch (FormatException)
                {
                    errorProviderCobertura.SetError(textBoxMontoCobertura, "Lo introducido debe ser un numero valido");
                }
            }
            else
            {
                errorProviderCobertura.SetError(textBoxMontoCobertura, "No puede estar vacio");
            }
            // Validar tipo de vehiculo Id
            if (!string.IsNullOrEmpty(tipoVehiculoId))
            {
                errorProviderCobertura.SetError(comboBoxTipoVehiculoCobertura, "");
                validacionTipoVehiculoId = true;
            }
            else
            {
                errorProviderCobertura.SetError(comboBoxTipoVehiculoCobertura, $"Es necesario registrar y seleccionar un tipo de vehiculo para poder registrar un vehiculo");
            }

            if (validacionId && validacionDescripcion && validacionTipoVehiculoId && validacionMonto)
            {
                registrarCobertura();
            }
        }

        private void actualizarConsultas()
        {
            actualizarConsultaCliente();
            actualizarConsultaSucursal();
            actualizarConsultaVehiculo();
            actualizarConsultaTipoVehiculo();
            actualizarConsultaCobertura();
            agregarAsignacionComboBox();
        }

    }
}

public class SucursalComboBoxItem
{
    public string Text { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
        return Text;
    }
}
