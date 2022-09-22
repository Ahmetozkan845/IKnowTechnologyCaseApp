using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.BLL.Models.VMs;
using IKnowTechnologyCase.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.UI.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult CreateNote()
        {
            return View();
        }


        const string apiUrl = "https://localhost:44394/api/";
        [HttpPost]
        public async Task<IActionResult> CreateNote(CreateNoteDTO model)
        {

            string url = apiUrl + "AppUser/CreateNote";
            AppUser appUser = await userManager.GetUserAsync(User);
            model.UserId = appUser.Id;
            
            HttpClient httpClient = new HttpClient();
            string jsonObject = JsonConvert.SerializeObject(model);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, model);
            if(response.IsSuccessStatusCode)
            {
                return View();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> NotebookList()
        {

            HttpClient httpClient = new HttpClient();
            AppUser appUser = await userManager.GetUserAsync(User);
            string url = apiUrl + "AppUser/GetNotes/" + appUser.Id;
            HttpResponseMessage response = await httpClient.GetAsync(url);  
            string result = await response.Content.ReadAsStringAsync();
            List<GetNoteVM> noteVMs = JsonConvert.DeserializeObject<List<GetNoteVM>>(result);   
            return View(noteVMs);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateNote(UpdateNoteDTO model)
        {
            string url = apiUrl + "AppUser/UpdateNote";                  
            HttpClient httpClient = new HttpClient();
            string jsonObject = JsonConvert.SerializeObject(model);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNote(int id)
        {
            HttpClient httpClient = new HttpClient();          
            string url = apiUrl + "AppUser/GetUpdateNote/" + id;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            UpdateNoteDTO noteVM = JsonConvert.DeserializeObject<UpdateNoteDTO>(result);
            return View(noteVM);

        }
        [HttpGet]
        public async Task<IActionResult> DeleteNote(int id)
        {
            HttpClient httpClient = new HttpClient();
            string url = apiUrl + "AppUser/GetDeleteNote/" + id;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            GetNoteVM noteVM = JsonConvert.DeserializeObject<GetNoteVM>(result);
            return View(noteVM);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteNote(GetNoteVM model)
        {
            string url = apiUrl + "AppUser/DeleteNote";
            HttpClient httpClient = new HttpClient();
            string jsonObject = JsonConvert.SerializeObject(model);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NotebookList","AppUser");
            }
            return View(model);
        }



    }
}
