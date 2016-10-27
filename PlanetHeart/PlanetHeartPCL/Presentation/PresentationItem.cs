namespace PlanetHeartPCL.Presentation
{
    public class PresentationItem
    {
        public string Title { get; }
        public string AddedBy { get; }
        public string ImageResourceId { get; }

        public PresentationItem(string title, string addedBy, string imageResourceId)
        {
            Title = title;
            AddedBy = addedBy;
            ImageResourceId = imageResourceId;
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
            return string.Equals(Title, other.Title) && string.Equals(AddedBy, other.AddedBy) && ImageResourceId == other.ImageResourceId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AddedBy != null ? AddedBy.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ ImageResourceId.GetHashCode();
                return hashCode;
            }
        }
    }
}