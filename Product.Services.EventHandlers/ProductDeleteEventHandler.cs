using ApplicationErrorException;
using Identitty.Services.EventHandlers.Commands;
using Identitty.Services.EventHandlers;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Services.EventHandlers.Commands;
using System.Text.Json;

namespace Product.Services.EventHandlers
{
    public class ProductDeleteEventHandler : IRequestHandler<ProductDeleteCommand, BaseResult<string>>
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductDeleteEventHandler> _logger;

        public ProductDeleteEventHandler(IProductService productService, ILogger<ProductDeleteEventHandler> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Eliminando producto - {Request}", JsonSerializer.Serialize(request));
            try
            {

                var product = _productService.GetById(request.Id);

                if (product is null)
                    throw new ApplicationErrorExceptions("No se encontro un producto con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                _productService.Delete(product);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al eliminar el producto.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }

            return new BaseResult<string> { Success = true };

        }

    }
}
