using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS2.Codes
{
    public class ServerToClient
    {
        public int Count { get; set; }
        public double Value { get; set; }
        public DataSet DS { get; set; }
        public DataTable DT { get; set; }
        public string Message { get; set; }

    }

    public class Product
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public double BuyingValue { get; set; }
        public double SellingValue { get; set; }
        public string MfgDate { get; set; }
        public string ExpDate { get; set; }
        public int Category { get; set; }
        public string SubCategory { get; set; }
        public string PackageSize { get; set; }
        public int Quantity { get; set; }
        public int Supplier { get; set; }
        public string Message { get; set; }
    }

    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerAccount
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime TransDate { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
    }

    public class Sale
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime SellDate { get; set; }
        public int Customer { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double Payment { get; set; }
        public double Balance { get; set; }
    }

    public class SaleDetail
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int Product { get; set; }
        public double BuyingValue { get; set; }
        public double SellingValue { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }

}
