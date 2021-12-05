using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StudyPlan
{
    /*
     * Класс для роботи з базою даних
     */
    public class Database
    {
        private string _cnnString;
        public string CnnString { get => _cnnString; set => _cnnString = value; }


        /*
         * Конструктор з параметрами
         */
        public Database(string cnnString)
        {
            _cnnString = cnnString;
        }

        /*
         * Конструктор без параметрів
         */
        public Database()
        {
            _cnnString = $@"Provider=Microsoft.ACE.OLEDB.12.0;
                            Data Source={Properties.Settings.Default.StudyPlanDbConnectionString}; 
                            Persist Security Info=False;";
        }

        public List<string> GetTables()
        {
            List<string> tables = new List<string>();
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                try
                {
                    connection.Open();
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, 
                        new object[] { null, null, null, "TABLE" });

                    foreach (DataRow item in dt.Rows)
                    {
                        tables.Add((string)item["TABLE_NAME"]);
                    }
                    connection.Close();
                    return tables;
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
            return tables;
        }

        /*
         * Метод отримання баз вступу за ідентифікатором групи та роком вступу
         */
        public List<EntryBase> GetEntryBases(int groupId, int entryYear)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"
                    SELECT DISTINCT [{Table.EntryBases}].ID, [{Table.EntryBases}].Назва
                    FROM ([{Table.EntryBases}] 
                    INNER JOIN [{Table.StudyPlans}] 
                        ON [{Table.EntryBases}].ID = [{Table.StudyPlans}].[База вступу]) 
                    INNER JOIN {Table.Groups} 
                        ON [{Table.StudyPlans}].ID = {Table.Groups}.[Навчальний план]
                    WHERE ((([{Table.StudyPlans}].[Рік вступу])={entryYear}) 
                        AND (({Table.Groups}.ID)={groupId}))";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<EntryBase> entryBases = new List<EntryBase>();
                            while (reader.Read())
                            {
                                EntryBase entryBase = new EntryBase
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Назва"))
                                };
                                entryBases.Add(entryBase);
                            }
                            return entryBases;
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
                return null;
            }
        }

        /*
         * Метод отримання навчального плану за ідентифікатором
         */
        public Plan GetPlan(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $"SELECT * FROM [{Table.StudyPlans}] WHERE ID={id}";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Plan plan = new Plan
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                EntryYear = reader.GetInt32(reader.GetOrdinal("Рік вступу")),
                                EntryBase = reader.GetInt32(reader.GetOrdinal("База вступу")),
                                Link = reader.GetString(reader.GetOrdinal("Посилання на навчальний план")),
                                Speciality = reader.GetInt32(reader.GetOrdinal("Освітня професійна програма")),
                                EducationLevel = reader.GetInt32(reader.GetOrdinal("Освітній рівень"))
                            };
                            return plan;
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
                return null;
            }
        }

        /*
         * Метод отримання списку семестрів за роком вступу, ідентифікаторами групи та бази вступу
         */
        public List<int> GetSemesters(int entryYear, int groupId, int entryBase)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"
                    SELECT DISTINCT [{Table.WorkPrograms}].Семестр
                    FROM [{Table.WorkPrograms}] 
                        INNER JOIN ((([{Table.EntryBases}] 
                        INNER JOIN [{Table.StudyPlans}] 
                            ON [{Table.EntryBases}].ID = [{Table.StudyPlans}].[База вступу]) 
                        INNER JOIN {Table.Groups} 
                            ON [{Table.StudyPlans}].ID = {Table.Groups}.[Навчальний план]) 
                        INNER JOIN [{Table.AccountingWorkPrograms}] 
                            ON [{Table.StudyPlans}].ID = [{Table.AccountingWorkPrograms}].[ID навчального плану]) 
                            ON [{Table.WorkPrograms}].ID = [{Table.AccountingWorkPrograms}].[ID робочої програми]
                        WHERE ((([{Table.StudyPlans}].[Рік вступу])={entryYear}) 
                            AND (({Table.Groups}.ID)={groupId}) 
                            AND (([{Table.StudyPlans}].[База вступу])={entryBase}))";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<int> semesters = new List<int>();
                            while (reader.Read())
                            {
                                semesters.Add(reader.GetInt32(reader.GetOrdinal("Семестр")));
                            }
                            return semesters;
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
                return null;
            }
        }

        /*
         * Метод отримання списку груп за роком вступу
         */
        public List<Group> GetGroups(int entryYear)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"
                    SELECT DISTINCT [{Table.Groups}].[ID], [{Table.Groups}].[Навчальний план], 
                        [{Table.GroupNames}].[Назва групи]
                    FROM [{Table.GroupNames}] 
                    INNER JOIN ([{Table.StudyPlans}] 
                    INNER JOIN {Table.Groups} 
                        ON [{Table.StudyPlans}].ID = {Table.Groups}.[Навчальний план]) 
                        ON [{Table.GroupNames}].ID = {Table.Groups}.[Назва групи]
                    WHERE ((([{Table.StudyPlans}].[Рік вступу])={entryYear}))";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<Group> groups = new List<Group>();
                            List<EntryBase> entryBases = new List<EntryBase>();
                            while (reader.Read())
                            {
                                Group group = new Group
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Plan = reader.GetInt32(reader.GetOrdinal("Навчальний план")),
                                    Name = reader.GetString(reader.GetOrdinal("Назва групи"))
                                };
                                groups.Add(group);
                            }
                            return groups;
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
                return null;
            }
        }

        /*
         * Метод отримання списку курсів 
         */
        public List<Item> GetCources()
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"
                    SELECT DISTINCT [Рік вступу],(Year(Now())-[Рік вступу]) AS [Курс]
                    FROM[{Table.StudyPlans}]
                    WHERE([Рік вступу] <= Year(Now())) AND(Year(Now()) - [Рік вступу]) > 0";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<Item> cources = new List<Item>();
                            while (reader.Read())
                            {
                                Item cource = new Item(
                                    reader.GetInt32(reader.GetOrdinal("Рік вступу")),
                                    reader.GetInt32(reader.GetOrdinal("Курс")).ToString());
                                cources.Add(cource);
                            }
                            return cources;
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
                return null;
            }
        }

        /*
         * Метод отримання дисципліни за ідентифікатором навчального плану
         * та семестром
         */
        public List<Discipline> GetDisciplines(int planId, int semester)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"
                    SELECT DISTINCT {Table.Disciplines}.*
                    FROM {Table.Disciplines} 
                    INNER JOIN([{Table.WorkPrograms}] 
                    INNER JOIN [{Table.AccountingWorkPrograms}] 
                    ON[{Table.WorkPrograms}].ID = [{Table.AccountingWorkPrograms}].[ID робочої програми]) 
                    ON {Table.Disciplines}.ID = [{Table.WorkPrograms}].Дисципліна
                    WHERE((([{Table.AccountingWorkPrograms}].[ID навчального плану]) = {planId}) 
                    AND(([{Table.WorkPrograms}].Семестр) = {semester}))";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<Discipline> disciplines = new List<Discipline>();
                            while (reader.Read())
                            {
                                Discipline discipline = new Discipline
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Назва дисципліни"))
                                };
                                disciplines.Add(discipline);
                            }
                            return disciplines;
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
                return null;
            }
        }

        /*
         * Метод зміни навчального плану за ідентифікатором
         */
        public void UpdateStudyPlan(int id, string link)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    string commText = $@"
                        UPDATE [{Table.StudyPlans}]
                        SET [Посилання на навчальний план]='{link}'
                        WHERE [ID]={id}";
                    command.CommandType = CommandType.Text;
                    command.CommandText = commText;
                    command.Connection = connection;
                    connection.Open();
                    try
                    {
                        _ = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show($"Помилка оновлення даних: {Environment.NewLine}{ex}", "Помилка", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}