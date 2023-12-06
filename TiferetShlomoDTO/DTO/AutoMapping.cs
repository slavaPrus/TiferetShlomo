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
        }

    }
}
