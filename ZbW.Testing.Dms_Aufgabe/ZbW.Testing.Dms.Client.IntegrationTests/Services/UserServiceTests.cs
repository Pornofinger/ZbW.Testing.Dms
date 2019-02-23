using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.IntegrationTests.Service
{
    [TestFixture]
    class UserServiceTests
    {
        private string ValidUser = "hansdampf";

        [Test]
        public void SaveUser_SetUser_SetUserCorrect()
        {
            var sutUserService = new UserService();
            var userTestableMock = A.Fake<UserTestable>();
            sutUserService.UserTestable = userTestableMock;

            sutUserService.SaveUsername(ValidUser);

            A.CallTo(() => userTestableMock.SetCurrentUsersernme(ValidUser));
            A.CallTo(() => userTestableMock.SaveSettings()).DoesNothing();

        }

        [Test]
        public void SaveUser_handleException_ThrowException()
        {
            var sutUserService = new UserService();
            var userTestableStub = A.Fake<UserTestable>();
            sutUserService.UserTestable = userTestableStub;

            A.CallTo(() => userTestableStub.SetCurrentUsersernme(A<string>.Ignored)).Throws<Exception>();

            void TestDelegate() => sutUserService.SaveUsername(null);

            Assert.That(TestDelegate, Throws.Exception.TypeOf<Exception>());
        }

        [Test]
        public void GetUser_returnUser_ValidUser()
        {
            var sutUserService = new UserService();
            var userTestableMock = A.Fake<UserTestable>();
            sutUserService.UserTestable = userTestableMock;
            sutUserService.SaveUsername(ValidUser);

            var result = sutUserService.GetUsername();

            Assert.That(result, Is.EqualTo(ValidUser));
        }

        [Test]
        public void RemoveUser_setUser_null()
        {
            var sutUserService = new UserService();
            var userTestableMock = A.Fake<UserTestable>();
            sutUserService.UserTestable = userTestableMock;
            sutUserService.SaveUsername(ValidUser);

            sutUserService.RemoveUserName();
            var result = sutUserService.GetUsername();

            Assert.That(result, Is.Empty);
        }
    }
}
