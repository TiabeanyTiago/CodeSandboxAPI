using Microsoft.AspNetCore.Mvc;
using ProductApi.Domain;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Product1", Price = 10.0M },
        new Product { Id = 2, Name = "Product2", Price = 20.0M }
    };

    [HttpGet]
    public ActionResult<List<Product>> Get()
    {
        return Products;
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var Product = Products.FirstOrDefault(p => p.Id == id);
        if (Product == null)
        {
            return NotFound();
        }
        return Product;
    }

    [HttpPost]
    public ActionResult<Product> Post(Product Product)
    {
        Products.Add(Product);
        return CreatedAtAction(nameof(Get), new { id = Product.Id }, Product);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Product ProductAtualizado)
    {
        var Product = Products.FirstOrDefault(p => p.Id == id);
        if (Product == null)
        {
            return NotFound();
        }
        Product.Name = ProductAtualizado.Name;
        Product.Price = ProductAtualizado.Price;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Product = Products.FirstOrDefault(p => p.Id == id);
        if (Product == null)
        {
            return NotFound();
        }
        Products.Remove(Product);
        return NoContent();
    }
}
