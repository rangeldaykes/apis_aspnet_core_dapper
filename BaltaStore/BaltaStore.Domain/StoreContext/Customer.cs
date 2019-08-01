namespace BaltaStore.Domain.StoreContext
{
    public class Person
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Salary { get; set; }
    }

    public class Customer : Person
    {
        public void Register() {}

        public void AoRegistrar() {}
    }

    public class SalesMan : Person
    {
        
    }
}