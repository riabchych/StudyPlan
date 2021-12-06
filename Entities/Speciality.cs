namespace StudyPlan
{
    /// <summary>
    /// Сутність Освітня професійна програма
    /// </summary>
    public class Speciality : BaseEntity
    {
        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public Speciality()
        {
            Id = 0;
            Name = "";
        }

        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Назва</param>
        public Speciality(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}