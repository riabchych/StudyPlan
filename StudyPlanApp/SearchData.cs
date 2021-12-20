namespace StudyPlan
{
    /// <summary>
    /// Клас для збереження даних під час вибору значень у випадаючих списках
    /// </summary>
    public class SearchData
    {
        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public SearchData()
        {
            Group = 0;
            EntryBase = 0;
            Semester = 0;
            Cource = 0;
            Plan = 0;
            WorkProgram = 0;
            Discipline = 0;
        }

        public int Group { get; set; }
        public int EntryBase { get; set; }
        public int Semester { get; set; }
        public int Cource { get; set; }
        public int Plan { get; set; }
        public int Discipline { get; set; }
        public int WorkProgram { get; set; }
    }
}