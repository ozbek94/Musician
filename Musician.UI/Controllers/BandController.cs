using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musician.Domain.Entity;
using Musician.Domain.Repositories;
using Musician.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musician.UI.Controllers
{
    [Route("Band")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandRepository _bandRepository;

        public BandController(IBandRepository bandRepository)
        {
            this._bandRepository = bandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Bands()
        {
            List<Band> musicians = await _bandRepository.GetBands();

            if (musicians.Count > 0)
            {
                return Ok(musicians);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> BandById(int id)
        {
            Band band = await _bandRepository.GetByBandId(id);

            if (band != null)
            {
                return Ok(band);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Band(BandModel Model)
        {
            Band band = new Band()
            {
                Name = Model.Name,
                InsertTime = DateTime.Now
            };

            await _bandRepository.CreateBand(band);

            return NoContent();
        }
        [HttpPost("BantMusician")]
        public async Task<IActionResult> BandMusician(Band band)
        {
            if(band == null)
            {
                return NotFound();
            };

            await _bandRepository.CreateBand(band);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateBand(int id, BandModel Model)
        {
            Band band = await _bandRepository.GetByBandId(id);

            if (band == null)
            {
                return BadRequest("Band bulunamadı.");
            }

            band.Name = Model.Name;

            await _bandRepository.Update(band);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            Band band = await _bandRepository.GetByBandId(id);

            if (band == null)
            {
                return BadRequest("Müzisyen bulunamadı.");
            }

            await _bandRepository.DeleteBand(band);

            return NoContent();
        }
    }
}