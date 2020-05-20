using lab_4.Shared.Components;
using lab_4.Utils;

namespace lab_4.PageObjects.EntryPages.My_Store
{
	public class LoginMyStore : PageBase
	{
		public Input Email => Select<Input>("email", FindBy.Id);

		public Input Password => Select<Input>("passwd", FindBy.Id);

		public Button SubmitLogin => Select<Button>("SubmitLogin", FindBy.Id);
	}
}
