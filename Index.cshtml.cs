using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icsocial2.Data;
using icsocial2.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace icsocial2.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private UserManager<ApplicationUser> _userManager;

        private ApplicationDbContext _db;
        
        public IndexModel(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> Profiles { get; set; }

        public async Task OnGetAsync()
        {
            System.Diagnostics.Debug.WriteLine("Getting user id");
            var userID = _userManager.GetUserId(HttpContext.User);
            System.Diagnostics.Debug.WriteLine(userID);
            Profiles = await _db.Users.Where(l => l.Id == userID).ToListAsync();

            System.Diagnostics.Debug.WriteLine($"Number of items: {Profiles.Count()}");
        }



    }
}
