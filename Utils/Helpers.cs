using System;

namespace Utils
{
    public class Helpers
    {
        // Helper para convertir string de genero a char
        public static char convertirGenero(string genero)
        {
            if (genero.ToLower() == "masculino" || genero.ToLower() == "")
            {
                return 'm';
            }
            else
            {
                return 'f';
            }
        }

        // Helper para convertir char de genero a string
        public static string convertirGenero(char genero)
        {
            if (genero == 'm')
            {
                return "masculino";
            }
            else
            {
                return "femenino";
            }

        }

        // Helper para convertir activo/inactivo a booleano, default (cuando estado es "") es activo
        public static bool stringToBool(string estadoString)
        {

            if (estadoString.ToLower() == "activo" || estadoString.ToLower() == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Helper para convertir de bool a string con el proposito de monstrarlo en el UI al consultar un objecto con este campo
        public static string boolToString(bool estado)
        {
            if (estado)
            {
                return "activo";
            }
            else
            {
                return "inactivo";
            }
        }
    
        public static string BoolToVarChar(bool estado)
        {
            string s = (estado ? 1 : 0).ToString();

            return s;
        }

        public static bool VarCharToBool(string estado)
        {
            bool b = false;
            if (estado.Equals("1"))
            {
                b = true;
            }

            return b;
        }

        //public static bool RevisarSucursalExistenteAsignacion(Sucursal sucursal)
        //{
        //    for (int i = 0; i < MainArrays.vehiculoSucursalArray.Length; i++)
        //    {
        //        if (MainArrays.vehiculoSucursalArray[i] != null && MainArrays.vehiculoSucursalArray[i].Sucursal == sucursal)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public static Vehiculo getVehiculoIndex(string vehiculoId)
        //{
        //    for (int i = 0; i < MainArrays.vehiculoArray.Length; i++)
        //    {
        //        if (MainArrays.vehiculoArray[i] != null && MainArrays.vehiculoArray[i].Id == vehiculoId)
        //        {
        //            return MainArrays.vehiculoArray[i];
        //        }
        //    }
        //    return null;
        //}

        //public static void markVehiculoAssigned(Vehiculo vehiculo)
        //{
        //    for (int i = 0; i < MainArrays.vehiculoArray.Length; i++)
        //    {
        //        if (MainArrays.vehiculoArray[i] != null && MainArrays.vehiculoArray[i].Id == vehiculo.Id)
        //        {
        //            MainArrays.vehiculoArray[i].Asignado = true;
        //        }
        //    }
        //}
    }
    public class CustomComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
