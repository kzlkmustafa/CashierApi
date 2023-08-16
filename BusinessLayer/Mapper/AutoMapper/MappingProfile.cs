using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductAddDto>();
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Basket, BasketAddDto>();
            CreateMap<BasketAddDto, Basket>();
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketDto, Basket>();

            CreateMap<BasketDetail, BasketDetailAddDto>();
            CreateMap<BasketDetailAddDto, BasketDetail>();
            CreateMap<BasketDetail, BasketDetailDto>();
            CreateMap<BasketDetailDto, BasketDetail>();

            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Kdv, KdvAddDto>();
            CreateMap<KdvAddDto, Kdv>();
            CreateMap<Kdv, KdvDto>();
            CreateMap<KdvDto, Kdv>();

        }
    }
}
