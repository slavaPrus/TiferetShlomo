using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<Contact,ContactDTO>();
            CreateMap<ContactDTO, Contact>();
            CreateMap<Flyer, FlyerDTO>();
            CreateMap<FlyerDTO, Flyer>();
            CreateMap<Joining, JoiningDTO>();
            CreateMap<JoiningDTO, Joining>();
            CreateMap<Lesson, LessonDTO>();
            CreateMap<LessonDTO, Lesson>();
            CreateMap<PictureSale, PictureSaleDTO>();
            CreateMap<PictureSaleDTO, PictureSale>();
            CreateMap<Tsfile, TsfileDTO>();
            CreateMap<TsfileDTO, Tsfile>();
            CreateMap<Test, TestDTO>();
            CreateMap<TestDTO, Test>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<LessonSubject, LessonSubjectDTO>();
            CreateMap<LessonSubjectDTO, LessonSubject>();
            CreateMap<LessonType, LessonTypeDTO>();
            CreateMap<LessonTypeDTO, LessonType>();
            CreateMap<ParashatShavua, ParashatShavuaDTO>();
            CreateMap<ParashatShavuaDTO, ParashatShavua>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<MarkDTO, Mark>();
            CreateMap<Mark, MarkDTO>();

        }

    }
}
