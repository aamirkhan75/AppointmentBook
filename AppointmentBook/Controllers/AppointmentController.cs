using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppointmentBook.Models;
using System.Data;
using System.Data.SqlClient;

namespace AppointmentBook.Controllers
{
    
    public class AppointmentController : Controller
    {

        SqlConnection conn = new SqlConnection(@"Data Source=PAMELA;Initial Catalog=AppointmentBook;Integrated Security=True;Pooling=False");


        // GET: Appointment
        public ActionResult Index()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("select * from Services", conn);
            DataSet Ds = new DataSet();
            adpt.Fill(Ds);
            // Here we are using List and the type of List is services. Services is my class here
            List<Services> LS = new List<Services>();
            foreach(DataRow Dr in Ds.Tables[0].Rows)
            {
                Services Sc = new Services();
                Sc.ServiceId  = Convert.ToInt32(Dr["ServiceId"].ToString());
                Sc.ServiceName = Dr["ServiceName"].ToString();
                Sc.ServiceDescription = Dr["ServiceDescription"].ToString();
                LS.Add(Sc);


            }
 


            return View(LS);
        }

        public ActionResult getdata()
        {

            return View("getdata1");
        }

        // This method is for specifically view data that is inserted by the user
        public ActionResult AddServices()
        {
            return View();
        }

        // This method is speciafically use for save the data in the database.
        [HttpPost]
        public ActionResult AddServices(Services services)
        {
            string str = "insert into services(ServiceName,ServiceDescription)values('" + services.ServiceName + "','" + services.ServiceDescription + "')";
            SqlCommand cmd = new SqlCommand(str,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }

        public ActionResult EditServices(int Id)
        {
            SqlDataAdapter adpt = new SqlDataAdapter("select * from Services where ServiceId=" +Id+  "", conn);
            DataSet Ds = new DataSet();
            adpt.Fill(Ds);
            // Here we are using List and the type of List is services. Services is my class here
            List<Services> LS = new List<Services>();
            foreach (DataRow Dr in Ds.Tables[0].Rows)
            {
                Services Sc = new Services();
                Sc.ServiceId = Convert.ToInt32(Dr["ServiceId"].ToString());
                Sc.ServiceName = Dr["ServiceName"].ToString();
                Sc.ServiceDescription = Dr["ServiceDescription"].ToString();
                LS.Add(Sc);


            }
            return View(LS);

        }
        [HttpPost]
        public ActionResult EditServices(FormCollection FS)
        {
            int Id = Convert.ToInt32(FS["ServiceId"]);
            string ServiceName = FS["ServiceName"];
            string ServiceDescription = FS["ServiceDescription"];
            string qry="update Services set SerViceName='" + ServiceName+"',ServiceDescription='"+ServiceDescription+"' where ServiceID="+Id+"";
            
            SqlCommand cmd = new SqlCommand(qry,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("Index");
        }


        public ActionResult DeleteServices(int Id )
        {
                   string qry="delete from Services where ServiceId = "+ Id+"";

                   SqlCommand cmd = new SqlCommand(qry, conn);
                   conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


            return RedirectToAction("index");
        }
        //public ActionResult AddAppointment(Appointment appointment)
        //{
        //    string str = "insert into appointment(FirstName,LastName,PhoneNumber,ServiceId,AppointmentDate,Cost,EmailId )values('" +FirtName+ "','"
        //        +LastName+ "', '"+PhoneNumber+ "','"  +ServiceId+ "','"

        //    return View();
        //}
    }
}