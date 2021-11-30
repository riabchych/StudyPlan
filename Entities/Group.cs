namespace StudyPlan
{
    /*
     * Сутність "Група"
     */
    public class Group : BaseEntity
    {
        private int _plan;
        private int _cource;


        public Group()
        {
            Id = 0;
            Name = "";
            Plan = 0;
            Cource = 0;
        }
        public Group(int id, string name, int plan, int cource)
        {
            Id = id;
            Name = name;
            Plan = plan;
            Cource = cource;
        }
        public int Cource { get => _cource; set => _cource = value; }

        public int Plan { get => _plan; set => _plan = value; }
    }
}