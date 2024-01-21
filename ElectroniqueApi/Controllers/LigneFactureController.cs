using ElectroniqueApi.Model;
using ElectroniqueApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroniqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigneFactureController : ControllerBase
    {
        private readonly IFactureLigneService<LigneFacture> factureLigneService;


        public LigneFactureController(IFactureLigneService<LigneFacture> factureLigneService)
        {
            this.factureLigneService = factureLigneService;

        }

        // GET: api/<FacureLigne>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = await factureLigneService.GetAll();
            return Ok(c);
        }


        [HttpGet("/byClient/{id}")]
        public async Task<IActionResult> GetByClinetId(int id)
        {
            var c = await factureLigneService.GetByClinetId(id);
            return Ok(c);
        }

        // GET api/<FactureLigne>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(byte id)
        {
            var p = await factureLigneService.Get(id);
            if (p == null)
                return NotFound($"No Ligne was found with ID : {id}");

            return Ok(p);
        }

        // POST api/<FactureLigne>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LigneFacture> ligne)
        {
            await factureLigneService.Add(ligne);
            return Ok(ligne);
        }

        // PUT api/<FactureLigne>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, [FromBody] LigneFacture ligne)
        {
            var p = await factureLigneService.Get(id);
            if (p == null)
                return NotFound($"No ligne was found with ID : {id}");
            await factureLigneService.Update(p);
            return Ok(ligne);
        }

        // DELETE api/<FactureLigne>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var p = await factureLigneService.Get(id);
            if (p == null)
                return NotFound($"No ligne was found with ID : {id}");
            await factureLigneService.Delete(id);
            return Ok(p);
        }
    }
}
