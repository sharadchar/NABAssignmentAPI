
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwnerPets.Api.Controllers;
using OwnerPets.Services;
using System.Collections.Generic;

namespace OwnerPets.Test
{
    [TestClass]
    public class OwnerPets_APITest
    {
        [TestMethod]
        public void Get_RecieveNullTest()
        {
            Mock petservicMock = new Mock<IPetsService>();
            petservicMock.As<IPetsService>().Setup(x => x.GetPetsClassified()).Returns<PetsClassified>(null);

            PetController controller = new PetController(petservicMock.Object as IPetsService);

            var result = controller.Get();

            Assert.IsTrue(((Microsoft.AspNetCore.Mvc.StatusCodeResult)result.Result).StatusCode == 404);

        }

        [TestMethod]
        public void Get_RecieveDataTest()
        {
            PetsClassified objPetsClassified = new PetsClassified
            {
                MalePets = new List<string> { "ABC", "DEF" },
                FemalePets = new List<string> { "ABC1", "DEF1", "GHI1" },
            };

            Mock petservicMock = new Mock<IPetsService>();
            petservicMock.As<IPetsService>().Setup(x => x.GetPetsClassified()).Returns(objPetsClassified);

            PetController controller = new PetController(petservicMock.Object as IPetsService);

            var result = controller.Get();

            Assert.IsTrue(((OwnerPets.Services.PetsClassified)((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value).FemalePets.Count == 3);

        }
    }
}
 