namespace Domain.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string BIC { get; set; }
        public string Name { get; set; }

        public Bank(int id, string bIC, string name)
        {
            this.Id = id;
            this.BIC = bIC;
            this.Name = name;
        }
    }
}
