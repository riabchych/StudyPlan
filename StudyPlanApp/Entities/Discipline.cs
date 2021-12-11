namespace StudyPlan
{

    /// <summary>
    /// Сутність Дисципліна
    /// </summary>
    public class Discipline : BaseEntity
    {
        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public Discipline()
        {
            Id = 0;
            Name = "";
        }

        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Назва</param>
        public Discipline(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
