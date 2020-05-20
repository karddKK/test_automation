namespace lab_4.PageObjects.EntryPages.My_Store.Product
{
	public class ColorProduct : PageBase
	{
		public string ColorName
		{

			get
			{
				var href = RelatedElement.GetProperty("href");
				var color = href.Substring(href.LastIndexOf("-") + 1);

				return color;
			}
		}
	}
}
