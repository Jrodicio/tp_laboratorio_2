using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;


namespace TestExcepcionesPersonas
{
    [TestClass]
    public class TestPersonas
    {
        [TestMethod]
        public void AlumnoRepetidoInvalidoTest()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno alumno1 = new Alumno(4, "Julian", "Rodicio", "40980255", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
                uni += alumno1;
                uni += alumno1;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
                return;
            }
        }

        [TestMethod]
        public void SinProfesorTest()
        {
            try
            {
                Universidad uni = new Universidad();
                Profesor profesor = uni == Universidad.EClases.Laboratorio;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
                return;
            }
        }

        [TestMethod]
        public void ProfesorNullTest()
        {
            Profesor profesor = new Profesor();

            try
            {
                if (profesor.Apellido != null)
                {
                }
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
                return;
            }

        }
    }
}
