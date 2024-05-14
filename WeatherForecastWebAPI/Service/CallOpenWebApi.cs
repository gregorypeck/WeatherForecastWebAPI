using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WeatherForecastWebAPI.Middleware
{
    public class CallOpenWebApi
    {
        //your Hosted Base URL
        string Baseurl = "http://192.168.90.1:85/";
        // GET: Student
        public async Task GetStudents()
        {
            //List<Student> StudentInfo = new List<Student>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                //Sending request to find web api REST service resource GetDepartments using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/ProjectA/GetDepartments");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                    var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                   // StudentInfo = JsonConvert.DeserializeObject<List<Student>>(ObjResponse);

                }
                //returning the student list to view  
                // return View(StudentInfo);
                //return new Action();
            }
        }
    }
}
