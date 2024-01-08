using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class LookUpDAL : ILookUpDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<LessonType>> GetAllLessonTypes()
        {
            try
            {
                return await _context.LessonTypes.Include(m => m.Describe).Include(m => m.Describe).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllLessonTypes DAL");
                return null;
            }
        }
        public async Task<List<LessonSubject>> GetAllLessonSubjects()
        {
            try
            {
                return await _context.LessonSubjects.Include(m => m.Describe).Include(m => m.Describe).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllLessonSubjects DAL");
                return null;
            }
        }
        public async Task<List<ParashatShavua>> GetAllParashatShavuas()
        {
            try
            {
                return await _context.ParashatShavuas.Include(m => m.Describe).Include(m => m.Describe).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllParashatShavuas DAL");
                return null;
            }
        }
    }
}
