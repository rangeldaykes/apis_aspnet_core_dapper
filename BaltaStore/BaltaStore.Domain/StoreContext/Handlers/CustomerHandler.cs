
using System;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
    Notifiable, 
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe

            // Verificar se o E-Mail já existe

            // Criar os VOs 
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar Entidades
            var customer = new Customer(name, document, email, command.Phone);
                        
            // Validar as entidades e VO
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            // Inserir o cliente no banco

            // Enviar convite do Slack

            // Envia um E-mail de boas vindas

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}