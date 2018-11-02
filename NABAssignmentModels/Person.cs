using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NABAssignmentModels
{
    /// <summary>
    /// This represents the model entity for person.
    /// </summary>
    [JsonArrayAttribute]
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            this.Pets = new List<Pet>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Models.GenderType"/> value.
        /// </summary>
        [JsonProperty("gender")]
        [EnumDataType(typeof(GenderType))]
        public GenderType GenderType { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        [JsonProperty("age")]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Pet"/> objects.
        /// </summary>
        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }
}
