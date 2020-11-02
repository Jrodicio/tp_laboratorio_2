using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entid;
using ClasesInstanciables;
using Excepciones;
namespace TestExcepcionesDNI
{
    [TestClass]
    public class Class1
    {

        [TestMethod]
        public void DNIConCaracteres()
        {

            string dniCaracter = "30.89567";
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
                // DNI Invalido?
                Profesor personaPrimero = new Profesor(1, "Juan", "Lopez", dni, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                return;
            }
            Assert.Fail("Sin excepción para DNI inválido: {0}.", dni);
        }

        [TestMethod]
        public void DNIMayor()
        {
            string dni = "100000000";
            try
            {
                Alumno alumno = new Alumno(3, "Juan", "Lopez", dni, Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void DNIDistintaNacionalidad()
        {
            string dni1 = "12567589";
            string dni2 = "92567589";

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
            string dniCaracter = "30895672";
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
