using lab_4.PageObjects.EntryPages.My_Store.Product;
using lab_4.Shared.Components;
using lab_4.Utils;
using System.Collections.Generic;

namespace lab_4.PageObjects.EntryPages.My_Store
{
	public class WomenMyStore : PageBase
	{
		public Button ViewList => Select<Button>("a[title='List']");

		public IReadOnlyCollection<ProductModel> Products =>
			SelectAll<ProductModel>("product-container", FindBy.ClassName);
	}
}
