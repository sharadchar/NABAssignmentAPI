using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace OwnerPets.Data
{
    public class JsonFileReader : IFileReader
    {

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;

        public JsonFileReader(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger("Logger");
        }
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
                _logger.Log(LogLevel.Critical, ex, "Error happened while reading Json file", null);
            }
            return null;
        }
    }
}
