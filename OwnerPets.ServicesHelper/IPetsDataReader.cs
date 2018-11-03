using OwnerPets.Data;
using System.Collections.Generic;

namespace OwnerPets.ServicesHelper
{
    public interface IPetsDataReader
    {
        List<Person> GetData(string filepath =  null); 
    }
}
