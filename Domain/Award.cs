namespace Domain
{
    public class Award
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Award(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}