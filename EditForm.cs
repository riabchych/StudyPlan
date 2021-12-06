using System;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class EditForm : Form
    {
        public string ActiveTable { get; set; }
        public bool EscapePressed { get; set; }
        public bool DataIsChanged { get; set; }

        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public EditForm()
        {
            InitializeComponent();
            dataGridView.UserDeletingRow += UserDeletingRow;
            bindingNavigatorDeleteItem.Click += UserDeletingRow;
        }

        /// <summary>
        /// Подія при завантаженні форми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditForm_Load(object sender, EventArgs e)
        {
            FillDataSet();
            Database db = new Database();
            listTablesListBox.DataSource = db.GetTables();
        }

        /// <summary>
        /// Заповнення таблиць даними
        /// </summary>
        private void FillDataSet()
        {
            _ = workProgramsTableAdapter.Fill(studyPlanDbDataSet.WorkPrograms);
            _ = specialitiesTableAdapter.Fill(studyPlanDbDataSet.Specialities);
            _ = educatioLevelsTableAdapter.Fill(studyPlanDbDataSet.EducationLevels);
            _ = accountingWorkProgramsTableAdapter.Fill(studyPlanDbDataSet.AccountingWorkPrograms);
            _ = groupNamesTableAdapter.Fill(studyPlanDbDataSet.GroupNames);
            _ = studyPlansTableAdapter.Fill(studyPlanDbDataSet.StudyPlans);
            _ = groupsTableAdapter.Fill(studyPlanDbDataSet.Groups);
            _ = entryBasesTableAdapter.Fill(studyPlanDbDataSet.EntryBases);
            _ = disciplinesTableAdapter.Fill(studyPlanDbDataSet.Disciplines);
            DataIsChanged = false;
            saveToolStripButton.Enabled = false;
        }

        /// <summary>
        /// Відображення таблиці дисциплін
        /// </summary>
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

        /// <summary>
        /// Відображення таблиці навчальних планів
        /// </summary>
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
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
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

        /// <summary>
        /// Відображення таблиці робочих програм
        /// </summary>
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
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
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

        /// <summary>
        /// Відображення таблиці груп
        /// </summary>
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
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
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

        /// <summary>
        /// Відображення таблиці обліку робочих програм
        /// </summary>
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
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
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
                //iDDataGridViewTextBoxColumn,
                iDWorkProgramDataGridViewComboBoxColumn,
                iDStudyPlanDataGridViewComboBoxColumn
            });
        }

        /// <summary>
        /// Відображення теблиці освітніх професійних програм
        /// </summary>
        private void FillSpecialityTable()
        {
            dataGridView.Columns.Clear();
            // 
            // bindingSource
            // 
            bindingSource.DataMember = "Specialities";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
            // 
            // nameDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Назва",
                HeaderText = "Назва",
                Name = "nameDataGridViewTextBoxColumn"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
        }

        /// <summary>
        /// Відображення таблиці баз вступу
        /// </summary>
        private void FillEntryBaseTable()
        {
            dataGridView.Columns.Clear();
            // 
            // bindingSource
            // 
            bindingSource.DataMember = "EntryBases";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
            // 
            // nameDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Назва",
                HeaderText = "Назва",
                Name = "nameDataGridViewTextBoxColumn"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
        }

        /// <summary>
        /// Відображення таблиці навчальних рівнів
        /// </summary>
        private void FillEducationLevelTable()
        {
            dataGridView.Columns.Clear();
            // 
            // bindingSource
            // 
            bindingSource.DataMember = "EducationLevels";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
            // 
            // nameDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Назва",
                HeaderText = "Назва",
                Name = "nameDataGridViewTextBoxColumn"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                nameDataGridViewTextBoxColumn
            });
        }

        /// <summary>
        /// Відображення таблиці назв груп
        /// </summary>
        private void FillGroupNameTable()
        {
            dataGridView.Columns.Clear();
            // 
            // bindingSource
            // 
            bindingSource.DataMember = "GroupNames";
            bindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            /*_ = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "iDDataGridViewTextBoxColumn"
            };*/
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Назва групи",
                HeaderText = "Назва групи",
                Name = "groupNameDataGridViewTextBoxColumn"
            };
            // 
            // dataGridView
            // 
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                //iDDataGridViewTextBoxColumn,
                groupNameDataGridViewTextBoxColumn
            });
        }

        /// <summary>
        /// Відображення обраної таблиці
        /// </summary>
        private void ShowTable()
        {
            switch (ActiveTable)
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

        /// <summary>
        /// Оновлення даних обраної таблиці в базі даних
        /// </summary>
        private void UpdateData()
        {
            try
            {
                _ = Validate();
                bindingSource.EndEdit();
                switch (ActiveTable)
                {
                    case Table.StudyPlans:
                        _ = studyPlansTableAdapter.Update(studyPlanDbDataSet.StudyPlans);
                        break;
                    case Table.WorkPrograms:
                        _ = workProgramsTableAdapter.Update(studyPlanDbDataSet.WorkPrograms);
                        break;
                    case Table.Disciplines:
                        _ = disciplinesTableAdapter.Update(studyPlanDbDataSet.Disciplines);
                        break;
                    case Table.Groups:
                        _ = groupsTableAdapter.Update(studyPlanDbDataSet.Groups);
                        break;
                    case Table.GroupNames:
                        _ = groupNamesTableAdapter.Update(studyPlanDbDataSet.GroupNames);
                        break;
                    case Table.EducationLevels:
                        _ = educatioLevelsTableAdapter.Update(studyPlanDbDataSet.EducationLevels);
                        break;
                    case Table.EntryBases:
                        _ = entryBasesTableAdapter.Update(studyPlanDbDataSet.EntryBases);
                        break;
                    case Table.Specialities:
                        _ = specialitiesTableAdapter.Update(studyPlanDbDataSet.Specialities);
                        break;
                    case Table.AccountingWorkPrograms:
                        _ = accountingWorkProgramsTableAdapter.Update(studyPlanDbDataSet.AccountingWorkPrograms);
                        break;
                    default:
                        break;
                }
                DataIsChanged = false;
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

        /// <summary>
        /// Подія при зміні таблиці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListTablesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listTablesListBox.SelectedIndex != -1)
            {
                if (DataIsChanged)
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
                ActiveTable = listTablesListBox.SelectedValue.ToString();
                saveToolStripButton.Enabled = false;
                ShowTable();
            }
        }

        /// <summary>
        /// Подія при видаленні рядку в таблиці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Ви дійсно бажаєте видалити рядок?", "Підтвердження дії",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Подія при видаленні рядку в таблиці натисненням кнопки видалення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDeletingRow(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно бажаєте видалити рядок?", "Підтвердження дії",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingSource.RemoveCurrent();
                DataIsChanged = true;
                saveToolStripButton.Enabled = true;
            }
        }

        /// <summary>
        /// Подія при натисненні кнопки збереження даних
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        /// <summary>
        /// Подія при натисненні будь якої кнопки в таблиці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EscapePressed = true;
            }
        }
        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.PreviewKeyDown -= Control_PreviewKeyDown;
            e.Control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
        }

        /// <summary>
        /// Подія при закінченні редагування в таблиці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!EscapePressed)
            {
                DataIsChanged = true;
                saveToolStripButton.Enabled = true;
            }
            else
            {
                EscapePressed = false;
            }
        }
    }
}
