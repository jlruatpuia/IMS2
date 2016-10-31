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
    class CustomerContext
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public ServerToClient GetCustomers()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, CustomerName, Address, Phone FROM Customer WHERE CustomerName NOT LIKE 'DefaultCustomer'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        public Customer GetCustomer(int ID)
        {
            Customer c = new Customer();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, CustomerName, Address, Phone FROM Customer WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                c.ID = ID;
                c.CustomerName = rd[1].ToString();
                c.Address = rd[2].ToString();
                c.Phone = rd[3].ToString();
            }
            catch {; }
            finally { cm.Close(); }
            return c;
        }

        public ServerToClient AddCustomer(Customer c)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Customer (CustomerName, Address, Phone) VALUES (@CNM, @ADR, @PHN)", cm);
            cmd.Parameters.AddWithValue("@CNM", c.CustomerName);
            cmd.Parameters.AddWithValue("@ADR", c.Address);
            cmd.Parameters.AddWithValue("@PHN", c.Phone);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                sc.Count = Convert.ToInt32(cmd.LastInsertedId);
            }
            catch (Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient UpdateCustomer(Customer c)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE Customer SET CustomerName=@CNM, Address=@ADR, Phone=@PHN WHERE ID=" + c.ID, cm);
            cmd.Parameters.AddWithValue("@CNM", c.CustomerName);
            cmd.Parameters.AddWithValue("@ADR", c.Address);
            cmd.Parameters.AddWithValue("@PHN", c.Phone);
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

        public ServerToClient DeleteCustomer(int ID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM customer WHERE ID=" + ID, cm);
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

        public ServerToClient GetCustomerAccount()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            cmd = new MySqlCommand("SELECT ID, CustomerName, Address, Phone FROM Customer", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "Customer");

            cmd = new MySqlCommand("SELECT ID, CustomerID, TransDate, Description, Debit, Credit, Balance FROM CustomerAccount", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "CustomerAccount");
            DataColumn pk = ds.Tables[0].Columns[0];
            DataColumn fk = ds.Tables[1].Columns[1];
            sc.Message = "pk_fk";
            ds.Relations.Add(sc.Message, pk, fk);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DS = ds;
            return sc;
        }

        public Customer DefaultCustomer()
        {
            Customer c = new Customer();
            MySqlCommand cmd;
            bool f = true;

            cmd = new MySqlCommand("SELECT ID, CustomerName, Address, Phone FROM customer WHERE CustomerName = 'DefaultCustomer'", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    c.ID = Convert.ToInt32(rd[0]);
                    c.CustomerName = rd[1].ToString();
                    c.Address = rd[2].ToString();
                    c.Phone = rd[3].ToString();
                }
                else
                    f = false;
            }
            catch { f = false; }
            finally { cm.Close(); }

            if (!f)
            {
                c.CustomerName = "DefaultCustomer";
                c.Address = "DefaultAddress";
                c.Phone = "DefaultPhone";
                cmd = new MySqlCommand("INSERT INTO Customer (CustomerName, Address, Phone) VALUES (@CNM, @ADR, @PHN)", cm);
                cmd.Parameters.AddWithValue("@CNM", c.CustomerName);
                cmd.Parameters.AddWithValue("@ADR", c.Address);
                cmd.Parameters.AddWithValue("@PHN", c.Phone);
                try
                {
                    cm.Open();
                    cmd.ExecuteNonQuery();
                    c.ID = Convert.ToInt32(cmd.LastInsertedId);
                }
                catch {; }
                finally { cm.Close(); }
            }
            return c;
        }

        public ServerToClient GetCustomerBalance(int CustomerID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(Debit) - SUM(Credit) FROM CustomerAccount WHERE CustomerID=" + CustomerID, cm);
            try
            {
                cm.Open();
                sc.Value = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch
            {
                sc.Value = 0;
            }
            finally { cm.Close(); }
            return sc;
        }
        public ServerToClient AddTrans(CustomerAccount ca)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO CustomerAccount (CustomerID, TransDate, Description, Debit, Credit, Balance) VALUES (@CID, @TDT, @DSC, @CDR, @CCR, @BAL)", cm);
            cmd.Parameters.AddWithValue("@CID", ca.CustomerID);
            cmd.Parameters.AddWithValue("@TDT", ca.TransDate);
            cmd.Parameters.AddWithValue("@DSC", ca.Description);
            cmd.Parameters.AddWithValue("@CDR", ca.Debit);
            cmd.Parameters.AddWithValue("@CCR", ca.Credit);
            cmd.Parameters.AddWithValue("@BAL", ca.Balance);
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

        public ServerToClient CustomerDetailReport()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT customer.CustomerName, customer.Address, customer.Phone, customeraccount.TransDate, customeraccount.Description, customeraccount.Debit, customeraccount.Credit, customeraccount.Balance FROM customer INNER JOIN customeraccount ON customeraccount.CustomerID = customer.ID", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient CustomerDetailReport(int CustomerID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT customer.CustomerName, customer.Address, customer.Phone, customeraccount.TransDate, customeraccount.Description, customeraccount.Debit, customeraccount.Credit, customeraccount.Balance FROM customer INNER JOIN customeraccount ON customeraccount.CustomerID = customer.ID WHERE customer.ID=" + CustomerID, cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        public ServerToClient AccountStatement(int CustomerID, DateTime DateFrom, DateTime DateTo)
        {
            ServerToClient sc = new ServerToClient();

            DataTable dt = new DataTable();
            dt.Columns.Add("TransDate", typeof(DateTime));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Debit", typeof(double));
            dt.Columns.Add("Credit", typeof(double));
            dt.Columns.Add("Balance", typeof(double));
            //string dtf = dtFr.Date.Year.ToString("0000") + "-" + dtFr.Date.Month.ToString("00") + "-" + dtFr.Date.Day.ToString("00");
            //string dtt = dtTo.Date.Year.ToString("0000") + "-" + dtTo.Date.Month.ToString("00") + "-" + dtTo.Date.Day.ToString("00");
            string dtf = MySettings.getDate(DateFrom);
            string dtt = MySettings.getDate(DateTo);

            MySqlCommand cmd = new MySqlCommand("SELECT Sum(Debit)-Sum(Credit) AS OpeningBalance FROM CustomerAccount WHERE CustomerID=" + CustomerID + " AND TransDate < '" + dtf + "'", cm);
            double OpeningBalance = 0;
            try
            {
                cm.Open();
                OpeningBalance = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch
            {
                OpeningBalance = 0;
            }
            finally
            {
                cm.Close();
            }

            dt.Rows.Add(DateFrom, "Opening Balance", OpeningBalance, 0, OpeningBalance);



            cmd = new MySqlCommand("SELECT TransDate, Description, CASE WHEN Debit=0 THEN NULL ELSE Debit END AS Dr, CASE WHEN Credit=0 THEN NULL ELSE Credit END AS Cr, Balance FROM CustomerAccount WHERE CustomerID=" + CustomerID + " AND CustomerAccount.TransDate BETWEEN DATE('" + dtf + "') AND DATE('" + dtt + "') ORDER BY TransDate", cm);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DateTime dd = DateTime.Parse(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                string desc = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                double debit, credit, balance;
                try { debit = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[2]); }
                catch { debit = 0; }
                try { credit = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[3]); }
                catch { credit = 0; }
                try { balance = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[4]); }
                catch { balance = 0; }
                dt.Rows.Add(dd, desc, debit, credit, balance);
            }
            dt.TableName = "AccountStateMent";
            sc.DT = dt;
            sc.Count = dt.Rows.Count;
            return sc;
        }
    }
}
