using System;
using System.Linq;
using System.Collections.Generic;
using northwind_mvc_i.Library.Models;

namespace Services
{
    public class ProductService
    {
        NorthwindContext context = new NorthwindContext();

        public Products GetProduct(int productId){
            var results = context.Products.Where(c => c.CategoryId == productId);
            if(results.Count() == 0){
                return null;
            }
            
            return results.First();
            
        }

        public List<Products> GetProductsByCategoryId(int categoryId) {
            var results = context.Products.Where(c => c.CategoryId == categoryId);
            if(results.Count() == 0){
                return new List<Products>();
            }
            
            return results.ToList();

        }

        public Products Add(string name, bool isActive, short categoryId){
            Products product = new Products();

            product.ProductName = name;
            product.Discontinued = isActive;
            product.CategoryId = categoryId;
            
            context.Add(product);
            context.SaveChanges();

            return product;
        }

        public Products Update(int id, bool isActive, short categoryId){
            Products product = GetProduct(id);
            if(product == null){
                return null;
            }

            product.Discontinued = isActive;
            product.CategoryId = categoryId;
            context.SaveChanges();

            return product;
        }

        public void Delete(Products product){
            context.Remove(product);
            context.SaveChanges();
        }

        public IEnumerable<Products> AllProducts(){
            return context.Products.OrderBy(c => c.ProductName);
        }
    }
}