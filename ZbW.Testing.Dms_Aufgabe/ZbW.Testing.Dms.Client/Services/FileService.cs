using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FileService
    {
        // Property ist von aussen nicht lesbar 
        public FileTestable FileTestable { private get; set; }

        public void CreateValutaFolderIfNotExists(string path)
        {
            Directory.CreateDirectory(path);
        }
        
        // Ein Standart für Property Injection wird im Konstruktor gesetzt
        public FileService()
        {
            FileTestable = new FileTestable();
        }

        public void RemoveDocumentOnSource(string path)
        {
            File.Delete(path);
        }

        public void CopyDocumentToTarge(string sourcePath, string targetPath)
        {
            try
            {
                FileTestable.Copy(sourcePath, targetPath, true);
            }
            catch (Exception e)
            {
                throw new CouldNotCopyFileException(" File konnte nicht kopiert werden", e);
            }
        }

        public string GetNewFileName(string typeName, string fileName, Guid guid)
        {
            var fileExtension = GetFileExtension(fileName);
            return $"{guid}_{typeName}.{fileExtension}";
        }

        public string GetFileExtension(string fileName)
        {
            var splittedByPoint = fileName.Split('.');
            return splittedByPoint[splittedByPoint.Length - 1];
        }

    }
}