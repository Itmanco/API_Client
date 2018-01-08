using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MExperiment.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using MExperiment.Models.Enum;

namespace MExperiment.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController()
        {

        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            Videos[] reports = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = await client.GetAsync("api/allvideos");
                if (response.IsSuccessStatusCode)
                {
                    reports = await response.Content.ReadAsAsync<Videos[]>();
                }
                return View(reports);
            }
                
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Videos res = null;
            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = await client.GetAsync("api/getvideobyid?id=" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    res = await response.Content.ReadAsAsync<Videos>();
                }
            }
                
            if (res == null)
            {
                return NotFound();
            }

            return View(res);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Title,Description,DateTime")] Videos movie)
        {
           movie.IdVideo = Guid.NewGuid();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync("api/putvideo?id=" + movie.IdVideo.ToString(), movie);               
            }
            //--- END

            return View(movie);
        }
 
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid? id, Guid? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            Videos res = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = await client.GetAsync("api/getvideobyid?id=" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    res = await response.Content.ReadAsAsync<Videos>();
                }
            }

            if (res == null)
            {
                return NotFound();
            }

            return View(res);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IdVideo, IdUser,Title,Description,DateTime")] Videos movie)
        {
            if (movie == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/updatevideo?id=" + movie.IdVideo.ToString(), movie);
                }
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            Videos movie = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = await client.GetAsync("api/getvideobyid?id=" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    movie = await response.Content.ReadAsAsync<Videos>();
                }
            }
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync("api/deletevideobyid?id=" + id.ToString());

                return RedirectToAction("Index", "Movies");
            }
        }

    }
}
