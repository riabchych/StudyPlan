using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{
    /// <summary>
    /// Клас головної форми
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly StudyPlanDatabaseAdapter StudyPlanDbAdapter;
        private readonly SearchData SearchData;
        private readonly EditTableForm EditForm;
        private Database DbAdapter;
        public List<EntryBase> EntryBases { get; set; }
        public List<Group> Groups { get; set; }
        public List<int> Semesters { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Item> Cources { get; set; }
        public Plan Plan { get; set; }

        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public MainForm()
        {
            SearchData = new SearchData();
            StudyPlanDbAdapter = new StudyPlanDatabaseAdapter();
            EditForm = new EditTableForm(GetTableNames());
            InitializeComponent();
        }

        /// <summary>
        /// Подія при завантаженні форми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Cources = StudyPlanDbAdapter.GetCources();
            if (Cources != null && Cources.Count > 0)
            {
                FillCourseCb();
            }
        }

        /// <summary>
        /// Метод заповнення списку курсів в ComboBox
        /// </summary>
        private void FillCourseCb()
        {
            courseCb.DataSource = null;
            courseCb.Items.Clear();
            courseCb.DisplayMember = "Description";
            courseCb.ValueMember = "Id";
            Cources = Cources.OrderBy(u => u.Description).ToList();
            Cources.Insert(0, new Item(0, "---Оберіть---"));
            courseCb.DataSource = Cources;
            courseCb.SelectedIndex = 0;
            courseCb.Enabled = true;
            courseLb.Enabled = true;
        }

        /// <summary>
        /// Метод заповнення списку Баз вступу в ComboBox
        /// </summary>
        private void FillEntryBaseCb()
        {
            entryBaseCb.DataSource = null;
            entryBaseCb.Items.Clear();
            entryBaseCb.DisplayMember = "Name";
            entryBaseCb.ValueMember = "Id";
            EntryBases.Insert(0, new EntryBase(0, "---Оберіть---"));
            entryBaseCb.DataSource = EntryBases;
            entryBaseCb.SelectedIndex = 0;
            entryBaseLb.Enabled = true;
            entryBaseCb.Enabled = true;
        }

        /// <summary>
        /// Метод заповнення списку семестрів в ComboBox
        /// </summary>
        private void FillSemesterCb()
        {
            semesterCb.DataSource = null;
            semesterCb.Items.Clear();
            _ = semesterCb.Items.Add("---Оберіть---");
            foreach (int semester in Semesters)
            {
                _ = semesterCb.Items.Add(semester);
            }
            semesterCb.SelectedIndex = 0;
            semesterCb.Enabled = true;
            semesterLb.Enabled = true;
        }

        /// <summary>
        /// Метод заповнення списку груп в ComboBox
        /// </summary>
        private void FillGroupCb()
        {
            groupCb.DataSource = null;
            groupCb.Items.Clear();
            Groups.Insert(0, new Group() { Id = 0, Name = "---Оберіть---" });
            groupCb.DisplayMember = "Name";
            groupCb.ValueMember = "Id";
            groupCb.DataSource = Groups;
            groupCb.SelectedIndex = 0;
            groupLb.Enabled = true;
            groupCb.Enabled = true;
        }

        /// <summary>
        /// Метод заповнення списку дисциплін елемента ComboBox
        /// </summary>
        private void FillDisciplineCb()
        {
            disciplineCb.DataSource = null;
            disciplineCb.Items.Clear();
            Disciplines.Insert(0, new Discipline() { Id = 0, Name = "---Оберіть---" });
            disciplineCb.DisplayMember = "Name";
            disciplineCb.ValueMember = "Id";
            disciplineCb.DataSource = Disciplines;
            disciplineCb.SelectedIndex = 0;
            disciplineLb.Enabled = true;
            disciplineCb.Enabled = true;
        }

        /// <summary>
        /// Метод для відключення елементів інтерфейсу користувача
        /// </summary>
        /// <param name="step">Номер кроку фільтрації</param>
        /// <remarks>
        /// Якщо на активному випадаючому списку(ComboBox) не вибране значення
        /// то наступні елементи інтерфейсу користувача будуть відключені.
        /// </remarks>
        private void DisableControls(int step = 0)
        {
            switch (step)
            {
                case 1:
                    SearchData.Group = 0;
                    entryBaseCb.SelectedIndex = -1;
                    entryBaseCb.Enabled = false;
                    entryBaseLb.Enabled = false;
                    semesterCb.SelectedIndex = -1;
                    semesterCb.Enabled = false;
                    semesterLb.Enabled = false;
                    disciplineCb.SelectedIndex = -1;
                    disciplineCb.Enabled = false;
                    disciplineLb.Enabled = false;
                    linkTb.Text = "";
                    linkTb.Enabled = false;
                    linkLb.Enabled = false;
                    editBt.Enabled = false;
                    previewBt.Enabled = false;
                    removeBt.Enabled = false;
                    break;
                case 2:
                    SearchData.EntryBase = 0;
                    semesterCb.SelectedIndex = -1;
                    semesterCb.Enabled = false;
                    semesterLb.Enabled = false;
                    disciplineCb.SelectedIndex = -1;
                    disciplineCb.Enabled = false;
                    disciplineLb.Enabled = false;
                    linkTb.Text = "";
                    linkTb.Enabled = false;
                    linkLb.Enabled = false;
                    editBt.Enabled = false;
                    previewBt.Enabled = false;
                    removeBt.Enabled = false;
                    break;
                case 3:
                    SearchData.Semester = 0;
                    disciplineCb.SelectedIndex = -1;
                    disciplineCb.Enabled = false;
                    disciplineLb.Enabled = false;
                    linkTb.Text = "";
                    linkTb.Enabled = false;
                    linkLb.Enabled = false;
                    editBt.Enabled = false;
                    previewBt.Enabled = false;
                    removeBt.Enabled = false;
                    break;
                case 4:
                    SearchData.Discipline = 0;
                    linkTb.Text = "";
                    linkTb.Enabled = false;
                    linkLb.Enabled = false;
                    editBt.Enabled = false;
                    previewBt.Enabled = false;
                    removeBt.Enabled = false;
                    break;
                default:
                    SearchData.EntryYear = 0;
                    groupCb.SelectedIndex = -1;
                    groupCb.Enabled = false;
                    groupLb.Enabled = false;

                    entryBaseCb.SelectedIndex = -1;
                    entryBaseCb.Enabled = false;
                    entryBaseLb.Enabled = false;

                    semesterCb.SelectedIndex = -1;
                    semesterCb.Enabled = false;
                    semesterLb.Enabled = false;

                    disciplineCb.SelectedIndex = -1;
                    disciplineCb.Enabled = false;
                    disciplineLb.Enabled = false;

                    linkTb.Text = "";
                    linkTb.Enabled = false;
                    linkLb.Enabled = false;
                    editBt.Enabled = false;
                    previewBt.Enabled = false;
                    removeBt.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Метод для відкриття посилання на навчальний план у Веб-браузері
        /// </summary>
        /// <param name="url">Посилання на навчальний план</param>
        private static void OpenUrl(string url)
        {
            DialogResult dr = MessageBox.Show("Ви дійсно бажаєте перейти за посиланням в браузері?",
                "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _ = Process.Start(url);
            }
        }

        /// <summary>
        /// Нормалізація рядка посилання на навчальний план
        /// </summary>
        /// <param name="url">Посилання на навчальний план</param>
        /// <returns>Посилання на навчальний план</returns>
        private string BeautyfyUrl(string url)
        {
            return url == string.Empty ? url : url.Trim('#');
        }
        
        /// <summary>
        /// Метод отримання списку таблиць
        /// </summary>
        /// <returns></returns>
        private List<string> GetTableNames()
        {
            DbAdapter = DbAdapter ?? new Database();
            return DbAdapter.GetTables();
        }

        /// <summary>
        /// Метод який змінює елементи редагування навчального плану
        /// </summary>
        /// <param name="isClicked">Чи була натиснута кнопка збереження або зміни навчального плану</param>
        /// <param name="link">Посилання на навчальний план</param>
        private void ChangeEditPlanCtrls(bool isClicked = false, string link = "")
        {
            if (isClicked && editBt.Text == "Зберегти")
            {
                linkTb.Enabled = true;
                linkLb.Enabled = true;
                linkTb.ReadOnly = true;
                editBt.Text = "Внести зміни";
                editBt.Enabled = true;
                previewBt.Enabled = true;
                removeBt.Enabled = true;
                Plan.Link = linkTb.Text;
                StudyPlanDbAdapter.UpdateStudyPlan(Plan.Id, linkTb.Text);
                return;
            }
            if ((isClicked && editBt.Text == "Внести зміни") || editBt.Text == "Додати")
            {
                linkTb.Enabled = true;
                linkLb.Enabled = true;
                linkTb.ReadOnly = false;
                linkTb.Text = link;
                editBt.Text = "Зберегти";
                editBt.Enabled = true;
                previewBt.Enabled = false;
                removeBt.Enabled = false;
                Plan.Link = link;
                return;
            }
            if (link == "")
            {
                linkLb.Enabled = false;
                linkTb.Enabled = false;
                linkTb.ReadOnly = true;
                linkTb.Text = "";
                editBt.Text = "Додати";
                editBt.Enabled = true;
                previewBt.Enabled = false;
                removeBt.Enabled = false;
                Plan.Link = "";
                return;
            }
            else
            {
                linkTb.Enabled = true;
                linkLb.Enabled = true;
                linkTb.ReadOnly = true;
                linkTb.Text = link;
                Plan.Link = link;
                editBt.Text = "Внести зміни";
                editBt.Enabled = true;
                previewBt.Enabled = true;
                removeBt.Enabled = true;
                return;
            }
        }


        /// <summary>
        /// Подія при зміні обраного значення у випадаючому списку курсів 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseCb_SelectedValueChanged(object sender, EventArgs e)
        {

            DisableControls();
            if (courseCb.SelectedIndex > 0)
            {
                SearchData.EntryYear = courseCb.SelectedValue == null ? 0 : int.Parse(courseCb.SelectedValue.ToString());
                if (courseCb.Items.Count > 1 && SearchData.EntryYear > 0)
                {
                    Groups = StudyPlanDbAdapter.GetGroups(SearchData.EntryYear);
                    if (Groups != null && Groups.Count > 0)
                    {
                        FillGroupCb();
                    }
                }
            }
        }

        /// <summary>
        /// Подія при зміні обраного значення у випадаючому списку груп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(1);
            if (groupCb.SelectedIndex > 0)
            {
                SearchData.Group = groupCb.SelectedValue == null ? 0 : (int)groupCb.SelectedValue;
                EntryBases = StudyPlanDbAdapter.GetEntryBases(SearchData.Group, SearchData.EntryYear);
                if (EntryBases != null && EntryBases.Count > 0)
                {
                    SearchData.Plan = Groups.Find(item => item.Id == SearchData.Group).Plan;
                    FillEntryBaseCb();
                }
            }

        }

        /// <summary>
        /// Подія при зміні значення у випадаючому списку бази вступу 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryBaseCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(2);
            if (entryBaseCb.SelectedIndex > 0)
            {
                SearchData.EntryBase = entryBaseCb.SelectedValue == null ? 0 : (int)entryBaseCb.SelectedValue;
                Semesters = StudyPlanDbAdapter.GetSemesters(SearchData.EntryYear, SearchData.Group, SearchData.EntryBase);
                if (Semesters != null && Semesters.Count > 0)
                {
                    FillSemesterCb();
                }
            }
        }

        /// <summary>
        /// Подія при зміні значення у випадаючому списку семестрів 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SemesterCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(3);
            if (semesterCb.SelectedIndex > 0)
            {
                SearchData.Semester = semesterCb.SelectedItem == null ? 0 : int.Parse(semesterCb.SelectedItem.ToString());
                Disciplines = StudyPlanDbAdapter.GetDisciplines(SearchData.Plan, SearchData.Semester);
                if (Disciplines != null && Disciplines.Count > 0)
                {
                    FillDisciplineCb();
                }
            }
        }

        /// <summary>
        /// Подія при зміні значення у випадаючому списку дисциплін 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisciplineCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(4);
            if (disciplineCb.SelectedIndex > 0)
            {
                SearchData.Discipline = disciplineCb.SelectedValue == null ? 0 : (int)disciplineCb.SelectedValue;
                Plan = StudyPlanDbAdapter.GetPlan(SearchData.Plan);
                if (linkTb.Text == "")
                {
                    if (Plan != null)
                    {
                        editBt.Text = "Внести зміни";
                        Plan.Link = BeautyfyUrl(Plan.Link);
                        ChangeEditPlanCtrls(false, Plan.Link);
                    }
                }
            }
        }

        /// <summary>
        /// Подія при натисненні на кнопку перегляду навчального плану
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBt_Click(object sender, EventArgs e)
        {
            OpenUrl(Plan.Link);
        }

        /// <summary>
        /// Подія при натисненні на кнопку редагування та збереження посилання на навчальний план
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBt_Click(object sender, EventArgs e)
        {
            ChangeEditPlanCtrls(true);
        }

        /// <summary>
        /// Подія при натисненні на кнопку видалення посилання на навчальний план
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveBt_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ви дійсно бажаєте видалити навчальний план?",
                "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                StudyPlanDbAdapter.UpdateStudyPlan(Plan.Id, "");
                ChangeEditPlanCtrls(false);
            }
        }

        /// <summary>
        /// Подія при натисненні на пункт меню редагування таблиць
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = EditForm.ShowDialog();
        }

        /// <summary>
        /// Подія при натисненні на на пункт меню виходу з програми 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}