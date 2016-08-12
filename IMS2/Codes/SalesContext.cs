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
                sc.Count = cmd.ExecuteNonQuery();
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
        public ServerToClient GetSales(string InvoiceNo)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT sale.SellDate, saledetail.ID, saledetail.Product, saledetail.Quantity, saledetail.SellingValue, saledetail.Amount FROM saledetail INNER JOIN sale ON sale.InvoiceNo=saledetail.InvoiceNo WHERE sale.InvoiceNo='" + InvoiceNo + "'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }
    }
}
