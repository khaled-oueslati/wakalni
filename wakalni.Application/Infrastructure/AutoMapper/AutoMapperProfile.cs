using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using wakalni.Application.Items.Models;
using wakalni.Entities;

namespace wakalni.Application.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
