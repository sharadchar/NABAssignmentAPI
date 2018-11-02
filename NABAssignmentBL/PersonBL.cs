using NABAssignmentModels;
using NABAssignmentServices;
using System;
using System.Collections.Generic;

namespace NABAssignmentBL
{
    public class PersonBL
    {
        private IDataReader _dataReader;

        public PersonBL(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public List<Person> GetPerson(string filepath)
        {
            return _dataReader.GetData(filepath);
        }
    }
}
