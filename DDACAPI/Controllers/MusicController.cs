using DDACAPI.Data;
using DDACAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDACAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicContext _context;

        public MusicController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusics()
        {
            return await _context.Music.ToListAsync();
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Music>> PostAuthor(Music music)
        {
            _context.Music.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusics", new { id = music.musicid }, music);
        }

    }

   
}
