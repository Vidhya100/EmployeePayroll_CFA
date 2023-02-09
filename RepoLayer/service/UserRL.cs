
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.service
{
    public class UserRL :IUserRL
    {
        private readonly UserContext userContext;
        private readonly IConfiguration iconfiguration;
        public static string Key = "vidhya@@kfxcbv@";

        public UserRL(UserContext userContext, IConfiguration iconfiguration)
        {
            this.userContext = userContext;
            this.iconfiguration = iconfiguration;
        }

        public UserEntity Registration(UserRegi userRegi)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userRegi.FirstName;
                userEntity.LastName = userRegi.LastName;
                userEntity.Email = userRegi.Email;
                userEntity.Password = ConvertoEncrypt(userRegi.Password);
                userContext.UserTable.Add(userEntity);

                int result = userContext.SaveChanges();

                if(result != 0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static string ConvertoEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertoDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData))
                return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
        public string Login(LoginModel loginModel)
        {
            try
            {
                var data = this.userContext.UserTable.FirstOrDefault(x => x.Email == loginModel.Email);
                var dPass = ConvertoDecrypt(data.Password);
                if (dPass == loginModel.Password && data != null)
                {
                    //loginModel.Email = data.Email;
                    //loginModel.Password = data.Password;
                  //  return loginModel;
                    var token = GenerateSecurityToken(data.Email, data.UserId);
                    return token;
                    
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string GenerateSecurityToken(string email, long UserId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
