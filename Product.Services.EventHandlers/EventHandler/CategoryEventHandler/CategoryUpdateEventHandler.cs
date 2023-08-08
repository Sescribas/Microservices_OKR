using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductCategoryCommand;
using Product.Services.EventHandlers.Commands.ProductCommand;
using Product.Services.EventHandlers.EventHandler.ProductEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.EventHandler.CategoryEventHandler
{
    public class CategoryUpdateEventHandler : IRequestHandler<CategoryUpdateCommand, BaseResult<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryUpdateEventHandler> _logger;

        public CategoryUpdateEventHandler(ICategoryService categoryService, ILogger<CategoryUpdateEventHandler> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Actualizando categoria - {Request}", JsonSerializer.Serialize(request));
            try
            {
                var category = _categoryService.GetById(request.Id);
                if (category is null)
                    throw new ApplicationErrorExceptions("No se encontro una categoria con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                category.Name = request.Name;
                category.Description = request.Description;

                _categoryService.Update(category);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al actualizar la categoria.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }

    }
}
