using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class LessonDAL : ILessonDAL
    {
        private readonly TIFERET_SHLOMOContext _context;

        public LessonDAL(TIFERET_SHLOMOContext context)
        {
            _context = context;
        }

        public IEnumerable<Lesson> GetAllLessons()
        {
            try
            {
                return _context.Lessons.Include(l => l.LessonSubject).Include(l => l.LessonType).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public Lesson GetLessonById(int id)
        {
            try
            {
                return _context.Lessons.Include(l => l.LessonSubject).Include(l => l.LessonType).FirstOrDefault(l => l.LessonId == id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void AddLesson(Lesson lesson)
        {
            try
            {
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void UpdateLesson(Lesson lesson)
        {
            try
            {
                _context.Entry(lesson).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void RemoveLesson(int id)
        {
            try
            {
                var lesson = _context.Lessons.Find(id);
                if (lesson != null)
                {
                    _context.Lessons.Remove(lesson);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }
    }
}
