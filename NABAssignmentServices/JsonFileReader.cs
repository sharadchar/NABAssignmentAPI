using System;
using System.Collections.Generic;
using System.Text;
using NABAssignmentModels;
using NABAssignmentRepository;

namespace NABAssignmentServices
{
    public class JsonFileReader : IDataReader
    {
        IRepository _repository;

        public JsonFileReader(IRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// This methood will read the person data from Json file
        /// </summary>
        /// <returns>return a list of person</returns>
        public List<Person> GetData(string filepath = null)
        {
            if (string.IsNullOrWhiteSpace(filepath)) return new List<Person>();

            return (_repository as PersonRepository).GetPersonFromJsonFile(filepath);
        }
    }
}
