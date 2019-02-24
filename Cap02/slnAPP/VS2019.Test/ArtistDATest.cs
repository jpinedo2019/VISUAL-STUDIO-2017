using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VS2019.Entities;

namespace VS2019.Data.Test
{
    [TestClass]
    public class ArtistDaTest
    {
        [TestMethod]
        public void GetCount()
        {

            var da = new ArtistDA();
            var cantidad = da.GetCount();
            //Verifica si pasó la prueba. Muestra un check
            Assert.IsTrue(cantidad > 0);
        }

        [TestMethod]
        public void GetList()
        {

            var da = new ArtistDA();
            var listado = da.Gets();
            //Verifica si pasó la prueba. Muestra un check
            Assert.IsTrue(listado.Count()>0);
        }


        [TestMethod]
        public void GetLiGetsWithParam()
        {

            var da = new ArtistDA();
            var listado = da.GetsWithParam("%a");
            //Verifica si pasó la prueba. Muestra un check
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetLiGetsWithParamSP()
        {

            var da = new ArtistDA();
            var listado = da.GetsWithParamSP("%a");
            //Verifica si pasó la prueba. Muestra un check
            Assert.IsTrue(listado.Count() > 0);
        }

        

        [TestMethod]
        public void InsertArtist()
        {

            var da = new ArtistDA();
            var id = da.InsertArtist(new Artist() { Name="Prueba"});
            //Verifica si pasó la prueba. Muestra un check
            Assert.IsTrue(id > 0);
        }

    }
}
