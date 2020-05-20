using lab_4.PageObjects;

namespace lab_4.Shared.Components
{
	public class Button : PageBase
	{
		public string Lable => RelatedElement.Text;

		public void Click() => RelatedElement.Click();
	}
}
