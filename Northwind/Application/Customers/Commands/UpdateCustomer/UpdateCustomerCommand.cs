﻿using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Persistence;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly NorthwindContext _context;

        public UpdateCustomerCommand(NorthwindContext context)
        {
            _context = context;
        }

        public async Task Execute(UpdateCustomerModel model)
        {
            var entity = await _context.Customers.SingleAsync(c => c.CustomerId == model.Id);

            entity.Address = model.Address;
            entity.City = model.City;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Country = model.Country;
            entity.Fax = model.Fax;
            entity.Phone = model.Phone;
            entity.PostalCode = model.PostalCode;

            _context.Customers.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
