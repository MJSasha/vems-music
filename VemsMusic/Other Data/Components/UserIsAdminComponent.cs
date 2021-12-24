using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Threading.Tasks;
using VemsMusic.Other_Data.Interfaces;

namespace VemsMusic.Other_Data.Components
{
    [ViewComponent]
    public class GetRedactionButtonIfUserIsAdminComponent
    {
        private readonly IAllUsers _allUsers;

        public GetRedactionButtonIfUserIsAdminComponent(IAllUsers allUsers)
        {
            _allUsers = allUsers;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            if (await UserIsAdminAsync(userId))
            {
                return new HtmlContentViewComponentResult(RedactionButton());
            }
            return null;
        }

        private async Task<bool> UserIsAdminAsync(string userId)
        {
            var user = await _allUsers.GetUserByIdAsync(Convert.ToInt32(userId));

            if (user.Role.Name == "admin")
            {
                return true;
            }
            return false;
        }
        private IHtmlContent RedactionButton()
        {
            return new HtmlString("<li class=\"nav - item\">\n" +
                "<a class=\"nav-link\" href=\"/DBRedaction/Index\">Редактирование</a>\n" +
                "</li>");
        }
    }
}
