using AutoMapper;
using BulbaCourses.GlobalAdminUser.Data.Models;
using BulbaCourses.GlobalAdminUser.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic
{
    public class MapperLogicProfile:Profile
    {
        public MapperLogicProfile()
        {
            CreateMap<UserDb, UserDTO>()
                .ForMember(x => x.Lockout, opt => opt.MapFrom(y => BoolToText(y.LockoutEnabled)))
                .ForMember(x=>x.Username, opt=>opt.MapFrom(y=>y.UserName));
            CreateMap<UserDTO, UserDb>();
            CreateMap<RegisterUserDb, RegisterUserDTO>().ReverseMap();
            CreateMap<Claim, ProfileParamsDTO>()
                .ForMember(x=>x.FieldName, opt=>opt.MapFrom(x=>GetClaim(x.ClaimType)))
                .ForMember(x=>x.ClaimType,opt=>opt.MapFrom(x=>x.ClaimType))
                .ForMember(x=>x.FieldValue, opt=>opt.MapFrom(x=>x.ClaimValue));
            CreateMap<UserDb, UserProfileDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.ProfileParams, opt => opt.MapFrom(s => s.Claims))
                .ForMember(x => x.Email, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "email")))
                .ForMember(x => x.GivenName, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "given_name")))
                .ForMember(x => x.FamilyName, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "family_name")))
                .ForMember(x => x.Gender, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "gender")))
                .ForMember(x => x.BirthDate, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "birthdate")))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "phone_number")))
                .ForMember(x => x.Address, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "address")))
                .ForMember(x => x.Picture, opt => opt.MapFrom(s => GetClaimValue(s.Claims, "picture")));

            CreateMap<RoleDb, RoleDTO>().ReverseMap();
            CreateMap<UserChangePassword, UserChangePasswordDTO>().ReverseMap();
            
            CreateMap<UserDTO, UserProfileDTO>();
          
        }

        private string GetClaimValue(IEnumerable<Claim> claims,string prop)
        {
            string claimValue = string.Empty;
            claimValue = claims.FirstOrDefault(x => x.ClaimType == prop)?.ClaimValue;
            return claimValue;
        }

        private string GetClaim(string claimType)
        {
            switch (claimType)
            {
                case "amr": 
                    return "AuthenticationMethod";
                case "sid":
                    return "SessionId";
                case "acr":
                    return "AuthenticationContextClassReference";
                case "auth_time":
                    return "AuthenticationTime";
                case "azp":
                    return "AuthorizedParty";
                case "at_hash":
                    return "AccessTokenHash";
                case "c_hash":
                    return "AuthorizationCodeHash";
                case "nonce":
                    return "Nonce";
                case "jti":
                    return "JwtId";
                case "iat":
                    return "IssuedAt";
                case "cnf":
                    return "Confirmation";
                case "scope":
                    return "Scope";
                case "id":
                    return "Id";
                case "secret":
                    return "Secret";
                case "idp":
                    return "IdentityProvider";
                case "role":
                    return "Role";
                case "reference_token_id":
                    return "ReferenceTokenId";
                case "authorization_return_url":
                    return "AuthorizationReturnUrl";
                case "partial_login_restart_url":
                    return "PartialLoginRestartUrl";
                case "partial_login_return_url":
                    return "PartialLoginReturnUrl";
                case "client_id":
                    return "ClientId";
                case "external_provider_user_id":
                    return "ExternalProviderUserId";
                case "updated_at":
                    return "UpdatedAt";
                case "nbf":
                    return "NotBefore";
                case "name":
                    return "Name";
                case "given_name":
                    return "GivenName";
                case "family_name":
                    return "FamilyName";
                case "middle_name":
                    return "MiddleName";
                case "nickname":
                    return "NickName";
                case "preferred_username":
                    return "PreferredUserName";
                case "profile":
                    return "Profile";
                case "picture":
                    return "Picture";
                case "website":
                    return "WebSite";
                case "exp":
                    return "Expiration";
                case "email":
                    return "Email";
                case "gender":
                    return "Gender";
                case "birthdate":
                    return "BirthDate";
                case "zoneinfo":
                    return "ZoneInfo";
                case "locale":
                    return "Locale";
                case "phone_number":
                    return "PhoneNumber";
                case "phone_number_verified":
                    return "PhoneNumberVerified";
                case "address":
                    return "Address";
                case "aud":
                    return "Audience";
                case "iss":
                    return "Issuer";
                case "email_verified":
                    return "EmailVerified";
                case "partial_login_resume_id":
                    return "PartialLoginResumeId";
                default:
                    return claimType;
            }
        }



        private string BoolToText(bool y)
        {
            return y ? "Yes" : "No";
        }
    }


}
