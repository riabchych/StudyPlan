﻿using System.Windows.Forms;

namespace StudyPlan
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
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
            this.SuspendLayout();
            // 
            // entryBaseCb
            // 
            this.entryBaseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entryBaseCb.Enabled = false;
            this.entryBaseCb.FormattingEnabled = true;
            this.entryBaseCb.Location = new System.Drawing.Point(10, 81);
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
            this.courseCb.Items.AddRange(new object[] {
            "---Оберіть---",
            "1",
            "2",
            "3",
            "4"});
            this.courseCb.Location = new System.Drawing.Point(10, 36);
            this.courseCb.Name = "courseCb";
            this.courseCb.Size = new System.Drawing.Size(174, 21);
            this.courseCb.TabIndex = 2;
            this.courseCb.SelectedValueChanged += new System.EventHandler(this.CourseCb_SelectedValueChanged);
            // 
            // entryBaseLb
            // 
            this.entryBaseLb.AutoSize = true;
            this.entryBaseLb.Enabled = false;
            this.entryBaseLb.Location = new System.Drawing.Point(10, 65);
            this.entryBaseLb.Name = "entryBaseLb";
            this.entryBaseLb.Size = new System.Drawing.Size(68, 13);
            this.entryBaseLb.TabIndex = 3;
            this.entryBaseLb.Text = "База вступу";
            // 
            // courseLb
            // 
            this.courseLb.AutoSize = true;
            this.courseLb.Enabled = false;
            this.courseLb.Location = new System.Drawing.Point(10, 20);
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
            this.groupCb.Location = new System.Drawing.Point(195, 36);
            this.groupCb.Name = "groupCb";
            this.groupCb.Size = new System.Drawing.Size(174, 21);
            this.groupCb.TabIndex = 8;
            this.groupCb.SelectedValueChanged += new System.EventHandler(this.GroupCb_SelectedValueChanged);
            // 
            // groupLb
            // 
            this.groupLb.AutoSize = true;
            this.groupLb.Enabled = false;
            this.groupLb.Location = new System.Drawing.Point(195, 20);
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
            this.semesterCb.Items.AddRange(new object[] {
            "---Оберіть---",
            "1",
            "2"});
            this.semesterCb.Location = new System.Drawing.Point(195, 81);
            this.semesterCb.Name = "semesterCb";
            this.semesterCb.Size = new System.Drawing.Size(174, 21);
            this.semesterCb.TabIndex = 7;
            this.semesterCb.SelectedValueChanged += new System.EventHandler(this.SemesterCb_SelectedValueChanged);
            // 
            // semesterLb
            // 
            this.semesterLb.AutoSize = true;
            this.semesterLb.Enabled = false;
            this.semesterLb.Location = new System.Drawing.Point(195, 65);
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
            this.disciplineCb.Location = new System.Drawing.Point(10, 127);
            this.disciplineCb.Name = "disciplineCb";
            this.disciplineCb.Size = new System.Drawing.Size(359, 21);
            this.disciplineCb.TabIndex = 10;
            this.disciplineCb.SelectedValueChanged += new System.EventHandler(this.DisciplineCb_SelectedValueChanged);
            // 
            // disciplineLb
            // 
            this.disciplineLb.AutoSize = true;
            this.disciplineLb.Enabled = false;
            this.disciplineLb.Location = new System.Drawing.Point(10, 111);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 289);
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
            this.Name = "Form1";
            this.Text = "Навчальний план";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

