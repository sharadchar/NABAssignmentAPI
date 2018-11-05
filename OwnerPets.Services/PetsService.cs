using Microsoft.Extensions.Options;
using OwnerPets.Common;
using OwnerPets.Data;
using OwnerPets.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OwnerPets.Services
{
    public class PetsService : IPetsService
    {
        private IPetsRepository _repository;
        //private IOptions<FileSettings> _filesettings;
        private IFileService _fileservice;
        private string filePath;

        public PetsService(IFileService fileservice, IPetsRepository repository)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        private List<Person> GetPetsData()
        {
            filePath = _fileservice.GetFilePath();
            
            var data = _repository.GetData(filePath);

            if (data == null) return null;

            return data;
        }

        public PetsClassified GetPetsClassified()
        {
            var result = new PetsClassified();

            var data = GetPetsData();

            if (data == null) return null;

            var malePets = data.Where(x => x.gender == GenderType.Male && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x => x).ToList();
            if (!malePets.IsNullOrEmpty())
            {
                result.MalePets = malePets;
            }

            var femalePets = data.Where(x => x.gender == GenderType.Female && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x => x).ToList();

            if (!femalePets.IsNullOrEmpty())
            {
                result.FemalePets = femalePets;
            }
            return result;
        }

      
    }
}
