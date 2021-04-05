using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic; 
using System.Linq; 
using restApi.Models;

namespace restApi.Controllers {
    [Route("api/[controller]")]     
    [ApiController]     
    public class UserController : ControllerBase     
    {        
        private readonly APIContext _context;          
        public UserController(APIContext context)         
        {             
            _context = context;              
            if (_context.Users.Count() == 0)             
                {                 
                    _context.Users.Add(new User { Name = "User1", Email ="user1@user.com" });                 
                    _context.SaveChanges();             
                }           
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(long id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }            
    } 
}