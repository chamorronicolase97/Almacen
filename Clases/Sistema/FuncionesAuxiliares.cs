using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases.Sistema
{
    /// <summary>
    /// Funciones que nos ayudaran a parsear objetos o validar algunos otros.
    /// </summary>
    public class FuncionesAuxiliares
    {
        
        /// <summary>
        /// Devuelve DBNull si el objeto es nulo, de caso contrario devuelve el objeto.
        /// </summary>
        /// <param name="objeto">valor a evaluar.</param>
        /// <returns>DBNULL o el objeto</returns>
        public static object ConvertDBNullIfNull(object? objeto)
        {
            if (objeto == null)
            {
                return DBNull.Value;
            }
            else
            {
                return objeto;
            }
        }


        public static decimal? ConvertToNDecimal(object input)
        {
            if (input == null)
            {
                return null;
            }

            // Try parsing as string
            if (input is string str)
            {
                if (decimal.TryParse(str, out decimal decimalResult))
                {
                    return decimalResult;
                }
            }

            // Not a number
            return null;
        }
    }
}
