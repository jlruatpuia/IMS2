using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace IMS2.Codes
{
    class MySettings
    {

        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public static int UserID { get; set; }
        public static string Password { get; set; }
        public static int UserLevel { get; set; }
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
            MySqlCommand cmd = new MySqlCommand("SELECT MID(InvoiceNo, 8, 5) FROM " + Table + " WHERE MID(InvoiceNo, 1, 3)='" + ShortName + "' AND MID(InvoiceNo, 5, 2) = 'RI' ORDER BY InvoiceNo DESC LIMIT 1", cm);
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

            cmd = new MySqlCommand("SELECT MID(InvoiceNo, 14) FROM " + Table + " WHERE MID(InvoiceNo, 1, 3)='" + ShortName + "' AND MID(InvoiceNo, 5, 2) = 'RI' AND MID(InvoiceNo, 8, 5)='" + yr + "' ORDER BY InvoiceNo DESC LIMIT 1", cm);
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

            return ShortName + "/RI/" + yr + "/" + (inv_no + 1).ToString("000000");
        }

        public string GetInvoiceNo(DateTime dt, string ShortName)
        {
            //string inv_no = "";
            int inv_no;
            string inv_yr = "";
            MySqlCommand cmd = new MySqlCommand("SELECT MID(InvoiceNo, 8, 5) FROM Sale WHERE MID(InvoiceNo, 1, 3)='" + ShortName + "' AND MID(InvoiceNo, 5, 2) = 'SI' ORDER BY InvoiceNo DESC LIMIT 1", cm);
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

            cmd = new MySqlCommand("SELECT MID(InvoiceNo, 14) FROM Sale WHERE MID(InvoiceNo, 1, 3)='" + ShortName + "' AND MID(InvoiceNo, 5, 2) = 'SI' AND MID(InvoiceNo, 8, 5)='" + yr + "' ORDER BY InvoiceNo DESC LIMIT 1", cm);
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

            return ShortName + "/SI/" + yr + "/" + (inv_no + 1).ToString("000000");
        }

        public static string getDate(DateTime dt)
        {
            return dt.Date.Year.ToString("0000") + "-" + dt.Date.Month.ToString("00") + "-" + dt.Date.Day.ToString("00");
        }

        public static string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        public static string ConnString()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        public static void GeometryFromString(string thisWindowGeometry, Form formIn)
        {
            if (string.IsNullOrEmpty(thisWindowGeometry) == true)
            {
                return;
            }
            string[] numbers = thisWindowGeometry.Split('|');
            string windowString = numbers[4];
            if (windowString == "Normal")
            {
                Point windowPoint = new Point(int.Parse(numbers[0]),
                    int.Parse(numbers[1]));
                Size windowSize = new Size(int.Parse(numbers[2]),
                    int.Parse(numbers[3]));

                bool locOkay = GeometryIsBizarreLocation(windowPoint, windowSize);
                bool sizeOkay = GeometryIsBizarreSize(windowSize);

                if (locOkay == true && sizeOkay == true)
                {
                    formIn.Location = windowPoint;
                    formIn.Size = windowSize;
                    formIn.StartPosition = FormStartPosition.Manual;
                    formIn.WindowState = FormWindowState.Normal;
                }
                else if (sizeOkay == true)
                {
                    formIn.Size = windowSize;
                }
            }
            else if (windowString == "Maximized")
            {
                formIn.Location = new Point(100, 100);
                formIn.StartPosition = FormStartPosition.Manual;
                formIn.WindowState = FormWindowState.Maximized;
            }
        }

        private static bool GeometryIsBizarreLocation(Point loc, Size size)
        {
            bool locOkay;
            if (loc.X < 0 || loc.Y < 0)
            {
                locOkay = false;
            }
            else if (loc.X + size.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                locOkay = false;
            }
            else if (loc.Y + size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                locOkay = false;
            }
            else
            {
                locOkay = true;
            }
            return locOkay;
        }

        private static bool GeometryIsBizarreSize(Size size)
        {
            return (size.Height <= Screen.PrimaryScreen.WorkingArea.Height &&
                size.Width <= Screen.PrimaryScreen.WorkingArea.Width);
        }

        public static string GeometryToString(Form mainForm)
        {
            return mainForm.Location.X.ToString() + "|" +
                mainForm.Location.Y.ToString() + "|" +
                mainForm.Size.Width.ToString() + "|" +
                mainForm.Size.Height.ToString() + "|" +
                mainForm.WindowState.ToString();
        }
    }

    

    public static class Cultures
    {
        public static readonly CultureInfo India =
        CultureInfo.GetCultureInfo("en-IN");
    }
}
