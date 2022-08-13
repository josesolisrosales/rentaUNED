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
                        km: reader.GetInt32(5)));
                }
            }

            connection.Close();

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

        public List<Vehiculo> ObtenerVehiculosNoAsignados()
        {
            List<Vehiculo> listaVehiculo = ObtenerVehiculos();
            List<string> listaVehiculosAsignados = ObtenerIDVehiculosAsignados();

           foreach(Vehiculo vehiculo in listaVehiculo.ToList())
            {
                if (listaVehiculosAsignados.Contains(vehiculo.Id))
                {
                    listaVehiculo.Remove(vehiculo);
                }
            }

            foreach(Vehiculo vehiculo in listaVehiculo)
            {
                Debug.WriteLine(vehiculo.Id);
            }

            return listaVehiculo;
        }

        public List<string> ObtenerIDVehiculosAsignados()
        {
            List <VehiculoSucursal> listaVehiculoSucursal = ObtenerVehiculoSucursal();
            List<string> idVehiculosAsignados = new List<string>();

            foreach (VehiculoSucursal vehiculoSucursal in listaVehiculoSucursal)
            {
                idVehiculosAsignados.Add(vehiculoSucursal.IdVehiculo);
            }

            return idVehiculosAsignados;

        }

        public List<VehiculoSucursal> ObtenerVehiculoSucursalUnico()
        {
            List<VehiculoSucursal> listaVehiculoSucursal = ObtenerVehiculoSucursal();
            List<int> uniqControl = new List<int>();

            foreach (VehiculoSucursal vehiculoSucursal in listaVehiculoSucursal.ToList())
            {
                if (!uniqControl.Contains(vehiculoSucursal.Id))
                {
                    uniqControl.Add(vehiculoSucursal.Id);
                }
                else
                {
                    listaVehiculoSucursal.Remove(vehiculoSucursal);
                }
            }

            return listaVehiculoSucursal;
        }

        public List<VehiculoSucursal> ObtenerVehiculoSucursalPorId(int id)
        {
            List<VehiculoSucursal> listaVehiculoSucursal = ObtenerVehiculoSucursal();
            List<VehiculoSucursal> listaVehiculosucursalPorId = new List<VehiculoSucursal>();

            foreach (VehiculoSucursal vehiculoSucursal in listaVehiculoSucursal)
            {
                if (vehiculoSucursal.Id == id)
                {
                    listaVehiculosucursalPorId.Add(vehiculoSucursal);
                }
            }

            return listaVehiculosucursalPorId;
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
    }
}
