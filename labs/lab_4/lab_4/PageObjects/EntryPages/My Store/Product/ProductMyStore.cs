using lab_4.Shared.Components;
using lab_4.Utils;

namespace lab_4.PageObjects.EntryPages.My_Store.Product
{
	public class ProductMyStore : PageBase
	{
		public Button SendToFriend => Select<Button>("send_friend_button", FindBy.Id);

		public Button OpenCard => Select<Button>("a[title='View my shopping cart']");

		public Button AddToCard => Select<Button>("button[name='Submit']");
	}
}
