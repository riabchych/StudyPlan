namespace StudyPlan
{
    partial class DisciplineForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studyPlanDbDataSet = new StudyPlan.StudyPlanDbDataSet();
            this.disciplinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disciplinesTableAdapter = new StudyPlan.StudyPlanDbDataSetTableAdapters.DisciplinesTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disciplineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyPlanDbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disciplinesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(195, 270);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 35);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Зберегти зміни";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.disciplineNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.disciplinesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(460, 251);
            this.dataGridView1.TabIndex = 1;
            // 
            // studyPlanDbDataSet
            // 
            this.studyPlanDbDataSet.DataSetName = "StudyPlanDbDataSet";
            this.studyPlanDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // disciplinesBindingSource
            // 
            this.disciplinesBindingSource.DataMember = "Disciplines";
            this.disciplinesBindingSource.DataSource = this.studyPlanDbDataSet;
            // 
            // disciplinesTableAdapter
            // 
            this.disciplinesTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // disciplineNameDataGridViewTextBoxColumn
            // 
            this.disciplineNameDataGridViewTextBoxColumn.DataPropertyName = "Назва дисципліни";
            this.disciplineNameDataGridViewTextBoxColumn.HeaderText = "Назва дисципліни";
            this.disciplineNameDataGridViewTextBoxColumn.Name = "disciplineNameDataGridViewTextBoxColumn";
            // 
            // DisciplineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.saveButton);
            this.Name = "DisciplineForm";
            this.Text = "Редагування дисциплін";
            this.Load += new System.EventHandler(this.DisciplineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyPlanDbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disciplinesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private StudyPlanDbDataSet studyPlanDbDataSet;
        private System.Windows.Forms.BindingSource disciplinesBindingSource;
        private StudyPlanDbDataSetTableAdapters.DisciplinesTableAdapter disciplinesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplineNameDataGridViewTextBoxColumn;
    }
}