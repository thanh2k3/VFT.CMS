using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Carts.Dto
{
    public class CartMapProfile : Profile
    {
        public CartMapProfile()
        {
            CreateMap<Cart, CartDto>();
        }
    }
}
