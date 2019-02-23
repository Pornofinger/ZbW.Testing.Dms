using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.IntegrationTests.Service
{
    [TestFixture]
    class DocumentServiceTests
    {
        [Test]
        public void CanFilterMetadata_HasValueBezeichnung_HasValue()
        {
            var documentSerice = new DocumentService();
            var metadataItem = A.Fake<MetadataItem>();
            documentSerice.MetadataItems = A.CollectionOfDummy<MetadataItem>(10).ToList();

            var type = documentSerice.MetadataItems[0].Type;
            var searchParam = documentSerice.MetadataItems[0].Bezeichnung;

            var result = documentSerice.FilterMetadataItems(type, searchParam);

            Assert.That(result, !Is.Empty);
        }

    }
}
