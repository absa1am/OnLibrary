namespace OnLibrary.Domain.Entities
{
    public class Book : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public Guid PublicationId { get; set; }
        public Publication Publication { get; set; }
        public List<BookAuthor> Authors { get; set; }
    }
}
