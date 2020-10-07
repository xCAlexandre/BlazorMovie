using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorMovie.Server;
using BlazorMovie.Shared;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly ApplicationDBContext db;

    public ProductController(ApplicationDBContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var products = await db.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var product = await db.Products.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
        return Ok(product);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Product product)
    {
        try
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Desc = product.Desc,
                Price = product.Price
            };

            db.Add(newProduct);
            await db.SaveChangesAsync();//insert
            return Ok();
        }
        catch (Exception e)
        {
            return View(e);
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Put([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Entry(product).State = EntityState.Modified;
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw (ex);
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<User>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var product = await db.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return Ok(product);
    }


}