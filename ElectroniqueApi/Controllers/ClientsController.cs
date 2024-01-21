using ElectroniqueApi.Model;
using ElectroniqueApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroniqueApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ICllientService<Client> clientService;


        public ClientsController(ICllientService<Client> clientService)
        {
            this.clientService = clientService;

        }

        // GET: api/<Client>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = await clientService.GetAll();
            return Ok(c);
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(byte id)
        {
            var p = await clientService.Get(id);
            if (p == null)
                return NotFound($"No client was found with ID : {id}");

            return Ok(p);
        }

        // POST api/<Categorie>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            
            await clientService.Add(client);
            return Ok(client);
        }

        // PUT api/<Client>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, [FromBody] Client client)
        {
            var p = await clientService.Get(id);
            if (p == null)
                return NotFound($"No client was found with ID : {id}");
            await clientService.Update(p);
            return Ok(client);
        }

        // DELETE api/<Client>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var p = await clientService.Get(id);
            if (p == null)
                return NotFound($"No client was found with ID : {id}");
            await clientService.Delete(id);
            return Ok(p);
        }
    }
}
