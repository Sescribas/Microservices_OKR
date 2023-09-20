using AutoMapper;
using OKR.Common.Domain.Dto_s;
using OKR.Common.Domain.Dtos.ProductStockDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain.Automapper
{
    public class ProductStockProfile : Profile
    {
        public ProductStockProfile()
        {
            CreateMap<ProductStock, GetProductStockDtoResponse>();
            CreateMap<GetProductStockDtoResponse, ProductStock>();

        }
    }
}
