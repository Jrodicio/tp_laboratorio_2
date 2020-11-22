using System;
using Archivos;
using Entidades;
using Excepciones;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class XMLTest
    {
        [TestMethod]
        public void TestGuardadoCorrectoMateriaPrima()
        {
            try
            {
                MateriaPrima materiaPrima = new MateriaPrima(1, "Verde aromático", MateriaPrima.ETipo.Lúpulo, "Duende ebrio SA", (float)799.99, (float)0.150);
                Producto producto;

                Xml<MateriaPrima> serializador = new Xml<MateriaPrima>();

                serializador.Guardar("MateriaPrima.xml", materiaPrima);
                serializador.Leer("MateriaPrima.xml", out producto);

                Assert.IsTrue( materiaPrima.IdProducto == producto.IdProducto
                            && materiaPrima.Descripcion == producto.Descripcion
                            && materiaPrima.Tipo == ((MateriaPrima) producto).Tipo
                            && materiaPrima.Marca == producto.Marca
                            && materiaPrima.Precio == producto.Precio
                            && materiaPrima.PesoKG == ((MateriaPrima) producto).PesoKG);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
            
        }

        [TestMethod]
        public void TestGuardadoCorrectoBarril()
        {
            try
            {
                
                Barril barril = new Barril(2, "Metalico autorefrigerante 50Lts", "Duende ebrio SA", (float)25999.99, Barril.ETamaño.Grande);
                Producto producto;

                Xml<Barril> serializador = new Xml<Barril>();
                serializador.Guardar("Barril.xml", barril);
                serializador.Leer("Barril.xml", out producto);

                Assert.IsTrue( barril.IdProducto == producto.IdProducto
                            && barril.Descripcion == producto.Descripcion
                            && barril.Marca == producto.Marca
                            && barril.Precio == producto.Precio
                            && barril.Tamaño == ((Barril) producto).Tamaño);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

       
    }
}




