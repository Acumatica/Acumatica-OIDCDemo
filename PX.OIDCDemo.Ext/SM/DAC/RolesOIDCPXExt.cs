using System;
using PX.Data;
using PX.SM;

namespace PX.OIDCDemo.Ext
{
    public sealed class RolesOIDCPXExt : PXCacheExtension<Roles>
    {
        public static bool IsActive() => true;

        #region UsrinSidedRoleID
        public abstract class usrinSidedRoleID : PX.Data.BQL.BqlString.Field<usrinSidedRoleID> { }

        [PXDBString(4, InputMask = ">999")]
        [PXUIField(DisplayName = "Role ID")]
        public String UsrinSidedRoleID { get; set; }
        #endregion

        #region UsrMindMatrixRole
        public abstract class usrMindMatrixRole : PX.Data.BQL.BqlString.Field<usrMindMatrixRole> { }

        [PXDBString(64, IsUnicode = true)]
        [PXUIField(DisplayName = "Role")]
        public String UsrMindMatrixRole { get; set; }
        #endregion
    }
}
