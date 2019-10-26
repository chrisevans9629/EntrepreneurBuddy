using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EntrepreneurBuddy.Areas.Identity.Data;
using EntrepreneurBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EntrepreneurBuddy.Areas.Identity.Pages.Account
{
    public class MentorRegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly AppDbContext dbContext;

        public MentorRegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger, AppDbContext dbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.dbContext = dbContext;
            Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [Required]
            [Display(Name ="Biography Information")]
            public string Bio { get; set; }

            [Required]
            [Display(Name = "Profile Image Url")]
            public string Image { get; set; }

            [Required]
            [Display(Name = "Position/Job Title")]
            public string Position { get; set; }

            [Required]
            [Display(Name = "Comma Seperated Skills (ex. 'Full-Stack, Business Management, Logistics Operation Management')")]
            public string Skills { get; set; }

            [Required]
            [Display(Name = "Postal Code")]
            public string Zip { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Mentor");
                    var entreprenuer = new Mentor()
                    {
                        AppUserId = user.Id,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        Email = Input.Email,
                        Bio = Input.Bio,
                        ImageUrl = Input.Image,
                        Position = Input.Position,
                        Skills = Input.Skills,
                        Zip = Input.Zip,
                        Rating = 0
                    };
                    dbContext.Add(entreprenuer);
                    dbContext.SaveChanges();
                    //todo: associate users
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
