using System;
using System.Linq;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContext;
using Dapper;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;
        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return 
                _context
                .Connection
                .Query<bool>(
                    @"select exists (select true from customer where document = @document)",
                    new { document = document }                    
                ).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return 
                _context
                .Connection
                .Query<bool>(
                    @"select exists (select true from customer where email = @email)",
                    new { email = email }                    
                ).FirstOrDefault();
        }

        public CustomerOrderCountResult GetCustomerOrderCountResult(string document)
        {
            return 
                _context
                .Connection
                .Query<CustomerOrderCountResult>(
                    @"
                    SELECT c.firstname || ' ' || c.lastname, c.document, c.id, count(o.id)
                      FROM public.customer c
                      LEFT JOIN public.order o on c.id = o.customerid
                     WHERE c.document = @document
                     group by c.firstname, c.lastname, c.document, c.id
                    ",
                    new { document = document }                    
                ).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection
            .Execute(
                @"
                INSERT INTO public.customer(
                    firstname, lastname, document, email, phone, id)
                    VALUES (@firstname, @lastname, @document, @email, @phone, @id)
                ",
                new {
                    firstname = customer.Name.FirstName,
                    lastname = customer.Name.LastName,
                    document = customer.Document.Number,
                    email = customer.Email.Address,
                    phone = customer.Phone,
                    id = customer.Id
                }
            );

            foreach (var address in customer.Addresses)
            {
                _context.Connection
                .Execute(
                    @"
                    INSERT INTO public.address(
                        id, customerid, number, complement, district, city, country, zipcode, type)
                        VALUES (@id, @customerid, @number, @complement, 
                                @district, @city, @country, @zipcode, @type)
                    ",
                    new {
                        id = address.Id,
                        customerid = customer.Id,
                        number = address.Number,
                        complement = address.Complement,
                        district = address.Distrinct,
                        city = address.City,
                        country = address.Country,
                        zipcode = address.ZipCode,
                        type = address.Type
                    }
                );
            }
        }
    }
}