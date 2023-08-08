using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.EventHandler.ProductEventHandler
{
    public class ProductUpdateEventHandler : IRequestHandler<ProductUpdateCommand, BaseResult<string>>
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductUpdateEventHandler> _logger;

        public ProductUpdateEventHandler(IProductService productService, ILogger<ProductUpdateEventHandler> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Actualizando producto - {Request}", JsonSerializer.Serialize(request));
            try
            {
                var product = _productService.GetById(request.Id);
                if (product is null)
                    throw new ApplicationErrorExceptions("No se encontro un producto con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                product.Name = request.Name;
                product.Description = request.Description;
                product.Brand = request.Brand;
                product.FabricationDate = request.FabricationDate;
                product.ExpirationDate = request.ExpirationDate;

                _productService.Update(product);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al actualizar el producto.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }

    }
}
