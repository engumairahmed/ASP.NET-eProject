using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RailwayTicketSystem.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" ,"StationMaster","TrainMaster"};
            string[] userNames = { "Admin", "User", "StationMaster", "TrainMaster" };
            string[] userEmails = { "admin@mail.com", "umair@mail.com", "stationmaster@mail.com", "trainmaster@mail.com" };
            string[] userPasses = { "Admin@123", "Umair@123", "Smaster@123", "TMaster@123" };

            IdentityResult roleResult;

            // Create roles if they don't exist
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them to the database
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            int length = userNames.Length;

            for (int i = 0; i < length; i++)
            {
                string email = userEmails[i]; 
                string password = userPasses[i];
                string role = roleNames[i];
                string name = userNames[i];

                IdentityUser user = await userManager.FindByEmailAsync(email);

                if (user == null)
                {

                    user = new IdentityUser()
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var createUser =await userManager.CreateAsync(user, password);


                    //code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var result = await userManager.ConfirmEmailAsync(user, token);

                    //if(createUser.Succeeded)

                    //{
                    //        var userId = await userManager.GetUserIdAsync(user);
                    //        //var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    //        //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    //        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    //        var res = await userManager.ConfirmEmailAsync(user, token);
                    //        Console.WriteLine(res);

                    //}   


                    if (!await userManager.IsInRoleAsync(user, role))
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }

}
