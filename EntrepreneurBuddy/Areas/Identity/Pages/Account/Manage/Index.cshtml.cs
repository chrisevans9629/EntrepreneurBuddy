﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EntrepreneurBuddy.Areas.Identity.Data;
using EntrepreneurBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntrepreneurBuddy.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly AppDbContext _appDbContext;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender,
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _appDbContext = appDbContext;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Mentor")]
            public Mentor Mentor { get; set; }

            [Display(Name = "Roles")]
            public IList<string> Roles { get; set; }

            [Display(Name = "Roles")]
            public Entreprenuer Entrepenuer { get; set; }


        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            foreach (String role in roles)
            {
                if (role == "Mentor")
                {
                    var mentor = _appDbContext.Mentors.FirstOrDefault(x => x.Email == email);

                    Input = new InputModel
                    {
                        Email = email,
                        PhoneNumber = phoneNumber,
                        Mentor = mentor,
                        Roles = roles,
                    };
                }
                if (role == "Entreprenuer")
                {
                    var entreprenuer = _appDbContext.Entrepenuers.FirstOrDefault(x => x.Email == email);

                    Input = new InputModel
                    {
                        Email = email,
                        PhoneNumber = phoneNumber,
                        Entrepenuer = entreprenuer,
                        Roles = roles
                    };
                }
            }      
            
            Username = userName;



            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            var roles = await _userManager.GetRolesAsync(user);

            foreach (String role in roles)
            {
                if (role == "Mentor")
                {
                    var mentor = _appDbContext.Mentors.FirstOrDefault(x => x.Email == email);

                    mentor.ImageUrl = Input.Mentor.ImageUrl;
                    mentor.Skills = Input.Mentor.Skills;
                    mentor.Bio = Input.Mentor.Bio;
                    mentor.LinkedInUrl = Input.Mentor.LinkedInUrl;


                    _appDbContext.Mentors.Update(mentor);
                    await _appDbContext.SaveChangesAsync();
                }
                if (role == "Entreprenuer")
                {
                    var entrepenuer = _appDbContext.Entrepenuers.FirstOrDefault(x => x.Email == email);

                    entrepenuer.FirstName = Input.Entrepenuer.FirstName;
                    entrepenuer.LastName = Input.Entrepenuer.LastName;
                   

                    _appDbContext.Entrepenuers.Update(entrepenuer);
                    await _appDbContext.SaveChangesAsync();
                }
            }
           

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
