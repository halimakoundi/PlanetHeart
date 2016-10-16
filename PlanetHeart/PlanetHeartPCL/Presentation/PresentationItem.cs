namespace PlanetHeart.Presentation
{
    public class PresentationItem
    {
        public string Title { get; }
        public string AddedBy { get; }
        public int ImageResourceId { get; }

        public PresentationItem(string title, string addedBy, int imageResourceId)
        {
            Title = title;
            AddedBy = addedBy;
            ImageResourceId = imageResourceId;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}