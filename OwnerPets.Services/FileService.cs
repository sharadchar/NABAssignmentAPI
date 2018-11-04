using Microsoft.Extensions.Options;
using OwnerPets.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPets.Services
{
    public class FileService : IFileService
    {

        private readonly IOptions<FileSettings> _fileSettings;

        public FileService(IOptions<FileSettings> fileSettings)
        {
            _fileSettings = fileSettings;
        }

        public string GetFilePath()
        {
            return _fileSettings.Value.FilePath;
        }
    }
}
