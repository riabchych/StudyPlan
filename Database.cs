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
        private List<Discipline> _disciplines;
        private List<Item> _cources;
        private string _cnnString;

        /*
         * Конструктор з параметрами
         */
        public Database(List<Plan> plans, List<WorkProgram> workPrograms,
            List<Discipline> disciplines, string cnnString, List<Item> cources)
        {
            _plans = plans;
            _workPrograms = workPrograms;
            _disciplines = disciplines;
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
            _disciplines = new List<Discipline>();
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
                                    Id = (int)reader["ID"],
                                    Name = (string)reader["Назва"]
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
                Plan plan = new Plan();
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            plan.Id = (int)reader["ID"];
                            plan.EntryYear = (string)reader["Рік вступу"];
                            plan.EntryBase = (int)reader["База вступу"];
                            plan.Program = (int)reader["Робоча програма"];
                            plan.Link = (string)reader["Посилання"];
                            plan.Speciality = (int)reader["Освітня професійна програма"];
                            plan.EducationLevel = (int)reader["Освітній рівень"];
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
                return plan;
            }
        }

        /*
         * Метод отримання робочої програми за ідентифікатором
         */
        public WorkProgram GetWorkProgram(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $"SELECT [ID],[Семестр],[Дисципліна] FROM [Робочі програми] WHERE [ID]={id}";
                command.CommandText = commText;
                command.Connection = connection;
                WorkProgram program = new WorkProgram();
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            program.Id = (int)reader["ID"];
                            program.Semester = (string)reader["Семестр"];
                            program.Discipline = (int)reader["Дисципліна"];
                            return program;
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
                return program;
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
                            List <Group> groups = new List<Group>();
                            List<EntryBase> entryBases = new List<EntryBase>();
                            while (reader.Read())
                            {
                                Group group = new Group
                                {
                                    Id = (int)reader["ID"],
                                    Plan = (int)reader["Навчальний план"],
                                    Name = (string)reader["Назва групи"]
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
                                Item cource = new Item((int)reader["Рік вступу"], reader["Курс"].ToString());
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
         * Метод отримання дисципліни за ідентифікатом
         */
        public void GetDisciplines(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $"SELECT [ID],[Назва дисципліни] FROM [Дисципліни] WHERE [ID]={id}";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Disciplines.Clear();
                            while (reader.Read())
                            {
                                Discipline discipline = new Discipline();
                                discipline.Id = (int)reader["ID"];
                                discipline.Name = (string)reader["Назва дисципліни"];
                                Disciplines.Add(discipline);
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
        public List<Discipline> Disciplines { get => _disciplines; set => _disciplines = value; }
        public List<Item> Cources { get => _cources; set => _cources = value; }
    }
}