using lab_4.Shared.Components;
using lab_4.Utils;

namespace lab_4.PageObjects.EntryPages.My_Store.Modal
{
	public class SendToFriendModal : PageBase
	{
		public string NameFriendLable => RelatedElement.FindElement("label[for='friend_name']")?.Text;

		public Button Send => Select<Button>("sendEmail", FindBy.Id);
	}
}
