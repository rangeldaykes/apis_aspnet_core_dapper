
using System;
using System.Collections.Generic;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommands: Notifiable, ICommand  
    {
        public PlaceOrderCommands()
        {
            OrderItens = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItens { get; set; }

        public bool IsValid()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                .IsGreaterThan(OrderItens.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
            ) ;

            return Valid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }    
}