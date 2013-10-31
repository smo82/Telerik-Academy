/*
 * Task01
 * Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
 * 
 * Task02
 * Write a program that retrieves the name and description of all categories in the Northwind DB.
 * 
 * Task03
 * Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. 
 * Can you do this with a single SQL query (with table join)?
 * 
 * Task04
 * Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
 * 
 * Task05
 * Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
 * 
 * Task06
 * Create an Excel file with 2 columns: name and score:
 * Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
 */

using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace _01.CategiesCount
{
    class CountCategories
    {
        private const string IMAGE_TARGET_FOLDER = @"..\..\ExportedImages\";

        static void Main()
        {
            string connectionString = Settings.Default.DbConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                //Task01
                CategoriesCount(connection);

                //Task02
                GetCategoriesInfo(connection);

                //Task03
                GetProductsByCategory(connection);

                //Task04
                AddProduct(connection);

                //Task05
                ExtractCategoryImages(connection);
            }

            string excelConnectionString = Settings.Default.ExcelConnectionString;
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

            excelConnection.Open();
            using (excelConnection)
            {
                //Task06
                ConnectToExcelFile(excelConnection);

                //Task07
                SetDataExcelFile(excelConnection);
            }
        }

        private static void SetDataExcelFile(OleDbConnection excelConnection)
        {
            //Task07
            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("Enter data in the excel file");
            OleDbCommand setExcelSheetData = new OleDbCommand(
                "INSERT INTO [Sheet$] ([Name], [Score]) " +
                "VALUES (@name, @score)", excelConnection);
            setExcelSheetData.Parameters.AddWithValue("@name", "New Person");
            setExcelSheetData.Parameters.AddWithValue("@score", "27");
            setExcelSheetData.ExecuteNonQuery();
        }

        private static void ConnectToExcelFile(OleDbConnection excelConnection)
        {
            //Task06
            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("The data (name and score) from the excel file is:");
            OleDbCommand getExcelSheetData = new OleDbCommand(
                "SELECT [Name], [Score] " +
                "FROM [Sheet$]", excelConnection);

            OleDbDataReader reader = getExcelSheetData.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];

                    Console.WriteLine("{0} - {1}", name, score);
                }
            }
        }

        private static void ExtractCategoryImages(SqlConnection connection)
        {
            //Task05
            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("Retrieve category images");

            SqlCommand cmdGetCategoryImages = new SqlCommand(
                "SELECT [CategoryName], [Picture] " +
                "FROM Categories " +
                "WHERE [Picture] IS NOT NULL", connection);

            SqlDataReader reader = cmdGetCategoryImages.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    categoryName = categoryName.Replace('/', ' ');
                    byte[] image = (byte[])reader["Picture"];

                    WriteBinaryFile(IMAGE_TARGET_FOLDER + categoryName + ".jpg", image);
                }
            }
        }

        private static void AddProduct(SqlConnection connection)
        {
            //Task04
            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("Add new product in the database:");

            SqlCommand cmdAddProduct = new SqlCommand(
                "INSERT INTO Products ([ProductName], [Discontinued]) " +
                "VALUES (@productName, @discontinued)", connection);
            cmdAddProduct.Parameters.AddWithValue("@productName", "NewProduct");
            cmdAddProduct.Parameters.AddWithValue("@discontinued", 0);
            try
            {
                cmdAddProduct.ExecuteNonQuery();
                Console.WriteLine("Row inserted successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL error occured: {0}", e);
            }
        }

        private static void GetProductsByCategory(SqlConnection connection)
        {
            //Task03
            SqlCommand cmdGetProductsByCategory = new SqlCommand(
                "SELECT [CategoryName], [ProductName] " +
                "FROM Categories c " +
                "JOIN Products p " +
                "ON c.CategoryID = p.CategoryID", connection);

            SqlDataReader reader = cmdGetProductsByCategory.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("The products by category are:");
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }
        }

        private static void GetCategoriesInfo(SqlConnection connection)
        {
            //Task02
            SqlCommand cmdGetCategoriesInfo = new SqlCommand("SELECT [CategoryName], [Description] FROM Categories", connection);
            SqlDataReader reader = cmdGetCategoriesInfo.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("The categories name and description are:");
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string categoryDescription = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", categoryName, categoryDescription);
                }
            }
        }

        private static void CategoriesCount(SqlConnection connection)
        {
            //Task01
            SqlCommand cmdCountCategories = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
            int categoriesCount = (int)cmdCountCategories.ExecuteScalar();

            Console.WriteLine("The number of records in the Categories table is {0}", categoriesCount);
        }

        private static void WriteBinaryFile(string fileName,
            byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }
    }
}