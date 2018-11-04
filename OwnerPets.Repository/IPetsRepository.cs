using System.Collections.Generic;
using OwnerPets.Data;

namespace OwnerPets.Repository
{
    public interface IPetsRepository
    {
        List<Person> GetData(string filepath = null);

    }
}