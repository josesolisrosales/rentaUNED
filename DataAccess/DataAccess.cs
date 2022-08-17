using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utils;

namespace DataAccess
{
    // Metodos de acceso a los datos en la base de datos SQL,
    //SE usan para insertar, y consultar la base de datos con diferentes "filtros" necesarios para el funcionamiento correcto de ciertas funciones del servidor y cliente

    public class DBOps
    {

        private string connectionChain;

        public DBOps()
        {
            connectionChain = ConfigurationManager.ConnectionStrings["RentaUNEDConexion"].ConnectionString;
        }
        public bool Registrar(Cliente cliente)
        {

            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO CLIENTE (IdCliente, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero)" +
                    " VALUES (@IdCliente, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Genero)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdCliente", cliente.Id);
                cmd.Parameters.AddWithValue("Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("PrimerApellido", cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("SegundoApellido", cliente.SegundoApellido);
                cmd.Parameters.AddWithValue("FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("Genero", cliente.Genero);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool Registrar(Sucursal sucursal)
        {

            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO SUCURSAL (IdSucursal, Nombre, Direccion, Estado, Telefono)" +
                    " VALUES (@IdSucursal, @Nombre, @Direccion, @Estado, @Telefono)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdSucursal", sucursal.Id);
                cmd.Parameters.AddWithValue("Nombre", sucursal.Nombre);
                cmd.Parameters.AddWithValue("Direccion", sucursal.Direccion);
                cmd.Parameters.AddWithValue("Estado", sucursal.Estado);
                cmd.Parameters.AddWithValue("Telefono", sucursal.Telefono);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Registrar(Cobertura cobertura)
        {

            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO COBERTURASEGURO (IdCobertura, Descripcion, IdTipoVehiculo, Estado, Monto)" +
                    " VALUES (@IdCobertura, @Descripcion, @IdTipoVehiculo, @Estado, @Monto)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdCobertura", cobertura.Id);
                cmd.Parameters.AddWithValue("Descripcion", cobertura.Descripcion);
                cmd.Parameters.AddWithValue("IdTipoVehiculo", cobertura.TipoVehiculo.Id);
                cmd.Parameters.AddWithValue("Estado", cobertura.Estado);
                cmd.Parameters.AddWithValue("Monto", cobertura.Monto);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool Registrar(Vehiculo vehiculo)
        {

            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO VEHICULO (IdPlaca, Marca, Modelo, IdTipoVehiculo, CostoAlquilerDia, Kilometraje)" +
                    " VALUES (@IdPlaca, @Marca, @Modelo, @IdTipoVehiculo, @CostoAlquilerDia, @Kilometraje)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdPlaca", vehiculo.Id);
                cmd.Parameters.AddWithValue("Marca", vehiculo.Marca);
                cmd.Parameters.AddWithValue("Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("IdTipoVehiculo", vehiculo.Tipo.Id);
                cmd.Parameters.AddWithValue("CostoAlquilerDia", vehiculo.AlquilerDiario);
                cmd.Parameters.AddWithValue("Kilometraje", vehiculo.Km);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Registrar(TipoVehiculo tipoVehiculo)
        {

            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO TIPOVEHICULO (IdTipo, Descripcion, Estado)" +
                    " VALUES (@IdTipo, @Descripcion, @Estado)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdTipo", tipoVehiculo.Id);
                cmd.Parameters.AddWithValue("Descripcion", tipoVehiculo.Descripcion);
                cmd.Parameters.AddWithValue("Estado", tipoVehiculo.Estado);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Registrar(VehiculoSucursal vehiculoSucursal)
        {

            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO VEHICULOSUCURSAL (IdAsignacion, IdSucursal, IdPlaca, FechaAsignacion)" +
                    "VALUES (@IdAsignacion, @IdSucursal, @IdPlaca, @FechaAsignacion)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdAsignacion", vehiculoSucursal.Id);
                cmd.Parameters.AddWithValue("IdSucursal", vehiculoSucursal.Sucursal.Id);
                cmd.Parameters.AddWithValue("IdPlaca", vehiculoSucursal.IdVehiculo);
                cmd.Parameters.AddWithValue("FechaAsignacion", vehiculoSucursal.Fecha);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Registrar(Reserva reserva)
        {
            try
            {
                SqlConnection connection;
                SqlCommand cmd = new SqlCommand();
                string sql;

                connection = new SqlConnection(connectionChain);
                sql = "INSERT INTO RESERVA (IdReserva, IdCliente, IdPlaca, FechaReserva, FechaInicio, FechaFin, MontoReserva)" +
                    "VALUES (@IdReserva, @IdCliente, @IdPlaca, @FechaReserva, @FechaInicio, @FechaFin, @MontoReserva)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("IdReserva", reserva.Id);
                cmd.Parameters.AddWithValue("IdCliente", reserva.IdCliente);
                cmd.Parameters.AddWithValue("IdPlaca", reserva.IdVehiculo);
                cmd.Parameters.AddWithValue("FechaReserva", reserva.FechaReserva);
                cmd.Parameters.AddWithValue("FechaInicio", reserva.FechaInicio);
                cmd.Parameters.AddWithValue("FechaFin", reserva.FechaFin);
                cmd.Parameters.AddWithValue("MontoReserva", reserva.Monto);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From Cliente";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();
            
            reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listaClientes.Add(new Cliente(
                        id:reader.GetString(0),
                        nombre:reader.GetString(1),
                        primerApellido:reader.GetString(2),
                        segundoApellido:reader.GetString(3),
                        fechaNacimiento:reader.GetDateTime(4),
                        genero:char.Parse(reader.GetString(5))));
                }
            }

            connection.Close();

            return listaClientes;
        }

        public List<Sucursal> ObtenerSucursales()
        {
            List<Sucursal> listaSucursales = new List<Sucursal>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From Sucursal";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listaSucursales.Add(new Sucursal(
                        id: reader.GetInt32(0),
                        nombre: reader.GetString(1),
                        direccion: reader.GetString(2),
                        estado: reader.GetBoolean(3),
                        telefono: reader.GetString(4)));
                }
            }

            connection.Close();

            return listaSucursales;
        }

        public List<Cobertura> ObtenerCoberturas()
        {
            List<Cobertura> listaCoberturas = new List<Cobertura>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From CoberturaSeguro";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listaCoberturas.Add(new Cobertura(
                        id: reader.GetInt32(0),
                        descripcion: reader.GetString(1),
                        tipoVehiculo: ObtenerTipoVehiculoPorId(reader.GetInt32(2)),
                        estado: reader.GetBoolean(3),
                        monto: reader.GetInt32(4)));
                }
            }

            connection.Close();

            return listaCoberturas;
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From Vehiculo";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listaVehiculos.Add(new Vehiculo(
                        id: reader.GetString(0),
                        marca: reader.GetString(1),
                        modelo: reader.GetString(2),
                        tipo: ObtenerTipoVehiculoPorId(reader.GetInt32(3)),
                        alquilerDiario: reader.GetInt32(4),
                        km: reader.GetInt32(5),
                        asignado: false));
                }
            }

            connection.Close();

            List<VehiculoSucursal> listaVehiculoSucursal = ObtenerVehiculoSucursal();

            foreach (VehiculoSucursal asignacion in listaVehiculoSucursal.ToList())
            {
                foreach (Vehiculo vehiculo in listaVehiculos)
                {
                    if (asignacion.IdVehiculo == vehiculo.Id)
                    {
                        vehiculo.Asignado = true;
                    }
                }
            }

            return listaVehiculos;
        }

        public List<TipoVehiculo> ObtenerTipoVehiculos()
        {
            List<TipoVehiculo> ListaTipoVehiculos = new List<TipoVehiculo>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From TIPOVEHICULO";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListaTipoVehiculos.Add(new TipoVehiculo(
                        id: reader.GetInt32(0),
                        descripcion: reader.GetString(1),
                        estado: reader.GetBoolean(2)));
                }
            }

            connection.Close();

            return ListaTipoVehiculos;
        }

        public List<Reserva> ObtenerReservas()
        {
            List<Reserva> listaReserva = new List<Reserva>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From RESERVA";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listaReserva.Add(new Reserva(
                        id: reader.GetInt32(0),
                        idCliente: reader.GetString(1),
                        idVehiculo: reader.GetString(2),
                        fechaReserva: reader.GetDateTime(3),
                        fechaInicio: reader.GetDateTime(4),
                        fechaFin: reader.GetDateTime(5),
                        monto: reader.GetInt32(6)));
                }
            }

            connection.Close();

            return listaReserva;
        }

        public Vehiculo ObtenerVehiculoPorId(string id)
        {
            List<Vehiculo> listaVehiculos = ObtenerVehiculos();

            foreach (Vehiculo vehiculo in listaVehiculos)
            {
                if (vehiculo.Id.Equals(id))
                {
                    return vehiculo;
                }
            }
            return null;
        }

        public List<VehiculoSucursal> ObtenerVehiculoSucursal()
        {
            List<VehiculoSucursal> ListaVehiculoSucursal = new List<VehiculoSucursal>();

            SqlConnection connection;
            SqlCommand cmd = new SqlCommand();
            string sql;
            SqlDataReader reader;

            connection = new SqlConnection(connectionChain);
            sql = "SELECT * From VEHICULOSUCURSAL";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListaVehiculoSucursal.Add(new VehiculoSucursal(
                        id: reader.GetInt32(0),
                        sucursal: ObtenerSucursalporId(reader.GetInt32(1)),
                        idVehiculo: reader.GetString(2),
                        fecha: reader.GetDateTime(3)));
                }
            }

            connection.Close();

            return ListaVehiculoSucursal;
        }

        public Cliente ObtenerClientePorId(string id)
        {
            List<Cliente> listaCliente = ObtenerClientes();

            foreach (Cliente cliente in listaCliente)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }

            return null;
        }

        public TipoVehiculo ObtenerTipoVehiculoPorId(int id)
        {
            foreach (TipoVehiculo tipoVehiculo in ObtenerTipoVehiculos())
            {
                if (tipoVehiculo.Id.Equals(id))
                {
                    return tipoVehiculo;
                }
            }

            return null;
        }

        public List<Sucursal> ObtenerSucursalesConAsignacion()
        {
            List<VehiculoSucursal> listaVehiculoSucursal = ObtenerVehiculoSucursal();
            List<int> IdSucursalUnico = new List<int>();
            List<Sucursal> sucursalesConAsignacion = new List<Sucursal>();

            foreach (VehiculoSucursal vehiculoSucursal in listaVehiculoSucursal.ToList())
            {
                if (!IdSucursalUnico.Contains(vehiculoSucursal.Sucursal.Id))
                {
                    IdSucursalUnico.Add(vehiculoSucursal.Sucursal.Id);
                }
            }

            foreach (int sucursalId in IdSucursalUnico)
            {
                sucursalesConAsignacion.Add(ObtenerSucursalporId(sucursalId));
            }

            return sucursalesConAsignacion;
        }

        public List<VehiculoSucursal> ObtenerVehiculoSucursalPorSucursal(Sucursal sucursal)
        {
            List<VehiculoSucursal> listaVehiculoSucursal = ObtenerVehiculoSucursal();
            List<VehiculoSucursal> listaVehiculosucursalPorSucursal = new List<VehiculoSucursal>();

            foreach (VehiculoSucursal vehiculoSucursal in listaVehiculoSucursal)
            {
                if (vehiculoSucursal.Sucursal.Id == sucursal.Id)
                {
                    listaVehiculosucursalPorSucursal.Add(vehiculoSucursal);
                }
            }

            return listaVehiculosucursalPorSucursal;
        }

        public Sucursal ObtenerSucursalporId(int id)
        {
            foreach (Sucursal sucursal in ObtenerSucursales())
            {
                if (sucursal.Id.Equals(id))
                {
                    return sucursal;
                }
            }

            return null;
        }

        public Sucursal ObtenerSucursalPorNombre(string nombre)
        {
            foreach (Sucursal sucursal in ObtenerSucursales())
            {
                if (sucursal.Nombre.Equals(nombre))
                {
                    return sucursal;
                }
            }

            return null;
        }

        public List<Cobertura> ObtenerCoberturaPorTipoVehiculo(int tipoVehiculoId)
        {
            List<Cobertura> coberturas = ObtenerCoberturas();
            List<Cobertura> coberturasPorTipoVehiculo = new List<Cobertura>();
            
            foreach (Cobertura cobertura in coberturas)
            {
                if (cobertura.TipoVehiculo.Id.Equals(tipoVehiculoId))
                {
                    coberturasPorTipoVehiculo.Add(cobertura);
                }
            }

            return coberturasPorTipoVehiculo;
            
        }

        public List<Reserva> ObtenerReservasPorCliente(string clientId)
        {
            List<Reserva> reservas = ObtenerReservas();
            List<Reserva> reservasCliente = new List<Reserva>();

            foreach (Reserva reserva in reservas)
            {
                if (reserva.IdCliente.Equals(clientId))
                {
                    reservasCliente.Add(reserva);
                }
            }

            return reservasCliente;
        }

        public bool validarClienteId(string id)
        {
            List<Cliente> listaCliente = ObtenerClientes();
            
            foreach (Cliente cliente in listaCliente)
            {
                if (cliente.Id.Equals(id))
                {
                    return true;
                }
            }

            return false;
        }

        public int GetNextAsignacionId()
        {
            List <VehiculoSucursal> listaVehiculoSucursal= ObtenerVehiculoSucursal();

            return listaVehiculoSucursal.Count + 1;
        }

        public int GetNextReservaId()
        {
            List<Reserva> listaReservas = ObtenerReservas();
            return listaReservas.Count + 1;
        }

        public bool CheckDisponibilidad(string vehiculoId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reserva> listaReservas = ObtenerReservas();

            foreach (Reserva reserva in listaReservas)
            {
                if (reserva.IdVehiculo.Equals(vehiculoId))
                {
                    if (fechaInicio <= reserva.FechaFin && reserva.FechaInicio <= fechaFin)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
