using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{

        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void ChequearLista()
            {
                Correo nuevo = new Correo();
                Assert.IsNotNull(nuevo.Paquetes);
            }

            [TestMethod]
            public void CargaTrackingID()
            {
                Correo correo1 = new Correo();
                Paquete p1 = new Paquete("aux1@gmail.com", "0000000000");
                Paquete p2 = new Paquete("aux2@gmail.com", "0000000000");
                try
                {
                    correo1 += p1;
                    correo1 += p2;
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
                }
            }
        
    }
}
