using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;

namespace TestArchivoNotFound
{
    [TestClass]
    public class TestArchivos
    {
        [TestMethod]
        public void TextoCorrecto()
        {
            Texto txt1 = new Texto();
            Assert.IsNotNull(txt1);
            bool rta = txt1.Guardar("Test.txt", "Esto es una prueba");
            Assert.IsTrue(rta);
            try
            {
                string datoErroneo = null;
                rta = txt1.Guardar("Test.txt", datoErroneo);

            }
            catch (Exception e) 
            {
                //No puedo agarrar esta excepcion
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }

        }
    }
}
