using System;
using AutoMapper;
using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;

namespace ProductsInventory.Api.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequest, Product>();
    }
}