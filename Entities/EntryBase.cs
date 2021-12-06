namespace StudyPlan
{
    /// <summary>
    /// Сутність База вступу
    /// </summary>
    public class EntryBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public EntryBase()
        {
            Id = 0;
            Name = "";
        }

        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Назва</param>
        public EntryBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
