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
        public async Task<(List<Lesson>, bool)> GetLessonsByPage(int skipCount, int pageSize)
        {
            try
            {
                // Use your DbContext to query the database for lesson based on skipCount and pageSize
                List<Lesson> lesson = await _context.Lessons
                    .OrderBy(lesson => lesson.LessonId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
                int totalCount = await _context.Lessons
                .CountAsync();

                // Calculate if there are more lesson available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (lesson, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetLessonsByPage in LessonDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }
        public async Task<(List<Lesson>, bool)> GetSearchLessonsByPage(int skipCount, int pageSize, string str)
        {
            try
            {
                // Use your DbContext to query the database for books based on skipCount and pageSize
                List<Lesson> lessons = await _context.Lessons
                    .Where(lesson => lesson.LessonName.Contains(str)) // search for lessons based on the bookname property
                    .OrderBy(lesson => lesson.LessonId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
                int totalCount = await _context.Lessons
                   .Where(lesson => lesson.LessonName.Contains(str))
                   .CountAsync();

                // Calculate if there are more lessons available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (lessons, hasNext);

            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetSearchLessonsByPage in LessonDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }
        public async Task<(List<Lesson>, bool)> GetFilterLessonsByPage(int skipCount, int pageSize, string str)
        {
            try
            {
                // Retrieve filtered Lesson from the repository based on category and pagination parameters
                List<Lesson> lessons = await _context.Lessons
                    .Where(lesson => lesson.LessonSubject.Describe == str) // Filter lessons based on category
                    .OrderBy(lesson => lesson.LessonId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();

                // Calculate total count of books for the given filter criteria
                int totalCount = await _context.Lessons
                    .Where(lesson => lesson.LessonName == str)
                    .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (lessons, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetFilterLessonsByPage in LessonDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }

    }
}

    

