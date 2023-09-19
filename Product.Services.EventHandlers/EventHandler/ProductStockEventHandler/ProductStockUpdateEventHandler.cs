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
    public class ProductStockUpdateEventHandler : IRequestHandler<ProductStockUpdateCommand, BaseResult<string>>
    {
        private readonly IProductStockService _productStockService;
        private readonly ILogger<ProductStockUpdateEventHandler> _logger;

        public ProductStockUpdateEventHandler(IProductStockService productStockService, ILogger<ProductStockUpdateEventHandler> logger)
        {
            _productStockService = productStockService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(ProductStockUpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Actualizando producto stock - {Request}", JsonSerializer.Serialize(request));
            try
            {
                var productStock = _productStockService.GetById(request.Id);
                if (productStock is null)
                    throw new ApplicationErrorExceptions("No se encontro un producto stock con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                productStock.SellingPrice = request.SellingPrice;
                productStock.Quantity = request.Quantity;
                productStock.Discount = request.Discount;
                productStock.Currency = request.Currency;
              
                _productStockService.Update(productStock);

            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al actualizar el producto stock.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }
    }
}
