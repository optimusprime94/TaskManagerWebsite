using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskManagerWebsite.Model;
using TaskManagerWebsite.Services;

namespace TaskManagerWebsite.Controllers
{
    public class HomeController : Controller
    {


        /* Here Is where Most of the action happens. We make three requests to get all task, user, and assignment 
         * Data. If the request fails we return an error message else we create an viewmodel to put all the data in
         * so the view can use it. This makes it easy to pass all the different dtos to the view together. */
        public async Task<ActionResult> Index()
        {
            TaskManagerViewModel model = new TaskManagerViewModel();

            var client = TaskManagerHttpClient.GetClient();

            /* Get all assignments and store in viewmodel */
            HttpResponseMessage response = await client.GetAsync("api/assignments");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                model.Assignmentlist = JsonConvert.DeserializeObject<IEnumerable<AssignmentDto>>(content);
            }
            else
            {
                return Content("Could not retrieve the information.");
            }

            /* Get all tasks and store in viewmodel */
            response = await client.GetAsync("api/tasks");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                model.Tasklist = JsonConvert.DeserializeObject<IEnumerable<TaskDto>>(content);
            }
            else
            {
                return Content("Could not retrieve the information.");
            }

            /* Get all users and store in viewmodel */
            response = await client.GetAsync("api/users");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                model.Userlist = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(content);
            }
            else
            {
                return Content("Could not retrieve the information.");
            }

            /* Finally return the view if successful */
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
