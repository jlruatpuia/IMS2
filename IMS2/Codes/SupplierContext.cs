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
    class SupplierContext
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public ServerToClient GetSuppliers()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, SupplierName, Address, Phone, CST, TIN FROM supplier WHERE SupplierName NOT LIKE 'DefaultSupplier'", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }

        public Supplier GetSupplier(int ID)
        {
            Supplier s = new Supplier();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, SupplierName, Address, Phone, CST, TIN FROM supplier WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                s.ID = ID;
                s.SupplierName = rd[1].ToString();
                s.Address = rd[2].ToString();
                s.Phone = rd[3].ToString();
            }
            catch {; }
            finally { cm.Close(); }
            return s;
        }

        public ServerToClient AddSupplier(Supplier s)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO supplier (SupplierName, Address, Phone, CST, TIN) VALUES (@SNM, @ADR, @PHN, @CST, @TIN)", cm);
            cmd.Parameters.AddWithValue("@SNM", s.SupplierName);
            cmd.Parameters.AddWithValue("@ADR", s.Address);
            cmd.Parameters.AddWithValue("@PHN", s.Phone);
            cmd.Parameters.AddWithValue("@CST", s.CST);
            cmd.Parameters.AddWithValue("@TIN", s.TIN);
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

        public ServerToClient UpdateSupplier(Supplier s)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("UPDATE supplier SET SupplierName=@SNM, Address=@ADR, Phone=@PHN, CST=@CST, TIN=@TIN WHERE ID=" + s.ID, cm);
            cmd.Parameters.AddWithValue("@SNM", s.SupplierName);
            cmd.Parameters.AddWithValue("@ADR", s.Address);
            cmd.Parameters.AddWithValue("@PHN", s.Phone);
            cmd.Parameters.AddWithValue("@CST", s.CST);
            cmd.Parameters.AddWithValue("@TIN", s.TIN);
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

        public ServerToClient DeleteSupplier(int ID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM supplier WHERE ID=" + ID, cm);
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

        public ServerToClient GetSupplierAccount()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            cmd = new MySqlCommand("SELECT ID, SupplierName, Address, Phone, CST, TIN FROM supplier", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "Supplier");

            cmd = new MySqlCommand("SELECT ID, SupplierID, TransDate, Description, Debit, Credit, Balance FROM supplieraccount", cm);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "SupplierAccount");
            DataColumn pk = ds.Tables[0].Columns[0];
            DataColumn fk = ds.Tables[1].Columns[1];
            sc.Message = "pk_fk";
            ds.Relations.Add(sc.Message, pk, fk);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DS = ds;
            return sc;
        }

        public ServerToClient GetSupplierBalance(int ID)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(Debit) - SUM(Credit) FROM supplieraccount WHERE SupplierID=" + ID, cm);
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

        public ServerToClient AddTrans(SupplierAccount sa)
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO supplieraccount (SupplierID, TransDate, Description, Debit, Credit, Balance) VALUES (@SID, @TDT, @DSC, @CDR, @CCR, @BAL)", cm);
            cmd.Parameters.AddWithValue("@SID", sa.SupplierID);
            cmd.Parameters.AddWithValue("@TDT", sa.TransDate);
            cmd.Parameters.AddWithValue("@DSC", sa.Description);
            cmd.Parameters.AddWithValue("@CDR", sa.Debit);
            cmd.Parameters.AddWithValue("@CCR", sa.Credit);
            cmd.Parameters.AddWithValue("@BAL", sa.Balance);
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

        public Supplier DefaultSupplier()
        {
            Supplier s = new Supplier();
            MySqlCommand cmd;
            bool f = true;

            cmd = new MySqlCommand("SELECT ID, SupplierName, Address, Phone, CST, TIN FROM supplier WHERE SupplierName = 'DefaultSupplier'", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    s.ID = Convert.ToInt32(rd[0]);
                    s.SupplierName = rd[1].ToString();
                    s.Address = rd[2].ToString();
                    s.Phone = rd[3].ToString();
                }
                else
                    f = false;
            }
            catch { f = false; }
            finally { cm.Close(); }

            if (!f)
            {
                s.SupplierName = "DefaultSupplier";
                s.Address = "DefaultAddress";
                s.Phone = "DefaultPhone";
                cmd = new MySqlCommand("INSERT INTO supplier (SupplierName, Address, Phone) VALUES (@SNM, @ADR, @PHN)", cm);
                cmd.Parameters.AddWithValue("@SNM", s.SupplierName);
                cmd.Parameters.AddWithValue("@ADR", s.Address);
                cmd.Parameters.AddWithValue("@PHN", s.Phone);
                try
                {
                    cm.Open();
                    cmd.ExecuteNonQuery();
                    s.ID = Convert.ToInt32(cmd.LastInsertedId);
                }
                catch {; }
                finally { cm.Close(); }
            }
            return s;
        }

        public ServerToClient SupplierDetailReport()
        {
            ServerToClient sc = new ServerToClient();
            MySqlCommand cmd = new MySqlCommand("SELECT supplier.SupplierName, supplier.Address, supplier.Phone, supplieraccount.TransDate, supplieraccount.Description, supplieraccount.Debit, supplieraccount.Credit, supplieraccount.Balance FROM supplier INNER JOIN supplieraccount ON supplieraccount.SupplierID = supplier.ID", cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.Count = ds.Tables[0].Rows.Count;
            sc.DT = ds.Tables[0];
            return sc;
        }
    }
}
