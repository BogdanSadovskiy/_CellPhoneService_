using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.Entity
{
    public class UserTable
    {
        public UserTable() { }
        public UserTable(int id, string firstName, string lastName, string phoneNumber,
            string email, string password, int roleId)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone_number = phoneNumber;
            this.Email = email; 
            this.Password = password;
            this.Role_id = roleId;
        }

   

        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone_number { get; set; }    
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Role_id { get; set; }

    }
}
