using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyPlan
{
    public partial class DisciplineForm : Form
    {
        public DisciplineForm()
        {
            InitializeComponent();
        }

        private void DisciplineForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studyPlanDbDataSet.Disciplines". При необходимости она может быть перемещена или удалена.
            this.disciplinesTableAdapter.Fill(this.studyPlanDbDataSet.Disciplines);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.disciplinesBindingSource.EndEdit();
                this.disciplinesTableAdapter.Update(this.studyPlanDbDataSet.Disciplines);
                MessageBox.Show("Дані успішно оновлено!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Помилка при оновленні даних!");
            }
        }
    }
}
