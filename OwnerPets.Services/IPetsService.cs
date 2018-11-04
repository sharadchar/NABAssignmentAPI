using System.Collections.Generic;
using OwnerPets.Data;

namespace OwnerPets.Services
{
    public interface IPetsService
    {
        PetsClassified GetPetsClassified();
    }
}