using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{
    internal class Database : IDatabase
    {
        /// <summary>
        /// Метод отримання списку таблиць
        /// </summary>
        /// <returns>Повертає список таблиць або значення null</returns>
        public List<string> GetTables()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                try
                {
                    connection.Open();
                    using (DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                        new object[] { null, null, null, "TABLE" }))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            List<string> tables = new List<string>();
                            tables.AddRange(from DataRow item in dt.Rows select (string)item["TABLE_NAME"]);
                            return tables;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }
    }
}
