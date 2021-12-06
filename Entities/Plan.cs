namespace StudyPlan
{
    /// <summary>
    /// Сутність Навчальний план
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// Конструктор за замовчуванням
        /// </summary>
        public Plan()
        {
            Id = 0;
            EntryYear = 0;
            Discipline = 0;
            EntryBase = 0;
            Speciality = 0;
            EducationLevel = 0;
            Link = "";
        }

        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="entryYear">Рік вступу</param>
        /// <param name="disciplineId">Ідентифікатор дисципліни</param>
        /// <param name="entryBaseId">Ідентифікатор бази вступу</param>
        /// <param name="specialityId">Ідентифікатор освітньої професійної програми</param>
        /// <param name="educationLevelId">Ідентифікатор освітнього рівня</param>
        /// <param name="link">Посилання на навчальний план</param>
        public Plan(int id, int entryYear, int disciplineId, int entryBaseId, int specialityId, int educationLevelId, string link)
        {
            Id = id;
            EntryYear = entryYear;
            Discipline = disciplineId;
            EntryBase = entryBaseId;
            Speciality = specialityId;
            EducationLevel = educationLevelId;
            Link = link;
        }
        public int Id { get; set; }
        public int EntryYear { get; set; }
        public int Discipline { get; set; }
        public int EntryBase { get; set; }
        public int Speciality { get; set; }
        public int EducationLevel { get; set; }
        public string Link { get; set; }
    }
}