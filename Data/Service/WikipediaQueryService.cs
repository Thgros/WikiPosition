using Microsoft.Extensions.Options;
using WikiPosition.Data.Model;
using WikiPosition.Option;

namespace WikiPosition.Data.Service{
    public class WikipediaQueryService{

        private readonly WikipediaQuerySettings settings;

        public WikipediaQueryService(IOptions<WikipediaQuerySettings> options)
        {
            this.settings = options.Value;
        }

        public async Task<List<WikipediaPagePosition>?> GetLocalWikipediaPages(double latitude, double longitude)
        {
            var uri = $"{settings.BaseUrl}?action=query&list=geosearch&gscoord={latitude}|{longitude}&gsradius=500&gslimit=50&format=json";

            var response = await QueryWikipediaApi(uri);
            return response?.Query.GeoSearch;
        }

        public async Task<WikipediaPageContent?> GetPageContent(int pageId)
        {
            var uri = $"{settings.BaseUrl}?action=query&format=json&prop=extracts&pageids={pageId}&formatversion=2&exlimit=1";
            var response = await QueryWikipediaApi(uri);
            return response?.Query.Pages[0];
        }

        public async Task<WikipediaResponse?> QueryWikipediaApi(string uri)
        {
            using var httpClient = new HttpClient();
            using var httpResponse = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            try
            {
                var stringResult = httpResponse.Content.ReadAsStringAsync().Result;
                return await httpResponse.Content.ReadFromJsonAsync<WikipediaResponse>();
            }
            catch(Exception ex) // Could be ArgumentNullException or UnsupportedMediaTypeException
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}