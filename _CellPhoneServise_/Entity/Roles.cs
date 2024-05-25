namespace _CellPhoneService_.Entity
{
    public class Roles
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public Roles(int id, string role)
        {
            Id = id;
            Role = role;
        }
        
    }
}
