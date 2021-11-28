namespace StudyPlan
{
    /*
     * Сутність "Група"
     */
    public class Group : BaseEntity
    {
        private string _studyYear;
        private int _plan;
        private int _сourse;

        public Group()
        {
            Id = 0;
            Name = "";
            StudyYear = "";
            Plan = 0;
            Course = 0;
        }
        public Group(int id, string groupName, string studyYear, int plan, int сourse)
        {
            Id = id;
            Name = groupName;
            StudyYear = studyYear;
            Plan = plan;
            Course = сourse;
        }
        public string StudyYear { get => _studyYear; set => _studyYear = value; }
        public int Plan { get => _plan; set => _plan = value; }
        public int Course { get => _сourse; set => _сourse = value; }
    }
}