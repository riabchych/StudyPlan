namespace StudyPlan
{
    /*
     * Сутність "Навчальний план"
     */
    public class Plan
    {
        private int _id;
        private string _entryYear;
        private string _studyForm;
        private int _discipline;
        private int _entryBase;
        private int _program;
        private int _speciality;
        private int _educationLevel;

        public Plan()
        {
            _id = 0;
            _entryYear = "";
            _discipline = 0;
            _studyForm = "";
            _entryBase = 0;
            _program = 0;
            _speciality = 0;
            _educationLevel = 0;
        }
        public Plan(int id, string entryYear, int discipline, string studyForm, int entryBase, int program, int speciality, int educationLevel)
        {
            _id = id;
            _entryYear = entryYear;
            _discipline = discipline;
            _studyForm = studyForm;
            _entryBase = entryBase;
            _program = program;
            _speciality = speciality;
            _educationLevel = educationLevel;
        }
        public int Id { get => _id; set => _id = value; }
        public string EntryYear { get => _entryYear; set => _entryYear = value; }
        public int Discipline { get => _discipline; set => _discipline = value; }
        public string StudyForm { get => _studyForm; set => _studyForm = value; }
        public int EntryBase { get => _entryBase; set => _entryBase = value; }
        public int Program { get => _program; set => _program = value; }
        public int Speciality { get => _speciality; set => _speciality = value; }
        public int EducationLevel { get => _educationLevel; set => _educationLevel = value; }
    }
}