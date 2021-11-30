namespace StudyPlan
{
    /*
     * Сутність "База вступу"
     */
    public class EntryBase
    {
        private int _id;
        private string _name;

        public EntryBase()
        {
            _id = 0;
            _name = "";
        }
        public EntryBase(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
