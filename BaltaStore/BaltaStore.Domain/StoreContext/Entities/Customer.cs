namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(
            string firstName,
            string lastName, 
            string document, 
            string email, 
            string phone, 
            string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}