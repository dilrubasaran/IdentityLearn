using identity_signup.Areas.Instructor.Models;
using identity_singup.Areas.Admin.Services;
using identity_singup.Infrastructure.Authorization;
using identity_singup.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Authorization
{
    public class EducationAuthorizationHandler : AuthorizationHandler<CanEditEducationPolicy, Education>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPermissionRequestService _permissionService;

        public EducationAuthorizationHandler(
            UserManager<AppUser> userManager,
            IPermissionRequestService permissionService)
        {
            _userManager = userManager;
            _permissionService = permissionService;
        }
        //Yetki sahibi mi ve e�itimi d�zenleyen ki�i mi kontrol eder 
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CanEditEducationPolicy requirement,
            Education resource)
        {
            var user = await _userManager.GetUserAsync((ClaimsPrincipal)context.User);
            if (user == null) return;

            if (context.User.IsInRole("admin"))
            {
                context.Succeed(requirement);
                return;
            }

            if (resource.CreatedBy != user.Id) return;

            var daysSinceCreation = (DateTime.Now - resource.CreatedAt).Days;
            if (daysSinceCreation <= requirement.AllowedDaysForEdit)
            {
                context.Succeed(requirement);
                return;
            }

            var hasExtendedPermission = await _permissionService
                .HasValidPermission(resource.Id, user.Id);
            
            if (hasExtendedPermission)
            {
                context.Succeed(requirement);
            }
        }
    }
} 