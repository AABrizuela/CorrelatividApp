using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelatividApp.Entidades
{
    public class Curricula
    {
        #region Atributos
        private int cantidadMaterias;
        private List<Materia> ListMaterias;
        public ECuatrimestre cuatrimestre;
        #endregion

        #region Propiedades
        public List<Materia> GetMaterias { get => this.ListMaterias; }

        public Materia this[int index] { get => this.ListMaterias[index]; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado que inicializa la lista de materias
        /// </summary>
        private Curricula()
        {
            ListMaterias = new List<Materia>();
        }

        /// <summary>
        /// Constructor publico que inicializa la cantidad de materias y que invoca al constructor privado
        /// para inicializar la lista de materias
        /// </summary>
        /// <param name="cantidad"></param>
        public Curricula(int cantidad) : this()
        {
            this.cantidadMaterias = cantidad;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga para agregar una materia a la curricula
        /// </summary>
        /// <param name="curricula"></param>
        /// <param name="materia"></param>
        /// <returns></returns>
        public static Curricula operator +(Curricula curricula, Materia materia)
        {
            if(!Object.Equals(curricula, null) && !Object.Equals(materia, null))
            {
                foreach (Materia item in curricula.ListMaterias)
                {
                    if(item.nombre != materia.nombre)
                    {
                        curricula.ListMaterias.Add(materia);
                        break;
                    }
                }
            }
            return curricula;
        }

        /// <summary>
        /// Sobrecarga para quitar una materia de la curricula
        /// </summary>
        /// <param name="curricula"></param>
        /// <param name="materia"></param>
        /// <returns></returns>
        public static Curricula operator -(Curricula curricula, Materia materia)
        {
            if(!Object.Equals(curricula, null) && !Object.Equals(materia, null))
            {
                foreach (Materia item in curricula.ListMaterias)
                {
                    if(item.nombre == materia.nombre)
                    {
                        curricula.ListMaterias.Remove(materia);
                        break;
                    }                    
                }
            }

            return curricula;
        }

        public static implicit operator string(Curricula curricula)
        {
            return curricula.GetMaterias.ToString();
        }
        #endregion
    }
}
