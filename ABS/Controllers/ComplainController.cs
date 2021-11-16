using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ABS.Models;
using System.Data;
using System.Data.SqlClient;
namespace ABS.Controllers
{
    public class ComplainController : ApiController
    {

        public IHttpActionResult Get()
        {
            List<JoinClass> jc = new List<JoinClass>();
            string constring = "Data Source=41.32.225.24;Initial Catalog=ABSWeb;Persist Security Info=True;User ID=Plugin01;Password=abs2020;MultipleActiveResultSets=True;Application Name=EntityFramework";
            SqlConnection con = new SqlConnection(constring);
            string q = "SELECT        csContactUs.Ref, csContactUs.TransDate AS ComplaintDate, csContactUsTypes.fNameA AS ComplaintType, csContactUs.Message AS Complaint, csContactUs.LastAction AS Reply, WebClientUsers.DisplayName,  csContactUs.TransDate AS Ad_Date FROM            csContactUs INNER JOIN csContactUsTypes ON csContactUs.ContactUsTypeID = csContactUsTypes.ContactUsTypeID INNER JOIN WebClientUsers ON csContactUs.UserID = WebClientUsers.UserID";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                JoinClass jcobj = new JoinClass();
                jcobj.Ref = dr["Ref"].ToString();
                jcobj.ComplainDate = (DateTime)dr["ComplaintDate"];
                jcobj.ComplainType = dr["ComplaintType"].ToString();
                jcobj.Complain = dr["Complaint"].ToString();
                jcobj.Reply = dr["Reply"].ToString();
                jcobj.Ad_User = dr["DisplayName"].ToString();
                jcobj.Ad_Date = (DateTime)dr["ComplaintDate"];              
                jc.Add(jcobj);
            }
            return Ok(jc);
        }
      
        public csContactU Get(string id)
        {
            using (ComplainDBContext entities = new ComplainDBContext())
            {
                return entities.csContactUs.FirstOrDefault(c => c.Ref == id);
            }
        }
        [HttpGet]
        public string csContactU  (DateTime startTime, DateTime endTime)
        {
            using (ComplainDBContext entities = new ComplainDBContext())
        {
            return "StartTime=" + startTime.ToString("yyyy/MM/dd") + " EndTime=" + endTime.ToString("yyyy/MM/dd");
                
            }

    }
    }
}
