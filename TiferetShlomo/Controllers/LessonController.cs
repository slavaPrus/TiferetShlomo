using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace TiferetShlomo.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonBL _lessonBL;

        public LessonController(ILessonBL lessonBL)
        {
            _lessonBL = lessonBL;
        }

        [HttpGet("getLessonsByPage/{page}")]
        public async Task<List<LessonDTO>> GetLessonsByPage(int page)
        {
            try
            {
                (List<LessonDTO> lessons, bool hasNext) = await _lessonBL.GetLessonsByPage(page);
                if (!hasNext)
                {
                    lessons.Add(null);
                }

                return lessons;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetBooksByPage Controller");
                return null;
            }
        }

        [HttpGet("GetSearchLessonsByPage")]
        public async Task<List<LessonDTO>> GetSearchLessonsByPage([FromQuery] int page, [FromQuery] string str)
        {
            try
            {
                (List<LessonDTO> lessons, bool hasNext) = await _lessonBL.GetSearchLessonsByPage(page, str);
                if (!hasNext)
                {
                    lessons.Add(null);
                }
                return lessons;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetSearchLessonsByPage Controller");
                return null;
            }
        }
        [HttpGet("GetFilterLessonsByPage")]
        public async Task<List<LessonDTO>> GetFilterLessonsByPage([FromQuery] int page, [FromQuery] string str)
        {
            try
            {
                // Call the BL layer function to retrieve filtered books
                (List<LessonDTO> filteredLessons, bool hasNext) = await _lessonBL.GetFilterLessonsByPage(page, str);

                // Add a null book at the end if hasNext is false
                if (!hasNext)
                {
                    filteredLessons.Add(null);
                }
                return filteredLessons;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFilterLessonsByPage Controller");
                return null;
            }
        }

        [HttpGet]
        public async Task<List<LessonDTO>> GetAlllessons()
        {
            try
            {
                List<LessonDTO> lessons = await _lessonBL.GetAllLessons();
                return lessons;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetAlllessons Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<LessonDTO> GetlessonById(int id)
        {
            try
            {
                LessonDTO lesson = await _lessonBL.GetLessonById(id);

                return lesson;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetlessonById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<LessonDTO>> Addlesson([FromBody] LessonDTO lesson)
        {
            try
            {
                List<LessonDTO> lessons = await _lessonBL.AddLesson(lesson);
                return lessons;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "Addlesson Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<LessonDTO> Updatelesson(int id, [FromBody] LessonDTO lesson)
        {
            try
            {

                LessonDTO existinglesson = await _lessonBL.UpdateLesson(lesson);
                return existinglesson;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "Updatelesson Controller");
                return null;
            }
        }
        [HttpDelete("{id}")]
        public async Task Removelesson(int id)
        {
            try
            {
                await _lessonBL.RemoveLesson(id);

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "Removelesson Controller");

            }
        }

    }
}
