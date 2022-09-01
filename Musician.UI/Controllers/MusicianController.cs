using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musician.Domain.Repositories;
using Musician.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musician.UI.Controllers
{
    [Route("Musician")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianRepository _musicianRepository;

        public MusicianController(IMusicianRepository musicianRepository)
        {
            this._musicianRepository = musicianRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Musicians()
        {
            List<Musician.Domain.Entity.Musician> musicians = await _musicianRepository.GetMusicians();

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
        public async Task<IActionResult> MusicianById(int id)
        {
            Musician.Domain.Entity.Musician musician = await _musicianRepository.GetByMusicianId(id);

            if (musician != null)
            {
                return Ok(musician);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Musician(MusicianModel Model)
        {
            Domain.Entity.Musician musician = new Domain.Entity.Musician()
            {
                Name = Model.Name,
                InsertTime = DateTime.Now
            };

            await _musicianRepository.CreateNewMusician(musician);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateMusician(int id, MusicianModel Model)
        {
            Musician.Domain.Entity.Musician musician = await _musicianRepository.GetByMusicianId(id);

            if (musician == null)
            {
                return BadRequest("Müzisyen bulunamadı.");
            }

            musician.Name = Model.Name;

            await _musicianRepository.Update(musician);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            Musician.Domain.Entity.Musician musician = await _musicianRepository.GetByMusicianId(id);

            if (musician == null)
            {
                return BadRequest("Müzisyen bulunamadı.");
            }

            await _musicianRepository.DeleteMusician(musician);

            return NoContent();
        }
    }
}
