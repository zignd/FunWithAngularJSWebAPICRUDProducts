using FunWithAngularJSWebAPICRUDProducts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FunWithAngularJSWebAPICRUDProducts.Controllers
{
    public class ProductsController : ApiController
    {
        private StoreContext db { get; set; }

        public ProductsController()
        {
            db = new StoreContext();
        }

        // GET api/products
        public IHttpActionResult Get()
        {   
            return Ok(db.Products.ToArray());
        }

        // GET api/products/1
        public IHttpActionResult Get(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST api/products
        [Authorize]
        public IHttpActionResult Post([FromBody]Product newProduct)
        {
            newProduct.LastUpdated = DateTime.Now;

            var storedProduct = db.Products.Add(newProduct);
            db.SaveChanges();

            return Ok(storedProduct.Id);
        }

        // PUT api/products/1
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]Product updatedProduct)
        {
            var storedProduct = db.Products.Find(id);

            if (storedProduct == null)
                return NotFound();

            storedProduct.CategoryId = updatedProduct.CategoryId;
            storedProduct.Name = updatedProduct.Name;
            storedProduct.Description = updatedProduct.Description;
            storedProduct.Price = updatedProduct.Price;
            storedProduct.LastUpdated = DateTime.Now;

            db.SaveChanges();

            return Ok();
        }

        // DELETE api/products/1
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
                NotFound();

            db.Products.Remove(product);

            db.SaveChanges();

            return Ok();
        }
    }
}
