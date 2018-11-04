using OwnerPets.Data;
using System.Collections.Generic;

namespace OwnerPets.Data
{
    public interface IFileReader
    {
        List<Person> GetPersonFromJsonFile(string filepath);
    }
}
