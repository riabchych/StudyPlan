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
            this.linkSpTextBox = new System.Windows.Forms.TextBox();
            this.linkSpLabel = new System.Windows.Forms.Label();
            this.previewSpBt = new System.Windows.Forms.Button();
            this.editSpButton = new System.Windows.Forms.Button();
            this.removeSpButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkWpLabel = new System.Windows.Forms.Label();
            this.linkWpTextBox = new System.Windows.Forms.TextBox();
            this.removeWpButton = new System.Windows.Forms.Button();
            this.editWpButton = new System.Windows.Forms.Button();
            this.previewWpBt = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
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
            // linkSpTextBox
            // 
            this.linkSpTextBox.Enabled = false;
            this.linkSpTextBox.Location = new System.Drawing.Point(13, 291);
            this.linkSpTextBox.Name = "linkSpTextBox";
            this.linkSpTextBox.ReadOnly = true;
            this.linkSpTextBox.Size = new System.Drawing.Size(355, 20);
            this.linkSpTextBox.TabIndex = 12;
            this.linkSpTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linkSpLabel
            // 
            this.linkSpLabel.AutoSize = true;
            this.linkSpLabel.Enabled = false;
            this.linkSpLabel.Location = new System.Drawing.Point(10, 275);
            this.linkSpLabel.Name = "linkSpLabel";
            this.linkSpLabel.Size = new System.Drawing.Size(167, 13);
            this.linkSpLabel.TabIndex = 13;
            this.linkSpLabel.Text = "Посилання на навчальний план";
            // 
            // previewSpBt
            // 
            this.previewSpBt.Enabled = false;
            this.previewSpBt.Location = new System.Drawing.Point(10, 316);
            this.previewSpBt.Name = "previewSpBt";
            this.previewSpBt.Size = new System.Drawing.Size(81, 27);
            this.previewSpBt.TabIndex = 14;
            this.previewSpBt.Text = "Переглянути";
            this.previewSpBt.UseVisualStyleBackColor = true;
            this.previewSpBt.Click += new System.EventHandler(this.PreviewBt_Click);
            // 
            // editSpButton
            // 
            this.editSpButton.Enabled = false;
            this.editSpButton.Location = new System.Drawing.Point(144, 317);
            this.editSpButton.Name = "editSpButton";
            this.editSpButton.Size = new System.Drawing.Size(87, 27);
            this.editSpButton.TabIndex = 15;
            this.editSpButton.Text = "Внести зміни";
            this.editSpButton.UseVisualStyleBackColor = true;
            this.editSpButton.Click += new System.EventHandler(this.EditBt_Click);
            // 
            // removeSpButton
            // 
            this.removeSpButton.Enabled = false;
            this.removeSpButton.Location = new System.Drawing.Point(287, 316);
            this.removeSpButton.Name = "removeSpButton";
            this.removeSpButton.Size = new System.Drawing.Size(81, 27);
            this.removeSpButton.TabIndex = 16;
            this.removeSpButton.Text = "Видалити";
            this.removeSpButton.UseVisualStyleBackColor = true;
            this.removeSpButton.Click += new System.EventHandler(this.RemoveBt_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(381, 24);
            this.menuStrip.TabIndex = 17;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Вихід";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTablesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.editToolStripMenuItem.Text = "Редагування";
            // 
            // editTablesToolStripMenuItem
            // 
            this.editTablesToolStripMenuItem.Name = "editTablesToolStripMenuItem";
            this.editTablesToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editTablesToolStripMenuItem.Text = "Таблиці";
            this.editTablesToolStripMenuItem.Click += new System.EventHandler(this.EditTablesToolStripMenuItem_Click);
            // 
            // linkWpLabel
            // 
            this.linkWpLabel.AutoSize = true;
            this.linkWpLabel.Enabled = false;
            this.linkWpLabel.Location = new System.Drawing.Point(10, 179);
            this.linkWpLabel.Name = "linkWpLabel";
            this.linkWpLabel.Size = new System.Drawing.Size(169, 13);
            this.linkWpLabel.TabIndex = 19;
            this.linkWpLabel.Text = "Посилання на робочу програму:";
            // 
            // linkWpTextBox
            // 
            this.linkWpTextBox.Enabled = false;
            this.linkWpTextBox.Location = new System.Drawing.Point(13, 195);
            this.linkWpTextBox.Name = "linkWpTextBox";
            this.linkWpTextBox.ReadOnly = true;
            this.linkWpTextBox.Size = new System.Drawing.Size(355, 20);
            this.linkWpTextBox.TabIndex = 20;
            this.linkWpTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // removeWpButton
            // 
            this.removeWpButton.Enabled = false;
            this.removeWpButton.Location = new System.Drawing.Point(287, 220);
            this.removeWpButton.Name = "removeWpButton";
            this.removeWpButton.Size = new System.Drawing.Size(81, 27);
            this.removeWpButton.TabIndex = 23;
            this.removeWpButton.Text = "Видалити";
            this.removeWpButton.UseVisualStyleBackColor = true;
            this.removeWpButton.Click += new System.EventHandler(this.DelWpButton_Click);
            // 
            // editWpButton
            // 
            this.editWpButton.Enabled = false;
            this.editWpButton.Location = new System.Drawing.Point(144, 221);
            this.editWpButton.Name = "editWpButton";
            this.editWpButton.Size = new System.Drawing.Size(87, 27);
            this.editWpButton.TabIndex = 22;
            this.editWpButton.Text = "Внести зміни";
            this.editWpButton.UseVisualStyleBackColor = true;
            this.editWpButton.Click += new System.EventHandler(this.EditWpButton_Click);
            // 
            // previewWpBt
            // 
            this.previewWpBt.Enabled = false;
            this.previewWpBt.Location = new System.Drawing.Point(10, 220);
            this.previewWpBt.Name = "previewWpBt";
            this.previewWpBt.Size = new System.Drawing.Size(81, 27);
            this.previewWpBt.TabIndex = 21;
            this.previewWpBt.Text = "Переглянути";
            this.previewWpBt.UseVisualStyleBackColor = true;
            this.previewWpBt.Click += new System.EventHandler(this.PreviewWpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 361);
            this.Controls.Add(this.removeWpButton);
            this.Controls.Add(this.editWpButton);
            this.Controls.Add(this.previewWpBt);
            this.Controls.Add(this.linkWpTextBox);
            this.Controls.Add(this.linkWpLabel);
            this.Controls.Add(this.removeSpButton);
            this.Controls.Add(this.editSpButton);
            this.Controls.Add(this.previewSpBt);
            this.Controls.Add(this.linkSpLabel);
            this.Controls.Add(this.linkSpTextBox);
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
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Навчальний план";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private TextBox linkSpTextBox;
        private Label linkSpLabel;
        private Button previewSpBt;
        private Button editSpButton;
        private Button removeSpButton;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem editTablesToolStripMenuItem;
        private Label linkWpLabel;
        private TextBox linkWpTextBox;
        private Button removeWpButton;
        private Button editWpButton;
        private Button previewWpBt;
    }
}

