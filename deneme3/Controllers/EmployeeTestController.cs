using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace deneme3.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var reponseMessage = await httpClient.GetAsync("https://localhost:7038/api/Default");
            var jsonString = await reponseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var reponseMessage = await httpClient.PostAsync("https://localhost:7038/api/Default", content);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var reponseMessage = await httpClient.GetAsync("https://localhost:7038/api/Default/"+ id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await reponseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var reponseMessage = await httpClient.PutAsync("https://localhost:7038/api/Default", content);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var reponseMessage = await httpClient.DeleteAsync("https://localhost:7038/api/Default/"+id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
