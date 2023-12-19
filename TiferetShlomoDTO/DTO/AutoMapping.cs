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
            CreateMap<BookPart, BookPartDTO>();
            CreateMap<BookPartDTO, BookPart>();
            CreateMap<Contact,ContactDTO>();
            CreateMap<ContactDTO, Contact>();
            CreateMap<Flyer, FlyerDTO>();
            CreateMap<FlyerDTO, Flyer>();
            CreateMap<Joining, JoiningDTO>();
            CreateMap<JoiningDTO, Joining>();
            CreateMap<Lesson, LessonDTO>();
            CreateMap<LessonDTO, Lesson>();
            CreateMap<Picture, PictureDTO>();
            CreateMap<PictureDTO, Picture>();

        }

    }
}
