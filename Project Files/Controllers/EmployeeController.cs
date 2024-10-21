using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

[Authorize(Roles = "Employee")]
public class EmployeeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public EmployeeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public IActionResult AddFarmer()
    {
        return View(new RegisterFarmerViewModel { Password = GeneratePasswordString() });
    }

    [HttpPost]
    public async Task<IActionResult> AddFarmer(RegisterFarmerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Farmer");

                var farmer = new Farmer
                {
                    Name = model.FullName,
                    ContactInfo = model.Email,
                    UserId = user.Id
                };

                _context.Farmers.Add(farmer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ViewFarmers));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult GeneratePassword()
    {
        return Json(new { password = GeneratePasswordString() });
    }

    private string GeneratePasswordString()
    {
        int length = 12;
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*?><-+=";
        StringBuilder res = new StringBuilder();
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            byte[] uintBuffer = new byte[sizeof(uint)];

            while (length-- > 0)
            {
                rng.GetBytes(uintBuffer);
                uint num = BitConverter.ToUInt32(uintBuffer, 0);
                res.Append(valid[(int)(num % (uint)valid.Length)]);
            }
        }
        return res.ToString();
    }

    public IActionResult ViewFarmers()
    {
        var farmers = _context.Farmers.ToList();
        return View(farmers);
    }

    [HttpGet]
    public async Task<IActionResult> FilterProducts(string category, DateTime? startDate, DateTime? endDate)
    {
        var products = from p in _context.Products.Include(p => p.Farmer) select p;

        if (!string.IsNullOrEmpty(category))
        {
            products = products.Where(p => p.Category == category);
        }

        if (startDate.HasValue)
        {
            products = products.Where(p => p.ProductionDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            products = products.Where(p => p.ProductionDate <= endDate.Value);
        }

        return View(await products.ToListAsync());
    }
}
