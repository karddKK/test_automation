using lab_4.Shared.Components;
using lab_4.Utils;

namespace lab_4.PageObjects.EntryPages.My_Store
{
	public class MainMyStore : PageBase
	{
		public Button SignIn => Select<Button>("login", FindBy.ClassName);

		public Button GoToWomenSection => Select<Button>("#block_top_menu > ul > li > a[title='Women']");

		public Button OpenCard => Select<Button>("a[title='View my shopping cart']");
	}
}
