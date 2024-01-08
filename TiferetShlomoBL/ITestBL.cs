using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface ITestBL
    {
        Task<List<TestDTO>> AddTest(TestDTO test);
        Task<List<TestDTO>> GetAllTests();
        Task<TestDTO> GetTestById(int id);
        Task RemoveTest(int id);
        Task<TestDTO> UpdateTest(TestDTO test);
    }
}