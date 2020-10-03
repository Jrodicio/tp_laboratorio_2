﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region Campos
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        #endregion

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible)
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            stringBuilder.AppendLine("");

            foreach (Vehiculo vehiculo in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if (vehiculo is Ciclomotor)
                        {
                            stringBuilder.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (vehiculo is Sedan)
                        {
                            stringBuilder.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if (vehiculo is Suv)
                        {
                            stringBuilder.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    default:
                        stringBuilder.AppendLine(vehiculo.Mostrar());
                        break;
                }
            }

            return stringBuilder.ToString();
        }
        

        #region "Sobrecarga Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo auxVehiculo in taller.vehiculos)
                {
                    if (auxVehiculo == vehiculo)
                    {
                        return taller;
                    }
                }

                taller.vehiculos.Add(vehiculo);
            }

            return taller;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            for (int index = 0; index < taller.vehiculos.Count; index++)
            {
                if(taller.vehiculos[index] == vehiculo)
                {
                    taller.vehiculos.RemoveAt(index);
                    break;
                }
            }
            return taller;
        }
        #endregion
        #endregion

        #region Tipos anidados
        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }
        #endregion
    }
}
