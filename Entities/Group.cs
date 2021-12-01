namespace StudyPlan
{
    /*
     * Сутність "Група"
     */
    public class Group : BaseEntity
    {
        private int _plan;

        public Group()
        {
            Id = 0;
            Name = "";
            Plan = 0;
        }
        public Group(int id, string name, int plan)
        {
            Id = id;
            Name = name;
            Plan = plan;
        }
        public int Plan { get => _plan; set => _plan = value; }
    }
}