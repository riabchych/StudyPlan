namespace StudyPlan
{
    /*
     * Сутність "Навчальний план"
     */
    public class Plan
    {
        private int _id;
        private int _entryYear;
        private int _discipline;
        private int _entryBase;
        private int _speciality;
        private int _educationLevel;
        private string _link;

        public Plan()
        {
            _id = 0;
            _entryYear = 0;
            _discipline = 0;
            _entryBase = 0;
            _speciality = 0;
            _educationLevel = 0;
        }
        public Plan(int id, int entryYear, int discipline, int entryBase, int speciality, int educationLevel, string link)
        {
            _id = id;
            _entryYear = entryYear;
            _discipline = discipline;
            _entryBase = entryBase;
            _speciality = speciality;
            _educationLevel = educationLevel;
            _link = link;
        }
        public int Id { get => _id; set => _id = value; }
        public int EntryYear { get => _entryYear; set => _entryYear = value; }
        public int Discipline { get => _discipline; set => _discipline = value; }
        public int EntryBase { get => _entryBase; set => _entryBase = value; }
        public int Speciality { get => _speciality; set => _speciality = value; }
        public int EducationLevel { get => _educationLevel; set => _educationLevel = value; }
        public string Link { get => _link; set => _link = value; }
    }
}