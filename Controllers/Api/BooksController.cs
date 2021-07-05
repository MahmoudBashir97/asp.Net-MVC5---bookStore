using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _Books.Models;

namespace _Books.Controllers.Api
{
    public class BooksController : ApiController
    {

        private readonly ApplicationDBContext _dbContext;

        public BooksController()
        {
            _dbContext = new ApplicationDBContext();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id) {
            var book = _dbContext.Books.Find(id);
            if (book == null)
                return NotFound();
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
