using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Web_API.Services;

namespace Test_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        // Example of the functioning of the 3 types of dependency injections
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomServiceTransient;
        
        private IRandomService _randomServiceSingleton02;
        private IRandomService _randomServiceScoped02;
        private IRandomService _randomServiceTransient02;

        public RandomController(
                [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton,
                [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
                [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient,
                [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton02,
                [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped02,
                [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient02
            )
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;
            
            _randomServiceSingleton02 = randomServiceSingleton02;
            _randomServiceScoped02 = randomServiceScoped02;
            _randomServiceTransient02 = randomServiceTransient02;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton 01", _randomServiceSingleton.Value);
            result.Add("Scoped 01", _randomServiceScoped.Value);
            result.Add("TRansient 01", _randomServiceTransient.Value);
            
            result.Add("Singleton 02", _randomServiceSingleton02.Value);
            result.Add("Scoped 02", _randomServiceScoped02.Value);
            result.Add("TRansient 02", _randomServiceTransient02.Value);

            return result;

            /*
             Result JSON:
                 {
                    "Singleton 01": 9,
                    "Scoped 01": 18,
                    "TRansient 01": 91,
                    "Singleton 02": 9,
                    "Scoped 02": 18,
                    "TRansient 02": 18
                }
            */
        }
    }

}
