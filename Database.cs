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
        private List<Plan> _plans;
        private List<Group> _groups;
        private List<WorkProgram> _workPrograms;
        private List<Discipline> _disciplines;
        private List<EntryBase> _entryBases;
        private string _cnnString;

        /*
         * Конструктор з параметрами
         */
        public Database(List<Plan> plans, List<Group> groups, List<WorkProgram> workPrograms,
            List<Discipline> disciplines, string cnnString, List<EntryBase> entryBases)
        {
            _plans = plans;
            _groups = groups;
            _workPrograms = workPrograms;
            _disciplines = disciplines;
            _cnnString = cnnString;
            _entryBases = entryBases;
        }

        /*
         * Конструктор без параметрів
         */
        public Database()
        {
            _plans = new List<Plan>();
            _groups = new List<Group>();
            _workPrograms = new List<WorkProgram>();
            _disciplines = new List<Discipline>();
            _entryBases = new List<EntryBase>();
            _cnnString = $@"Provider=Microsoft.ACE.OLEDB.12.0;
                            Data Source={Properties.Settings.Default.StudyPlanDbConnectionString}; 
                            Persist Security Info=False;";
        }

        /*
         * Метод отримання баз вступу за ідентифікатором
         */
        public void GetEntryBase(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $"SELECT * FROM [Бази вступу] WHERE [ID]={id}";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            EntryBases.Clear();
                            while (reader.Read())
                            {
                                EntryBase entryBase = new EntryBase();
                                entryBase.Id = (int)reader["ID"];
                                entryBase.Name = (string)reader["Назва бази вступу"];
                                EntryBases.Add(entryBase);
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
                            plan.StudyForm = (string)reader["Форма навчання"];
                            plan.EntryBase = (int)reader["База вступу"];
                            plan.Program = (int)reader["Робоча програма"];
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
                string commText = $"SELECT [ID],[Посилання],[Семестр],[Дисципліна] FROM [Робочі програми] WHERE [ID]={id}";
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
                            program.Link = (string)reader["Посилання"];
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
        public void GetGroups(int cource)
        {
            using (OleDbConnection connection = new OleDbConnection(CnnString))
            {
                OleDbCommand command = new OleDbCommand();
                string commText = $"SELECT * FROM [Групи] WHERE [Курс]={cource}";
                command.CommandText = commText;
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Groups.Clear();
                            while (reader.Read())
                            {
                                Group group = new Group();
                                group.Id = (int)reader["ID"];
                                group.Course = (int)reader["Курс"];
                                group.Plan = (int)reader["Навчальний план"];
                                group.StudyYear = (string)reader["Навчальний рік"];
                                group.Name = (string)reader["Назва групи"];
                                Groups.Add(group);
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
                    string commText = $"UPDATE [Робочі програми] SET [Посилання]='{link}'  WHERE [ID]={id}";
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
        public List<Group> Groups { get => _groups; set => _groups = value; }
        public List<WorkProgram> WorkPrograms { get => _workPrograms; set => _workPrograms = value; }
        public List<Discipline> Disciplines { get => _disciplines; set => _disciplines = value; }
        public List<EntryBase> EntryBases { get => _entryBases; set => _entryBases = value; }
    }
}