using System;

using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        private const string VALID_USER = "a";

        private const string INVALID_USER = "";


        [Test]
        public void Enable_Login_LoginView()
        {
            // arrange
            var sut = new LoginViewModel(null);

            //act
            sut.Benutzername = VALID_USER;
            var result = sut.CmdLogin.CanExecute();

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Cant_Login_LoginView()
        {
            //arrange
            var sut = new LoginViewModel(null);

            //act
            sut.Benutzername = INVALID_USER;
            var result = sut.CmdLogin.CanExecute();

            //assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CheckUserName_Login_LoginView()
        {
            //arrange
            var sut = new LoginViewModel(null);

            //act
            sut.Benutzername = VALID_USER;
            var result = sut.Benutzername;

            //assert
            Assert.That(result, Is.EqualTo(VALID_USER));
        }

        [Test]
        public void LoginViewModel_LoginAbbruch_False()
        {
            // arrange
            var sut = new LoginViewModel(null);

            //act
            var result = sut.CmdAbbrechen.CanExecute();

            //assert
            Assert.That(result, Is.True);
        }
    }
}
