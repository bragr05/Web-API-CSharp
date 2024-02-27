using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Test_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsynchronousController : ControllerBase
    {
        // Example of sync method
        [HttpGet("sync")]
        public ActionResult GetSync() {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Connected to the BD");

            Thread.Sleep(1000);
            Console.WriteLine("Mail sent");

            Console.WriteLine("Proccess Finsh");
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed); 
        }

        // Example of async method (Task<T> is a class representing an asynchronous operation)
        [HttpGet("async")]
        public async Task<IActionResult> GetAsync() 
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var task01 = new Task(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Connected to the BD");
            });
            

            var task02 = new Task<string>(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Mail sent");
                return "Message Mail";
            });

            task01.Start();
            task02.Start();

            await task01;
            var result = await task02;
            Console.WriteLine("result");
            Console.WriteLine("Proccess Finsh");

            stopwatch.Stop();
            return Ok(stopwatch.Elapsed);
        }

    }
}
