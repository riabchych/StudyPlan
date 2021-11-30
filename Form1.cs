using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class Form1 : Form
    {
        private readonly Database db;
        private readonly SearchData searchData;
        private WorkProgram workProgram;
        private Plan plan;

        public Form1()
        {

            db = new Database();
            searchData = new SearchData();
            workProgram = new WorkProgram();
            plan = new Plan();
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillCourseCb();
        }

        /*
         * Метод заповнення списку курсів для елемента ComboBox
         */
        private void FillCourseCb()
        {
            courseCb.DataSource = null;
            courseCb.Items.Clear();
            db.Cources.Insert(0, new Item(0, "---Оберіть---"));
            courseCb.DisplayMember = "Description";
            courseCb.ValueMember = "Id";
            db.GetCources();
            courseCb.DataSource = db.Cources.OrderBy(u => u.Description).ToList();
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
            db.EntryBases.Insert(0, new EntryBase() { Id = 0, Name = "---Оберіть---" });
            entryBaseCb.DisplayMember = "Name";
            entryBaseCb.ValueMember = "Id";
            entryBaseCb.DataSource = db.EntryBases;
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
            semesterCb.Items.Add(workProgram.Semester);
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
            db.Groups.Insert(0, new Group() { Id = 0, Name = "---Оберіть---" });
            groupCb.DisplayMember = "Name";
            groupCb.ValueMember = "Id";
            groupCb.DataSource = db.Groups;
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
            db.Disciplines.Insert(0, new Discipline() { Id = 0, Name = "---Оберіть---" });
            disciplineCb.DisplayMember = "Name";
            disciplineCb.ValueMember = "Id";
            disciplineCb.DataSource = db.Disciplines;
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
                    searchData.Course = 0;
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
                plan.Link = linkTb.Text;
                db.UpdateStudyPlan(plan.Id, linkTb.Text);
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
                plan.Link = link;
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
                plan.Link = "";
                return;
            }
            else
            {
                linkTb.Enabled = true;
                linkLb.Enabled = true;
                linkTb.ReadOnly = true;
                linkTb.Text = link;
                plan.Link = link;
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
                searchData.Course = courseCb.SelectedItem == null ? 0 : int.Parse((string)courseCb.SelectedItem);
                if (courseCb.Items.Count > 1 && searchData.Course > 0)
                {
                    db.Groups.Clear();
                    db.GetGroups(searchData.Course);

                    if (db.Groups.Count > 0)
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
                if (groupCb.Items.Count > 1 && searchData.Group > 0)
                {
                    int id = db.Groups.Find(item => item.Id == searchData.Group).Plan;
                    plan = db.GetPlan(id);
                    workProgram = db.GetWorkProgram(plan.Program);
                    db.GetEntryBase(plan.EntryBase);
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

                if (semesterCb.Items.Count > 1 && searchData.EntryBase > 0)
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
                searchData.Semester = semesterCb.SelectedItem == null ? 0 : int.Parse((string)semesterCb.SelectedItem);

                if (semesterCb.Items.Count > 1)
                {
                    db.GetDisciplines(workProgram.Discipline);
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

                if (linkTb.Text == "")
                {
                    if (plan != null)
                    {
                        editBt.Text = "Внести зміни";
                        ChangeEditPlanCtrls(false, plan.Link);
                    }
                }
            }
        }

        /*
         * Подія яка виконується при натисненні на кнопку "Переглянути"
         */
        private void PreviewBt_Click(object sender, EventArgs e)
        {
            OpenUrl(plan.Link);
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
                db.UpdateStudyPlan(plan.Id, "");
                ChangeEditPlanCtrls(false);
            }
        }
    }
}