using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomo.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly ITestBL _testBL;

        public TestController(ITestBL testBL)
        {
            _testBL = testBL;
        }

        [HttpGet]
        public async Task<List<TestDTO>> GetAllTests()
        {
            try
            {
                List<TestDTO> tests = await _testBL.GetAllTests();
                return tests;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllTests Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<TestDTO> GetTestById(int id)
        {
            try
            {
                TestDTO test = await _testBL.GetTestById(id);
                return test;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetTestById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<TestDTO>> AddTest([FromBody] TestDTO test)
        {
            try
            {
                List<TestDTO> tests = await _testBL.AddTest(test);
                return tests;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddTest Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<TestDTO> UpdateTest(int id, [FromBody] TestDTO test)
        {
            try
            {
                TestDTO existingTest = await _testBL.UpdateTest(test);
                return existingTest;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateTest Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemoveTest(int id)
        {
            try
            {
                await _testBL.RemoveTest(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveTest Controller");
            }
        }
    }
}

