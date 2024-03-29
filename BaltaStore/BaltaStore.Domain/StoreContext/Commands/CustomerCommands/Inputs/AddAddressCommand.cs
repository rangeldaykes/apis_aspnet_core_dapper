using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Distrinct { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        public bool IsValid()
        {
            return Valid;
        }
    }
}