using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // Other custom for for access this endpoint
        [HttpGet("all")]
        // Especific return type of endpoint (example List<>)
        public List<People> GetAll() => Repository.PeopleList;

        // Note: This endpoint use params here to diference to others get methods
        [HttpGet("{id}")] 
        public People GetByID(int id) => Repository.PeopleList.First((p) => p.Id == id);
        
        [HttpGet("search/{name}")]
        public List<People> GetMatches(string name) =>
            // Use LINQ to find Matches (Uses toUpper for ignore Capital letters)
            Repository.PeopleList.Where((p) => p.Name.ToUpper().Contains(name.ToUpper())).ToList();

        // This is an example of Error handling with Acction Results
        [HttpGet("acction-result/{id}")]
        public ActionResult<People> GetByIDActionResult(int id)
        {
            var people = Repository.PeopleList.FirstOrDefault((p) => p.Id == id);

            if (people == null)
            {
                // Uses codes HTTP to responses with erros
                return NotFound();
            }
            
            return Ok(people);
        }

        // Uses of Interfaces IActionResult to responses HTTP
        [HttpPost]
        public IActionResult Add(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {
                return BadRequest();
            }

            Repository.PeopleList.Add(people);

            return NoContent();
        }

    }

    public class Repository
    {
        public static List<People> PeopleList = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Foo",
                Birthdate = DateTime.Today,
            },
            new People()
            {
                Id=2,
                Name = "Bar",
                Birthdate = DateTime.Today,
            },
            new People()
            {
                Id=3,
                Name = "Foo",
                Birthdate = DateTime.Today,
            }
        };
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
