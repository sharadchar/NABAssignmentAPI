using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwnerPets.Data;
using OwnerPets.Repository;
using OwnerPets.Services;

namespace OwnerPets.Test
{
    [TestClass]
    public class PetsServiceTest
    {
        [TestMethod]
        public void GetPetsClassified_NullDataTest()
        {
            Mock fileServiceMock = new Mock<IFileService>(MockBehavior.Default);
            fileServiceMock.As<IFileService>().Setup(x => x.GetFilePath()).Returns("ABC");

            Mock repositoryMock = new Mock<IPetsRepository>();
            repositoryMock.As<IPetsRepository>().Setup(x => x.GetData(It.IsAny<string>())).Returns<PetsClassified>(null);

            PetsService petservice = new PetsService(fileServiceMock.Object as IFileService, repositoryMock.Object as IPetsRepository);

            var result =petservice.GetPetsClassified();

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetPetsClassified_DataRecievedTest()
        {
            List<Person> personDataObj = new List<Person>
            {
                new Person
                {
                    age=27, gender=GenderType.Male, name="A1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="AP1", type=PetType.Cat
                        }
                    }
                },
                new Person
                {
                    age=27, gender=GenderType.Male, name="B1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="BP2", type=PetType.Cat
                        },
                        new Pet
                        {
                            name="BP1", type=PetType.Dog
                        }
                    }
                },                
                new Person
                {
                    age=27, gender=GenderType.Male, name="C1",
                    pets=null
                },
                 new Person
                {
                    age=27, gender=GenderType.Female, name="FA1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="FAP4", type=PetType.Cat
                        },
                        new Pet
                        {
                            name="FAP2", type=PetType.Dog
                        },
                        new Pet
                        {
                            name="FAP1", type=PetType.Cat
                        }
                        ,
                        new Pet
                        {
                            name="FAP3", type=PetType.Fish
                        }
                    }
                },
                 new Person
                {
                    age=27, gender=GenderType.Female, name="FB1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="FBP1", type=PetType.Fish
                        },
                        new Pet
                        {
                            name="FBP2", type=PetType.Dog
                        }
                        ,
                        new Pet
                        {
                            name="FBP3", type=PetType.Cat
                        }
                    }
                }
            };

            Mock fileServiceMock = new Mock<IFileService>(MockBehavior.Default);
            fileServiceMock.As<IFileService>().Setup(x => x.GetFilePath()).Returns("ABC");

            Mock repositoryMock = new Mock<IPetsRepository>();
            repositoryMock.As<IPetsRepository>().Setup(x => x.GetData(It.IsAny<string>())).Returns(personDataObj);

            PetsService petservice = new PetsService(fileServiceMock.Object as IFileService, repositoryMock.Object as IPetsRepository);

            var result = petservice.GetPetsClassified();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.MalePets.Count == 2);
            Assert.IsTrue(result.FemalePets.Count == 3);

        }

        [TestMethod]
        public void GetPetsClassified_NoMalePetTest()
        {
            List<Person> personDataObj = new List<Person>
            {
                new Person
                {
                    age=27, gender=GenderType.Female, name="A1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="AP1", type=PetType.Cat
                        }
                    }
                },
                new Person
                {
                    age=27, gender=GenderType.Female, name="B1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="BP2", type=PetType.Cat
                        },
                        new Pet
                        {
                            name="BP1", type=PetType.Dog
                        }
                    }
                },
                new Person
                {
                    age=27, gender=GenderType.Female, name="C1",
                    pets=null
                },
                 new Person
                {
                    age=27, gender=GenderType.Female, name="FA1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="FAP4", type=PetType.Cat
                        },
                        new Pet
                        {
                            name="FAP2", type=PetType.Dog
                        },
                        new Pet
                        {
                            name="FAP1", type=PetType.Cat
                        }
                        ,
                        new Pet
                        {
                            name="FAP3", type=PetType.Fish
                        }
                    }
                },
                 new Person
                {
                    age=27, gender=GenderType.Female, name="FB1",
                    pets=new List<Pet>
                    {
                        new Pet
                        {
                            name="FBP1", type=PetType.Fish
                        },
                        new Pet
                        {
                            name="FBP2", type=PetType.Dog
                        }
                        ,
                        new Pet
                        {
                            name="FBP3", type=PetType.Cat
                        }
                    }
                }
            };

            Mock fileServiceMock = new Mock<IFileService>(MockBehavior.Default);
            fileServiceMock.As<IFileService>().Setup(x => x.GetFilePath()).Returns("ABC");

            Mock repositoryMock = new Mock<IPetsRepository>();
            repositoryMock.As<IPetsRepository>().Setup(x => x.GetData(It.IsAny<string>())).Returns(personDataObj);

            PetsService petservice = new PetsService(fileServiceMock.Object as IFileService, repositoryMock.Object as IPetsRepository);

            var result = petservice.GetPetsClassified();

            Assert.IsNotNull(result);
            Assert.IsNull(result.MalePets);
            Assert.IsTrue(result.FemalePets.Count == 5);

        }
    }
}
