using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace IMS2.Codes
{
    public class ProductContext 
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public ServerToClient GetProductSimple()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT p.ID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, p.PackageSize FROM product p INNER JOIN category c ON p.Category=c.ID", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }
        public ServerToClient GetProducts()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT p.ID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, d.ID AS ProductDetailID, d.BuyingValue, d.SellingValue, d.MfgDate, d.ExpDate, p.PackageSize, d.Quantity, d.BarCode FROM product p INNER JOIN productdetail d ON p.ID = d.ProductID INNER JOIN category AS c ON p.Category = c.ID", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProductDetailFull()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            cmd = new MySqlCommand("SELECT p.ID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, p.PackageSize, Sum(d.Quantity) AS TotalQuantity FROM product AS p INNER JOIN category AS c ON p.Category = c.ID INNER JOIN productdetail d ON d.ProductID = p.ID GROUP BY p.ID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, p.PackageSize", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "product");

            cmd = new MySqlCommand("SELECT ID, ProductID, BuyingValue, SellingValue, MfgDate, ExpDate, Quantity, BarCode FROM productdetail", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "productdetail");
            DataColumn pk = ds.Tables[0].Columns[0];
            DataColumn fk = ds.Tables[1].Columns[1];
            sc.Message = "pk_fk";
            ds.Relations.Add(sc.Message, pk, fk);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DS = ds;
            return sc;
        }

        public ServerToClient GetProductReport()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT p.ID AS PID, d.ID AS DID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, d.BuyingValue, d.SellingValue, d.MfgDate, d.ExpDate, p.PackageSize, Sum(d.Quantity) AS TotalQuantity, Sum(d.Quantity) AS TotalQuantity, Sum(d.Quantity) * d.BuyingValue AS TotalBuyingValue, Sum(d.Quantity) * d.SellingValue AS TotalSellingValue FROM product AS p INNER JOIN productdetail AS d ON p.ID = d.ProductID INNER JOIN category AS c ON p.Category = c.ID GROUP BY c.CategoryName, p.SubCategory, p.Company, p.ProductName, d.BuyingValue, d.SellingValue, d.MfgDate, d.ExpDate, p.PackageSize", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProductReport(string SearchField, string SearchText)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT p.ID AS PID, d.ID AS DID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, d.BuyingValue, d.SellingValue, d.MfgDate, d.ExpDate, p.PackageSize, Sum(d.Quantity) AS TotalQuantity FROM product AS p INNER JOIN productdetail AS d ON p.ID = d.ProductID INNER JOIN category AS c ON p.Category = c.ID WHERE " + SearchField + " LIKE '%" + SearchText + "%' GROUP BY c.CategoryName, p.SubCategory, p.Company, p.ProductName, d.BuyingValue, d.SellingValue, d.MfgDate, d.ExpDate, p.PackageSize", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProductDetailSimple()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            cmd = new MySqlCommand("SELECT p.ID, c.CategoryName, p.SubCategory, p.Company, p.ProductName, p.PackageSize FROM product p INNER JOIN category c ON p.Category=c.ID", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "product");

            cmd = new MySqlCommand("SELECT ProductID, BuyingValue, SellingValue, MfgDate, ExpDate, SUM(Quantity) AS Quantity FROM productdetail GROUP BY ProductID, BuyingValue, SellingValue, MfgDate, ExpDate", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "productdetail");
            DataColumn pk = ds.Tables[0].Columns[0];
            DataColumn fk = ds.Tables[1].Columns[0];
            sc.Message = "pk_fk";
            ds.Relations.Add(sc.Message, pk, fk);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DS = ds;
            return sc;
        }

        public ServerToClient GetProductsFull()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT p.ID, p.Company, p.ProductName, p.BarCode, p.BuyingValue, p.BuyingValue*p.Quantity AS TotalBuyingValue, p.SellingValue, p.SellingValue*p.Quantity AS TotalSellingValue, p.MfgDate, p.ExpDate, c.CategoryName, p.SubCategory, p.PackageSize, p.Quantity FROM product p INNER JOIN category c ON p.Category=c.ID", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProductsSimple()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT p.Company, p.ProductName, p.BuyingValue, p.BuyingValue*SUM(p.Quantity) AS TotalBuyingValue, p.SellingValue, p.SellingValue*SUM(p.Quantity) AS TotalSellingValue, p.MfgDate, p.ExpDate, c.CategoryName, p.SubCategory, p.PackageSize, SUM(p.Quantity) AS Quantity FROM product p INNER JOIN category c ON p.Category=c.ID GROUP BY p.Company, p.ProductName, p.BuyingValue, p.SellingValue, p.MfgDate, p.ExpDate, c.CategoryName, p.SubCategory, p.PackageSize", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProducts(int Category)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE Category=" + Category, cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }
        public ServerToClient GetProducts(string SubCategory)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE SubCategory='" + SubCategory + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProducts(string Company, bool f)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE Company='" + Company + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProducts(int Category, string SubCategory)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE Category=" + Category + " AND SubCategory='" + SubCategory + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProducts(string SubCategory, string Company)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE SubCategory='" + SubCategory + "' AND Company='" + Company + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetProducts(int Category, string SubCategory, string Company)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE Category=" + Category + " AND SubCategory='" + SubCategory + "' AND Company='" + Company + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public Product GetProduct(int ID)
        {
            Product p = new Product();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Category, SubCategory, Company, ProductName, PackageSize FROM product WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                p.Category = Convert.ToInt32(rd[1]);
                p.SubCategory = rd[2].ToString();
                p.Company = rd[3].ToString();
                p.ProductName = rd[4].ToString();
                p.PackageSize = rd[5].ToString();
            }
            catch {; }
            finally { cm.Close(); }
            return p;
        }

        public ProductDetail GetProductDetail(int ID)
        {
            ProductDetail d = new ProductDetail();
            MySqlCommand cmd = new MySqlCommand("SELECT ProductID, BuyingValue, SellingValue, MfgDate, ExpDate, Quantity, BarCode, SupplierID FROM productdetail WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                d.ID = ID;
                d.ProductID = Convert.ToInt32(rd[0]);
                d.BuyingValue = Convert.ToDouble(rd[1]);
                d.SellingValue = Convert.ToDouble(rd[2]);
                d.MfgDate = rd[3].ToString();
                d.ExpDate = rd[4].ToString();
                d.Quantity = Convert.ToInt32(rd[5]);
                d.BarCode = rd[6].ToString();
                d.Supplier = Convert.ToInt32(rd[7]);
            }
            catch{; }
            finally { cm.Close(); }
            return d;
        }

        public Product GetProduct(string BarCode)
        {
            Product p = new Product();
            MySqlCommand cmd = new MySqlCommand("SELECT p.ID, p.Category, p.SubCategory, p.Company, p.ProductName, p.PackageSize FROM product p INNER JOIN productdetail d ON p.ID = d.ProductID WHERE d.BarCode='" + BarCode + "'", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    p.ID = Convert.ToInt32(rd[0]);
                    p.Category = Convert.ToInt32(rd[1]);
                    p.SubCategory = rd[2].ToString();
                    p.Company = rd[3].ToString();
                    p.ProductName = rd[4].ToString();
                    p.PackageSize = rd[5].ToString();
                }
                else
                {
                    p.Message = "Product not found";
                }
            }
            catch {; }
            finally { cm.Close(); }
            return p;
        }

        public ProductDetail GetProductDetail(string BarCode)
        {
            ProductDetail p = new ProductDetail();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, ProductID, BuyingValue, SellingValue, MfgDate, ExpDate, Quantity, Barcode FROM productdetail WHERE BarCode='" + BarCode + "' AND Quantity>=1", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    p.ID = Convert.ToInt32(rd[0]);
                    p.ProductID = Convert.ToInt32(rd[1]);
                    p.BuyingValue = Convert.ToDouble(rd[2]);
                    p.SellingValue = Convert.ToDouble(rd[3]);
                    p.MfgDate = rd[4].ToString();
                    p.ExpDate = rd[5].ToString();
                    p.Quantity = Convert.ToInt32(rd[6]);
                    p.BarCode = rd[7].ToString();
                }
                else
                {
                }
            }
            catch {; }
            finally { cm.Close(); }
            return p;
        }

        public ServerToClient AddProduct(Product p)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO product (Category, SubCategory, Company, ProductName, PackageSize) VALUES (@CAT, @SCT, @CMP, @PNM, @PKG)", cm);
            cmd.Parameters.AddWithValue("@CAT", p.Category);
            cmd.Parameters.AddWithValue("@SCT", p.SubCategory);
            cmd.Parameters.AddWithValue("@CMP", p.Company);
            cmd.Parameters.AddWithValue("@PNM", p.ProductName);
            cmd.Parameters.AddWithValue("@PKG", p.PackageSize);

            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                sc.Count = (int)cmd.LastInsertedId;
            }
            catch(Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient AddProductDetail(ProductDetail d)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO productdetail(ProductID, BuyingValue, SellingValue, MfgDate, ExpDate, Quantity, BarCode, SupplierID) VALUES(@PID, @BVL, @SVL, @MFG, @EXP, @QTY, @BCD, @SUP)", cm);
            cmd.Parameters.AddWithValue("@PID", d.ProductID);
            cmd.Parameters.AddWithValue("@BVL", d.BuyingValue);
            cmd.Parameters.AddWithValue("@SVL", d.SellingValue);
            cmd.Parameters.AddWithValue("@MFG", d.MfgDate);
            cmd.Parameters.AddWithValue("@EXP", d.ExpDate);
            cmd.Parameters.AddWithValue("@QTY", d.Quantity);
            cmd.Parameters.AddWithValue("@BCD", d.BarCode);
            cmd.Parameters.AddWithValue("@SUP", d.Supplier);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                sc.Count = (int)cmd.LastInsertedId;
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient UpdateProduct(Product p)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE product SET Category=@CAT, SubCategory=@SCT, Company=@CMP, ProductName=@PNM, PackageSize=@PKG WHERE ID=" + p.ID, cm);
            cmd.Parameters.AddWithValue("@CAT", p.Category);
            cmd.Parameters.AddWithValue("@SCT", p.SubCategory);
            cmd.Parameters.AddWithValue("@CMP", p.Company);
            cmd.Parameters.AddWithValue("@PNM", p.ProductName);
            cmd.Parameters.AddWithValue("@PKG", p.PackageSize);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient UpdateProductDetail(ProductDetail d)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE productdetail SET BuyingValue=@BVL, SellingValue=@SVL, MfgDate=@MFG, ExpDate=@EXP, Quantity=@QTY, BarCode=@BCD, SupplierID=@SUP WHERE ID=" + d.ID, cm);
            cmd.Parameters.AddWithValue("@BVL", d.BuyingValue);
            cmd.Parameters.AddWithValue("@SVL", d.SellingValue);
            cmd.Parameters.AddWithValue("@MFG", d.MfgDate);
            cmd.Parameters.AddWithValue("@EXP", d.ExpDate);
            cmd.Parameters.AddWithValue("@QTY", d.Quantity);
            cmd.Parameters.AddWithValue("@BCD", d.BarCode);
            cmd.Parameters.AddWithValue("@SUP", d.Supplier);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient DeleteProduct(int ID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM product WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient DeleteProductDetail(int ID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM productdetail WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient updateQuantity(int ID, int Value, string type)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE productdetail SET Quantity=Quantity" + type + "" + Value + " WHERE ID=" + ID, cm);

            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient GetCompany()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Company FROM product ORDER BY Company", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetCompany(string SubCategory)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Company FROM product WHERE SubCategory='" + SubCategory + "' ORDER BY Company", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }
        public ServerToClient GetCompany(int Category)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Company FROM product WHERE Category=" + Category + "  ORDER BY Company", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetCompany(int Category, string SubCategory)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Company FROM product WHERE Category=" + Category + " AND SubCategory='" + SubCategory + "'  ORDER BY Company", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        #region Category

        public ServerToClient GetCategories()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, CategoryName FROM category", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public Category GetCategory(int ID)
        {
            Category c = new Category();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, CategoryName FROM category WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                c.ID = Convert.ToInt32(rd[0]);
                c.CategoryName = rd[1].ToString();
            }
            catch {; }
            finally { cm.Close(); }
            return c;
        }

        public ServerToClient GetSubCategory(int CategoryID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT SubCategory FROM product WHERE Category=" + CategoryID + " ORDER BY SubCategory", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetSubCategory()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT SubCategory FROM product ORDER BY SubCategory", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient AddCategory(Category c)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd;
            cmd = new MySqlCommand("INSERT INTO category (CategoryName) VALUES (@CNM)", cm);
            cmd.Parameters.AddWithValue("@CNM", c.CategoryName);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                sc.Count = (int)cmd.LastInsertedId;
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }

            return sc;
        }

        public ServerToClient UpdateCategory(Category c)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE category SET CategoryName=@CNM WHERE ID=" + c.ID, cm);
            cmd.Parameters.AddWithValue("@CNM", c.CategoryName);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient DeleteCategory(int ID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM category WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }
        


        #endregion
    }
}
