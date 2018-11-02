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
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            this.pets = new List<Pet>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Models.GenderType"/> value.
        /// </summary>
        [EnumDataType(typeof(GenderType))]
        public GenderType gender { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int age { get; set; }

        ///// <summary>
        ///// Gets or sets the list of <see cref="Pet"/> objects.
        ///// </summary>        
        public List<Pet> pets { get; set; }
    }
}
