namespace StudyPlan
{

    /// <summary>
    /// Сутність Група
    /// </summary>
    public class Group : BaseEntity
    {
        public int Plan { get; set; }

        /// <summary>
        /// Конструтор за замовчуванням
        /// </summary>
        public Group()
        {
            Id = 0;
            Name = "";
            Plan = 0;
        }

        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Назва</param>
        /// <param name="plan">План</param>
        public Group(int id, string name, int plan)
        {
            Id = id;
            Name = name;
            Plan = plan;
        }
    }
}