using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.IntegrationTests.Service
{
    [TestFixture]
    class FileServiceTests
    {
        private string Source_Path = "source_path";
        private string Target_Path = "target_path";

        [Test]
        public void CopyDocument_IsCallCorrect_CallsCopyCorrect()
        {
            var sutFileServcie = new FileService();
            var fileTestableMock = A.Fake<FileTestable>();
            sutFileServcie.FileTestable = fileTestableMock;

            sutFileServcie.CopyDocumentToTarge(Source_Path, Target_Path);

            A.CallTo(() => fileTestableMock.Copy(Source_Path, Target_Path, true)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CopyDocument_handleIOExceptionCorrect_ThrowException()
        {
            var sutFileService = new FileService();
            var fileTestableStub = A.Fake<FileTestable>();
            sutFileService.FileTestable = fileTestableStub;

            A.CallTo(() => fileTestableStub.Copy(A<string>.Ignored, A<string>.Ignored, A<Boolean>.Ignored))
                .Throws<IOException>();

            void TestDelegate() => sutFileService.CopyDocumentToTarge(Source_Path, Target_Path);

            Assert.That(TestDelegate, Throws.Exception.TypeOf<CouldNotCopyFileException>());
            Assert.That(TestDelegate, Throws.Exception.InnerException.TypeOf<IOException>());
            
        }


        [Test]
        public void CreateFolder_Create_True()
        {
            var sut = new FileService();
            var path = "C:/temp/test";

            sut.CreateValutaFolderIfNotExists(path);

            DirectoryAssert.Exists(path);
            Directory.Delete(path);
        }

        [Test]
        public void RemoveDocument_deleteDocument_true()
        {
            var sutFielService = new FileService();
            var path = "C:/temp/testfile.txt";

            File.Create(path).Dispose();
            sutFielService.RemoveDocumentOnSource(path);
            
            FileAssert.DoesNotExist(path);
        }
    }
}
