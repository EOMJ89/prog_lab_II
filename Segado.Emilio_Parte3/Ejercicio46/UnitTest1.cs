using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio36_Library;

namespace Ejercicio46
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListaInstanciada()
        {
            Competencia a = new Competencia(2, 3, Competencia.TipoCompetencia.Motos);

            Assert.IsNotNull(a.Competidores);
        }

        [TestMethod]
        public void AutoEnMoto()
        {
            Competencia ab = new Competencia(2, 3, Competencia.TipoCompetencia.Motos);
            AutoF1 auto1 = new AutoF1(2, "Ferrari");

            try
            {
                bool resultado = ab + auto1;
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestMotoEnAuto()
        {
            Competencia ac = new Competencia(2, 3, Competencia.TipoCompetencia.F1);
            MotoCross moto1 = new MotoCross(2, "Honda");

            try
            {
                bool resultado = ac + moto1;
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (Exception) { }

        }

        [TestMethod]
        public void AgregarYEstar()
        {
            Competencia ac = new Competencia(2, 3, Competencia.TipoCompetencia.Motos);
            MotoCross moto1 = new MotoCross(2, "Honda");

            bool resultado = ac + moto1;
            if (ac != moto1)
            { Assert.Fail(); }
        }

        [TestMethod]
        public void QuitarYNoEstar()
        {
            Competencia ac = new Competencia(2, 3, Competencia.TipoCompetencia.Motos);
            MotoCross moto1 = new MotoCross(2, "Honda");

            bool resultado = ac + moto1;
            resultado = ac - moto1;

            if (ac == moto1)
            { Assert.Fail(); }
        }
    }
}