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
        private DateTime TestDateTime = DateTime.Now;


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

        [Test]
        public void Benutzer_get_ValidUser()
        {
            //arrange
            var sut = new DocumentDetailViewModel(ValidUser, null);

            //act
            var result = sut.Benutzer.Clone();

            //assert
            Assert.That(result, Is.EqualTo(ValidUser));
        }

        [Test]
        public void IsRemoveFileEnabled_Return_True()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.IsRemoveFileEnabled = true;

            var result = sut.IsRemoveFileEnabled;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsTypItemSelectet_Return_ValidUser()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.SelectedTypItem = ValidUser;

            var result = sut.SelectedTypItem;

            Assert.That(result, Is.EqualTo(ValidUser));
        }

        [Test]
        public void GetBezeichnung_Return_ValidUser()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.Bezeichnung = ValidUser;

            var result = sut.Bezeichnung;

            Assert.That(result, Is.EqualTo(ValidUser));
        }

        [Test]
        public void GetStichwoerter_Return_ValidUser()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.Stichwoerter = ValidUser;

            var result = sut.Stichwoerter;

            Assert.That(result, Is.EqualTo(ValidUser));
        }

        [Test]
        public void ValutaDatum_Get_TestDateTime()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.ValutaDatum = TestDateTime;

            var result = sut.ValutaDatum;

            Assert.That(result, Is.EqualTo(TestDateTime));
        }
    }
}
