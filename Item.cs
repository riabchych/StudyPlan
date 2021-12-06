namespace StudyPlan
{
    /// <summary>
    /// Клас елемента 
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="description">Опис</param>
        public Item(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}