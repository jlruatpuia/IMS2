using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace IMS2.Codes
{
    class SalesContext
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public ServerToClient AddSale(Sale s)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Sale (InvoiceNo, SellDate, Customer, Amount, Discount, Payment, Balance) VALUES (@INV, @SDT, @CID, @AMT, @DSC, @PMT, @BAL)", cm);
            cmd.Parameters.AddWithValue("@INV", s.InvoiceNo);
            cmd.Parameters.AddWithValue("@SDT", s.SellDate);
            cmd.Parameters.AddWithValue("@CID", s.Customer);
            cmd.Parameters.AddWithValue("@AMT", s.Amount);
            cmd.Parameters.AddWithValue("@DSC", s.Discount);
            cmd.Parameters.AddWithValue("@PMT", s.Payment);
            cmd.Parameters.AddWithValue("@BAL", s.Balance);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { sc.Message = ex.Message; }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient AddSaleDetails(SaleDetail sd)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO SaleDetail (InvoiceNo, Product, Quantity, BuyingValue, SellingValue, Amount) VALUES (@INV, @PID, @QTY, @BVL, @SVL, @TAM)", cm);
            cmd.Parameters.AddWithValue("@INV", sd.InvoiceNo);
            cmd.Parameters.AddWithValue("@PID", sd.Product);
            cmd.Parameters.AddWithValue("@QTY", sd.Quantity);
            cmd.Parameters.AddWithValue("@BVL", sd.BuyingValue);
            cmd.Parameters.AddWithValue("@SVL", sd.SellingValue);
            cmd.Parameters.AddWithValue("@TAM", sd.Amount);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                sc.Count = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient GetSales()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT InvoiceNo FROM sale ORDER BY InvoiceNo", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        //public ServerToClient QuickSaleReceipt(string InvoiceNo)
        //{
        //    ServerToClient sc = new ServerToClient();
        //    MySqlCommand cmd = new MySqlCommand("SELECT sale.InvoiceNo, sale.SellDate, product.ProductName, product.PackageSize, saledetail.SellingValue * saledetail.Quantity AS Amount, saledetail.Quantity FROM sale INNER JOIN saledetail ON saledetail.InvoiceNo = sale.InvoiceNo INNER JOIN product ON saledetail.Product = product.ID WHERE sale.InvoiceNo = '" + InvoiceNo + "'", cm);
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    sc.Count = ds.Tables[0].Rows.Count;
        //    sc.DT = ds.Tables[0];
        //    return sc;
        //}

        public ServerToClient GetSales(string InvoiceNo)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT customer.CustomerName, customer.Address, customer.Phone, sale.InvoiceNo,  sale.SellDate, sale.Discount, sale.Payment, sale.Balance, Sum(saledetail.Quantity) AS Quantity, saledetail.SellingValue, SUM(saledetail.Quantity) * saledetail.SellingValue AS Amount, CONCAT(product.Company, ' ', product.ProductName, ' ', product.PackageSize) AS ProductName, GROUP_CONCAT(productdetail.BarCode) AS BarCode FROM  (customer INNER JOIN sale ON customer.ID = sale.Customer) INNER JOIN((product INNER JOIN productdetail ON product.ID = productdetail.ProductID) INNER JOIN saledetail ON product.ID = saledetail.Product) ON sale.InvoiceNo = saledetail.InvoiceNo WHERE sale.InvoiceNo = '" + InvoiceNo + "' GROUP BY product.ProductName, SaleDetail.SellingValue", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetSales(DateTime sellDate)
        {
            string dt = MySettings.getDate(sellDate);

            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(product.Company, ' ', product.ProductName, ' ', product.PackageSize) AS ProductName, saledetail.SellingValue, SUM(saledetail.Quantity) AS TotalQuantity, saledetail.SellingValue * SUM(saledetail.Quantity) AS Amount, SUM(sale.Discount) AS Discount, SUM(sale.Balance) AS Balance, sale.SellDate FROM product INNER JOIN saledetail ON saledetail.Product = product.ID INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo WHERE sale.SellDate = DATE('" + dt + "') GROUP BY product.Company, product.ProductName, product.PackageSize, saledetail.SellingValue, sale.SellDate", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient GetSales(DateTime date1, DateTime date2)
        {
            string df = MySettings.getDate(date1);
            string dt = MySettings.getDate(date2);

            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(product.Company, ' ', product.ProductName, ' ', product.PackageSize) AS ProductName, saledetail.SellingValue, SUM(saledetail.Quantity) AS TotalQuantity, saledetail.SellingValue * SUM(saledetail.Quantity) AS Amount, SUM(sale.Discount) AS Discount, SUM(sale.Balance) AS Balance, sale.SellDate FROM product INNER JOIN saledetail ON saledetail.Product = product.ID INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo WHERE sale.SellDate BETWEEN DATE('" + df + "') AND ('" + dt + "') GROUP BY product.Company, product.ProductName, product.PackageSize, saledetail.SellingValue, sale.SellDate", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }


        public ServerToClient QuickSaleReport(string InvoiceNo)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT sale.InvoiceNo, sale.SellDate, CONCAT(product.Company, ' ', product.ProductName) AS ProductName, saledetail.SellingValue * saledetail.Quantity AS Amount, saledetail.Quantity FROM sale INNER JOIN saledetail ON saledetail.InvoiceNo = sale.InvoiceNo INNER JOIN product ON saledetail.Product = product.ID WHERE sale.InvoiceNo = '" + InvoiceNo + "'", cm);

            //MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(product.Company, ' ', product.ProductName) AS productname, saledetail.Quantity, saledetail.SellingValue, sale.Amount, sale.Discount, saledetail.InvoiceNo FROM product INNER JOIN(saledetail INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo) ON saledetail.Product =  product.ID WHERE sale.InvoiceNo = '" + InvoiceNo + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            cmd = new MySqlCommand("SELECT SUM(Quantity) FROM saledetail WHERE InvoiceNo='" + InvoiceNo + "'", cm);
            try
            {
                cm.Open();
                sc.Count = (int)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally
            {
                cm.Close();
            }
            sc.Count = ds.Tables[0].Rows.Count;
            return sc;
        }

        public ServerToClient SalesByProductNameChart(DateTime DateFrom, DateTime DateTo)
        {
            string df = MySettings.getDate(DateFrom);
            string dt = MySettings.getDate(DateTo);

            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT product.ProductName, Sum(productdetail.Quantity) AS Quantity FROM product INNER JOIN productdetail ON productdetail.ProductID = product.ID INNER JOIN saledetail ON  saledetail.Product = product.ID INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo WHERE sale.SellDate =  DATE('" + df + "') AND DATE('" + dt + "') GROUP BY product.ProductName, sale.SellDate", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }
    }
}
