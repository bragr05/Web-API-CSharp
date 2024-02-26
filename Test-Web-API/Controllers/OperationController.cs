using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Web_API.Controllers
{
    // URL of the driver, by default it has a 'helper' which indicates that the driver name
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        // You must indicate which HTTP method you will use
        [HttpGet]
        public decimal Add(decimal a, decimal b) { return a + b; }

        // Example to get params URL and Headers and custom header
        [HttpPost]
        public decimal Subtract(Numbers numbers, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string contentLength, [FromHeader(Name = "X-Custom-Header")] string CustomHeader) 
        {
            Console.WriteLine(Host);
            Console.WriteLine(contentLength);
            Console.WriteLine(CustomHeader);
            return numbers.a - numbers.b;
        }
    }

    public class Numbers
    {
        public decimal a { get; set; }
        public decimal b { get; set; }
    }
}


