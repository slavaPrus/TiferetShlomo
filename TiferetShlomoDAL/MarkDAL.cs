using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class MarkDAL : IMarkDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();
        public async Task<List<Mark>> GetAllMarks()
        {
            try
            {
                return await _context.Marks.Include(m => m.Test).Include(m => m.User).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllMarks DAL");
                return null;
            }
        }


        public async Task<List<Mark>> GetMarksByUserId(int userId)
        {
            try
            {
                // Query the database to retrieve marks by userId
                var marks = await _context.Marks
                    .Include(m => m.Test)  // Include related Test entity
                    .Where(m => m.UserId == userId)
                    .ToListAsync();

                return marks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetMarksByUserId DAL");
                return null; // Or you can rethrow the exception if you want to handle it elsewhere
            }
        }


        public async Task<List<Mark>> AddMark(Mark mark)
        {
            try
            {
                await _context.Marks.AddAsync(mark);
                await _context.SaveChangesAsync();
                return await GetAllMarks();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "AddMark DAL");
                return null;
            }
        }
        public async Task<Mark> UpdateMark(Mark mark)
        {
            try
            {
                Mark existingMark = await _context.Marks.FirstOrDefaultAsync(x => x.MarkId == mark.MarkId);
                if (existingMark != null)
                {
                    existingMark.UserId = mark.UserId;
                    existingMark.TestId = mark.TestId;
                    // Update other properties as needed

                    await _context.SaveChangesAsync();
                }
                return existingMark;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "UpdateMark DAL");
                return null;
            }
        }

        public async Task RemoveMark(int id)
        {
            try
            {
                Mark mark = await _context.Marks.FindAsync(id);
                if (mark != null)
                {
                    _context.Marks.Remove(mark);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "RemoveMark DAL");
            }
        }

    }
}
