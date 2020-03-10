using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using northwind_mvc_i.Library.Models;
using Services;

namespace northwind_mvc_i.Controllers
{
    [Route("")] // Make an action or controller default..
    [Route("[controller]")] // The route contains the controller name.
    public class OverviewController : Controller // Extends Controller
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        CustomerService customerService = new CustomerService();
        
        [Route("")] // Default action
        [Route("[action]")] // The route contains the action name.
        public IActionResult Index()
        {
            // Passing data to the view.
            return View(customerService.AllCustomers());
        }

        NorthwindContext context = new NorthwindContext();
        [Route("Orders")]
        public IActionResult GetOrdersByCustomerId(string costumerId)
        {

            var results = context.Orders.ToList().Where(m => m.CustomerId == costumerId);              
            
            return View(results);
        }

    }

}