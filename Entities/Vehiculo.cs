namespace Entities
{
    public class Vehiculo
    {
        private string id;
        private string marca;
        private string modelo;
        private TipoVehiculo tipo;
        private int alquilerDiario;
        private int km;
        private bool asignado;

        public Vehiculo()
        { }

        public Vehiculo(
            string id,
            string marca,
            string modelo,
            TipoVehiculo tipo,
            int alquilerDiario,
            int km,
            bool asignado
            )
        {
            this.id = id;
            this.marca = marca;
            this.modelo = modelo;
            this.tipo = tipo;
            this.alquilerDiario = alquilerDiario;
            this.km = km;
            this.asignado = asignado;
        }

        public string Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Marca
        {
            set { marca = value; }
            get { return marca; }
        }

        public string Modelo
        {
            set { modelo = value; }
            get { return modelo; }
        }

        public TipoVehiculo Tipo
        {
            set { tipo = value; }
            get { return tipo; }
        }

        public int AlquilerDiario
        {
            set { alquilerDiario = value; }
            get { return alquilerDiario; }
        }

        public int Km
        {
            set { km = value; }
            get { return km; }
        }

        public bool Asignado
        {
            set { asignado = value; }
            get { return asignado; }
        }
    }
}
