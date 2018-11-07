//
//  Author:
//    Kristijan Klepač kristijan.klepac@gmail.com
//
//  Copyright (c) 2018, www.kristijanklepac.info
//
//  All rights reserved.
//
//
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using webapptesy.AccountViewModels;
using webapptesy.Data;
using webapptesy.Helpers;
using webapptesy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapptesy.Controllers
{
    [EnableCors("CORSPolicy")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public TokenController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        // GET: api/token
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {

                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

                    if (!result.Succeeded)
                    {

                        return Unauthorized();
                    }
                    // table and this user must exist because they are created on Register user 
                    var userToken = await _context.UsersTokens.SingleOrDefaultAsync(em => em.Email == model.Email);

                    if (userToken == null) // shit happens ???
                    {
                        return Unauthorized();
                    }

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Token:Issuer"],
                        audience: _configuration["Token:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(60),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                SecurityAlgorithms.HmacSha256)
                    );

                    // this token must be inserted in table UsersToken for this user
                    var genToken = new JwtSecurityTokenHandler().WriteToken(token);

                    ////////////////////////////////////////////////////////////
                    /// 
                    /// Store token in some table for check permissions in 
                    /// ImagerService 
                    /// (Image resize and save service by ChrisVz written in Java)
                    /// 
                    //////////////////////////////////////////////////////////// 

                    userToken.TokenValue = genToken; // update this user in table UsersTokens with new token
                    /// update ....
                    _context.Entry(userToken).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    ///////////////////////////////////////////////////////////


                    return Ok(new { token = genToken, userfolder = userToken.UserFolder });
                }
            }

            return BadRequest(model);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    ///////////////////////////////////////////////////////////
                    /// 
                    /// we must create new row for this user in table UsersToken
                    /// also we wil create unique folder name for future use
                    /// example images for that user (all images uploaded
                    /// will go inside that folder
                    /// 
                    /// ///////////////////////////////////////////////////////

                    var userToken = new UserToken
                    {
                        Email = model.Email,
                        TokenName = "token",
                        TokenValue = "",
                        UserFolder = Guid.NewGuid().ToString()
                    };
                    // add ...
                    _context.UsersTokens.Add(userToken);
                    await _context.SaveChangesAsync();

                }

            }


            return Ok(model);
        }


        public string Encrypt(string encryptString, string encryptKey)
        {
            string EncryptionKey = encryptKey;
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string Decrypt(string cipherText, string encryptKey)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

       


    }
}
