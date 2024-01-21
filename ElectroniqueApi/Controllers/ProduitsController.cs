using ElectroniqueApi.Model;
using ElectroniqueApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectroniqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IProduitService<Produit> produitService;
        private readonly ICategorieService<Categorie> categorieService;


        public ProduitsController(IProduitService<Produit> produitService, ICategorieService<Categorie> categorieService)
        {   
            this.produitService = produitService;
            this.categorieService = categorieService;
        }

        // GET: api/<Produit>
        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            var p = await produitService.GetAll();
           


            return Ok(p);
        }

        // GET api/<Produit>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(byte id)
        {
            var p = await produitService.Get(id);
            if (p == null)
                return NotFound($"No produit was found with ID : {id}");
           
            return Ok(p);
        }

        // POST api/<Produit>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produit produit)
        {
            await produitService.Add(produit);
            return Ok(produit);
        }

        // PUT api/<Produit>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produit produit)
        {

           await  produitService.Update(produit,  id);
            return Ok(produit);
        }

        // DELETE api/<Produit>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var p = await produitService.Get(id);
            if (p == null)
                return NotFound($"No produit was found with ID : {id}");
           await produitService.Delete(id);
            return Ok(p);
        }
    }
}
