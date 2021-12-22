#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeFollowMVC.Services;
using AnimeFollowMVC.Services.Models;
using System.Net.Http.Headers;

namespace AnimeFollowMVC.Controllers
{
    public class AnimesController : Controller
    {
        private HttpClient _httpClient = new HttpClient();
        public AnimesController()
        {
            this._httpClient.BaseAddress = new Uri("https://localhost:7111/api/");
            this._httpClient.DefaultRequestHeaders.Accept   
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            IEnumerable<Anime> animes = await this._httpClient.GetFromJsonAsync<IEnumerable<Anime>>("anime");
            return View(animes);
        }

        //GET: Animes/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Anime anime = await this._httpClient.GetFromJsonAsync<Anime>($"anime/{id}");

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                await this._httpClient.PostAsJsonAsync<Anime>("anime", anime);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Anime anime = await this._httpClient.GetFromJsonAsync<Anime>($"anime/{id}");

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Anime anime)
        {
            if (id != anime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await this._httpClient.PutAsJsonAsync<Anime>($"anime/{id}", anime);
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Anime anime = await this._httpClient.GetFromJsonAsync<Anime>($"anime/{id}");

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._httpClient.DeleteAsync($"anime/{id}");
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return this._httpClient.GetFromJsonAsync<Anime>($"anime/{id}") != null;
        }
    }
}
