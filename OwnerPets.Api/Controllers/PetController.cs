using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private IOptions<FileSettings> _options;

        public PetController(IConfiguration Configuration, IOptions<FileSettings> options)
        {
            _configuration = Configuration;
            _options = options;
        }

        [HttpGet]
        public ActionResult<PetsClassified> Get()
        {
            PetsService personBL = new PetsService(_options);

            PetsClassified petsClassified = personBL.GetPetsClassified();

            return petsClassified;
        }

        [HttpGet("{gender}")]
        public ActionResult<IEnumerable<string>> Get(string gender)
        {
            PetsService personBL = new PetsService(_options);

            var petsClassified = personBL.GetPetsByGender(gender);

            return petsClassified;
        }


    }
}
