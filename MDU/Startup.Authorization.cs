using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDU
{
    public static class StartupAuthorization
    {
        public static void AddSecurity(this AuthorizationOptions auth)
        {
            auth.AddPolicy("Admin", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Admin", "Owner");
            });

            auth.AddPolicy("Owner", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Owner", "Super_Admin");
            });

            auth.AddPolicy("User", policy =>
            {
                policy.RequireAuthenticatedUser();
            });

            auth.AddPolicy("Ahl", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("AHL");
            });

            auth.AddPolicy("Chat", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
        }
    }
}
