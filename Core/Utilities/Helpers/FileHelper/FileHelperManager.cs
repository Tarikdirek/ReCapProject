﻿using Core.Utilities.Helpers.GUIDHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) 
            { 
                File.Delete(filePath);
            
            }
        }

        public string Update(IFormFile file, string root, string filePath)
        {
            if (File.Exists(filePath)) 
            {
                File.Delete(filePath);
            }
            return Upload(file,root);
        }

        public string Upload(IFormFile file, string root)
        {
            string filePath = "";

            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension=Path.GetExtension(root);
                string guid = GuidHelper.CreateGuid();
                filePath = guid + extension;

                using (FileStream fileStream = File.Create(root+filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
