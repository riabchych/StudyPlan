using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{
    /*
     * Класс для роботи з базою даних
     */
    public class Database
    {
        private List<Plan> _plans;
        private List<WorkProgram> _workPrograms;
        private List<Item> _cources;
        private string _cnnString;

        /*
         * Конструктор з параметрами
         */
        public Database(List<Plan> plans, List<WorkProgram> workPrograms,
            string cnnString, List<Item> cources)
        {
            _plans = plans;
            _workPrograms = workPrograms;
            _cnnString = cnnString;
            _cources = cources;
        }

        /*
         * Конструктор без параметрів
         */
        public Database()
        {
            _plans = new List<Plan>();
            _workPrograms = new List<WorkProgram>();
            _cources = new List<Item>();
            _cnnString = $@"Provider=Microsoft.ACE.OLEDB.12.0;
                            Data Source={Properties.Settings.Default.StudyPlanDbConnectionString}; 
                            Persist Security Info=False;";
        }

        /*
         * Метод отримання баз вступу за ідентифікатором групи та роком вступу
         */
        public List<EntryBase> GetEntryBases(int groupId, int entryYear)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"SELECT DISTINCT [Бази вступу].ID, [Бази вступу].Назва
FROM ([Бази вступу] INNER JOIN [Навчальні плани] ON [Бази вступу].ID = [Навчальні плани].[База вступу]) INNER JOIN Групи ON [Навчальні плани].ID = Групи.[Навчальний план]
WHERE ((([Навчальні плани].[Рік вступу])={entryYear}) AND ((Групи.ID)={groupId}))";
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
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
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
                string commText = $"SELECT * FROM [Навчальні плани] WHERE [ID]={id}";
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
                                Id = (int)reader["ID"],
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
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }

        /*
         * Метод отримання списку семестрів за роком вступу, ідентификітором групи та ідентификітором бази вступу
         */
        public List<int> GetSemesters(int entryYear, int groupId, int entryBase)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"SELECT DISTINCT [Робочі програми].Семестр
FROM [Робочі програми] INNER JOIN ((([Бази вступу] INNER JOIN [Навчальні плани] ON [Бази вступу].ID = [Навчальні плани].[База вступу]) INNER JOIN Групи ON [Навчальні плани].ID = Групи.[Навчальний план]) INNER JOIN [Облік робочих програм] ON [Навчальні плани].ID = [Облік робочих програм].[ID навчального плану]) ON [Робочі програми].ID = [Облік робочих програм].[ID робочої програми]
WHERE ((([Навчальні плани].[Рік вступу])={entryYear}) AND ((Групи.ID)={groupId}) AND (([Навчальні плани].[База вступу])={entryBase}))";
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
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }

        /*
         * Метод отримання списку груп за номером курсу
         */
        public List<Group> GetGroups(int entryYear)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"SELECT DISTINCT Групи.*
FROM [Навчальні плани] INNER JOIN Групи ON [Навчальні плани].ID = Групи.[Навчальний план]
WHERE [Навчальні плани].[Рік вступу]={entryYear}";
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
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
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
        public void GetCources()
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"SELECT DISTINCT [Рік вступу],(Year(Now())-[Рік вступу]) AS [Курс]
                                     FROM[Навчальні плани]
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
                            Cources.Clear();
                            while (reader.Read())
                            {
                                Item cource = new Item(reader.GetInt32(reader.GetOrdinal("Рік вступу")), reader.GetInt32(reader.GetOrdinal("Курс")).ToString());
                                Cources.Add(cource);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /*
         * Метод отримання дисципліни за роком вступу, ідентифікатором групи,
         * ыдентифыкаторм бази вступу та ідентифікатором робочої програми
         */
        public List<Discipline> GetDisciplines(int planId, int semester)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $@"SELECT DISTINCT Дисципліни.*
FROM Дисципліни INNER JOIN([Робочі програми] INNER JOIN [Облік робочих програм] ON[Робочі програми].ID = [Облік робочих програм].[ID робочої програми]) ON Дисципліни.ID = [Робочі програми].Дисципліна
WHERE((([Облік робочих програм].[ID навчального плану]) = {planId}) AND(([Робочі програми].Семестр) = {semester}))";
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
                    _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }

        /*
         * Метод зміни навчального плану за ідентифікатом
         */
        public void UpdateStudyPlan(int id, string link)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    string commText = $"UPDATE [Навчальний план] SET [Посилання]='{link}'  WHERE [ID]={id}";
                    command.CommandType = CommandType.Text;
                    command.CommandText = commText;
                    command.Connection = connection;
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show($"Помилка отримання даних: {Environment.NewLine}{ex}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public List<Plan> Plans { get => _plans; set => _plans = value; }
        public string CnnString { get => _cnnString; set => _cnnString = value; }
        public List<WorkProgram> WorkPrograms { get => _workPrograms; set => _workPrograms = value; }
        public List<Item> Cources { get => _cources; set => _cources = value; }
    }
}