namespace StudyPlan
{
    /*
     * Сутність "Робоча програма"
     */
    public class WorkProgram
    {
        private int _id;
        private int _discipline;
        private string _branchKnowledge;
        private string _code;
        private string _link;
        private string _semester;
        public WorkProgram()
        {
            _id = 0;
            _discipline = 0;
            _branchKnowledge = "";
            _code = "";
            _link = "";
            _semester = "";
        }
        public WorkProgram(int id, int discipline, string branchKnowledge, string code, string semester, string link)
        {
            _id = id;
            _discipline = discipline;
            _branchKnowledge = branchKnowledge;
            _code = code;
            _semester = semester;
            _link = link;
        }
        public int Id { get => _id; set => _id = value; }
        public int Discipline { get => _discipline; set => _discipline = value; }
        public string BranchKnowledge { get => _branchKnowledge; set => _branchKnowledge = value; }
        public string Code { get => _code; set => _code = value; }
        public string Semester { get => _semester; set => _semester = value; }
        public string Link { get => _link; set => _link = value; }
    }
}