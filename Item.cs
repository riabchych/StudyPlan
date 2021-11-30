namespace StudyPlan
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Item(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }
    }
}