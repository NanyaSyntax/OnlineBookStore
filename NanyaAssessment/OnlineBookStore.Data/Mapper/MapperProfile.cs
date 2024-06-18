using AutoMapper;
using OnlineBookStore.Data.DTO;
using OnlineBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Data.Mapper
{
    public class MapperProfile : Profile
    {
        protected MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Cart, CartDTO>();
            CreateMap<PurchaseHistory, PurchaseHistoryDTO>();
        }
    }
}
