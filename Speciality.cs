namespace StudyPlan
{
    /*
     * Сутність "Освітня професійна програма"
     */
    public class Speciality : BaseEntity
    {
        public Speciality()
        {
            Id = 0;
            Name = "";
        }
        public Speciality(int id, string name, string code)
        {
            Id = id;
            Name = name;
        }
        
    }
}