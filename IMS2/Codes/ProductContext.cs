using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace IMS2.Codes
{
    public class ProductContext 
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        public ServerToClient GetProducts()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
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

        public Product GetProduct(int ID)
        {
            Product p = new Product();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                p.Company = rd[1].ToString();
                p.ProductName = rd[2].ToString();
                p.BarCode = rd[3].ToString();
                p.BuyingValue = Convert.ToDouble(rd[4]);
                p.SellingValue = Convert.ToDouble(rd[5]);
                p.MfgDate = rd[6].ToString();
                p.ExpDate = rd[7].ToString();
                p.Category = Convert.ToInt32(rd[8]);
                p.SubCategory = rd[9].ToString();
                p.PackageSize = rd[10].ToString();
                p.Quantity = Convert.ToInt32(rd[11]);
            }
            catch {; }
            finally { cm.Close(); }
            return p;
        }

        public Product GetProduct(string BarCode)
        {
            Product p = new Product();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity FROM product WHERE BarCode='" + BarCode + "'", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    p.Company = rd[1].ToString();
                    p.ProductName = rd[2].ToString();
                    p.BarCode = rd[3].ToString();
                    p.BuyingValue = Convert.ToDouble(rd[4]);
                    p.SellingValue = Convert.ToDouble(rd[5]);
                    p.MfgDate = rd[6].ToString();
                    p.ExpDate = rd[7].ToString();
                    p.Category = Convert.ToInt32(rd[8]);
                    p.SubCategory = rd[9].ToString();
                    p.PackageSize = rd[10].ToString();
                    p.Quantity = Convert.ToInt32(rd[11]);
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

        public ServerToClient AddProduct(Product p)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO product (Company, ProductName, BarCode, BuyingValue, SellingValue, MfgDate, ExpDate, Category, SubCategory, PackageSize, Quantity) VALUES (@CMP, @PNM, @BCD, @BVL, @SVL, @MFG, @EXP, @CAT, @SCT, @PKG, @QTY)", cm);
            cmd.Parameters.AddWithValue("@CMP", p.Company);
            cmd.Parameters.AddWithValue("@PNM", p.ProductName);
            cmd.Parameters.AddWithValue("@BCD", p.BarCode);
            cmd.Parameters.AddWithValue("@BVL", p.BuyingValue);
            cmd.Parameters.AddWithValue("@SVL", p.SellingValue);
            cmd.Parameters.AddWithValue("@MFG", p.MfgDate);
            cmd.Parameters.AddWithValue("@EXP", p.ExpDate);
            cmd.Parameters.AddWithValue("@CAT", p.Category);
            cmd.Parameters.AddWithValue("@SCT", p.SubCategory);
            cmd.Parameters.AddWithValue("@PKG", p.PackageSize);
            cmd.Parameters.AddWithValue("@QTY", p.Quantity);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient UpdateProduct(Product p)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE product SET Company=@CMP, ProductName=@PNM, BarCode=@BCD, BuyingValue=@BVL, SellingValue=@SVL, MfgDate=@MFG, ExpDate=@EXP, Category=@CAT, SubCategory=@SCT, PackageSize=@PKG, Quantity=@QTY WHERE ID=" + p.ID, cm);
            cmd.Parameters.AddWithValue("@CMP", p.Company);
            cmd.Parameters.AddWithValue("@PNM", p.ProductName);
            cmd.Parameters.AddWithValue("@BCD", p.BarCode);
            cmd.Parameters.AddWithValue("@BVL", p.BuyingValue);
            cmd.Parameters.AddWithValue("@SVL", p.SellingValue);
            cmd.Parameters.AddWithValue("@MFG", p.MfgDate);
            cmd.Parameters.AddWithValue("@EXP", p.ExpDate);
            cmd.Parameters.AddWithValue("@CAT", p.Category);
            cmd.Parameters.AddWithValue("@SCT", p.SubCategory);
            cmd.Parameters.AddWithValue("@PKG", p.PackageSize);
            cmd.Parameters.AddWithValue("@QTY", p.Quantity);
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

        public ServerToClient GetCompany()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Company FROM product", cm);
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
            MySqlCommand cmd = new MySqlCommand("DELETE FROM category ID=" + ID, cm);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
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

        #endregion
    }
}
