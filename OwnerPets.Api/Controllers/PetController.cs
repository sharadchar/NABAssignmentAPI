using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OwnerPets.Data;
using OwnerPets.Repository;
using OwnerPets.Services;
using OwnerPets.ServicesHelper;
using System.Collections.Generic;

namespace OwnerPets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IConfiguration _configuration;

        public PetController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        [HttpGet]
        public ActionResult<PetsClassified> Get()
        {
            string filepath = _configuration["PetsFilePath"].ToString();

            IRepository repository = new PetsRepository();
            IPetsDataReader dataReader = new JsonFileReader(repository);
            PetsService personBL = new PetsService(dataReader);

            PetsClassified petsClassified = personBL.GetPetsClassified(filepath);

            return petsClassified;
        }

        [HttpGet("{gender}")]
        public ActionResult<IEnumerable<string>> Get(string gender)
        {
            string filepath = _configuration["PetsFilePath"].ToString();

            IRepository repository = new PetsRepository();
            IPetsDataReader dataReader = new JsonFileReader(repository);
            PetsService personBL = new PetsService(dataReader);

            var petsClassified = personBL.GetPetsByGender(filepath,gender);

            return petsClassified;
        }


    }
}
