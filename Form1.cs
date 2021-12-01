using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class Form1 : Form
    {
        private readonly Database db;
        private readonly SearchData searchData;
        private List<EntryBase> entryBases;
        private List<Group> groups;
        private List<int> semesters;


        private WorkProgram workProgram;
        private Plan plan;

        public Form1()
        {

            db = new Database();
            searchData = new SearchData();
            workProgram = new WorkProgram();
            entryBases = new List<EntryBase>();
            groups = new List<Group>();
            semesters = new List<int>();
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
            courseCb.DisplayMember = "Description";
            courseCb.ValueMember = "Id";
            db.GetCources();
            db.Cources = db.Cources.OrderBy(u => u.Description).ToList();
            db.Cources.Insert(0, new Item(0, "---Оберіть---"));
            courseCb.DataSource = db.Cources;
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
            entryBases.Insert(0, new EntryBase(0, "---Оберіть---"));
            entryBaseCb.DataSource = entryBases;
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
            foreach (int semester in semesters)
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
            groups.Insert(0, new Group() { Id = 0, Name = "---Оберіть---" });
            groupCb.DisplayMember = "Name";
            groupCb.ValueMember = "Id";
            groupCb.DataSource = groups;
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
                searchData.EntryYear = courseCb.SelectedValue == null ? 0 : int.Parse(courseCb.SelectedValue.ToString());
                if (courseCb.Items.Count > 1 && searchData.EntryYear > 0)
                {
                    groups = db.GetGroups(searchData.EntryYear);
                    if (groups != null && groups.Count > 0)
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
                entryBases = db.GetEntryBases(searchData.Group, searchData.EntryYear);
                if (entryBases != null && entryBases.Count > 0)
                {
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
                semesters = db.GetSemesters(searchData.EntryYear, searchData.Group, searchData.EntryBase);

                if (semesters != null && semesters.Count > 0)
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