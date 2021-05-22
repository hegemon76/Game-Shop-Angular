namespace API.Entities
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public bool Invoice { get; set; }
        public string Name { get; set; }
        public virtual Order Order { get; set; }
    }
}