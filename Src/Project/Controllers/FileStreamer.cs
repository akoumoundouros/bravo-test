using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Project.Controllers
{
    public class FileStreamer : Controller
    {
        private string _dir;
        public FileStreamer()
        {
            _dir = Directory.GetCurrentDirectory() + @"\wwwroot";
        }

        /// <summary>
        /// Takes a path relative to wwwroot, and returns the file.
        /// Throws a file not found exception if the file doesn't exist.
        /// </summary>
        public FileResult Index (string id)
        {
            var path = _dir + id;
            if (!new FileInfo(path).Exists)
                throw new FileNotFoundException();
            string type = "";
            new FileExtensionContentTypeProvider().TryGetContentType(path, out type);
            return new PhysicalFileResult(path, type);
        }
    }
}
