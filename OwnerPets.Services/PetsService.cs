using OwnerPets.Data;
using OwnerPets.ServicesHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OwnerPets.Services
{
    public class PetsService
    {
        private IPetsDataReader _dataReader;

        public PetsService(IPetsDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public List<Person> GetPetsData(string filepath)
        {
            return _dataReader.GetData(filepath);
        }

        public PetsClassified GetPetsClassified(string filepath)
        {
            var result = new PetsClassified();

            var data =  _dataReader.GetData(filepath);


            result.MalePets = data.Where(x => x.gender == GenderType.Male && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).ToList();

            result.FemalePets = data.Where(x => x.gender == GenderType.Female && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).ToList();

            return result;
        }

        public List<string> GetPetsByGender(string filepath, string gender)
        {

            GenderType genderType = (GenderType)Enum.Parse(typeof(GenderType), gender, true);
            
            var data = _dataReader.GetData(filepath);

            var result = data.Where(x => x.gender == genderType && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).ToList();

            return result;
        }
    }
}
