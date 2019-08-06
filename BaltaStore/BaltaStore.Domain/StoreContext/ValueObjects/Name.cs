using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new Contract().Requires().HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() 
        {
            return $"{FirstName} {LastName}";
        }
    }
}