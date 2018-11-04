using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace OwnerPets.Data
{
    public class JsonFileReader : IFileReader
    {
        /// <summary>
        /// This method reads the person information from Json file and returns a list of person
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>Returns a list of persons</returns>
        public List<Person> GetPersonFromJsonFile(string filepath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filepath)) return null;

                var res = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(filepath));

                return res;
            }
            catch (Exception ex)
            {
                //Log error here
            }
            return null;
        }
    }
}
