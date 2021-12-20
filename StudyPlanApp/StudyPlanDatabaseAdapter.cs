using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{

    /// <summary>
    /// Клас для роботи з базою даних
    /// </summary>
    public class StudyPlanDatabaseAdapter : IStudyPlanDatabaseAdapter
    {
        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public StudyPlanDatabaseAdapter()
        {
        }

        /// <summary>
        /// Метод отримання баз вступу
        /// </summary>
        /// <param name="groupId">Ідентифікатор групи</param>
        /// <returns>Список баз вступу</returns>
        public List<EntryBase> GetEntryBases(int groupId)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
                    SELECT DISTINCT [{Table.EntryBases}].ID, [{Table.EntryBases}].Назва
                    FROM ([{Table.EntryBases}] 
                    INNER JOIN [{Table.StudyPlans}] 
                        ON [{Table.EntryBases}].ID = [{Table.StudyPlans}].[База вступу]) 
                    INNER JOIN {Table.Groups} 
                        ON [{Table.StudyPlans}].ID = {Table.Groups}.[Навчальний план]
                    WHERE {Table.Groups}.ID={groupId}";
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
                }
                return null;
            }
        }

        /// <summary>
        /// Метод отримання навчального плану за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор навчального плану</param>
        /// <returns>Навчальний план</returns>
        public Plan GetPlan(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT DISTINCT * FROM [{Table.StudyPlans}] WHERE ID={id}";
                    try
                    {
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                _ = reader.Read();
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
                }
                return null;
            }
        }

        /// <summary>
        /// Метод отримання списку семестрів
        /// </summary>
        /// <param name="groupId">Ідентифікатор групи</param>
        /// <param  name="entryBaseId">Ідентифікатор бази вступу</param>
        /// <returns>Список семестрів</returns>
        public List<int> GetSemesters(int groupId, int entryBaseId)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
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
                        WHERE ((({Table.Groups}.ID)={groupId}) 
                            AND (([{Table.StudyPlans}].[База вступу])={entryBaseId}))";
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
                }
                return null;
            }
        }

        /// <summary>
        /// Метод отримання списку груп
        /// </summary>
        /// <param name="cource">Номер курсу</param>
        /// <returns>Список груп</returns>
        public List<Group> GetGroups(int cource)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    int year = DateTime.Now.Year;
                    string expr = $"WHERE [{Table.StudyPlans}].[Рік вступу]={(cource == 1 ? year : year - --cource)}";
                    command.Connection = connection;
                    command.CommandText = $@"
                        SELECT DISTINCT [{Table.Groups}].[ID], [{Table.Groups}].[Навчальний план], 
                            [{Table.GroupNames}].[Назва групи]
                        FROM [{Table.GroupNames}] 
                        INNER JOIN ([{Table.StudyPlans}] 
                        INNER JOIN {Table.Groups} 
                            ON [{Table.StudyPlans}].ID = {Table.Groups}.[Навчальний план]) 
                            ON [{Table.GroupNames}].ID = {Table.Groups}.[Назва групи]
                        {expr}";
                    try
                    {
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                List<Group> groups = new List<Group>();
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
                }
                return null;
            }
        }

        /// <summary>
        /// Метод отримання списку семестрів
        /// </summary>
        /// <returns>Список семестрів</returns>
        public List<Item> GetCources()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
                        SELECT DISTINCT [Рік вступу], IIF([Рік вступу]=Year(Now()),1,Year(Now())-[Рік вступу]+1) as Курс
                        FROM [{Table.StudyPlans}]
                        WHERE([Рік вступу] <= Year(Now()) and [Рік вступу] >= Year(Now())-3)";
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
                                return cources.GroupBy(x => x.Description).Select(x => x.First()).ToList();
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
        }

        /// <summary>
        /// Метод отримання дисципліни
        /// </summary>
        /// <param name="planId">Ідентифікатор навчального плану</param>
        /// <param name="semester">Номер семестру</param>
        /// <returns>Список дисциплін</returns>
        public List<Discipline> GetDisciplines(int planId, int semester)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
                    SELECT DISTINCT {Table.Disciplines}.*
                    FROM {Table.Disciplines} 
                    INNER JOIN([{Table.WorkPrograms}] 
                    INNER JOIN [{Table.AccountingWorkPrograms}] 
                        ON[{Table.WorkPrograms}].ID = [{Table.AccountingWorkPrograms}].[ID робочої програми]) 
                        ON {Table.Disciplines}.ID = [{Table.WorkPrograms}].Дисципліна
                    WHERE [{Table.AccountingWorkPrograms}].[ID навчального плану] = {planId} 
                        AND [{Table.WorkPrograms}].Семестр = {semester}";
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
                }
                return null;
            }
        }

        /// <summary>
        /// Метод зміни посилання на навчальний план
        /// </summary>
        /// <param name="id">Ідентифікатор навчального плану</param>
        /// <param name="link">Посилання на навчальний план</param>
        public void UpdateStudyPlan(int id, string link)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"
                        UPDATE [{Table.StudyPlans}]
                        SET [Посилання на навчальний план]='{link}'
                        WHERE [ID]={id}";
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

        /// <summary>
        /// Метод отримання посилання на робочу програму
        /// </summary>
        /// <param name="planId">Ідентифікатор навчального плану</param>
        /// <param name="disciplineId">Ідентифікатор дисципліни</param>
        /// <param name="semester">Номер семестру</param>
        /// <returns>Поислання на робочу програму</returns>
        public string GetWorkProgramLink(int planId, int disciplineId, int semester, ref int workProgramId)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
                        SELECT DISTINCT [Робочі програми].[ID], [Робочі програми].[Посилання на робочу програму]
                        FROM Дисципліни 
                        INNER JOIN ([Робочі програми] 
                        INNER JOIN ([Навчальні плани] 
                        INNER JOIN [Облік робочих програм] 
                            ON [Навчальні плани].ID = [Облік робочих програм].[ID навчального плану]) 
                            ON [Робочі програми].ID = [Облік робочих програм].[ID робочої програми]) 
                            ON Дисципліни.ID = [Робочі програми].Дисципліна
                        WHERE ((([Робочі програми].Дисципліна)={disciplineId}) 
                            AND (([Робочі програми].Семестр)={semester}) 
                            AND (([Навчальні плани].ID)={planId}))";
                    try
                    {
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                _ = reader.Read();
                                workProgramId = reader.GetInt32(reader.GetOrdinal("ID"));
                                return reader.GetString(reader.GetOrdinal("Посилання на робочу програму"));
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

        public void UpdateWorkProgram(int id, string link)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.StudyPlanDbConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"
                        UPDATE [{Table.WorkPrograms}]
                        SET [Посилання на робочу програму]='{link}'
                        WHERE [ID]={id}";
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