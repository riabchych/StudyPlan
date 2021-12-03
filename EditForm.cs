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

            bindingSource.DataMember = "StudyPlans";
            BindingSource bindingSourceSpecialities = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "Specialities"
            };
            BindingSource bindingSourceEducationLevels = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "EducationLevels"
            };
            BindingSource bindingSourceEntryBases = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "EntryBases"
            };
            // 
            // iDDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };
            // 
            // specialityDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn specialityDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Освітня професійна програма",
                HeaderText = "Освітня професійна програма",
                Name = "specialityDataGridViewComboBoxColumn",
                DataSource = bindingSourceSpecialities,
                ValueMember = "ID",
                DisplayMember = "Назва"

            };
            // 
            // educationLevelDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn educationLevelDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Освітній рівень",
                HeaderText = "Освітній рівень",
                Name = "educationLevelDataGridViewComboBoxColumn",
                DataSource = bindingSourceEducationLevels,
                ValueMember = "ID",
                DisplayMember = "Назва"
            };
            // 
            // entryBaseDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn entryBaseDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "База вступу",
                HeaderText = "База вступу",
                Name = "entryBaseDataGridViewComboBoxColumn",
                DataSource = bindingSourceEntryBases,
                ValueMember = "ID",
                DisplayMember = "Назва"
            };
            // 
            // studyPlanLinkDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn studyPlanLinkDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Посилання на навчальний план",
                HeaderText = "Посилання на навчальний план",
                Name = "studyPlanLinkDataGridViewTextBoxColumn"
            };
            // 
            // entryYearDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn entryYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Рік вступу",
                HeaderText = "Рік вступу",
                Name = "entryYearDataGridViewTextBoxColumn"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                specialityDataGridViewComboBoxColumn,
                educationLevelDataGridViewComboBoxColumn,
                entryBaseDataGridViewComboBoxColumn,
                studyPlanLinkDataGridViewTextBoxColumn,
                entryYearDataGridViewTextBoxColumn
            });
        }

        public void FillWorkProgramTable()
        {

            bindingSource.DataMember = "WorkPrograms";
            //Discipline Data Source
            BindingSource bindingSourceDisciplines = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "Disciplines"
            };
            // 
            // iDDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };
            // 
            // semesterDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn semesterDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Семестр",
                HeaderText = "Семестр",
                Name = "semesterDataGridViewTextBoxColumn"
            };
            // 
            // disciplinaDataGridViewComboBoxColumn
            // 
            DataGridViewComboBoxColumn disciplinaDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Дисципліна",
                HeaderText = "Дисципліна",
                DataSource = bindingSourceDisciplines,
                ValueMember = "ID",
                DisplayMember = "Назва дисципліни"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                semesterDataGridViewTextBoxColumn,
                disciplinaDataGridViewComboBoxColumn
            });
        }

        private void FillGroupTable()
        {
            bindingSource.DataMember = "Groups";
            //GroupNames Data Source
            BindingSource bindingSourceGroupName = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "GroupNames"
            };
            //StudyPlan Data Source
            BindingSource bindingSourceStudyPlan = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "StudyPlans"
            };
            // 
            // iDDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };
            // 
            // studyPlanDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn studyPlanDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Навчальний план",
                HeaderText = "Навчальний план",
                DataSource = bindingSourceStudyPlan,
                ValueMember = "ID",
                DisplayMember = "ID"
            };
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn groupNameDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Назва групи",
                HeaderText = "Назва групи",
                DataSource = bindingSourceGroupName,
                ValueMember = "ID",
                DisplayMember = "Назва групи"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                studyPlanDataGridViewComboBoxColumn,
                groupNameDataGridViewComboBoxColumn
            });
        }

        private void FillAccountingWorkProgramTable()
        {
            bindingSource.DataMember = "AccountingWorkPrograms";
            BindingSource bindingSourceStudyPlan = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "StudyPlans"
            };
            BindingSource bindingSourceWorkProgram = new BindingSource
            {
                DataSource = studyPlanDbDataSet,
                DataMember = "WorkPrograms"
            };
            // 
            // iDDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };
            // 
            // iDWorkProgramDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn iDWorkProgramDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ID робочої програми",
                HeaderText = "ID робочої програми",
                DataSource = bindingSourceWorkProgram,
                ValueMember = "ID",
                DisplayMember = "ID"
            };
            // 
            // studyPlanDataGridViewTextBoxColumn
            // 
            DataGridViewComboBoxColumn iDStudyPlanDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ID навчального плану",
                HeaderText = "ID навчального плану",
                DataSource = bindingSourceStudyPlan,
                ValueMember = "ID",
                DisplayMember = "ID"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                iDDataGridViewTextBoxColumn,
                iDWorkProgramDataGridViewComboBoxColumn,
                iDStudyPlanDataGridViewComboBoxColumn
            });
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні даних: {Environment.NewLine}{ex}");
            }
        }
    }
}
