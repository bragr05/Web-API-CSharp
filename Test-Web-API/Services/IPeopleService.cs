using Test_Web_API.Controllers;

namespace Test_Web_API.Services
{
    public interface IPeopleService
    {
        bool Validate(People people);
    }
}
