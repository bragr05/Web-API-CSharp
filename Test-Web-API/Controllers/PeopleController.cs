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
        public List<People> GetPeoples() => Repository.PeopleList;
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
                Name = "Yee",
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
