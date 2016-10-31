using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS2.Codes
{
    class PurchaseContext
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public ServerToClient AddPurchase(Purchase p)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Purchase (InvoiceNo, PurchaseDate, SupplierID, Amount, Payment, Balance) VALUES (@INV, @PDT, @SID, @TAM, @TPM, @TBL)", cm);
            cmd.Parameters.AddWithValue("@INV", p.InvoiceNo);
            cmd.Parameters.AddWithValue("@PDT", p.PurchaseDate);
            cmd.Parameters.AddWithValue("@SID", p.SupplierID);
            cmd.Parameters.AddWithValue("@TAM", p.Amount);
            cmd.Parameters.AddWithValue("@TPM", p.Payment);
            cmd.Parameters.AddWithValue("@TBL", p.Balance);
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

        public ServerToClient AddPurchaseDetail(PurchaseDetail pd)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO PurchaseDetail (InvoiceNo, ProductID, Quantity, BuyingValue, SellingValue, Amount) VALUES (@INV, @PID, @QTY, @BVL, @SVL, @TAM)", cm);
            cmd.Parameters.AddWithValue("@INV", pd.InvoiceNo);
            cmd.Parameters.AddWithValue("@PID", pd.ProductID);
            cmd.Parameters.AddWithValue("@QTY", pd.Quantity);
            cmd.Parameters.AddWithValue("@BVL", pd.BuyingValue);
            cmd.Parameters.AddWithValue("@SVL", pd.SellingValue);
            cmd.Parameters.AddWithValue("@TAM", pd.Amount);
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

        public ServerToClient ViewPurchase(DateTime date)
        {
            string dt = MySettings.getDate(date);
            ServerToClient sc = new ServerToClient();

            MySqlCommand cmd = new MySqlCommand("SELECT purchase.PurchaseDate, CONCAT(product.Company, ' ', product.ProductName) AS ProductName, product.PackageSize, PurchaseDetail.BuyingValue, Sum(PurchaseDetail.Quantity) AS SumOfQuantity, PurchaseDetail.BuyingValue * Sum(PurchaseDetail.Quantity) AS SumOfAmount FROM product INNER JOIN purchasedetail ON purchasedetail.ProductID = product.ID INNER JOIN purchase ON purchasedetail.InvoiceNo = purchase.InvoiceNo WHERE purchase.PurchaseDate = DATE('" + dt + "') GROUP BY     Product.ProductName", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;

        }

        public ServerToClient ViewPurchase(DateTime date1, DateTime date2)
        {
            string df = MySettings.getDate(date1);
            string dt = MySettings.getDate(date2);
            ServerToClient sc = new ServerToClient();

            MySqlCommand cmd = new MySqlCommand("SELECT purchase.PurchaseDate, CONCAT(product.Company, ' ', product.ProductName) AS ProductName, product.PackageSize, PurchaseDetail.BuyingValue, Sum(PurchaseDetail.Quantity) AS SumOfQuantity, PurchaseDetail.BuyingValue * Sum(PurchaseDetail.Quantity) AS SumOfAmount FROM product INNER JOIN purchasedetail ON purchasedetail.ProductID = product.ID INNER JOIN purchase ON purchasedetail.InvoiceNo = purchase.InvoiceNo WHERE purchase.PurchaseDate BETWEEN DATE('" + df + "') AND DATE('" + dt + "') GROUP BY     Product.ProductName", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;

        }
    }
}
