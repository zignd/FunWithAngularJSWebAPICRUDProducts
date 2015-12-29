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
    public class CategoriesController : ApiController
    {
        private StoreContext db { get; set; }

        public CategoriesController()
        {
            db = new StoreContext();
        }

        // GET api/categories
        public IHttpActionResult Get()
        {
            return Ok(db.Categories.ToArray());
        }

        // GET api/categories/1
        public IHttpActionResult Get(int id)
        {
            var category = db.Categories.Find(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST api/categories
        [Authorize]
        public IHttpActionResult Post([FromBody]Category newCategory)
        {
            newCategory.LastUpdated = DateTime.Now;

            var storedCategory = db.Categories.Add(newCategory);
            db.SaveChanges();

            return Ok(storedCategory.Id);
        }

        // PUT api/categories/1
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]Category updatedCategory)
        {
            var storedCategory = db.Categories.Find(id);

            if (storedCategory == null)
                return NotFound();

            storedCategory.Name = updatedCategory.Name;
            storedCategory.Description = updatedCategory.Description;
            updatedCategory.LastUpdated = DateTime.Now;

            db.SaveChanges();

            return Ok();
        }

        // DELETE api/categories/1
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);

            if (category == null)
                NotFound();

            db.Categories.Remove(category);

            db.SaveChanges();

            return Ok();
        }
    }
}
