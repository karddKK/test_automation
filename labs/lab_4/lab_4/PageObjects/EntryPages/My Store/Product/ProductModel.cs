using lab_4.Shared.Components;
using lab_4.Utils;
using System.Collections.Generic;

namespace lab_4.PageObjects.EntryPages.My_Store.Product
{
	public class ProductModel : PageBase
	{
		public string Name => RelatedElement.FindElement("product-name", FindBy.ClassName)?.Text;
		public string Description => RelatedElement.FindElement("product-desc", FindBy.ClassName)?.Text;

		public IReadOnlyCollection<ColorProduct> Colors => SelectAll<ColorProduct>("color_pick", FindBy.ClassName);

		public void Open() => Select<Button>("product-name", FindBy.ClassName)?.Click();
	}
}
