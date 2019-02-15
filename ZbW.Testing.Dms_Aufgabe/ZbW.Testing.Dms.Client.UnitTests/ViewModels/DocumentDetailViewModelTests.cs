using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;


namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels
{
    [TestFixture]
    class DocumentDetailViewModelTests
    {
        private const string ValidUser = "hansdampf";
        [Test]
        public void DDVM_CmdSpeichern_true()
        {
            //arrange
            var sut = new DocumentDetailViewModel(ValidUser, null);

            //act
            var result = sut.CmdSpeichern.CanExecute();

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DDVM_CMDDurchsuchen_true()
        {
            //arrange
            var sut = new DocumentDetailViewModel(ValidUser, null);

            //act
            var result = sut.CmdDurchsuchen.CanExecute();

            //assert
            Assert.That(result, Is.True);
        }

    }
}
