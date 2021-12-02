namespace StudyPlan
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studyPlanDbDataSet = new StudyPlan.StudyPlanDbDataSet();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableAdapterManager = new StudyPlan.StudyPlanDbDataSetTableAdapters.TableAdapterManager();
            this.accountingWorkProgramsTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.AccountingWorkProgramsTableAdapter();
            this.disciplinesTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.DisciplinesTableAdapter();
            this.educatioLevelsTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.EducatioLevelsTableAdapter();
            this.entryBasesTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.EntryBasesTableAdapter();
            this.groupNamesTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.GroupNamesTableAdapter();
            this.groupsTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.GroupsTableAdapter();
            this.specialitiesTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.SpecialitiesTableAdapter();
            this.studyPlansTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.StudyPlansTableAdapter();
            this.workProgramsTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.WorkProgramsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyPlanDbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.DataSource = this.bindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(460, 251);
            this.dataGridView.TabIndex = 0;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = this.studyPlanDbDataSet;
            this.bindingSource.Position = 0;
            // 
            // studyPlanDbDataSet
            // 
            this.studyPlanDbDataSet.DataSetName = "StudyPlanDbDataSet";
            this.studyPlanDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(195, 269);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 36);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Зберегти зміни";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AccountingWorkProgramsTableAdapter = this.accountingWorkProgramsTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DisciplinesTableAdapter = this.disciplinesTableAdapter;
            this.tableAdapterManager.EducatioLevelsTableAdapter = this.educatioLevelsTableAdapter;
            this.tableAdapterManager.EntryBasesTableAdapter = this.entryBasesTableAdapter;
            this.tableAdapterManager.GroupNamesTableAdapter = this.groupNamesTableAdapter;
            this.tableAdapterManager.GroupsTableAdapter = this.groupsTableAdapter;
            this.tableAdapterManager.SpecialitiesTableAdapter = this.specialitiesTableAdapter;
            this.tableAdapterManager.StudyPlansTableAdapter = this.studyPlansTableAdapter;
            this.tableAdapterManager.UpdateOrder = StudyPlan.StudyPlanDbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WorkProgramsTableAdapter = this.workProgramsTableAdapter;
            // 
            // accountingWorkProgramsTableAdapter
            // 
            this.accountingWorkProgramsTableAdapter.ClearBeforeFill = true;
            // 
            // disciplinesTableAdapter
            // 
            this.disciplinesTableAdapter.ClearBeforeFill = true;
            // 
            // educatioLevelsTableAdapter
            // 
            this.educatioLevelsTableAdapter.ClearBeforeFill = true;
            // 
            // entryBasesTableAdapter
            // 
            this.entryBasesTableAdapter.ClearBeforeFill = true;
            // 
            // groupNamesTableAdapter
            // 
            this.groupNamesTableAdapter.ClearBeforeFill = true;
            // 
            // groupsTableAdapter
            // 
            this.groupsTableAdapter.ClearBeforeFill = true;
            // 
            // specialitiesTableAdapter
            // 
            this.specialitiesTableAdapter.ClearBeforeFill = true;
            // 
            // studyPlansTableAdapter
            // 
            this.studyPlansTableAdapter.ClearBeforeFill = true;
            // 
            // workProgramsTableAdapter
            // 
            this.workProgramsTableAdapter.ClearBeforeFill = true;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "EditForm";
            this.Text = "Редагування даних";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyPlanDbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button saveButton;
        public StudyPlanDbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        public StudyPlanDbDataSet studyPlanDbDataSet;
        public System.Windows.Forms.BindingSource bindingSource;
        public StudyPlanDbDataSetTableAdapters.DisciplinesTableAdapter disciplinesTableAdapter;
        public StudyPlanDbDataSetTableAdapters.EntryBasesTableAdapter entryBasesTableAdapter;
        public StudyPlanDbDataSetTableAdapters.GroupsTableAdapter groupsTableAdapter;
        public StudyPlanDbDataSetTableAdapters.StudyPlansTableAdapter studyPlansTableAdapter;
        public StudyPlanDbDataSetTableAdapters.GroupNamesTableAdapter groupNamesTableAdapter;
        public StudyPlanDbDataSetTableAdapters.AccountingWorkProgramsTableAdapter accountingWorkProgramsTableAdapter;
        public StudyPlanDbDataSetTableAdapters.EducatioLevelsTableAdapter educatioLevelsTableAdapter;
        public StudyPlanDbDataSetTableAdapters.SpecialitiesTableAdapter specialitiesTableAdapter;
        public StudyPlanDbDataSetTableAdapters.WorkProgramsTableAdapter workProgramsTableAdapter;
    }
}