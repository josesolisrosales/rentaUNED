using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;

namespace Client
{
    public class ClientTCP
    {

        private static IPAddress serverIP;
        private static TcpClient client;
        private static IPEndPoint serverEndPoint;
        private static StreamWriter clientStreamWriter;
        private static StreamReader clientStreamReader;


        public static int Connect(string pClientId)
        {

            try
            {
                serverIP = IPAddress.Parse("127.0.0.1");
                client = new TcpClient();
                client.ReceiveTimeout = 5000;
                serverEndPoint = new IPEndPoint(serverIP, 14100);
                client.Connect(serverEndPoint);
                SocketMsg<string> msgConnect = new SocketMsg<string> { Method = "Conectar", Entity = pClientId };

                clientStreamReader = new StreamReader(client.GetStream());
                clientStreamWriter = new StreamWriter(client.GetStream());

                clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msgConnect));
                clientStreamWriter.Flush();

                var reply = clientStreamReader.ReadLine();

                int validacion = JsonConvert.DeserializeObject<int>(reply);

                if (validacion == 1)
                {
                    return 1;
                } else
                {
                    client.Close();
                    return validacion;
                    
                }

            }
            catch (SocketException)
            {

                return -2;
            }
        }

        public static void Disconnect(string pClientId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "Desconectar", Entity = pClientId };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();
            client.Close();
        }

        public static bool ValidateId(string pClientId)
        {

            bool validacion = false;
            try
            {

                SocketMsg<string> msg = new SocketMsg<string> { Method = "ValidarId", Entity = pClientId };

                clientStreamReader = new StreamReader(client.GetStream());
                clientStreamWriter = new StreamWriter(client.GetStream());

                clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
                clientStreamWriter.Flush();

                var reply = clientStreamReader.ReadLine();

                validacion = JsonConvert.DeserializeObject<bool>(reply);

                return validacion;
            }
            catch (SocketException)
            {

                return false;
            }
        }

        public static Cliente ObtenerCliente(string pClientId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "ObtenerCliente", Entity = pClientId };
            
            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();

            var reply = clientStreamReader.ReadLine();

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(reply);

            return cliente;
        }

        public static List<Sucursal> ObtenerSucursalesActivas()
        {

            SocketMsg<string> msg = new SocketMsg<string> { Method = "ObtenerSucursales", Entity = null };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();

            var reply = clientStreamReader.ReadLine();

            List<Sucursal> listaSucursalesActivas = JsonConvert.DeserializeObject<List<Sucursal>>(reply);

            return listaSucursalesActivas;
        }

        public static List<Vehiculo> ObtenerVehiculosPorSucursal(string idSucursal)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "ObtenerVehiculosPorSucursal", Entity = idSucursal };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();
            var reply = clientStreamReader.ReadLine();

            List<Vehiculo> listaVehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(reply);

            return listaVehiculos;
        }

        public static Vehiculo ObtenerVehiculoPorId(string vehiculoId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "ObtenerVehiculoPorId", Entity = vehiculoId };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();

            var reply = clientStreamReader.ReadLine();

            Vehiculo vehiculo = JsonConvert.DeserializeObject<Vehiculo>(reply);

            return vehiculo;
        }

        public static List<Cobertura> ObtenerCoberturasPorTipoVehiculo(int tipoVehiculoId)
        {
            SocketMsg<int>msg = new SocketMsg<int>{ Method = "ObtenerCoberturasPorTipoVehiculo", Entity = tipoVehiculoId };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();

            var reply = clientStreamReader.ReadLine();

            List<Cobertura> listaCoberturas = JsonConvert.DeserializeObject<List<Cobertura>>(reply);

            return listaCoberturas;
        }

        public static void LockDb(string pClientId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "LockDb", Entity = pClientId };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();
        }

        public static void UnlockDb(string pClientId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "UnlockDb", Entity = pClientId };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();
        }

        public static bool checkDbLock(string pClientId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "checkDbLock", Entity = pClientId };

            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();
            var reply = clientStreamReader.ReadLine();

            bool busy = JsonConvert.DeserializeObject<bool>(reply);

            return busy;
        }

        public static bool checkDisponibilidadVehiculo(string vehiculoId, DateTime fechaInicio, DateTime fechaFinal)
        {
            bool disponibilidad = true;

            CheckReserva checkReserva = new CheckReserva();
            checkReserva.idVehiculo = vehiculoId;
            checkReserva.fechaInicio = fechaInicio;
            checkReserva.fechaFin = fechaFinal;

            SocketMsg<CheckReserva> msg = new SocketMsg<CheckReserva> { Method = "CheckDisponibilidadVehiculo", Entity = checkReserva };
            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();

            var reply = clientStreamReader.ReadLine();

            disponibilidad = JsonConvert.DeserializeObject<bool>(reply);

            return disponibilidad;
        }

        public static void RegistrarReserva(Reserva reserva)
        {
            SocketMsg<Reserva> msg = new SocketMsg<Reserva> { Method = "RegistrarReserva", Entity = reserva };
            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();
        }

        public static List<Reserva> ConsultarReservasPorCliente(string clientId)
        {
            SocketMsg<string> msg = new SocketMsg<string> { Method = "ConsultarReservasPorCliente", Entity = clientId };
            clientStreamWriter.WriteLine(JsonConvert.SerializeObject(msg));
            clientStreamWriter.Flush();

            var reply = clientStreamReader.ReadLine();
            List<Reserva> reservas = JsonConvert.DeserializeObject<List<Reserva>>(reply);

            return reservas;

        }
    }
}
