using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OKR.Common.Domain.Dtos.SellDto;
using Microsoft.Extensions.Logging;
using OKR.Common.Repositories.Interfaces;
using AutoMapper;
using ApplicationErrorException;

namespace Inventory.Services.EventHandler.Queries
{
    public class GetAllSellQuery : IRequest<List<GetSellDtoResponse>>
    {

        public class GetAllSellQueryHandler : IRequestHandler<GetAllSellQuery, List<GetSellDtoResponse>>
        {
            private readonly ILogger<GetAllSellQueryHandler> _logger;
            private readonly ISellCollection _sellCollection;
            private readonly IMapper _mapper;

            public GetAllSellQueryHandler(ILogger<GetAllSellQueryHandler> logger, ISellCollection sellCollection, IMapper mapper)
            {
                _logger = logger;
                _sellCollection = sellCollection;
                _mapper = mapper;
            }

            public async Task<List<GetSellDtoResponse>> Handle(GetAllSellQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var sells = _sellCollection.GetAllSell();

                    var sellDto = _mapper.Map<List<GetSellDtoResponse>>(sells.Result);

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
