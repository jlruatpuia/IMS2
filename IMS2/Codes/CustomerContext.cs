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
            cmd = new MySqlCommand("SELECT ID, CustomerName, Address, Phone FROM Customer WHERE CustomerName NOT LIKE 'DefaultCustomer'", cm);
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
    }
}
