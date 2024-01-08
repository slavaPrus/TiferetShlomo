using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public class TestBL : ITestBL
    {
        private readonly ITestDAL _testDAL;
        private readonly IMapper _mapper;

        public TestBL(ITestDAL testDAL, IMapper mapper)
        {
            _testDAL = testDAL;
            _mapper = mapper;
        }

        public async Task<List<TestDTO>> GetAllTests()
        {
            try
            {
                List<Test> tests = await _testDAL.GetAllTests();
                List<TestDTO> testsDTO = _mapper.Map<List<TestDTO>>(tests);
                return testsDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllTests BL");
                return null;
            }
        }

        public async Task<TestDTO> GetTestById(int id)
        {
            try
            {
                Test test = await _testDAL.GetTestById(id);
                TestDTO testDTO = _mapper.Map<TestDTO>(test);
                return testDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetTestById BL");
                return null;
            }
        }

        public async Task<List<TestDTO>> AddTest(TestDTO test)
        {
            try
            {
                Test t = _mapper.Map<Test>(test);
                List<Test> tests = await _testDAL.AddTest(t);
                List<TestDTO> testsDTO = _mapper.Map<List<TestDTO>>(tests);
                return testsDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddTest BL");
                return null;
            }
        }

        public async Task<TestDTO> UpdateTest(TestDTO test)
        {
            try
            {
                Test t = _mapper.Map<Test>(test);
                Test updatedTest = await _testDAL.UpdateTest(t);
                TestDTO updatedTestDTO = _mapper.Map<TestDTO>(updatedTest);
                return updatedTestDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateTest BL");
                return null;
            }
        }

        public async Task RemoveTest(int id)
        {
            try
            {
                await _testDAL.RemoveTest(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveTest BL");
            }
        }
    }
}

