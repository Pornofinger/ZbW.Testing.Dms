using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class DocumentService : BindableBase
    {
        private static string FILE_TYPE_NAME = "Content";
        private static string METASATA_TYPE_NAME = "Metadata";

        private string _targePath;

        private List<MetadataItem> _metadataItems;

        private FileService _fileService;
        private XmlService _xmlService;

        public DocumentService()
        {
            _targePath = ConfigurationManager.AppSettings["RepositoryDir"];
            _fileService = new FileService();
            _xmlService = new XmlService();
        }

        public List<MetadataItem> MetadataItems
        {
            get => _metadataItems;

            set => SetProperty(ref _metadataItems, value);
        }

        public void AddDocumentToDms(MetadataItem metadataItem)
        {
            var targetPath = _targePath + "/" + metadataItem.ValutaDatum.Year;
            var guid = Guid.NewGuid();
            var newFileName = _fileService.GetNewFileName(FILE_TYPE_NAME, metadataItem.FilePath, guid);
            var sourcePath = metadataItem.FilePath;
            metadataItem.FilePath = targetPath + "/" + newFileName; ;
            _fileService.CreateValutaFolderIfNotExists(targetPath);

            HandelDocument(metadataItem, sourcePath, guid);
            HandelMetadata(metadataItem, targetPath, guid);
        }

        public void openFile(MetadataItem metadataItem)
        {
            Process.Start(metadataItem.FilePath);
        }

        private void HandelDocument(MetadataItem metadataItem, string sourcePath, Guid guid)
        {
            var targetPath = metadataItem.FilePath;
            // Es wird kein new FileTestable mehr benötigt --> standard wird im Konstruktor vom FileService gesetzt
            _fileService.CopyDocumentToTarge(sourcePath, targetPath);

            if (metadataItem.IsRemoveFileEnabled) _fileService.RemoveDocumentOnSource(metadataItem.FilePath);
        }


        private void HandelMetadata(MetadataItem metadataItem, string targetPath, Guid guid)
        {
            var newFileName = _fileService.GetNewFileName(METASATA_TYPE_NAME, ".xml", guid);
            var newFilePath = targetPath + "/" + newFileName;

            var serializeXml = _xmlService.SeralizeMetadataItem(metadataItem);
            _xmlService.SaveXml(serializeXml, newFilePath);
        }

        public List<MetadataItem> GetAllMetadataItems()
        {
            var folderPaths = GetAllFolderPaths(_targePath);
            var xmlPathsFromAllFoders = new ArrayList();
            var metadataItemList = new ArrayList();

            foreach (var folderPath in folderPaths)
            {
                var xmlPathsFromOneFolder = GetAllXmlPaths(folderPath);
                xmlPathsFromAllFoders.AddRange(xmlPathsFromOneFolder);
            }

            foreach (var xmlPath in xmlPathsFromAllFoders) metadataItemList.Add(_xmlService.DeseralizeMetadataItem((string)xmlPath));

            MetadataItems = metadataItemList.Cast<MetadataItem>().ToList();
            return MetadataItems;
        }

        public List<MetadataItem> FilterMetadataItems(string type, string searchParam)
        {
            if (string.IsNullOrEmpty(searchParam) && string.IsNullOrEmpty(type)) return MetadataItems;

            if (string.IsNullOrEmpty(searchParam)) searchParam = "";

            var filteredItems = MetadataItems.Where(item =>
            {
                return (item.Bezeichnung.Contains(searchParam) ||
                        item.Stichwoerter.Contains(searchParam) ||
                        item.Erfassungsdatum.ToString().Contains(searchParam) ||
                        item.ValutaDatum.ToString().Contains(searchParam)) &&
                       (string.IsNullOrEmpty(type) || item.Type.Equals(type));
            }).ToList();

            return filteredItems;
        }

        private string[] GetAllFolderPaths(string targetPath)
        {
            return Directory.GetDirectories(targetPath);
        }

        private ArrayList GetAllXmlPaths(string folderPath)
        {
            var xmlPaths = new ArrayList();
            foreach (var file in Directory.EnumerateFiles(folderPath, "*.xml")) xmlPaths.Add(file);

            return xmlPaths;
        }
    }
}