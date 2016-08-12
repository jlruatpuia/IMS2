﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace IMS2.Codes
{
    class MySettings
    {

        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public string GetFinancialYear(DateTime dt)
        {
            string finyear = "";

            int m = dt.Month;
            int y = dt.Year;
            if (m > 3)
            {
                finyear = y.ToString().Substring(2, 2) + "-" + Convert.ToString((y + 1)).Substring(2, 2);
            }
            else
            {
                finyear = Convert.ToString((y - 1)).Substring(2, 2) + "-" + y.ToString().Substring(2, 2);
            }
            return finyear;
        }

        public string GetInvoiceNo(DateTime dt, string Table, string ShortName)
        {
            //string inv_no = "";
            int inv_no;
            string inv_yr = "";
            MySqlCommand cmd = new MySqlCommand("SELECT MID(InvoiceNo, 8, 5) FROM " + Table + " WHERE MID(InvoiceNo, 5, 2) = 'RI' ORDER BY InvoiceNo DESC LIMIT 1", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                inv_yr = rd[0].ToString();
                inv_yr = inv_yr.Substring(0, 5);
            }
            catch
            {
                inv_yr = GetFinancialYear(dt);
            }
            finally { cm.Close(); }

            string yr = inv_yr == GetFinancialYear(dt) ? inv_yr : GetFinancialYear(dt);

            cmd = new MySqlCommand("SELECT MID(InvoiceNo, 14) FROM " + Table + " WHERE MID(InvoiceNo, 5, 2) = 'RI' AND MID(InvoiceNo, 8, 5)='" + yr + "' ORDER BY InvoiceNo DESC LIMIT 1", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                string i = rd[0].ToString();
                inv_no = Convert.ToInt32(rd[0]); //.ToString();
            }
            catch
            {
                inv_no = 0;
            }
            finally { cm.Close(); }

            return ShortName + "/RI/" + yr + "/" + (inv_no + 1).ToString("0000");
        }

        public string GetInvoiceNo(DateTime dt, string ShortName)
        {
            //string inv_no = "";
            int inv_no;
            string inv_yr = "";
            MySqlCommand cmd = new MySqlCommand("SELECT MID(InvoiceNo, 8, 5) FROM Sale WHERE MID(InvoiceNo, 5, 2) = 'SI' ORDER BY InvoiceNo DESC LIMIT 1", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                inv_yr = rd[0].ToString();
                inv_yr = inv_yr.Substring(0, 5);
            }
            catch
            {
                inv_yr = GetFinancialYear(dt);
            }
            finally { cm.Close(); }

            string yr = inv_yr == GetFinancialYear(dt) ? inv_yr : GetFinancialYear(dt);

            cmd = new MySqlCommand("SELECT MID(InvoiceNo, 14) FROM Sale WHERE MID(InvoiceNo, 5, 2) = 'SI' AND MID(InvoiceNo, 8, 5)='" + yr + "' ORDER BY InvoiceNo DESC LIMIT 1", cm);
            try
            {
                cm.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                string i = rd[0].ToString();
                inv_no = Convert.ToInt32(rd[0]); //.ToString();
            }
            catch
            {
                inv_no = 0;
            }
            finally { cm.Close(); }

            return ShortName + "/SI/" + yr + "/" + (inv_no + 1).ToString("0000");
        }
    }
}
