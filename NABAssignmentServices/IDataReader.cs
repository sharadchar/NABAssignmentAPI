using NABAssignmentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NABAssignmentServices
{
    public interface IDataReader
    {
        List<Person> GetData(string filepath =  null); 
    }
}
