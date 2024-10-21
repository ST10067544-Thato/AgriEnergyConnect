using System.Collections.Generic;

public class Farmer
{
    public int FarmerID { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    // Add this property to link Farmer to ApplicationUser
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public ICollection<Product> Products { get; set; }
}
