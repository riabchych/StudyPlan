using System.Windows.Forms;

namespace StudyPlan
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.entryBaseCb = new System.Windows.Forms.ComboBox();
            this.courseCb = new System.Windows.Forms.ComboBox();
            this.entryBaseLb = new System.Windows.Forms.Label();
            this.courseLb = new System.Windows.Forms.Label();
            this.groupCb = new System.Windows.Forms.ComboBox();
            this.groupLb = new System.Windows.Forms.Label();
            this.semesterCb = new System.Windows.Forms.ComboBox();
            this.semesterLb = new System.Windows.Forms.Label();
            this.disciplineCb = new System.Windows.Forms.ComboBox();
            this.disciplineLb = new System.Windows.Forms.Label();
            this.linkTb = new System.Windows.Forms.TextBox();
            this.linkLb = new System.Windows.Forms.Label();
            this.previewBt = new System.Windows.Forms.Button();
            this.editBt = new System.Windows.Forms.Button();
            this.removeBt = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisciplinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EntryBasesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StudyPlansToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpecialityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.educationLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // entryBaseCb
            // 
            this.entryBaseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entryBaseCb.Enabled = false;
            this.entryBaseCb.FormattingEnabled = true;
            this.entryBaseCb.Location = new System.Drawing.Point(10, 96);
            this.entryBaseCb.Name = "entryBaseCb";
            this.entryBaseCb.Size = new System.Drawing.Size(174, 21);
            this.entryBaseCb.TabIndex = 0;
            this.entryBaseCb.SelectedValueChanged += new System.EventHandler(this.EntryBaseCb_SelectedValueChanged);
            // 
            // courseCb
            // 
            this.courseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseCb.Enabled = false;
            this.courseCb.FormattingEnabled = true;
            this.courseCb.Location = new System.Drawing.Point(10, 51);
            this.courseCb.Name = "courseCb";
            this.courseCb.Size = new System.Drawing.Size(174, 21);
            this.courseCb.TabIndex = 2;
            this.courseCb.SelectedValueChanged += new System.EventHandler(this.CourseCb_SelectedValueChanged);
            // 
            // entryBaseLb
            // 
            this.entryBaseLb.AutoSize = true;
            this.entryBaseLb.Enabled = false;
            this.entryBaseLb.Location = new System.Drawing.Point(10, 80);
            this.entryBaseLb.Name = "entryBaseLb";
            this.entryBaseLb.Size = new System.Drawing.Size(68, 13);
            this.entryBaseLb.TabIndex = 3;
            this.entryBaseLb.Text = "База вступу";
            // 
            // courseLb
            // 
            this.courseLb.AutoSize = true;
            this.courseLb.Enabled = false;
            this.courseLb.Location = new System.Drawing.Point(10, 35);
            this.courseLb.Name = "courseLb";
            this.courseLb.Size = new System.Drawing.Size(81, 13);
            this.courseLb.TabIndex = 5;
            this.courseLb.Text = "Курс навчання";
            // 
            // groupCb
            // 
            this.groupCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupCb.Enabled = false;
            this.groupCb.FormattingEnabled = true;
            this.groupCb.Location = new System.Drawing.Point(195, 51);
            this.groupCb.Name = "groupCb";
            this.groupCb.Size = new System.Drawing.Size(174, 21);
            this.groupCb.TabIndex = 8;
            this.groupCb.SelectedValueChanged += new System.EventHandler(this.GroupCb_SelectedValueChanged);
            // 
            // groupLb
            // 
            this.groupLb.AutoSize = true;
            this.groupLb.Enabled = false;
            this.groupLb.Location = new System.Drawing.Point(195, 35);
            this.groupLb.Name = "groupLb";
            this.groupLb.Size = new System.Drawing.Size(36, 13);
            this.groupLb.TabIndex = 9;
            this.groupLb.Text = "Група";
            // 
            // semesterCb
            // 
            this.semesterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterCb.Enabled = false;
            this.semesterCb.FormattingEnabled = true;
            this.semesterCb.Location = new System.Drawing.Point(195, 96);
            this.semesterCb.Name = "semesterCb";
            this.semesterCb.Size = new System.Drawing.Size(174, 21);
            this.semesterCb.TabIndex = 7;
            this.semesterCb.SelectedValueChanged += new System.EventHandler(this.SemesterCb_SelectedValueChanged);
            // 
            // semesterLb
            // 
            this.semesterLb.AutoSize = true;
            this.semesterLb.Enabled = false;
            this.semesterLb.Location = new System.Drawing.Point(195, 80);
            this.semesterLb.Name = "semesterLb";
            this.semesterLb.Size = new System.Drawing.Size(51, 13);
            this.semesterLb.TabIndex = 6;
            this.semesterLb.Text = "Семестр";
            // 
            // disciplineCb
            // 
            this.disciplineCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.disciplineCb.Enabled = false;
            this.disciplineCb.FormattingEnabled = true;
            this.disciplineCb.Location = new System.Drawing.Point(10, 142);
            this.disciplineCb.Name = "disciplineCb";
            this.disciplineCb.Size = new System.Drawing.Size(359, 21);
            this.disciplineCb.TabIndex = 10;
            this.disciplineCb.SelectedValueChanged += new System.EventHandler(this.DisciplineCb_SelectedValueChanged);
            // 
            // disciplineLb
            // 
            this.disciplineLb.AutoSize = true;
            this.disciplineLb.Enabled = false;
            this.disciplineLb.Location = new System.Drawing.Point(10, 126);
            this.disciplineLb.Name = "disciplineLb";
            this.disciplineLb.Size = new System.Drawing.Size(66, 13);
            this.disciplineLb.TabIndex = 11;
            this.disciplineLb.Text = "Дисципліна";
            // 
            // linkTb
            // 
            this.linkTb.Enabled = false;
            this.linkTb.Location = new System.Drawing.Point(10, 197);
            this.linkTb.Name = "linkTb";
            this.linkTb.ReadOnly = true;
            this.linkTb.Size = new System.Drawing.Size(359, 20);
            this.linkTb.TabIndex = 12;
            this.linkTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linkLb
            // 
            this.linkLb.AutoSize = true;
            this.linkLb.Enabled = false;
            this.linkLb.Location = new System.Drawing.Point(10, 181);
            this.linkLb.Name = "linkLb";
            this.linkLb.Size = new System.Drawing.Size(167, 13);
            this.linkLb.TabIndex = 13;
            this.linkLb.Text = "Посилання на навчальний план";
            // 
            // previewBt
            // 
            this.previewBt.Enabled = false;
            this.previewBt.Location = new System.Drawing.Point(10, 222);
            this.previewBt.Name = "previewBt";
            this.previewBt.Size = new System.Drawing.Size(81, 27);
            this.previewBt.TabIndex = 14;
            this.previewBt.Text = "Переглянути";
            this.previewBt.UseVisualStyleBackColor = true;
            this.previewBt.Click += new System.EventHandler(this.PreviewBt_Click);
            // 
            // editBt
            // 
            this.editBt.Enabled = false;
            this.editBt.Location = new System.Drawing.Point(144, 223);
            this.editBt.Name = "editBt";
            this.editBt.Size = new System.Drawing.Size(87, 27);
            this.editBt.TabIndex = 15;
            this.editBt.Text = "Внести зміни";
            this.editBt.UseVisualStyleBackColor = true;
            this.editBt.Click += new System.EventHandler(this.EditBt_Click);
            // 
            // removeBt
            // 
            this.removeBt.Enabled = false;
            this.removeBt.Location = new System.Drawing.Point(287, 222);
            this.removeBt.Name = "removeBt";
            this.removeBt.Size = new System.Drawing.Size(81, 27);
            this.removeBt.TabIndex = 16;
            this.removeBt.Text = "Видалити";
            this.removeBt.UseVisualStyleBackColor = true;
            this.removeBt.Click += new System.EventHandler(this.RemoveBt_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(381, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem1});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // ExitToolStripMenuItem1
            // 
            this.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1";
            this.ExitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem1.Text = "Вихід";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisciplinesToolStripMenuItem1,
            this.EntryBasesToolStripMenuItem1,
            this.GroupsToolStripMenuItem1,
            this.StudyPlansToolStripMenuItem1,
            this.WorkProgramsToolStripMenuItem,
            this.SpecialityToolStripMenuItem,
            this.educationLevelsToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.EditToolStripMenuItem.Text = "Редагування";
            // 
            // DisciplinesToolStripMenuItem1
            // 
            this.DisciplinesToolStripMenuItem1.Name = "DisciplinesToolStripMenuItem1";
            this.DisciplinesToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.DisciplinesToolStripMenuItem1.Text = "Дисципліни";
            this.DisciplinesToolStripMenuItem1.Click += new System.EventHandler(this.дисципліниToolStripMenuItem1_Click);
            // 
            // EntryBasesToolStripMenuItem1
            // 
            this.EntryBasesToolStripMenuItem1.Name = "EntryBasesToolStripMenuItem1";
            this.EntryBasesToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.EntryBasesToolStripMenuItem1.Text = "Бази вступу";
            this.EntryBasesToolStripMenuItem1.Click += new System.EventHandler(this.базиВступуToolStripMenuItem1_Click);
            // 
            // GroupsToolStripMenuItem1
            // 
            this.GroupsToolStripMenuItem1.Name = "GroupsToolStripMenuItem1";
            this.GroupsToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.GroupsToolStripMenuItem1.Text = "Групи";
            this.GroupsToolStripMenuItem1.Click += new System.EventHandler(this.групиToolStripMenuItem1_Click);
            // 
            // StudyPlansToolStripMenuItem1
            // 
            this.StudyPlansToolStripMenuItem1.Name = "StudyPlansToolStripMenuItem1";
            this.StudyPlansToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.StudyPlansToolStripMenuItem1.Text = "Навчальні плани";
            // 
            // WorkProgramsToolStripMenuItem
            // 
            this.WorkProgramsToolStripMenuItem.Name = "WorkProgramsToolStripMenuItem";
            this.WorkProgramsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.WorkProgramsToolStripMenuItem.Text = "Робочі програми";
            // 
            // SpecialityToolStripMenuItem
            // 
            this.SpecialityToolStripMenuItem.Name = "SpecialityToolStripMenuItem";
            this.SpecialityToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.SpecialityToolStripMenuItem.Text = "Освітні професійні програми";
            // 
            // educationLevelsToolStripMenuItem
            // 
            this.educationLevelsToolStripMenuItem.Name = "educationLevelsToolStripMenuItem";
            this.educationLevelsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.educationLevelsToolStripMenuItem.Text = "Освітні рівні";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 277);
            this.Controls.Add(this.removeBt);
            this.Controls.Add(this.editBt);
            this.Controls.Add(this.previewBt);
            this.Controls.Add(this.linkLb);
            this.Controls.Add(this.linkTb);
            this.Controls.Add(this.disciplineLb);
            this.Controls.Add(this.disciplineCb);
            this.Controls.Add(this.groupLb);
            this.Controls.Add(this.groupCb);
            this.Controls.Add(this.semesterCb);
            this.Controls.Add(this.semesterLb);
            this.Controls.Add(this.courseLb);
            this.Controls.Add(this.entryBaseLb);
            this.Controls.Add(this.courseCb);
            this.Controls.Add(this.entryBaseCb);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Навчальний план";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox entryBaseCb;
        private ComboBox courseCb;
        private Label entryBaseLb;
        private Label courseLb;
        private ComboBox groupCb;
        private Label groupLb;
        private ComboBox semesterCb;
        private Label semesterLb;
        private ComboBox disciplineCb;
        private Label disciplineLb;
        private TextBox linkTb;
        private Label linkLb;
        private Button previewBt;
        private Button editBt;
        private Button removeBt;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem1;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem DisciplinesToolStripMenuItem1;
        private ToolStripMenuItem EntryBasesToolStripMenuItem1;
        private ToolStripMenuItem GroupsToolStripMenuItem1;
        private ToolStripMenuItem StudyPlansToolStripMenuItem1;
        private ToolStripMenuItem WorkProgramsToolStripMenuItem;
        private ToolStripMenuItem SpecialityToolStripMenuItem;
        private ToolStripMenuItem educationLevelsToolStripMenuItem;
    }
}

