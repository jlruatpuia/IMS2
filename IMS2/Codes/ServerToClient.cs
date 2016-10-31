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
        public int Category { get; set; }
        public string SubCategory { get; set; }
        public string Company { get; set; }
        public string ProductName { get; set; }
        public string PackageSize { get; set; }
        public string Message { get; set; }
    }

    public class ProductDetail
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public double BuyingValue { get; set; }
        public double SellingValue { get; set; }
        public string MfgDate { get; set; }
        public string ExpDate { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }
        public int Supplier { get; set; }
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

    public class Purchase
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int SupplierID { get; set; }
        public double Amount { get; set; }
        public double Payment { get; set; }
        public double Balance { get; set; }

    }

    public class PurchaseDetail
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double BuyingValue { get; set; }
        public double SellingValue { get; set; }
        public double Amount { get; set; }
    }

    public class Supplier
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CST { get; set; }
        public string TIN { get; set; }
    }

    public class SupplierAccount
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public DateTime TransDate { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
    }

    public class Users
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserLevel { get; set; }
    }
}
