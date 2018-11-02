using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NABAssignmentBL;
using NABAssignmentModels;
using NABAssignmentRepository;
using NABAssignmentServices;
using System.Collections.Generic;

namespace NABAssignmentAPI.Controllers
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

            IRepository repository = new PersonRepository();
            IDataReader dataReader = new JsonFileReader(repository);
            PersonBL personBL = new PersonBL(dataReader);

            PetsClassified petsClassified = personBL.GetPetsClassified(filepath);

            return petsClassified;
        }

        [HttpGet("{gender}")]
        public ActionResult<IEnumerable<string>> Get(string gender)
        {
            string filepath = _configuration["PetsFilePath"].ToString();

            IRepository repository = new PersonRepository();
            IDataReader dataReader = new JsonFileReader(repository);
            PersonBL personBL = new PersonBL(dataReader);

            var petsClassified = personBL.GetPetsByGender(filepath,gender);

            return petsClassified;
        }


    }
}
