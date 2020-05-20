using lab_4.Utils;
using System.Linq;

namespace lab_4.PageObjects.EntryPages.My_Store
{
	public class FooterMyStore : PageBase
	{
		public string Phone
		{

			get
			{
				var lis = RelatedElement.FindElements("li", FindBy.TagName);
				var li = lis.FirstOrDefault(li => li.FindElements("icon-phone", FindBy.ClassName).Any());
				var phone = li?.FindElement("span", FindBy.TagName)?.Text;
				return phone;
			}
		}

		public string Email
		{

			get
			{
				var lis = RelatedElement.FindElements("li", FindBy.TagName);
				var li = lis.FirstOrDefault(li => li.FindElements("icon-envelope-alt", FindBy.ClassName).Any());
				var email = li?.FindElement("span", FindBy.TagName)?.Text;
				return email;
			}
		}
	}
}
