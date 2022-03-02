using ECom.Infrastructure.Identity.Models;
using ECom.Web.Areas.Admin.Models;
using AutoMapper;

namespace ECom.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}