using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;

namespace TiferetShlomoBL
{
    public class LessonBL : ILessonBL
    {
        private readonly ILessonDAL _lessonDAL; // Inject ILessonDAL interface here
        private readonly IMapper _mapper;
        public LessonBL(ILessonDAL lessonDAL, IMapper mapper)
        {
            _lessonDAL = lessonDAL;
            _mapper = mapper;

        }

        public IEnumerable<Lesson> GetAllLessons()
        {
            try
            {
                return _lessonDAL.GetAllLessons();
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
                return _lessonDAL.GetLessonById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddLesson(Lesson lesson)
        {
            try
            {
                _lessonDAL.AddLesson(lesson);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLesson(Lesson lesson)
        {
            try
            {
                _lessonDAL.UpdateLesson(lesson);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveLesson(int id)
        {
            try
            {
                _lessonDAL.RemoveLesson(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
