using NABAssignmentModels;
using NABAssignmentServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NABAssignmentBL
{
    public class PersonBL
    {
        private IDataReader _dataReader;

        public PersonBL(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public List<Person> GetPerson(string filepath)
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
