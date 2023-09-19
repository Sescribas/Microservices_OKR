using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductStockCommand;
using Product.Services.EventHandlers.EventHandler.ProductEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.EventHandler.ProductStockEventHandler
{
    public class ProductStockDeleteEventHandler : IRequestHandler<ProductStockDeleteCommand, BaseResult<string>>
    {
        private readonly IProductService _productService;
        private readonly IProductStockService _productStockService;

        private readonly ILogger<ProductStockDeleteEventHandler> _logger;

        public ProductStockDeleteEventHandler(IProductService productService, IProductStockService productStockService, ILogger<ProductStockDeleteEventHandler> logger)
        {
            _productService = productService;
            _logger = logger;
            _productStockService = productStockService;
        }

        public async Task<BaseResult<string>> Handle(ProductStockDeleteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Eliminando producto stock - {Request}", JsonSerializer.Serialize(request));
            try
            {

                var productStock = _productStockService.GetById(request.Id);

                if (productStock is null)
                    throw new ApplicationErrorExceptions("No se encontro un producto stock con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                var product = _productService.GetById(productStock.ProductId);

                if (product is null)
                    throw new ApplicationErrorExceptions("No se encontro un producto con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                productStock.Product = null;
                product.ProductStock = null;

                _productService.Update(product);
                _productStockService.Delete(productStock);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al eliminar el producto stock.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }

            return new BaseResult<string> { Success = true };

        }
    }
}
