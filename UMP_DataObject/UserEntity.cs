using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace UMP_DataObject
{
    public class UserEntity
    {
        //Declaring Variables

        private Guid _UserId;
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private string _Gender;
        private string _Street;
        private string _City;
        private string _Province;
        private string _Country;
        private string _PostalCode; 

        //Setting Values

        public Guid UserId { get { return _UserId; } set { _UserId= value; } }
       
        public string FirstName { get { return _FirstName;} set { _FirstName= value; } }
       
        public string LastName { get { return _LastName;} set { _LastName= value; } }

        public DateTime DateOfBirth { get { return _DateOfBirth; } set { _DateOfBirth= value; } }

        public string Gender { get { return _Gender;} set { _Gender= value; } } 

        public string Street { get { return _Street;} set { _Street= value; } }
        
        public string City { get { return _City;} set { _City = value; } }

        public  string Province { get { return _Province;} set { _Province= value; } }  

        public string Country { get { return _Country;} set { _Country= value; } }
       
        public string PostalCode { get { return _PostalCode;} set { _PostalCode= value; } }

    }
}
