using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSQLEntityModel;
using OpenAccessModelSupermarkets;

namespace SupermarketManagement
{
    public class ConvertMySqlToMSSQL
    {
        public static MSSQLEntityModel.Product ConvertMySqlToMSSQLProduct(OpenAccessModelSupermarkets.Product mySqlProduct)
        {
            MSSQLEntityModel.Product mssqlProduct = new MSSQLEntityModel.Product();
            mssqlProduct.ProductName = mySqlProduct.ProductName;
            mssqlProduct.ProductPrice = mySqlProduct.ProductPrice;
            mssqlProduct.VendorId = mySqlProduct.VendorId;
            mssqlProduct.MeasureId = mySqlProduct.MeasureId;
            mssqlProduct.ProductsId = mySqlProduct.ProductId;

            return mssqlProduct;
        }

        public static MSSQLEntityModel.Measure ConvertMySqlToMSSQLMeasure(OpenAccessModelSupermarkets.Measure mySqlMeasure)
        {
            MSSQLEntityModel.Measure mssqlMeasure = new MSSQLEntityModel.Measure();
            mssqlMeasure.MeasureName = mySqlMeasure.MeasureName;
            var test = mySqlMeasure.MeasureId;
            mssqlMeasure.MeasureId = mySqlMeasure.MeasureId;

            return mssqlMeasure;
        }

        public static MSSQLEntityModel.Vendor ConvertMySqlToMSSQLVendor(OpenAccessModelSupermarkets.Vendor mySqlVendor)
        {
            MSSQLEntityModel.Vendor mssqlVendor = new MSSQLEntityModel.Vendor();
            mssqlVendor.VendorName = mySqlVendor.VendorName;
            mssqlVendor.VendorId = mySqlVendor.VendorId;

            return mssqlVendor;
        }
    }
}
