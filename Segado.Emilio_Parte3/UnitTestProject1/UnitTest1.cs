using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio42_Library;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(UnaException))]
        public void TestConstructorNumero()
        {
            Numero a = new Numero(3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(MiExcepcion))]
        public void TestConstructorN2()
        {
            N2 a = new N2(2, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivide()
        {
            Numero.Divide(2, 0);
        }
    }
}
