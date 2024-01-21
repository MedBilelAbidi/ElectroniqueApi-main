using ElectroniqueApi.Model;
using ElectroniqueApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroniqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieService<Categorie> categorieService;


        public CategoriesController( ICategorieService<Categorie> categorieService)
        {
            this.categorieService = categorieService;

        }

        // GET: api/<Categorie>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = await categorieService.GetAll();
            return Ok(c);
        }

        // GET api/<Categorie>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(byte id)
        {
            var p = await categorieService.Get(id);
            if (p == null)
                return NotFound($"No categorie was found with ID : {id}");

            return Ok(p);
        }

        // POST api/<Categorie>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categorie categorie)
        {
            await categorieService.Add(categorie);
            return Ok(categorie);
        }

        // PUT api/<Produit>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, [FromBody] Categorie categorie)
        {

            await categorieService.Update(categorie);
            return Ok(categorie);
        }

        // DELETE api/<Produit>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var p = await categorieService.Get(id);
            if (p == null)
                return NotFound($"No categorie was found with ID : {id}");
            await categorieService.Delete(id);
            return Ok(p);
        }
    }
}
