using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common
{
    public static class Constant
    {
        #region "integer constants"
        public static class Numbers
        {
            
        }
        #endregion

        #region string constants
        public static class ClaimIdentifiers
        {
            public const string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
            public const string Id = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
            public const string Email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
            public const string Name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
            public const string UserName = "UserName";
        }
        #endregion
    }
}
