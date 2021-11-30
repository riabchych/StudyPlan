namespace StudyPlan
{
    /*
     * Сутність "Робоча програма"
     */
    public class WorkProgram
    {
        private int _id;
        private int _discipline;
        private string _semester;
        public WorkProgram()
        {
            _id = 0;
            _discipline = 0;
            _semester = "";
        }
        public WorkProgram(int id, int discipline, string semester)
        {
            _id = id;
            _discipline = discipline;
            _semester = semester;
        }
        public int Id { get => _id; set => _id = value; }
        public int Discipline { get => _discipline; set => _discipline = value; }
        public string Semester { get => _semester; set => _semester = value; }
    }
}