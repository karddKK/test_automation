using lab_4.PageObjects.EntryPages.My_Store.Product;
using lab_4.Utils;
using System.Collections.Generic;

namespace lab_4.PageObjects.EntryPages.My_Store
{
	public class OrderMyStore : PageBase
	{
		public IReadOnlyCollection<ProductFromOrderModel> Products =>
			SelectAll<ProductFromOrderModel>("cart_item", FindBy.ClassName);

		public FooterMyStore Footer =>
			Select<FooterMyStore>("footer-container", FindBy.ClassName);
	}
}
