using ElectroniqueApi.Model;
using ElectroniqueApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroniqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturesController : ControllerBase
    {
        private readonly IFactureService<Facture> factureService;

        public FacturesController(IFactureService<Facture> factureService)
        {
            this.factureService = factureService;
        }
        // GET: api/<Facures>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = await factureService.GetAll();
            return Ok(c);
        }

        // GET api/<Factures>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(byte id)
        {
            var p = await factureService.Get(id);
            if (p == null)
                return NotFound($"No facture was found with ID : {id}");

            return Ok(p);
        }

        // POST api/<Factures>
        [HttpPost]
        public async Task<ActionResult<Facture>> Post([FromBody] Facture facture)
        {
            await factureService.Add(facture);
            return Ok();
        }

        // PUT api/<Factures>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, [FromBody] Facture facture)
        {
            var p = await factureService.Get(id);
            if (p == null)
                return NotFound($"No facture was found with ID : {id}");
            await factureService.Update(p);
            return Ok(facture);
        }

        // DELETE api/<Factures>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var p = await factureService.Get(id);
            if (p == null)
                return NotFound($"No facture was found with ID : {id}");
            await factureService.Delete(id);
            return Ok(p);
        }
    }
}
