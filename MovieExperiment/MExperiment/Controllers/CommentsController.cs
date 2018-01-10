using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MExperiment.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using MExperiment.Models.Enum;

namespace MExperiment.Controllers
{
    public class CommentsController : Controller
    {
        public CommentsController()
        {           
        }

        public async Task<IActionResult> Create(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            @ViewData["SelectedMovie"] = id;
            //TODO: Add user logged
            @ViewData["userLogged"] = new Guid("0E984725-C51C-4BF4-9960-E1C80E27ABA0");
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVideo,IdUser,Text,DateTime")] Comments comment)
        {
            comment.IdComment = Guid.NewGuid();
            //Start
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/putcomment?id=" + comment.IdVideo.ToString(), comment);

                return RedirectToAction("Details", "Movies", new { id = comment.IdVideo.ToString() });
            }
            //--- END
        }

        //// GET: Comments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync("api/deletecommentbyid?id=" + id.ToString());

                return RedirectToAction("Index", "Movies");
            }
        }
    }
}
