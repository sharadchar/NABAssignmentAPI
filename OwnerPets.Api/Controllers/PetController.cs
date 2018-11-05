using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OwnerPets.Services;

namespace OwnerPets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetsService _petService;

        public PetController(IPetsService petService)
        {
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
