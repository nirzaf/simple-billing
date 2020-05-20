using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Newtonsoft.Json;
using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SimpleBilling
{
    public static class Info
    {
        private static readonly Random random = new Random();
        public static int CashierId { get; set; }

        public static void Mes(string mes)
        {
            MessageBox.Show(mes);
        }

        public static int ToInt(TextBox tb)
        {
            if (IsEmpty(tb))
            {
                return Convert.ToInt32(tb.Text.Trim());
            }
            else
            {
                return 0;
            }
        }

        public static bool YesNoConfirmation(string message, string title)
        {
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;

        }

        public static void Enter(TextBox Txt, string PlaceHolder)
        {
            if (Txt.Text == PlaceHolder)
            {
                Txt.Text = string.Empty;
                Txt.ForeColor = System.Drawing.Color.Black;
            }
        }

        public static void Leave(TextBox Txt, string PlaceHolder)
        {
            if (string.IsNullOrWhiteSpace(Txt.Text.Trim()))
            {
                Txt.Text = PlaceHolder;
                Txt.ForeColor = System.Drawing.Color.DarkGray;
            }
        }

        public static void PlaceHolder(TextBox tb)
        {
            if (tb.Focused)
            {
                tb.Text = string.Empty;
                tb.ForeColor = System.Drawing.Color.Black;
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void Required()
        {
            MessageBox.Show("Please make sure you have entered all the required fields");
        }

        public static DateTime Today()
        {
            string Date = DateTime.Today.ToShortDateString();
            DateTime Today = Convert.ToDateTime(Date);
            return Today;
        }

        public static bool IsNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            if (!char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }

        public static void IsDecimal(KeyPressEventArgs e, TextBox txt)
        {
            if (!IsNumber(e.KeyChar, txt.Text))
                e.Handled = true;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static void IsInt(KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        public static string ToString(TextBox tb)
        {
            if (IsEmpty(tb))
            {
                return tb.Text.Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool IsEmpty(TextBox t)
        {
            if (string.IsNullOrWhiteSpace(t.Text.Trim()))
            {
                Mes("Input value cannot be empty");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ExportReceiptsAsPDF(DataTable dt)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = RandomString(5) + DateTime.Now.ToShortDateString().Replace("/", "")
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = sfd.FileName;
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    Paragraph header = new Paragraph("Receipts").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
                    Paragraph subheader = new Paragraph("Detailed Report").SetTextAlignment(TextAlignment.CENTER).SetFontSize(15);
                    Paragraph dl = new Paragraph("                ").SetTextAlignment(TextAlignment.CENTER).SetFontSize(15);
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(header);
                    document.Add(subheader);
                    document.Add(ls);
                    document.Add(dl);
                    Table table = new Table(6, false);
                    table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    table.SetVerticalAlignment(VerticalAlignment.TOP);
                    table.AddHeaderCell("Receipt No");
                    table.AddHeaderCell("Date");
                    table.AddHeaderCell("Time");
                    table.AddHeaderCell("Sub Total");
                    table.AddHeaderCell("Total Discounts");
                    table.AddHeaderCell("Net Total");

                    foreach (DataRow d in dt.Rows)
                    {
                        table.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[0].ToString())));
                        table.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph(d[1].ToString())));
                        table.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[2].ToString())));
                        table.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph(d[4].ToString())));
                        table.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[5].ToString())));
                        table.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph(d[6].ToString())));
                    }

                    float subTotal = GetDTSum(dt, 4);
                    float discoutTotal = GetDTSum(dt, 5);
                    float netTotal = GetDTSum(dt, 6);

                    table.AddFooterCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.GRAY).Add(new Paragraph(string.Empty)));
                    table.AddFooterCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.GRAY).Add(new Paragraph(string.Empty)));
                    table.AddFooterCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.GRAY).Add(new Paragraph(string.Empty)));
                    table.AddFooterCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.GRAY).Add(new Paragraph(subTotal.ToString())));
                    table.AddFooterCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.GRAY).Add(new Paragraph(discoutTotal.ToString())));
                    table.AddFooterCell(new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.GRAY).Add(new Paragraph(netTotal.ToString())));

                    document.Add(table);
                    document.Close();
                    StartProcess(fileName);
                }
            }
            catch (Exception ex)
            {
                Mes(ex.Message);
            }
        }

        public static void SendToPrinter(string file)
        {
            ProcessStartInfo info = new ProcessStartInfo
            {
                Verb = "print",
                FileName = file,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process p = new Process
            {
                StartInfo = info
            };
            p.Start();
            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (!p.CloseMainWindow())
                p.Kill();
        }

        public static void StartProcess(string Path)
        {
            try
            {
                Process.Start(Path);
            }
            catch (Exception ex)
            {
                Mes(ex.Message);
            }
        }

        public static void ExpPDF(DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "test"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Spire.DataExport.PDF.PDFExport PDFExport = new Spire.DataExport.PDF.PDFExport
                {
                    DataSource = Spire.DataExport.Common.ExportSource.DataTable,
                    DataTable = dt,
                    ActionAfterExport = Spire.DataExport.Common.ActionType.OpenView
                };
                PDFExport.PDFOptions.PageOptions.Orientation = Spire.DataExport.Common.PageOrientation.Landscape;
                PDFExport.SaveToFile(sfd.FileName);
            }
        }

        public static float GetDGVSum(DataGridView dt, int cell)
        {
            float sum = (from DataGridViewRow row in dt.Rows
                         where row.Cells[0].FormattedValue.ToString() != string.Empty
                         select Convert.ToSingle(row.Cells[cell].FormattedValue)).Sum();
            return sum;
        }

        public static float GetDTSum(DataTable dt, int cell)
        {
            float sum = dt.AsEnumerable().Sum(c => c.Field<float>(cell));
            return sum;
        }

        public static void Add(Exception ex)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.Settings.FirstOrDefault(c => c.UserId == 1);
                    string path = data.ExceptionPath;
                    string fileName = path + "exception.json";
                    string rawJson;
                    if (!File.Exists(fileName))
                    {
                        File.Create(fileName);
                    }

                    rawJson = File.ReadAllText(fileName);
                    var ec = JsonConvert.DeserializeObject<ExpCollection>(rawJson);

                    if (ec != null)
                    {
                        int Count = ec.Exceptions.Count;
                        Exp Exps = new Exp
                        {
                            Id = ++Count,
                            Time = DateTime.Now.ToShortTimeString(),
                            Date = DateTime.Today.ToShortDateString(),
                            Message = ex.Message.ToString(),
                            StackTrace = ex.StackTrace.ToString()
                        };
                        ec.Exceptions.Add(Exps);
                        string serializedJson = JsonConvert.SerializeObject(ec, Formatting.Indented);
                        File.WriteAllText(path, serializedJson);
                    }
                    else
                    {
                        ExpCollection exp = new ExpCollection
                        {
                            Exceptions = new List<Exp>()
                        };
                        Exp Exps = new Exp
                        {
                            Id = 1,
                            Time = DateTime.Now.ToShortTimeString(),
                            Date = DateTime.Today.ToShortDateString(),
                            Message = ex.Message.ToString(),
                            StackTrace = ex.StackTrace.ToString()
                        };
                        exp.Exceptions.Add(Exps);
                        string serializedJson = JsonConvert.SerializeObject(exp, Formatting.Indented);
                        File.WriteAllText(path, serializedJson);
                    }
                }
            }
            catch (Exception e)
            {
                Add(e);
            }
            finally
            {
                Mes(ex.Message);
            }
        }

        public static DbConnection ConString()
        {
            try
            {
                string fileName = "conString.json";
                string rawJson = File.ReadAllText(fileName);
                var cs = JsonConvert.DeserializeObject<ConnectionString>(rawJson);
                return GetSqlConnection(cs.Source, cs.Database, cs.UserId, cs.Password, cs.IntegratedSecurity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DbConnection GetSqlConnection(string dataSource, string dbName, string uId, string pW, bool trusted)
        {
            var sqlConnStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                MultipleActiveResultSets = true
            };

            if (trusted)
            {
                sqlConnStringBuilder.IntegratedSecurity = true;
            }
            else
            {
                sqlConnStringBuilder.UserID = uId;
                sqlConnStringBuilder.Password = pW;
            }

            var sqlConnFact = new SqlConnectionFactory(sqlConnStringBuilder.ConnectionString);
            var sqlConn = sqlConnFact.CreateConnection(dbName);
            return sqlConn;
        }
    }
}