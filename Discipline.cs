namespace StudyPlan
{
    /*
     * Сутність "Дисципліна"
     */
    public class Discipline : BaseEntity
    {
        public Discipline()
        {
            Id = 0;
            Name = "";
        }
        public Discipline(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
