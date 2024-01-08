using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface ITestDAL
    {
        Task<List<Test>> AddTest(Test test);
        Task<List<Test>> GetAllTests();
        Task<Test> GetTestById(int id);
        Task RemoveTest(int id);
        Task<Test> UpdateTest(Test test);
    }
}