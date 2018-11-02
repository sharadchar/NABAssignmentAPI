using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NABAssignmentBL;
using NABAssignmentModels;
using NABAssignmentRepository;
using NABAssignmentServices;

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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            string filepath = _configuration["PetsFilePath"].ToString();

            IRepository repository = new PersonRepository();
            IDataReader dataReader = new JsonFileReader(repository);
            PersonBL personBL = new PersonBL(dataReader);

            List<Person> personWithPets  =  personBL.GetPerson(filepath);

            return personWithPets;            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }        
    }
}
