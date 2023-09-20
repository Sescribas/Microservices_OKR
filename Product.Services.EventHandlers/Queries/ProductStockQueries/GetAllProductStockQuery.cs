using ApplicationErrorException;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain.Dtos.ProductStockDto;
using OKR.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Queries.ProductStockQueries
{
    public class GetAllProductStockQuery : IRequest<List<GetProductStockDtoResponse>>
    {        

        public class GetAllProductStockQueryHandler : IRequestHandler<GetAllProductStockQuery, List<GetProductStockDtoResponse>>
        {
            private readonly ILogger<GetAllProductStockQueryHandler> _logger;
            private readonly IProductStockService _productStockService;
            private readonly IMapper _mapper;

            public GetAllProductStockQueryHandler(ILogger<GetAllProductStockQueryHandler> logger, IProductStockService productStockService,IMapper mapper)
            {
                _logger = logger;
                _productStockService = productStockService;
                _mapper = mapper;
            }

            public async Task<List<GetProductStockDtoResponse>> Handle(GetAllProductStockQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var productsStock = _productStockService.GetProducts();

                    var productStocks = _mapper.Map<List<GetProductStockDtoResponse>>(productsStock);

                    return productStocks;
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                    throw new ApplicationErrorExceptions("Hubo un error al buscar los producto stock.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);
                }
            }
            
        }
    
    }
}
