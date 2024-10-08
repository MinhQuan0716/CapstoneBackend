﻿using Application.InterfaceService;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            string fileName=file.FileName;
            if (file.Length == 0)
            {
                throw new Exception("File is empty");
            }
           var storage = new FirebaseStorage("firestorage-4ee45.appspot.com")
                             .Child(fileName);
            await storage.PutAsync(file.OpenReadStream());
            var dowloadUrl = await storage.GetDownloadUrlAsync();
            return dowloadUrl;
        }
    }
}
