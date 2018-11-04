using Microsoft.Extensions.Options;
using OwnerPets.Data;
using OwnerPets.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OwnerPets.Services
{
    public class PetsService : IPetsService
    {
        private IPetsRepository _repository;
        private IOptions<FileSettings> _filesettings;
        private string filePath;

        public PetsService(IOptions<FileSettings> filesettings, IPetsRepository repository)
        {
            _repository = repository;
            _filesettings = filesettings;
        }

        private List<Person> GetPetsData()
        {
            filePath = new FileService(_filesettings).GetFilePath();
            
            var data = _repository.GetData(filePath);

            if (data == null) return null;

            return data;
        }

        public PetsClassified GetPetsClassified()
        {
            var result = new PetsClassified();

            var data = GetPetsData();

            if (data == null) return null;

            result.MalePets = data.Where(x => x.gender == GenderType.Male && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x => x).ToList();

            result.FemalePets = data.Where(x => x.gender == GenderType.Female && x.pets != null).SelectMany(x => x.pets).Where(y => y.type == PetType.Cat).Select(y => y.name).OrderBy(x => x).ToList();

            return result;
        }

      
    }
}
