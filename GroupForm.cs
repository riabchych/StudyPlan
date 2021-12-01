using System;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class GroupForm : Form
    {
        public GroupForm()
        {
            InitializeComponent();
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet.Groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.studyPlanDbDataSet.Groups);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.groupsBindingSource.EndEdit();
                this.groupsTableAdapter.Update(this.studyPlanDbDataSet.Groups);
                MessageBox.Show("Дані успішно оновлено!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Помилка при оновленні даних!");
            }
        }
    }
}
