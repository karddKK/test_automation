using lab_4.Shared.Components;
using lab_4.Utils;

namespace lab_4.PageObjects.EntryPages.My_Store.Modal
{
	public class AddToShoppingCardModal : PageBase
	{
		public Button Close => Select<Button>("cross", FindBy.ClassName);
	}
}
