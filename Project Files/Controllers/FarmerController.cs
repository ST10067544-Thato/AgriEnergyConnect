using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize(Roles = "Farmer")]
public class FarmerController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<FarmerController> _logger;

    public FarmerController(ApplicationDbContext context, ILogger<FarmerController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        _logger.LogInformation("AddProduct POST called");

        // Remove Farmer from validation
        ModelState.Remove("Farmer");

        if (ModelState.IsValid)
        {
            _logger.LogInformation("Model is valid");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);
            if (farmer != null)
            {
                _logger.LogInformation($"Farmer found: {farmer.Name}");
                product.FarmerID = farmer.FarmerID;
                product.Farmer = farmer;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Product saved");
                return RedirectToAction(nameof(ViewProducts));
            }
            else
            {
                _logger.LogWarning("Farmer not found");
                ModelState.AddModelError(string.Empty, "Farmer not found.");
            }
        }
        else
        {
            _logger.LogWarning("Model is invalid");
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }
        }
        return View(product);
    }

    public async Task<IActionResult> ViewProducts()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var farmer = await _context.Farmers.Include(f => f.Products).FirstOrDefaultAsync(f => f.UserId == userId);
        if (farmer == null || !farmer.Products.Any())
        {
            ViewBag.Message = "You have no products saved yet.";
            return View(Enumerable.Empty<Product>());
        }
        return View(farmer.Products);
    }
}
