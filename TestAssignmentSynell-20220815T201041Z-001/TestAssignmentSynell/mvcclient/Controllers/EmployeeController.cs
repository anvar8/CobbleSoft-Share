using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using mvcclient.Models;
using Microsoft.AspNetCore.Http;
using mvcclient.Extensions;
using System.IO;
using System.Net.Http.Headers;

namespace mvcclient.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IConfiguration _config;

        private readonly HttpClient _client;
        private string baseUrl;


        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration config, HttpClient client)
        {
            _client = client;
            _config = config;
            baseUrl = _config.GetSection("apiUrl").Value;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1, string SearchString = "", string sortOrder = "", string sortProperty = "Surname", string prevProp = "Surname")
        {
            
            EmployeeViewModel items = null;
     
            ViewData["SortDirection"] = String.IsNullOrEmpty(sortOrder) ||sortOrder == "desc" || sortProperty != prevProp ? "asc": "desc" ;
            var testOrder =  ViewData["SortDirection"]; 
            var testCur = sortProperty;
            var testprev = prevProp;
            ViewData["PreviousProperty"] = sortProperty;
            var httpResponse = await _client.GetAsync(baseUrl + "employee/getemployees?pageIndex=" + page + "&search=" + SearchString + "&sort=true" + "&sortDirection=" + ViewData["SortDirection"] + "&sortingProp=" + sortProperty);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve items");
            }
        
            var content = await httpResponse.Content.ReadAsStringAsync();
            items = JsonConvert.DeserializeObject<EmployeeViewModel>(content);
            return View(items);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var httpResponse = await _client.DeleteAsync(baseUrl + "employee/deleteemployee?id=" + id);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Delete failed");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee item = null;
            var httpResponse = await _client.GetAsync(baseUrl + "employee/getemployee?id=" + id);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve items");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            item = JsonConvert.DeserializeObject<Employee>(content);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employeeToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var content = JsonConvert.SerializeObject(employeeToEdit);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var httpResponse = await _client.PutAsync(baseUrl + "employee/updateemployee?id=" + employeeToEdit.Id, byteContent);
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot update item");
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }


            }
            return View(employeeToEdit);
        }



        [HttpPost("UploadBatch")]
        public async Task<IActionResult> UploadBatch(IFormFile file)
        {
            var filePath = Path.Combine("Temp", file.FileName);
            byte[] bArray = await file.GetBytes();
            var byteArrayContent = new ByteArrayContent(bArray);
            var postResponse = await _client.PostAsync(baseUrl + "employee/createbatch", new MultipartFormDataContent {
                    { byteArrayContent, "file", file.FileName }
                });
            EmployeeViewModel items = null;

            if (postResponse.IsSuccessStatusCode)
            {
                var content = await postResponse.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<EmployeeViewModel>(content);               
            }
            return RedirectToAction("Index");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}