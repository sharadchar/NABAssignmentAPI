using Newtonsoft.Json;
using OwnerPets.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace OwnerPets.Repository
{
    public class PetsRepository : IPetsRepository
    {
        IFileReader _fileReader;

        public PetsRepository(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        /// <summary>
        /// This methood will read the person data from Json file
        /// </summary>
        /// <returns>return a list of person</returns>
        public List<Person> GetData(string filepath = null)
        {
            if (string.IsNullOrWhiteSpace(filepath)) return new List<Person>();

            var result = _fileReader.GetPersonFromJsonFile(filepath);

            if (result == null) return null;
            return result;
        }
    }
}
