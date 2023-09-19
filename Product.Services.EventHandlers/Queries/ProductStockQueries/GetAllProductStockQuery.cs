using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain.Dtos.ProductStockDto;
using OKR.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Queries.ProductStockQueries
{
    public class GetAllProductStockQuery : IRequest<List<GetAllProductStockDtoResponse>>
    {        

        public class GetAllProductStockQueryHandler : IRequestHandler<GetAllProductStockQuery, List<GetAllProductStockDtoResponse>>
        {
            private readonly ILogger<GetAllProductStockQueryHandler> _logger;
            private readonly IProductStockService _productStockService;

            public GetAllProductStockQueryHandler(ILogger<GetAllProductStockQueryHandler> logger, IProductStockService productStockService)
            {
                _logger = logger;
                _productStockService = productStockService;
            }

            public async Task<List<GetAllProductStockDtoResponse>> Handle(GetAllProductStockQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var productsStock = _productStockService.GetProducts();

                    var productStocks =await MapProducts(productsStock);


                    return productStocks;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            private async Task<List<GetAllProductStockDtoResponse>> MapProducts(List<OKR.Common.Domain.ProductStock> products)
            {
                List<GetAllProductStockDtoResponse> result = new List<GetAllProductStockDtoResponse>();
                foreach (var product in products)
                {
                    result.Add(new GetAllProductStockDtoResponse
                    {
                        Id = product.Id,
                        ProductId = product.ProductId,
                        SellingPrice = product.SellingPrice,
                        Quantity = product.Quantity,
                        Discount = product.Discount,
                        LastUpdated = product.LastUpdated,
                        Currency = product.Currency,
                    });
                }
                return await Task.FromResult(result); 
            }
        }
    
    }
}
