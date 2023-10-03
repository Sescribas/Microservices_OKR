using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Configuration.Configurations.ProductApi
{
    public class ProductApiConfigurationsOptions
    { 

        public string Host { get; set; } = null!;

        public EndPoints EndPoints { get; set; } = null!;
    }

    public class EndPoints
    {
        #region Category
        public string CreateCategory { get; set; }
        public string UpdateCategory { get; set; }
        public string DeleteCategory { get; set; }
        public string GetAllCategory { get; set; }

        #endregion

        #region Product
        public string CreateProduct { get; set; }
        public string UpdateProduct { get; set; }
        public string DeleteProduct { get; set; }
        public string GetAllProduct { get; set; }
        public string GetByIdProduct { get; set; }
        public string GetByCategoryIdProduct { get; set; }        
        #endregion

        #region ProductStock
        public string CreateProductStock { get; set; }
        public string UpdateProductStock { get; set; }
        public string GetAllProductStock { get; set; }
        public string GetByIdProductStock { get; set; }

        #endregion

    }

}
