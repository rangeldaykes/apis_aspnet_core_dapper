
using System;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
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
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso"); 

            // Verificar se o E-Mail já existe
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email já está em uso");             

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

            if (Invalid)
                return null;
            // Inserir o cliente no banco
            _repository.Save(customer);

            // Envia um E-mail de boas vindas
            _emailService.Send(email.Address, "hello@email.com", "Bem vindo", "Seja bem vindo aqui");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}