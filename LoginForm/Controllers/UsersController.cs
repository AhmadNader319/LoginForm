using Microsoft.AspNetCore.Mvc;
using LoginForm.Services;
using LoginForm.Models;
using Newtonsoft.Json;
using MongoDB.Bson;
using Amazon.Runtime.Internal;
using System.IO;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginForm.Controllers
{

    [Route("api/User")]
    public class UsersController : Controller
    {
        private readonly UserServices userServices;

        public UsersController(UserServices usrServices)
        {
            userServices = usrServices;
        }
        // GET: api/User
        [HttpGet]
        public async Task<List<User>> Get() => await userServices.GetAsync();


        // GET api/User/65f58e468c6a06180254d072
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            User user = await userServices.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post()
        {
            // Read the request body stream
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string requestBody = await reader.ReadToEndAsync();

                // Manually deserialize JSON into User object
                User newUser = JsonConvert.DeserializeObject<User>(requestBody);

                // Check if deserialization was successful
                if (newUser == null)
                {
                    return BadRequest(); // If deserialization fails, return BadRequest
                }

                // Process the User object (e.g., save to database)
                await userServices.CreateAsync(newUser);

                // Return a success response
                return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
            }
        }


        // PUT api/User/65f58e468c6a06180254d072
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE api/User/65f58e468c6a06180254d072
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}

