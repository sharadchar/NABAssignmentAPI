using System.ComponentModel.DataAnnotations;

namespace OwnerPets.Data
{
    /// <summary>
    /// This represents the model entity for pet.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the PetType value.
        /// </summary>
        [EnumDataType(typeof(PetType))]
        public PetType type { get; set; }
    }
}
