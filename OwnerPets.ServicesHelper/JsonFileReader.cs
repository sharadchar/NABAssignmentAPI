using OwnerPets.Data;
using OwnerPets.Repository;
using System.Collections.Generic;

namespace OwnerPets.ServicesHelper
{
    public class JsonFileReader : IPetsDataReader
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

            return (_repository as PetsRepository).GetPersonFromJsonFile(filepath);
        }
    }
}
