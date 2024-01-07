using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class LessonDAL : ILessonDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();


        public async Task<List<Lesson>> GetAllLessons()
        {
            try
            {
                return await _context.Lessons.ToListAsync();

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllLessons DAL");
                return null;
            }

        }

        public async Task<Lesson> GetLessonById(int id)
        {
            try
            {
                return await _context.Lessons.FindAsync(id);

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetLessonById DAL");
                return null;

            }

        }

        public async Task<List<Lesson>> AddLesson(Lesson Lesson)
        {
            try
            {
                await _context.Lessons.AddAsync(Lesson);
                _context.SaveChanges();
                return await GetAllLessons();

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddLesson DAL");
                return null;

            }

        }

        public async Task<Lesson> UpdateLesson(Lesson lesson)
        {
            try
            {
                Lesson existingLesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == lesson.LessonId);
                if (existingLesson != null)
                {
                    existingLesson.LessonName = lesson.LessonName;
                    existingLesson.LessonSubjectId = lesson.LessonSubjectId;
                    existingLesson.LessonUrl = lesson.LessonUrl;
                    existingLesson.LessonData = lesson.LessonData;
                    existingLesson.LessonTypeId = lesson.LessonTypeId;

                    _context.SaveChanges();
                }
                return existingLesson;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateLesson DAL");
                return null;
            }

        }

        public async Task RemoveLesson(int id)
        {
            try
            {
                Lesson Lesson = _context.Lessons.Find(id);
                _context.Lessons.Remove(Lesson);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "RemoveLesson DAL");
            }

        }
    }
}
