using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityServer4.Models;
using PX.Data;
using PX.DbServices.QueryObjectModel;
using PX.Oidc.Interfaces;
using PX.SM;

namespace PX.OIDCDemo.Ext
{
    public class OIDCCustomClaimProvider : IPluginClaimProvider
    {
        public string PluginDescription => "inSided Claims Provider";

        public IReadOnlyList<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            //Scope and additional claims for inSided
            new IdentityResource
                {
					Name = "insided",
                    DisplayName = "inSided (Roles)",
                    ShowInDiscoveryDocument = false,
                    Emphasize = true,
                    Required = true,
                    UserClaims = new List<string>
                    {
                        inSidedConnectedApplication.InsidedClaims.Id,
                        inSidedConnectedApplication.InsidedClaims.Username,
                        inSidedConnectedApplication.InsidedClaims.CustomRoles,
                    }
                }
        };

        public IReadOnlyList<Claim> GetCurrentUserClaims()
        {
            var liClaims = new List<Claim>();

            var userInfoProvider = CommonServiceLocator.ServiceLocator.Current.GetInstance<ICurrentUserInformationProvider>();

            Guid? currentUserPKID = userInfoProvider.GetUserId();
            string currentUserName = userInfoProvider.GetUserName();

            liClaims.Add(new Claim(inSidedConnectedApplication.InsidedClaims.Id, currentUserPKID.ToString()));
            liClaims.Add(new Claim(inSidedConnectedApplication.InsidedClaims.Username, currentUserName));
            liClaims.Add(new Claim(inSidedConnectedApplication.InsidedClaims.CustomRoles, GetAllowedRoles(currentUserName)));

            return liClaims;
        }

        private string GetAllowedRoles(string userName)
        {
            if (String.IsNullOrEmpty(userName)) { return String.Empty; }

            return String.Join(",", PXDatabase.SelectMulti<Roles>(
                                        Yaql.join<UsersInRoles>(Yaql.eq<UsersInRoles.rolename, Roles.rolename>(), YaqlJoinType.INNER),
                                            new PXDataFieldValue<RolesOIDCPXExt.usrinSidedRoleID>(typeof(Roles).Name, null, PXComp.ISNOTNULL),
                                            new PXDataFieldValue<UsersInRoles.username>(typeof(UsersInRoles).Name, userName, PXComp.EQ),
                                            new PXDataField<RolesOIDCPXExt.usrinSidedRoleID>(typeof(Roles).Name)).
                                        Select(p => p.GetString(0)));
        }
    }
}
