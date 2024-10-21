using System;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }

    public int FarmerID { get; set; }

    // Remove the [Required] attribute from the Farmer property
    public Farmer Farmer { get; set; }
}
