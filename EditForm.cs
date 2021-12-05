using System;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class EditForm : Form
    {
        private string activeTable;
        private bool escapePressed;
        public bool dataIsChanged;

        public EditForm()
        {
            InitializeComponent();
            dataGridView.UserDeletingRow += UserDeletingRow;
            bindingNavigatorDeleteItem.Click += UserDeletingRow;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            FillDataSet();
            // Отримання списку таблиць
            listTablesListBox.DataSource = new Database().GetTables();
        }

        private void FillDataSet()
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
            dataGridView.Columns.Clear();
            bindingSource.DataMember = "Disciplines";
            bindingSource.Position = 0;
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn disciplneNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
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
            dataGridView.Columns.Clear();
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
                //iDDataGridViewTextBoxColumn,
                specialityDataGridViewComboBoxColumn,
                educationLevelDataGridViewComboBoxColumn,
                entryBaseDataGridViewComboBoxColumn,
                studyPlanLinkDataGridViewTextBoxColumn,
                entryYearDataGridViewTextBoxColumn
            });
        }

        public void FillWorkProgramTable()
        {
            dataGridView.Columns.Clear();
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
                //iDDataGridViewTextBoxColumn,
                semesterDataGridViewTextBoxColumn,
                disciplinaDataGridViewComboBoxColumn
            });
        }

        private void FillGroupTable()
        {
            dataGridView.Columns.Clear();
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
                //iDDataGridViewTextBoxColumn,
                studyPlanDataGridViewComboBoxColumn,
                groupNameDataGridViewComboBoxColumn
            });
        }

        private void FillAccountingWorkProgramTable()
        {
            dataGridView.Columns.Clear();
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
            dataGridView.Columns.Clear();
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
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
            dataGridView.Columns.Clear();
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
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
            dataGridView.Columns.Clear();
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
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
            dataGridView.Columns.Clear();
            DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                groupNameDataGridViewTextBoxColumn
            });
            // 
            // bindingSource
            // 
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
            switch (activeTable)
            {
                case Table.StudyPlans:
                    editTablesGroupBox.Text = "Редагування навчальних планів";
                    FillStudyPlanTable();
                    break;
                case Table.WorkPrograms:
                    editTablesGroupBox.Text = "Редагування робочих програм";
                    FillWorkProgramTable();
                    break;
                case Table.Disciplines:
                    editTablesGroupBox.Text = "Редагування дисциплін";
                    FillDisciplineTable();
                    break;
                case Table.Groups:
                    editTablesGroupBox.Text = "Редагування груп";
                    FillGroupTable();
                    break;
                case Table.GroupNames:
                    editTablesGroupBox.Text = "Редагування назв груп";
                    FillGroupNameTable();
                    break;
                case Table.EducationLevels:
                    editTablesGroupBox.Text = "Редагування освітніх рівнів";
                    FillEducationLevelTable();
                    break;
                case Table.EntryBases:
                    editTablesGroupBox.Text = "Редагування баз вступу";
                    FillEntryBaseTable();
                    break;
                case Table.Specialities:
                    editTablesGroupBox.Text = "Редагування освітніх професійних програм";
                    FillSpecialityTable();
                    break;
                case Table.AccountingWorkPrograms:
                    editTablesGroupBox.Text = "Редагування обліків робочих програм";
                    FillAccountingWorkProgramTable();
                    break;
                default:
                    editTablesGroupBox.Text = "";
                    break;
            }
        }

        private void UpdateTable()
        {
            switch (activeTable)
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

        private void UpdateData()
        {
            try
            {
                Validate();
                bindingSource.EndEdit();
                UpdateTable();
                dataIsChanged = false;
                saveToolStripButton.Enabled = false;
                _ = MessageBox.Show($"Дані успішно оновлено", "Повідомлення",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Помилка оновлення даних: {Environment.NewLine}{ex}", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                FillDataSet();
            }
        }

        private void ListTablesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listTablesListBox.SelectedIndex != -1)
            {
                if (dataIsChanged)
                {
                    if (MessageBox.Show("Ви не зберегли зміни, бажаєте зберегти?", "Підтвердження дії",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdateData();
                    }
                    else
                    {
                        FillDataSet();
                    }

                }
                activeTable = listTablesListBox.SelectedValue.ToString();
                ShowTable();
                dataIsChanged = false;
                saveToolStripButton.Enabled = false;
            }
        }

        private void UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Ви дійсно бажаєте видалити рядок?", "Підтвердження дії",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void UserDeletingRow(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно бажаєте видалити рядок?", "Підтвердження дії",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingSource.RemoveCurrent();
                dataIsChanged = true;
                saveToolStripButton.Enabled = true;
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                escapePressed = true;
            }
        }

        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.PreviewKeyDown -= Control_PreviewKeyDown;
            e.Control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!escapePressed)
            {
                dataIsChanged = true;
                saveToolStripButton.Enabled = true;
            }
            else escapePressed = false;
        }
    }
}
