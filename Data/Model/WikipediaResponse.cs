namespace WikiPosition.Data.Model{
    public class WikipediaResponse
    {
        public string BatchComplete { get; set; }

        public WikipediaQueryResult Query { get; set; }
    }
}