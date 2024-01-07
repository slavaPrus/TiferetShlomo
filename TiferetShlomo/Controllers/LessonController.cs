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
    public class lessonController : ControllerBase
    {
        private readonly ILessonBL _lessonBL;

        public lessonController(ILessonBL lessonBL)
        {
            _lessonBL = lessonBL;
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
