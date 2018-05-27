using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassesCentralita;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarLista()
        {
            //Arrange
            Centralita centralita1 = new Centralita("ABC");
            Assert.IsNotNull(centralita1._listaDeLlamadas);
        }

        [TestMethod]
        public void ValidarCentralitaExceptionLocal()
        {
            //Arrange
            Centralita centralita1 = new Centralita("ABC");
            Local llamada1 = new Local("A", "B", 1, 2);
            Local llamada2 = new Local("A", "B", 2, 3);

            //Act
            centralita1 += llamada1;
            try { centralita1 += llamada2; }
            catch (CentralitaException e)
            { }
        }

        [TestMethod]
        public void ValidarCentralitaExceptionProvincial()
        {
            //Arrange
            Centralita centralita2 = new Centralita("ABC");
            Provincial llamada1 = new Provincial("A", "B", 1, EFranja.Franja_2);
            Provincial llamada2 = new Provincial("A", "B", 2, EFranja.Franja_3);

            //Act
            centralita2 += llamada1;

            try { centralita2 += llamada2; }
            catch (CentralitaException e)
            { }
        }

        [TestMethod]
        public void ValidarDobleLlamada()
        {
            Provincial llamada1 = new Provincial("A", "B", 1, EFranja.Franja_2);
            Provincial llamada2 = new Provincial("A", "B", 2, EFranja.Franja_3);
            Local llamada3 = new Local("A", "B", 1, 2);
            Local llamada4 = new Local("A", "B", 2, 3);

            if (llamada1 != llamada2)
            { Assert.Fail(); }
            if (llamada3 != llamada4)
            { Assert.Fail(); }

            if (llamada1 == llamada3 || llamada1 == llamada4)
            { Assert.Fail(); }

            if (llamada2 == llamada3 || llamada2 == llamada4)
            { Assert.Fail(); }
        }
    }
}
