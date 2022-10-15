using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Ui.Areas.Manager
{
	[Area("Manager")]
	[Authorize]
	public class ManagerBaseController: Controller
	{
	}
}
