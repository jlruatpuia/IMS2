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
    class Dashboard
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);


        public ServerToClient SalesByCategory(DateTime dateFrom, DateTime dateTo)
        {
            string df = MySettings.getDate(dateFrom);
            string dt = MySettings.getDate(dateTo);
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT category.CategoryName, SUM(saledetail.Quantity) AS TotalQuantity FROM saledetail INNER JOIN product ON saledetail.Product = product.ID INNER JOIN category ON product.Category = category.ID INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo WHERE sale.SellDate BETWEEN '" + df + "' AND '" + dt + "' GROUP BY CategoryName", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient SalesByProduct(DateTime dateFrom, DateTime dateTo)
        {
            string df = MySettings.getDate(dateFrom);
            string dt = MySettings.getDate(dateTo);
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT product.ProductName, SUM(saledetail.Quantity) AS TotalQuantity FROM saledetail INNER JOIN product ON saledetail.Product = product.ID INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo WHERE sale.SellDate BETWEEN '" + df + "' AND '" + dt + "' GROUP BY ProductName", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient SalesByCompany(DateTime dateFrom, DateTime dateTo)
        {
            string df = MySettings.getDate(dateFrom);
            string dt = MySettings.getDate(dateTo);
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT(product.Company), SUM(saledetail.Quantity) AS TotalQuantity FROM saledetail INNER JOIN product ON saledetail.Product = product.ID INNER JOIN sale ON saledetail.InvoiceNo = sale.InvoiceNo WHERE sale.SellDate BETWEEN '" + df + "' AND '" + dt + "' GROUP BY Company", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            return sc;
        }
    }
}
