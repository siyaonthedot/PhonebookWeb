using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
//using System.Net.Http.Formatting;
using System.Web.Mvc;
using PhonebookWeb.Models;
namespace PhonebookWeb.Controllers
{
    public class ContactsController : Controller
    {
        string Baseurl = "http://localhost:58109/";
        // GET: Contacts
        public async Task<ActionResult> Index()
        {

            List<ContactModel> contacts = new List<ContactModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource Contacts using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Contacts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Contact list  
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);

                }
            }
        
            return View(contacts);
        }

        private async Task<List<ContactModel>>GetContacts()
        {
           List<ContactModel> contacts = new List<ContactModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource Contacts using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Contacts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Contact list  
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);

                }
                //returning the employee list to view 
            }


            return contacts;
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ContactModel contact = null;
            List<ContactModel> contacts = new List<ContactModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource Contacts using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Contacts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Contact list  
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);
                    contact = contacts.FirstOrDefault(x => x.ID == id);

                }
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Create(ContactModel model)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource Contacts using HttpClient  
                    //StringContent content = new StringContent(collection);
                    string json =  JsonConvert.SerializeObject(model); ;
                    HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PostAsync("api/Contacts/Post", c).ConfigureAwait(false);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                       // contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);

                    }
                    //returning the employee list to view 
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ContactModel contact = null;
            List<ContactModel> contacts = new List<ContactModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource Contacts using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Contacts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Contact list  
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);
                    contact = contacts.FirstOrDefault(x => x.ID == id);

                }
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit( ContactModel model)
        {
            try
            {
                ContactModel contact = null;

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource Contacts using HttpClient  
                    //StringContent content = new StringContent(collection);
                    string json = JsonConvert.SerializeObject(model); ;
                    HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PostAsync("api/Contacts/Post", c).ConfigureAwait(false);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        // contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);

                    }
                    //returning the employee list to view 
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ContactModel contact = null;
            List<ContactModel> contacts = new List<ContactModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource Contacts using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Contacts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Contact list  
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);
                    contact = contacts.FirstOrDefault(x => x.ID == id);

                }
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(ContactModel model)
        {
            try
            {
                ContactModel contact = null;

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource Contacts using HttpClient  
                    //StringContent content = new StringContent(collection);
                    string json = JsonConvert.SerializeObject(model); ;
                    HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.DeleteAsync("api/Contacts/"+ model.ID).ConfigureAwait(false);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        // contacts = JsonConvert.DeserializeObject<List<ContactModel>>(EmpResponse);

                    }
                    //returning the employee list to view 
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
