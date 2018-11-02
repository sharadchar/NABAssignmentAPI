using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NABAssignmentModels
{
    /// <summary>
    /// This represents the model entity for pet.
    /// </summary>
    [JsonObjectAttribute]
    public class Pet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Models.PetType"/> value.
        /// </summary>
        [JsonProperty("type")]
        [EnumDataType(typeof(PetType))]
        public PetType PetType { get; set; }
    }
}
