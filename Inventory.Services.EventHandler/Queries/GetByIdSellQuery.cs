using ApplicationErrorException;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain.Dtos.SellDto;
using OKR.Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Services.EventHandler.Queries
{
    public class GetByIdSellQuery : IRequest<GetSellDtoResponse>
    {
        public string SellId { get; set; }

        public GetByIdSellQuery(string sellId)
        {
            SellId = sellId;
        }

        public class GetByIdSellQueryHandler : IRequestHandler<GetByIdSellQuery, GetSellDtoResponse>
        {
            private readonly ILogger<GetByIdSellQueryHandler> _logger;
            private readonly ISellCollection _sellCollection;
            private readonly IMapper _mapper;

            public GetByIdSellQueryHandler(ILogger<GetByIdSellQueryHandler> logger, ISellCollection sellCollection, IMapper mapper)
            {
                _logger = logger;
                _sellCollection = sellCollection;
                _mapper = mapper;
            }

            public async Task<GetSellDtoResponse> Handle(GetByIdSellQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var sells = _sellCollection.GetSellById(request.SellId);

                    var sellDto = _mapper.Map<GetSellDtoResponse>(sells.Result);

                    return sellDto;
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                    throw new ApplicationErrorExceptions("Hubo un error al buscar las ventas.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);
                }
            }
        }
    }
}
