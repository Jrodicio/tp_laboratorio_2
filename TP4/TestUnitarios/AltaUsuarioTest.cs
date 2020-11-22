using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class AltaUsuarioTest
    {
        /// <summary>
        /// Se testea la creacion de un usuario con nombre inválido
        /// </summary>
        [TestMethod]
        public void TestCreacionErroneaUsuario()
        {
            try
            {
                Usuario usuario = new Usuario("alijo.de arte!$#", "123456789");
            }
            catch(UsuarioInvalidoException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Se testea la creacion de un usuario con nombre inválido
        /// </summary>
        [TestMethod]
        public void TestCreacionUsuarioCorrecto()
        {
            try
            {
                Usuario usuario = new Usuario("astersproun", "password123");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}

