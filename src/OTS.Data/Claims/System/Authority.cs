using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Claims.System
{
    public static class Authority
    {
        #region Admin
        public const string ADMIN_ROLE_VIEW = "Admin.Role.View";
        public const string ADMIN_ROLE_EDIT = "Admin.Role.Edit";
        public static readonly List<string> LIST_ADMIN_CLAIMS = new()
        {
            ADMIN_ROLE_VIEW,
            ADMIN_ROLE_EDIT
        };
        #endregion

        #region Moderator
        public const string MOD_ROLE_VIEW = "Mod.Role.Ban";
        public const string MOD_TEST_VIEW = "Mod.Test.View";
        public const string MOD_TEST_DELETE = "Mod.Test.Delete";
        public static readonly List<string> LIST_MOD_CLAIMS = new()
        {
            MOD_ROLE_VIEW,
            MOD_TEST_VIEW,
            MOD_TEST_DELETE
        };
        #endregion

        #region User
        public const string USER_TEST_CREATE = "User.Test.Create";
        public const string USER_TEST_VIEW = "User.Test.View";
        public const string USER_TEST_EDIT = "User.Test.Edit";
        public const string USER_TEST_DELETE = "User.Test.Delete";
        public static readonly List<string> LIST_USER_CLAIMS = new()
        {
            USER_TEST_CREATE,
            USER_TEST_VIEW,
            USER_TEST_EDIT,
            USER_TEST_DELETE
        };
        #endregion
    }
}
