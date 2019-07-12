using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStore.Domain;

namespace Data.ADO
{
    public class ProductsDAL
    {

        public string GetProductName()
        {
            string productNames = "";
            //create a SQLConnection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog =uStore; Integrated Security =true";
            //open the connection to the database
            conn.Open();
            //create a SQLCommand object
            SqlCommand cmdGetProducts = new SqlCommand("Select * from Products", conn);
            //execute the command
            SqlDataReader rdrGetProducts = cmdGetProducts.ExecuteReader();

            //process the DataReader (if data is to be returned)
            while (rdrGetProducts.Read())
            {
                productNames += (string)rdrGetProducts["Name"] + " ";
            }
            //close the connection to the database (this is critical)
            rdrGetProducts.Close();//optional, but strongly suggested.
            conn.Close();//REQUIRED!
            return productNames;
        }//end GetFirstName()

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog=uStore; Integrated Security =true";
                conn.Open();
                SqlCommand cmdGetProducts = new SqlCommand("Select * from Products", conn);
                SqlDataReader rdrProducts = cmdGetProducts.ExecuteReader();
                while (rdrProducts.Read())
                {
                    ProductModel prod = new ProductModel()
                    {
                        ProductID = (int)rdrProducts["ProductID"],
                        Name = (string)rdrProducts["Name"],
                        Description = (rdrProducts["Description"] is DBNull) ? "N/A" : (string)rdrProducts["Description"],
                        Price = (rdrProducts["Price"] is DBNull) ? 0m : (decimal)rdrProducts["Price"],
                        UnitsInStock = (rdrProducts["UnitsInStock"] is DBNull) ? 0 : (short)rdrProducts["UnitsInStock"],
                        ProductImage = (rdrProducts["ProductImage"] is DBNull) ? "N/A" : (string)rdrProducts["ProductImage"],
                        StatusId = (int)rdrProducts["StatusId"],
                        CategoryID = (rdrProducts["CategoryID"] is DBNull) ? 0 : (int)rdrProducts["CategoryID"],
                        Notes = (rdrProducts["Notes"] is DBNull) ? "N/A" : (string)rdrProducts["Notes"],
                        ReferenceURL = (rdrProducts["ReferenceURL"] is DBNull) ? "N/A" : (string)rdrProducts["ReferenceURL"]
                    };
                    products.Add(prod);
                }//end while
                rdrProducts.Close();
            }//end using
            return products;
        }//end GetProducts
        
        public void CreateProduct(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog =uStore; Integrated Security =true";
                conn.Open();
                SqlCommand cmdInsertProduct = new SqlCommand(
                    @"Insert into Products
                    (Name, Description, Price, UnitsInStock, ProductImage, StatusId, CategoryID, Notes, ReferenceURL)
                    Values(@Name, @Description, @Price, @UnitsInStock, @ProductImage, @StatusId, @CategoryID, @Notes, @ReferenceURL)", conn);

                cmdInsertProduct.Parameters.AddWithValue("Name", product.Name);

                if (product.Description != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue("Description", product.Description);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("Description", DBNull.Value);
                }

                if (product.Price != 0m)
                {
                    cmdInsertProduct.Parameters.AddWithValue("Price", product.Price);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("Price", DBNull.Value);
                }

                if (product.UnitsInStock != 0)
                {
                    cmdInsertProduct.Parameters.AddWithValue("UnitsInStock", product.UnitsInStock);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("UnitsInStock", DBNull.Value);
                }

                if (product.ProductImage != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue("ProductImage", product.ProductImage);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("ProductImage", DBNull.Value);
                }

                cmdInsertProduct.Parameters.AddWithValue("StatusId", product.StatusId);

                if (product.CategoryID != 0)
                {
                    cmdInsertProduct.Parameters.AddWithValue("CategoryID", product.CategoryID);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("CategoryID", DBNull.Value);
                }

                if (product.Notes != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue("Notes", product.Notes);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("Notes", DBNull.Value);
                }

                if (product.ReferenceURL != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue("ReferenceURL", product.ReferenceURL);
                }
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue("ReferenceURL", DBNull.Value);
                }

                cmdInsertProduct.ExecuteNonQuery(); //CUD (create, update, and delete)
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog =uStore; Integrated Security =true";
                conn.Open();
                SqlCommand cmdDeleteProduct = new SqlCommand("Delete from Products where ProductID = @ProductID", conn);

                cmdDeleteProduct.Parameters.AddWithValue("ProductID", id);
                cmdDeleteProduct.ExecuteNonQuery();
            }//end using
        }//end DeleteAuthor()

        public ProductModel GetProduct(int id)
        {
            ProductModel prod = null;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog =uStore; Integrated Security =true";
                conn.Open();
                SqlCommand cmdGetProduct = new SqlCommand("Select * from Products where ProductID = @ProductID", conn);
                cmdGetProduct.Parameters.AddWithValue("ProductID", id);
                SqlDataReader rdrProducts = cmdGetProduct.ExecuteReader();
                if (rdrProducts.Read())
                {
                    prod = new ProductModel()
                    {
                        ProductID = (int)rdrProducts["ProductID"],
                        Name = (string)rdrProducts["Name"],
                        Description = (rdrProducts["Description"] is DBNull) ? "" : (string)rdrProducts["Description"],
                        Price = (rdrProducts["Price"] is DBNull) ? 0m : (decimal)rdrProducts["Price"],
                        UnitsInStock = (rdrProducts["UnitsInStock"] is DBNull) ? 0 : (short)rdrProducts["UnitsInStock"],
                        ProductImage = (rdrProducts["ProductImage"] is DBNull) ? "" : (string)rdrProducts["ProductImage"],
                        StatusId = (int)rdrProducts["StatusId"],
                        CategoryID = (rdrProducts["CategoryID"] is DBNull) ? 0 : (int)rdrProducts["CategoryID"],
                        Notes = (rdrProducts["Notes"] is DBNull) ? "" : (string)rdrProducts["Notes"],
                        ReferenceURL = (rdrProducts["ReferenceURL"] is DBNull) ? "" : (string)rdrProducts["ReferenceURL"]
                    };
                }//end if
                rdrProducts.Close();
            }//end using
            return prod;
        }//end getProduct()

        public void UpdateProduct(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog =uStore; Integrated Security =true";
                conn.Open();
                SqlCommand cmdUpdateProduct = new SqlCommand("Update Products set Name = @Name, Description = @Description, Price = @Price, UnitsInStock = @UnitsInStock, ProductImage = @ProductImage, StatusId = @StatusId, CategoryID = @CategoryID, Notes = @Notes, ReferenceURL = @ReferenceURL Where ProductID = @ProductID", conn);

                cmdUpdateProduct.Parameters.AddWithValue("ProductID", product.ProductID);
                cmdUpdateProduct.Parameters.AddWithValue("Name", product.Name);

                if (product.Description != null && product.Description != "")
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Description", product.Description);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Description", DBNull.Value);
                }//end if

                if (product.Price != 0m)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Price", product.Price);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Price", DBNull.Value);
                }//end if

                if (product.UnitsInStock != 0)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("UnitsInStock", product.UnitsInStock);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("UnitsInStock", DBNull.Value);
                }//end if

                if (product.ProductImage != null && product.ProductImage != "")
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ProductImage", product.ProductImage);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ProductImage", DBNull.Value);
                }//end if

                cmdUpdateProduct.Parameters.AddWithValue("StatusId", product.StatusId);
               
                if (product.CategoryID != 0)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("CategoryID", product.CategoryID);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("CategoryID", DBNull.Value);
                }//end if

                if (product.Notes != null && product.Notes != "")
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Notes", product.Notes);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Notes", DBNull.Value);
                }//end if

                if (product.ReferenceURL != null && product.ReferenceURL != "")
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ReferenceURL", product.ReferenceURL);
                }
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ReferenceURL", DBNull.Value);
                }//end if
                cmdUpdateProduct.ExecuteNonQuery();
            }//end using
        }//end updateproduct()
    }//end class
}//end namespace
