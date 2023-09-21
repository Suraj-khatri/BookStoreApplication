namespace BookStoreApplication.Data
{
    public class BookGallery
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public Book Book { get; set; }

    }
}
