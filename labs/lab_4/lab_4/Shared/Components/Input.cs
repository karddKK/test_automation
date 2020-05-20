using lab_4.PageObjects;

namespace lab_4.Shared.Components
{
	public class Input : PageBase
	{
		public string Value => RelatedElement.Text;

		public void SendKeys(string value) => RelatedElement.SendKeys(value);
	}
}
