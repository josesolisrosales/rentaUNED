using System;

namespace Entities
{
    public class Cliente
    {
        private string id;
        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private DateTime fechaNacimiento;
        private char genero;

        public Cliente()
        { }

        public Cliente(
            string id,
            string nombre,
            string primerApellido,
            string segundoApellido,
            DateTime fechaNacimiento,
            char genero)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.fechaNacimiento = fechaNacimiento;
            this.genero = genero;
        }

        public string Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public string PrimerApellido
        {
            set { primerApellido = value; }
            get { return primerApellido; }
        }

        public string SegundoApellido
        {
            set { segundoApellido = value; }
            get { return segundoApellido; }
        }

        public DateTime FechaNacimiento
        {
            set { fechaNacimiento = value; }
            get { return fechaNacimiento; }
        }

        public char Genero
        {
            set { genero = value; }
            get { return genero; }
        }
    }
}
