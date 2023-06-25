namespace OnLibrary.Domain.Entities
{
    public class Publication : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
