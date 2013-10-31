using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SupermarketManagement
{
    class ProductVendorSales
    {
        [JsonProperty ("product-id")]
        public int ProductId { get; set; }

        [JsonProperty ("product-name")]
        public string ProductName { get; set; }

        [JsonProperty ("vendor-name")]
        public string VendorName { get; set; }

        [JsonProperty ("total-quantity-sold")]
        public int TotalQuantitySold { get; set; }

        [JsonProperty ("total-incomes")]
        public decimal TotalIncomes { get; set; }
    }
}
