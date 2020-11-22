using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class TXTTest
    {
        [TestMethod]
        public void TestGuardadoCorrectoMateriaPrima()
        {
            try
            {
                MateriaPrima materiaPrima = new MateriaPrima(1, "Verde aromático", MateriaPrima.ETipo.Lúpulo, "Duende ebrio SA", (float)799.99, (float)0.150);
                Txt<MateriaPrima> archivoText = new Txt<MateriaPrima>();

                archivoText.Guardar("MateriaPrima.txt", materiaPrima);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }
    }
}
