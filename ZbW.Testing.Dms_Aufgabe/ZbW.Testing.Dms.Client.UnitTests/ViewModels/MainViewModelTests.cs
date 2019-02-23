using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels
{
    [TestFixture]
    class MainViewModelTests
    {
        private const string ValidUser = "hansdampf";

        [Test]
        public void MainViewModel_getBenutezr_ValidUser()
        {
            //arrange
            var sut = new MainViewModel( ValidUser);

            //act
            var result = sut.Benutzer;

            //assert
            Assert.That(result, Is.EqualTo(ValidUser));
        }



    }
}
