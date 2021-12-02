using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class MainForm : Form
    {
        private readonly Database db;
        private readonly SearchData searchData;
        private List<EntryBase> entryBases;
        private List<Group> groups;
        private List<int> semesters;
        private List<Discipline> disciplines;
        private List<Item> cources;
        private Plan plan;
        public List<EntryBase> EntryBases { get => entryBases; set => entryBases = value; }
        public List<Group> Groups { get => groups; set => groups = value; }
        public List<int> Semesters { get => semesters; set => semesters = value; }
        public List<Discipline> Disciplines { get => disciplines; set => disciplines = value; }
        public List<Item> Cources { get => cources; set => cources = value; }
        public Plan Plan { get => plan; set => plan = value; }

        public MainForm()
        {
            db = new Database();
            searchData = new SearchData();
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Cources = db.GetCources();
            if (Cources != null && Cources.Count > 0)
            {
                FillCourseCb();
            }
        }

        /*
         * Метод заповнення списку курсів для елемента ComboBox
         */
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

        /*
         * Метод заповнення списку Бази вступу для елемента ComboBox
        */
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

        /*
         * Метод заповнення списку семестрів елемента ComboBox
        */
        private void FillSemesterCb()
        {
            semesterCb.DataSource = null;
            semesterCb.Items.Clear();
            semesterCb.Items.Add("---Оберіть---");
            foreach (int semester in Semesters)
            {
                semesterCb.Items.Add(semester);
            }
            semesterCb.SelectedIndex = 0;
            semesterCb.Enabled = true;
            semesterLb.Enabled = true;
        }

        /*
         * Метод заповнення списку груп елемента ComboBox
        */
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

        /*
         * Метод заповнення списку дисциплін елемента ComboBox
        */
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

        /*
         * Метод для відключення елементів інтерфейсу користувача 
         * якщо не вибраний жодний пункт у випадаючому списку(ComboBox).
         * Тобто якщо на активному випадаючому списку(ComboBox) не вибране значення
         * то наступні елементи інтерфейсу користувача будуть відключені.
         */
        private void DisableControls(int step = 0)
        {
            switch (step)
            {
                case 1:
                    searchData.Group = 0;
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
                    searchData.EntryBase = 0;
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
                    searchData.Semester = 0;
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
                    searchData.Discipline = 0;
                    linkTb.Text = "";
                    linkTb.Enabled = false;
                    linkLb.Enabled = false;
                    editBt.Enabled = false;
                    previewBt.Enabled = false;
                    removeBt.Enabled = false;
                    break;
                default:
                    searchData.EntryYear = 0;
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

        /*
         * Метод для відкриття посилання на навчальний план у Веб-браузері
         */
        private static void OpenUrl(string url)
        {
            DialogResult dr = MessageBox.Show("Ви дійсно бажаєте перейти за посиланням в браузері?", "Навчальний план", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Process.Start(url);
            }
        }

        private string BeautyfyUrl(string url)
        {
            return url.Trim('#');
        }

        /*
         * Метод який змінює елементи редагування навчального плану, а також 
         * редагує, додає та видаляє  його.
         */
        private void ChangeEditPlanCtrls(bool isUpdating = false, string link = "")
        {
            if (isUpdating && editBt.Text == "Зберегти")
            {
                linkTb.Enabled = true;
                linkLb.Enabled = true;
                linkTb.ReadOnly = true;
                editBt.Text = "Внести зміни";
                editBt.Enabled = true;
                previewBt.Enabled = true;
                removeBt.Enabled = true;
                Plan.Link = linkTb.Text;
                db.UpdateStudyPlan(Plan.Id, linkTb.Text);
                return;
            }

            if (isUpdating && editBt.Text == "Внести зміни" || editBt.Text == "Додати")
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

        /*
         * Подія яка виконується при зміні значення у випадаючому списку курсів 
         */
        private void CourseCb_SelectedValueChanged(object sender, EventArgs e)
        {

            DisableControls();
            if (courseCb.SelectedIndex > 0)
            {
                searchData.EntryYear = courseCb.SelectedValue == null ? 0 : int.Parse(courseCb.SelectedValue.ToString());
                if (courseCb.Items.Count > 1 && searchData.EntryYear > 0)
                {
                    Groups = db.GetGroups(searchData.EntryYear);
                    if (Groups != null && Groups.Count > 0)
                    {
                        FillGroupCb();
                    }
                }

            }
        }

        /*
         * Подія яка виконується при зміні значення у випадаючому списку груп 
         */
        private void GroupCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(1);
            if (groupCb.SelectedIndex > 0)
            {
                searchData.Group = groupCb.SelectedValue == null ? 0 : (int)groupCb.SelectedValue;
                EntryBases = db.GetEntryBases(searchData.Group, searchData.EntryYear);
                if (EntryBases != null && EntryBases.Count > 0)
                {
                    searchData.Plan = Groups.Find(item => item.Id == searchData.Group).Plan;
                    FillEntryBaseCb();
                }
            }

        }

        /*
         * Подія яка виконується при зміні значення у випадаючому списку бази вступу 
         */
        private void EntryBaseCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(2);
            if (entryBaseCb.SelectedIndex > 0)
            {
                searchData.EntryBase = entryBaseCb.SelectedValue == null ? 0 : (int)entryBaseCb.SelectedValue;
                Semesters = db.GetSemesters(searchData.EntryYear, searchData.Group, searchData.EntryBase);
                if (Semesters != null && Semesters.Count > 0)
                {
                    FillSemesterCb();
                }
            }
        }

        /*
         * Подія яка виконується при зміні значення у випадаючому списку семестрів 
         */
        private void SemesterCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(3);
            if (semesterCb.SelectedIndex > 0)
            {
                searchData.Semester = semesterCb.SelectedItem == null ? 0 : int.Parse(semesterCb.SelectedItem.ToString());
                Disciplines = db.GetDisciplines(searchData.Plan, searchData.Semester);
                if (Disciplines != null && Disciplines.Count > 0)
                {
                    FillDisciplineCb();
                }
            }
        }

        /*
         * Подія яка виконується при зміні значення у випадаючому списку дисциплін 
         */
        private void DisciplineCb_SelectedValueChanged(object sender, EventArgs e)
        {
            DisableControls(4);

            if (disciplineCb.SelectedIndex > 0)
            {
                searchData.Discipline = disciplineCb.SelectedValue == null ? 0 : (int)disciplineCb.SelectedValue;
                Plan = db.GetPlan(searchData.Plan);
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

        /*
         * Подія яка виконується при натисненні на кнопку "Переглянути"
         */
        private void PreviewBt_Click(object sender, EventArgs e)
        {
            OpenUrl(Plan.Link);
        }

        /*
         * Подія яка виконується при натисненні на кнопку "Редагувати", "Внести зміни" та "Зберегти"
         */
        private void EditBt_Click(object sender, EventArgs e)
        {
            ChangeEditPlanCtrls(true);
        }

        /*
         * Подія яка виконується при натисненні на кнопку "Видалили"
         */
        private void RemoveBt_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ви дійсно бажаєте видалити навчальний план?", "Навчальний план", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                db.UpdateStudyPlan(Plan.Id, "");
                ChangeEditPlanCtrls(false);
            }
        }

        private void DisciplinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.Disciplines).ShowDialog();
        }

        private void GroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.Groups).ShowDialog();
        }

        private void EntryBasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.EntryBases).ShowDialog();
        }

        private void StudyPlansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.StudyPlans).ShowDialog();
        }

        private void WorkProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.WorkPrograms).ShowDialog();
        }

        private void SpecialityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.Specialities).ShowDialog();
        }

        private void EducationLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new EditForm(Table.EducationLevels).ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}