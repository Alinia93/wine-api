
using Microsoft.AspNetCore.Mvc;
using Wine_Api.Models;

namespace Wine_Api.Controllers;


[ApiController]
[Route("[controller]")]

public class wineController : ControllerBase
{

    public static List<Wine> wines { get; set; } = new()


        { new Wine { Name = "Chateau Margaux", Year = 2010, Color = "Red", Description = "Elegant and full-bodied." },
            new Wine { Name = "Domaine de la Romanee-Conti", Year = 2005, Color = "Red", Description = "Complex and velvety." },
            new Wine { Name = "Opus One", Year = 2012, Color = "Red", Description = "Harmonious blend with rich flavors." },
            new Wine { Name = "Cloudy Bay Sauvignon Blanc", Year = 2019, Color = "White", Description = "Crisp and refreshing." },         new Wine { Name = "Barolo Riserva", Year = 2013, Color = "Red", Description = "Robust with a long finish." },
            new Wine { Name = "Rombauer Vineyards Chardonnay", Year = 2018, Color = "White", Description = "Buttery and smooth." },
            new Wine { Name = "Silver Oak Cabernet Sauvignon", Year = 2015, Color = "Red", Description = "Velvety texture with rich fruit." },
            new Wine { Name = "Sancerre", Year = 2020, Color = "White", Description = "Crisp acidity with citrus notes." },         new Wine { Name = "Rioja Reserva", Year = 2014, Color = "Red", Description = "Smooth and well-balanced." },
            new Wine { Name = "Prosecco", Year = 218, Color = "Sparkling", Description = "Light and effervescent." },
            new Wine { Name = "Malbec", Year = 2017, Color = "Red", Description = "Bold and fruity." },
            new Wine { Name = "Chardonnay", Year = 2019, Color = "White", Description = "Fresh and lively." },
            new Wine { Name = "Cabernet Franc", Year = 2016, Color = "Red", Description = "Herbaceous with dark fruit." },         new Wine { Name = "Gewürztraminer", Year = 2018, Color = "White", Description = "Aromatic and floral." },
            new Wine { Name = "Zinfandel", Year = 2015, Color = "Red", Description = "Spicy and bold." },
            new Wine { Name = "Pinot Grigio", Year = 2021, Color = "White", Description = "Crisp and citrusy." },
            new Wine { Name = "Merlot", Year = 2014, Color = "Red", Description = "Soft and approachable." },
            new Wine { Name = "Champagne Brut", Year =2019, Color = "Sparkling", Description = "Toasty and celebratory." },
            new Wine { Name = "Syrah/Shiraz", Year = 2017, Color = "Red", Description = "Full-bodied with dark fruit." },
            new Wine { Name = "Sauvignon Blanc", Year = 2020, Color = "White", Description = "Zesty and herbaceous." }
        };


    // Get-metod. Hämta alla vin 

    [HttpGet]
    public ActionResult<List<Wine>> Get()
    {
        if (wines != null && wines.Any())
        {
            return Ok(wines);
        }
        else
        {
            return NotFound("Could not find wines");
        }
    }



    //Get by id. Hämta ett vin 
    [HttpGet("{id}")]
    public ActionResult<Wine> Get(int id)
    {
        Wine? wine = wines.FirstOrDefault(w => w.Id == id);
        if (wine != null)
        {
            return Ok(wine);

        }
        else
        {
            return NotFound("Could not find a wine");
        }
    }



    //Post lägg till ett vin 

    [HttpPost]
    public ActionResult Post(Wine wine)
    {
        if (wine == null
            || string.IsNullOrEmpty(wine.Name)
            || string.IsNullOrEmpty(wine.Color) || wine.Year < 0)
        {
            return BadRequest("Could not add wine. Did you fill in all the necessary information?");
        }

        wines.Add(wine);
        return Ok("Wine is added");
    }


    //Put uppdatera ett vin 
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Wine updatedWine)
    {
        if (string.IsNullOrEmpty(updatedWine.Name) || string.IsNullOrEmpty(updatedWine.Color) || updatedWine.Year < 0)
        {
            return BadRequest("All necessary information must be provided.");
        }

        Wine? wine = wines.FirstOrDefault(w => w.Id == id);
        if (wine == null)
        {
            return BadRequest("The wine you want to update does not seem to exist");
        }
        wine.Name = updatedWine.Name;
        wine.Color = updatedWine.Color;
        wine.Description = updatedWine.Description;
        return Ok("The wine is updated");
    }



    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Wine? wineToDelete = wines.FirstOrDefault(w => w.Id == id);
        if (wineToDelete != null)
        {
            wines.Remove(wineToDelete);
            return Ok("The wine is deleted");
        }

        return BadRequest("The wine does not seem to exist");


    }




}

