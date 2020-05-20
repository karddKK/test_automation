using lab_4.Utils;

namespace lab_4.PageObjects.EntryPages.My_Store.Product
{
	public class ProductFromOrderModel : PageBase
	{
		public string PhotoUrl => RelatedElement.FindElement(".cart_product img")?.GetProperty("src");
	}
}
