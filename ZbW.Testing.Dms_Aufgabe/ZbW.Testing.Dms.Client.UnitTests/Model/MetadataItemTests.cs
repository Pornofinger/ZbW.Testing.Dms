using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.UnitTests.Model
{
    [TestFixture]
    public class MetadataItemTests
    {
        private string TestingText = "Test Something";
        private DateTime TestDateTime = DateTime.Now ;


        [Test]
        public void GetBezeichnung_Return_TestingText()
        {
            var sut = new MetadataItem();
            sut.Bezeichnung = TestingText;
            
            var result = sut.Bezeichnung;

            Assert.That(result, Is.EqualTo(TestingText));
        }

        [Test]
        public void GetBenutzer_GetSet_TestingText()
        {
            var sut = new MetadataItem();
            sut.Benutzer = TestingText;

            var result = sut.Benutzer;

            Assert.That(result, Is.EqualTo(TestingText));
        }

        [Test]
        public void GetFilePath_GetSet_TestingText()
        {
            var sut = new MetadataItem();
            sut.FilePath = TestingText;

            var result = sut.FilePath;

            Assert.That(result, Is.EqualTo(TestingText));
        }

        [Test]
        public void SetIsRemoveFileEnabled_Get_True()
        {
            var sut = new MetadataItem();

            sut.IsRemoveFileEnabled = true;

            Assert.IsTrue(sut.IsRemoveFileEnabled);
        }

        [Test]
        public void SetType_Get_TestingText()
        {
            var sut = new MetadataItem();
            sut.Type = TestingText;

            var result = sut.Type;

            Assert.That(result, Is.EqualTo(TestingText));
        }

        [Test]
        public void Erfassungsdatum_Get_TestDateTime()
        {
            var sut = new MetadataItem();
            sut.Erfassungsdatum = TestDateTime;

            var result = sut.Erfassungsdatum;

            Assert.That(result, Is.EqualTo(TestDateTime));
        }

        [Test]
        public void ValutaDatum_Get_TestDateTime()
        {
            var sut = new MetadataItem();
            sut.ValutaDatum = TestDateTime;

            var result = sut.ValutaDatum;

            Assert.That(result, Is.EqualTo(TestDateTime));
        }

        [Test]
        public void SetStichwoerter_Get_TestingText()
        {
            var sut = new MetadataItem();
            sut.Stichwoerter = TestingText;

            var result = sut.Stichwoerter;
            
            Assert.That(result, Is.EqualTo(TestingText));
        }

    }
}