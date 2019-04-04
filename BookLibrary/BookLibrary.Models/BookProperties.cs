namespace BookLibrary.Models
{
    public class BookProperties : IItemProperties
    {
        public int    Id              { get; set; }
        public string Name            { get; set; }
        public string Writers         { get; set; }
        public int    PublicationYear { get; set; }
        public string Genre           { get; set; }
        public string Language        { get; set; }
        public int    NumberOfPages   { get; set; }
        public string Publisher       { get; set; }
        public int    RecommendedAge  { get; set; }
        public bool   IsHere          { get; set; }
        public long   TimeToReturn    { get; set; }
    }
}
