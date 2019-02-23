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

namespace ZbW.Testing.Dms.Client.UnitTests.Service
{
    [TestFixture]
    class FileServiceTests
    {

        [Test]
        public void NewFileNameContent_Generate_ReturnsValidFileName()
        {
            var sutFileService = new FileService();
            var fileExtension = "TestExtension";
            var fileName = "TestFile";
            var guid = new Guid("3e911311-f1de-4279-9fed-a8a1a270845c");

            var result = sutFileService.GetNewFileName(fileName, fileExtension, guid);

            Assert.That(result, Is.EqualTo($"{guid}_{fileName}.{fileExtension}"));
        }
    }
}
