using ApplicationErrorException;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain;
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
    public class GetByIdProductStockQuery : IRequest<GetProductStockDtoResponse>
    {
        public int ProductStockId { get; set; }

        public GetByIdProductStockQuery(int productStockId)
        {
            ProductStockId = productStockId;
        }

        public class GetByIdProductStockQueryHandler : IRequestHandler<GetByIdProductStockQuery, GetProductStockDtoResponse>
        {
            private readonly ILogger<GetByIdProductStockQueryHandler> _logger;
            private readonly IProductStockService _productStockService;
            private readonly IMapper _mapper;

            public GetByIdProductStockQueryHandler(ILogger<GetByIdProductStockQueryHandler> logger, IProductStockService productStockService, IMapper mapper)
            {
                _logger = logger;
                _productStockService = productStockService;
                _mapper = mapper;
            }

            public async Task<GetProductStockDtoResponse> Handle(GetByIdProductStockQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var productsStock = _productStockService.GetById(request.ProductStockId);

                    if (productsStock is null)
                        throw new ApplicationErrorExceptions("No se encontro un producto stock con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                    var response = _mapper.Map<GetProductStockDtoResponse>(productsStock);

                    return response;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                    throw new ApplicationErrorExceptions("Hubo un error al buscar el producto stock.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);
                }
            }
            
        }
    }
}
