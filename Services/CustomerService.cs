using System;
using System.Linq;
using System.Collections.Generic;
using northwind_mvc_i.Library.Models;
using northwind_mvc_i;

namespace Services
{
    public class CustomerService
    {
        NorthwindContext context = new NorthwindContext();

        public IEnumerable<Customers> AllCustomers(){
            return context.Customers.OrderBy(c => c.ContactName);
        }

    }}