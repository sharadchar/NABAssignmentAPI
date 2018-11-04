using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OwnerPets.Services;

namespace OwnerPets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IConfiguration _configuration;
        private IPetsService _petService;

        public PetController(IConfiguration Configuration, IPetsService petService)
        {
            _configuration = Configuration;
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<PetsClassified> Get()
        {
            PetsClassified petsClassified = _petService.GetPetsClassified();

            if (petsClassified == null)
            {
                return NotFound();
            }

            return Ok(petsClassified);
        }

    }
}
