using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    class FileTestable
    {
        public virtual void Copy(string sourceFileName, string destFileName, Boolean overwrite)
        {
            File.Copy(sourceFileName, destFileName, true);

        }
    }
}
