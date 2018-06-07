using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDU.Authentication
{
    public class AuthenticationClaims
    {
        public const string UserIdClaim = "http://identity.MDU.com/userid";
        public const string UserNameClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        public const string NameClaim = "http://identity.MDU.com/name";
        public const string EmailClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        public const string IsStaffClaim = "http://identity.MDU.com/isstaff";
        public const string RoleClaim = "http://identity.MDU.com/role";
    }
}
