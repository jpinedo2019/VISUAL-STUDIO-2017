﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumaEsOK()
        {
            //Podemos hacer pruebas unitarias a la capa de datos, controllers(MVC)

            Assert.IsTrue(4 + 5 == 9);
        }
    }
}
