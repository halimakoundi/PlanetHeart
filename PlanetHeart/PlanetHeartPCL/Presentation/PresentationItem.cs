namespace PlanetHeartPCL.Presentation
{
    public class PresentationItem
    {
        public string Title { get; }
        public string AddedBy { get; }
        public string ImageUrl { get; }

        public PresentationItem(string title, string addedBy, string imageUrl)
        {
            Title = title;
            AddedBy = addedBy;
            ImageUrl = imageUrl;
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object obj)
        {
            return Equals((PresentationItem)obj);
        }

        protected bool Equals(PresentationItem other)
        {
            return string.Equals(Title, other.Title) && string.Equals(AddedBy, other.AddedBy) && ImageUrl == other.ImageUrl;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Title?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (AddedBy?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ImageUrl.GetHashCode();
                return hashCode;
            }
        }
    }
}