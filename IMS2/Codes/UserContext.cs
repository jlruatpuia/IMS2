using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS2.Codes
{
   
    class UserContext
    {
        OleDbConnection cm = new OleDbConnection(ConfigurationManager.ConnectionStrings["csusers"].ConnectionString);

        public ServerToClient getUsers()
        {
            ServerToClient sc = new ServerToClient();
            OleDbCommand cmd = new OleDbCommand("SELECT [ID], [UserName], '****' AS [Password], [UserLevel] FROM [user]", cm);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT =  ds.Tables[0];
            sc.Count = ds.Tables[0].Rows.Count;
            return sc;
        }

        public ServerToClient getUsers(int UserID)
        {
            ServerToClient sc = new ServerToClient();
            OleDbCommand cmd = new OleDbCommand("SELECT [ID], [UserName], '****' AS [Password], [UserLevel] FROM [user] WHERE ID=" + UserID, cm);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sc.DT = ds.Tables[0];
            sc.Count = ds.Tables[0].Rows.Count;
            return sc;
        }

        public Users getUser(int ID)
        {
            Users u = new Users();
            OleDbCommand cmd = new OleDbCommand("SELECT [UserName], [Password], [UserLevel] FROM [user] WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    u.UserName = rd[0].ToString();
                    u.Password = rd[1].ToString();
                    u.UserLevel = Convert.ToInt32(rd[2]);
                }
                else
                {
                    //
                }
            }
            catch {; }
            finally { cm.Close(); }
            return u;
        }

        public ServerToClient Login(string UserName, string Password)
        {
            ServerToClient sc = new ServerToClient();
            OleDbCommand cmd = new OleDbCommand("SELECT ID, UserLevel FROM [user] WHERE [UserName]='" + UserName + "' AND [Password]='" + Password + "'", cm);
            try
            {
                cm.Open();
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    sc.Count = Convert.ToInt32(rd[0]);
                    MySettings.UserLevel = Convert.ToInt32(rd[1]);
                }
                else
                    sc.Message = "UserName/Password incorrect!";
            }
            catch(Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally { cm.Close(); }
            return sc;
        }

        public ServerToClient addUser(Users u)
        {
            ServerToClient sc = new ServerToClient();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO [user] ([UserName], [Password], [UserLevel]) VALUES (@UNM, @PWD, @ULV)", cm);
            cmd.Parameters.AddWithValue("@UNM", u.UserName);
            cmd.Parameters.AddWithValue("@PWD", u.Password);
            cmd.Parameters.AddWithValue("@ULV", u.UserLevel);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally
            {
                cm.Close();
            }
            return sc;
        }

        public ServerToClient updateUser(Users u)
        {
            ServerToClient sc = new ServerToClient();
            OleDbCommand cmd = new OleDbCommand("UPDATE [user] SET [UserName]=@UNM, [Password]=@PWD, [UserLevel]=@ULV WHERE ID=" + u.ID, cm);
            cmd.Parameters.AddWithValue("@UNM", u.UserName);
            cmd.Parameters.AddWithValue("@PWD", u.Password);
            cmd.Parameters.AddWithValue("@ULV", u.UserLevel);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally
            {
                cm.Close();
            }
            return sc;
        }

        public ServerToClient deleteUser(int ID)
        {
            int Admins = 0;
            int Levels = 0;

            ServerToClient sc = new ServerToClient();
            OleDbCommand cmd;

            cmd = new OleDbCommand("SELECT COUNT(*) FROM [user] WHERE UserLevel=0", cm);
            try
            {
                cm.Open();
                Admins = (int)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally { cm.Close(); }

            cmd = new OleDbCommand("SELECT UserLevel FROM [user] WHERE ID=" + ID, cm);
            try
            {
                cm.Open();
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                Levels = Convert.ToInt32(rd[0]);
            }
            catch (Exception ex)
            {
                sc.Message = ex.Message;
            }
            finally { cm.Close(); }

            if(Admins <= 1 && Levels == 0)
            {
                sc.Message = "Cannot delete user! At least one admin is needed!";
                
            }
            else
            {
                cmd = new OleDbCommand("DELETE FROM [user] WHERE ID=" + ID, cm);
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
            }

            return sc;
        }
    }
}
