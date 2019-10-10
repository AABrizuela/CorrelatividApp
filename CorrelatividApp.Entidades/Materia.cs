using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelatividApp.Entidades
{
    public class Materia
    {
        #region Atributos
        public string nombre;
        public string codigo;
        public string estado;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Materia.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="codigo"></param>
        public Materia(string nombre, string codigo, string estado)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.estado = estado;
        }
        #endregion        

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga implicita de string, devuelve los atributos de la clase en una cadena.
        /// </summary>
        /// <param name="materia"></param>
        public static implicit operator string(Materia materia)
        {
            return materia.codigo + " - " + materia.nombre;
        }
        #endregion
    }
}
