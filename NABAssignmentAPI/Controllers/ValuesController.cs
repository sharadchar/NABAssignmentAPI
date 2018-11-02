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
    public class ValuesController : ControllerBase
    {
        private IConfiguration _configuration;

        public ValuesController(IConfiguration Configuration)
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

            //return new Person[] {
            //    new Person
            //    {
            //        Age=21,
            //        GenderType=GenderType.Female,
            //        Name="Simmi",
            //        Pets=new List<Pet>
            //        {
            //            new Pet
            //            {
            //                Name="tom",
            //                PetType=PetType.Dog
            //            }
            //        }
            //    }
            //};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
