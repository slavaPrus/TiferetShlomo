using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class TestDAL : ITestDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<Test>> GetAllTests()
        {
            try
            {
                return await _context.Tests.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllTests DAL");
                return null;
            }
        }

        public async Task<Test> GetTestById(int id)
        {
            try
            {
                return await _context.Tests.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetTestById DAL");
                return null;
            }
        }

        public async Task<List<Test>> AddTest(Test test)
        {
            try
            {
                await _context.Tests.AddAsync(test);
                _context.SaveChanges();
                return await GetAllTests();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddTest DAL");
                return null;
            }
        }

        public async Task<Test> UpdateTest(Test test)
        {
            try
            {
                Test t = await _context.Tests.FirstOrDefaultAsync(x => x.TestId == test.TestId);
                if (t != null)
                {
                    t.TestDate = test.TestDate;
                    t.Describe = test.Describe;
                    // Other properties assignment if needed

                    _context.SaveChanges();
                }
                return t;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateTest DAL");
                return null;
            }
        }

        public async Task RemoveTest(int id)
        {
            try
            {
                Test test = _context.Tests.Find(id);
                _context.Tests.Remove(test);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveTest DAL");
            }
        }
    }
}

