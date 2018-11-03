using Microsoft.Extensions.Options;
using OwnerPets.Data;
using OwnerPets.Repository;
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
        private string filePath;

        public PetsService(IOptions<FileSettings> filesettings )
        {
            IRepository repository = new PetsRepository();
            IPetsDataReader dataReader = new JsonFileReader(repository);

            _dataReader = dataReader;
            filePath = new FileService(filesettings).GetFilePath();
        }

        public List<Person> GetPetsData()
        {
            return _dataReader.GetData(filePath);
        }

        public PetsClassified GetPetsClassified()
        {
            var result = new PetsClassified();

            var data = GetPetsData();


            result.MalePets = data.Where(x => x.gender == GenderType.Male && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x => x).ToList();

            result.FemalePets = data.Where(x => x.gender == GenderType.Female && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x => x).ToList();

            return result;
        }

        public List<string> GetPetsByGender(string gender)
        {

            GenderType genderType = (GenderType)Enum.Parse(typeof(GenderType), gender, true);
            
            var data = GetPetsData();

            var result = data.Where(x => x.gender == genderType && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x=>x).ToList();

            return result;
        }
    }
}
