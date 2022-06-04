using System;
namespace WikiPosition.Data.Model
{
	public class WikipediaPageContent
    {
        public int PageId { get; set; }

        public int Ns { get; set; }

        public string Title { get; set; }

        public string Extract { get; set; }
	}
}

