namespace WikiPosition.Data.Model{
    public class WikipediaQueryResult
    {
        public List<WikipediaPagePosition>? GeoSearch { get; set; }

        public List<WikipediaPageContent> Pages { get; set; }
    }
}