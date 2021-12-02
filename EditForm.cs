using System;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class EditForm : Form
    {
        private Table _activeTable;

        public Table ActiveTable { get => _activeTable; set => _activeTable = value; }

        public EditForm(Table activeTable)
        {
            _activeTable = activeTable;
            InitializeComponent();
            ShowTable();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.WorkPrograms". При необходимости она может быть перемещена или удалена.
            workProgramsTableAdapter.Fill(studyPlanDbDataSet.WorkPrograms);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.Specialities". При необходимости она может быть перемещена или удалена.
            specialitiesTableAdapter.Fill(studyPlanDbDataSet.Specialities);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.EducationLevels". При необходимости она может быть перемещена или удалена.
            educatioLevelsTableAdapter.Fill(studyPlanDbDataSet.EducationLevels);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.AccountingWorkPrograms". При необходимости она может быть перемещена или удалена.
            accountingWorkProgramsTableAdapter.Fill(studyPlanDbDataSet.AccountingWorkPrograms);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.GroupNames". При необходимости она может быть перемещена или удалена.
            groupNamesTableAdapter.Fill(studyPlanDbDataSet.GroupNames);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.StudyPlans". При необходимости она может быть перемещена или удалена.
            studyPlansTableAdapter.Fill(studyPlanDbDataSet.StudyPlans);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.Groups". При необходимости она может быть перемещена или удалена.
            groupsTableAdapter.Fill(studyPlanDbDataSet.Groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.EntryBases". При необходимости она может быть перемещена или удалена.
            entryBasesTableAdapter.Fill(studyPlanDbDataSet.EntryBases);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet1.Disciplines". При необходимости она может быть перемещена или удалена.
            disciplinesTableAdapter.Fill(studyPlanDbDataSet.Disciplines);
        }

        public void FillDisciplineTable()
        {
            dataGridView.DataMember = "Disciplines";
            bindingSource.DataMember = "Disciplines";
            bindingSource.Position = 0;
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn disciplneNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                disciplneNameDataGridViewTextBoxColumn
            });
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            disciplneNameDataGridViewTextBoxColumn.DataPropertyName = "Назва дисципліни";
            disciplneNameDataGridViewTextBoxColumn.HeaderText = "Назва дисципліни";
            disciplneNameDataGridViewTextBoxColumn.Name = "disciplneNameDataGridViewTextBoxColumn";
        }

        public void FillStudyPlanTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn specialityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn educationLevelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn entryBaseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn studyPlanLinkDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn entryYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                specialityDataGridViewTextBoxColumn,
                educationLevelDataGridViewTextBoxColumn,
                entryBaseDataGridViewTextBoxColumn,
                studyPlanLinkDataGridViewTextBoxColumn,
                entryYearDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "StudyPlans";
            bindingSource.DataMember = "StudyPlans";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // specialityDataGridViewTextBoxColumn
            // 
            specialityDataGridViewTextBoxColumn.DataPropertyName = "Освітня професійна програма";
            specialityDataGridViewTextBoxColumn.HeaderText = "Освітня професійна програма";
            specialityDataGridViewTextBoxColumn.Name = "specialityDataGridViewTextBoxColumn";
            // 
            // educationLevelDataGridViewTextBoxColumn
            // 
            educationLevelDataGridViewTextBoxColumn.DataPropertyName = "Освітній рівень";
            educationLevelDataGridViewTextBoxColumn.HeaderText = "Освітній рівень";
            educationLevelDataGridViewTextBoxColumn.Name = "educationLevelDataGridViewTextBoxColumn";
            // 
            // entryBaseDataGridViewTextBoxColumn
            // 
            entryBaseDataGridViewTextBoxColumn.DataPropertyName = "База вступу";
            entryBaseDataGridViewTextBoxColumn.HeaderText = "База вступу";
            entryBaseDataGridViewTextBoxColumn.Name = "entryBaseDataGridViewTextBoxColumn";
            // 
            // studyPlanLinkDataGridViewTextBoxColumn
            // 
            studyPlanLinkDataGridViewTextBoxColumn.DataPropertyName = "Посилання на навчальний план";
            studyPlanLinkDataGridViewTextBoxColumn.HeaderText = "Посилання на навчальний план";
            studyPlanLinkDataGridViewTextBoxColumn.Name = "studyPlanLinkDataGridViewTextBoxColumn";
            // 
            // entryYearDataGridViewTextBoxColumn
            // 
            entryYearDataGridViewTextBoxColumn.DataPropertyName = "Рік вступу";
            entryYearDataGridViewTextBoxColumn.HeaderText = "Рік вступу";
            entryYearDataGridViewTextBoxColumn.Name = "entryYearDataGridViewTextBoxColumn";
        }

        public void FillWorkProgramTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn semesterDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn disciplinaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                semesterDataGridViewTextBoxColumn,
                disciplinaDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "WorkPrograms";
            bindingSource.DataMember = "WorkPrograms";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // semesterDataGridViewTextBoxColumn
            // 
            semesterDataGridViewTextBoxColumn.DataPropertyName = "Семестр";
            semesterDataGridViewTextBoxColumn.HeaderText = "Семестр";
            semesterDataGridViewTextBoxColumn.Name = "semesterDataGridViewTextBoxColumn";
            // 
            // disciplinaDataGridViewTextBoxColumn
            // 
            disciplinaDataGridViewTextBoxColumn.DataPropertyName = "Дисципліна";
            disciplinaDataGridViewTextBoxColumn.HeaderText = "Дисципліна";
            disciplinaDataGridViewTextBoxColumn.Name = "disciplinaDataGridViewTextBoxColumn";
        }

        private void FillGroupTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn studyPlanDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                studyPlanDataGridViewTextBoxColumn,
                groupNameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "Groups";
            bindingSource.DataMember = "Groups";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // studyPlanDataGridViewTextBoxColumn
            // 
            studyPlanDataGridViewTextBoxColumn.DataPropertyName = "Навчальний план";
            studyPlanDataGridViewTextBoxColumn.HeaderText = "Навчальний план";
            studyPlanDataGridViewTextBoxColumn.Name = "studyPlanDataGridViewTextBoxColumn";
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            groupNameDataGridViewTextBoxColumn.DataPropertyName = "Назва групи";
            groupNameDataGridViewTextBoxColumn.HeaderText = "Назва групи";
            groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
        }

        private void FillAccountingWorkProgramTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn iDWorkProgramDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn iDStudyPlanDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                iDWorkProgramDataGridViewTextBoxColumn,
                iDStudyPlanDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "AccountingWorkPrograms";
            bindingSource.DataMember = "AccountingWorkPrograms";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // iDWorkProgramDataGridViewTextBoxColumn
            // 
            iDWorkProgramDataGridViewTextBoxColumn.DataPropertyName = "ID робочої програми";
            iDWorkProgramDataGridViewTextBoxColumn.HeaderText = "ID робочої програми";
            iDWorkProgramDataGridViewTextBoxColumn.Name = "iDWorkProgramDataGridViewTextBoxColumn";
            // 
            // iDStudyPlanDataGridViewTextBoxColumn
            // 
            iDStudyPlanDataGridViewTextBoxColumn.DataPropertyName = "ID навчального плану";
            iDStudyPlanDataGridViewTextBoxColumn.HeaderText = "ID навчального плану";
            iDStudyPlanDataGridViewTextBoxColumn.Name = "iDStudyPlanDataGridViewTextBoxColumn";
        }

        private void FillSpecialityTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "Specialities";
            bindingSource.DataMember = "Specialities";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Назва";
            nameDataGridViewTextBoxColumn.HeaderText = "Назва";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
        }

        private void FillEntryBaseTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "EntryBases";
            bindingSource.DataMember = "EntryBases";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Назва";
            nameDataGridViewTextBoxColumn.HeaderText = "Назва";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
        }

        private void FillEducationLevelTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "EducationLevels";
            bindingSource.DataMember = "EducationLevels";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Назва";
            nameDataGridViewTextBoxColumn.HeaderText = "Назва";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
        }

        private void FillGroupNameTable()
        {
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                groupNameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
            dataGridView.DataMember = "GroupNames";
            bindingSource.DataMember = "GroupNames";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            groupNameDataGridViewTextBoxColumn.DataPropertyName = "Назва групи";
            groupNameDataGridViewTextBoxColumn.HeaderText = "Назва групи";
            groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
        }

        private void ShowTable()
        {
            switch (ActiveTable)
            {
                case Table.StudyPlans:
                    FillStudyPlanTable();
                    break;
                case Table.WorkPrograms:
                    FillWorkProgramTable();
                    break;
                case Table.Disciplines:
                    FillDisciplineTable();
                    break;
                case Table.Groups:
                    FillGroupTable();
                    break;
                case Table.GroupNames:
                    FillGroupNameTable();
                    break;
                case Table.EducationLevels:
                    FillEducationLevelTable();
                    break;
                case Table.EntryBases:
                    FillEntryBaseTable();
                    break;
                case Table.Specialities:
                    FillSpecialityTable();
                    break;
                case Table.AccountingWorkPrograms:
                    FillAccountingWorkProgramTable();
                    break;
                default:
                    break;
            }
        }

        private void UpdateTable()
        {
            switch (ActiveTable)
            {
                case Table.StudyPlans:
                    studyPlansTableAdapter.Update(studyPlanDbDataSet.StudyPlans);
                    break;
                case Table.WorkPrograms:
                    workProgramsTableAdapter.Update(studyPlanDbDataSet.WorkPrograms);
                    break;
                case Table.Disciplines:
                    disciplinesTableAdapter.Update(studyPlanDbDataSet.Disciplines);
                    break;
                case Table.Groups:
                    groupsTableAdapter.Update(studyPlanDbDataSet.Groups);
                    break;
                case Table.GroupNames:
                    groupNamesTableAdapter.Update(studyPlanDbDataSet.GroupNames);
                    break;
                case Table.EducationLevels:
                    educatioLevelsTableAdapter.Update(studyPlanDbDataSet.EducationLevels);
                    break;
                case Table.EntryBases:
                    entryBasesTableAdapter.Update(studyPlanDbDataSet.EntryBases);
                    break;
                case Table.Specialities:
                    specialitiesTableAdapter.Update(studyPlanDbDataSet.Specialities);
                    break;
                case Table.AccountingWorkPrograms:
                    accountingWorkProgramsTableAdapter.Update(studyPlanDbDataSet.AccountingWorkPrograms);
                    break;
                default:
                    break;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                bindingSource.EndEdit();
                UpdateTable();
                MessageBox.Show("Дані успішно оновлено!");
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при оновленні даних!");
            }
        }
    }
}
