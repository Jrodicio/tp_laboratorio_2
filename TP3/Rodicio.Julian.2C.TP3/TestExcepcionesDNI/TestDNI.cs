﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestExcepcionesDNI
{
    [TestClass]
    public class TestDNI
    {

        [TestMethod]
        public void DNIConCaracteres()
        {

            string dniCaracter = "50.12232";
            try
            {
                Alumno alumno = new Alumno(1, "Juan", "Lopez", dniCaracter, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void DNIMenor()
        {

            string dni = "0";
            try
            {
                Profesor personaPrimero = new Profesor(1, "Juan", "Lopez", dni, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                return;
            }
        }

        [TestMethod]
        public void DNIMayor()
        {
            string dni = "100000000";
            try
            {
                Alumno alumno = new Alumno(3, "Juan", "Lopez", dni, Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void DNIDistintaNacionalidad()
        {
            string dni1 = "40980255";
            string dni2 = "94717549";

            try
            {
                Alumno alumno = new Alumno(4, "Juan", "Lopez", dni1, Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
                return;
            }

            try
            {
                Alumno alumno = new Alumno(9, "Juan", "Lopez", dni2, Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
                return;
            }
        }

        [TestMethod]
        public void DNINumerico()
        {
            string dniCaracter = "40980255";
            int i = 1;
            Alumno alumno = new Alumno(1, "Juan", "Lopez", dniCaracter, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try
            {
                if (alumno.DNI.GetType() != i.GetType())
                {
                    return;
                }
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(InvalidOperationException));
            }
        }
    }
}

