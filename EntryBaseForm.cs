using System;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class EntryBaseForm : Form
    {
        public EntryBaseForm()
        {
            InitializeComponent();
        }

        private void EntryBaseForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet.EntryBases". При необходимости она может быть перемещена или удалена.
            this.entryBasesTableAdapter.Fill(this.studyPlanDbDataSet.EntryBases);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.entryBasesBindingSource.EndEdit();
                this.entryBasesTableAdapter.Update(this.studyPlanDbDataSet.EntryBases);
                MessageBox.Show("Дані успішно оновлено!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Помилка при оновленні даних!");
            }
        }
    }
}
