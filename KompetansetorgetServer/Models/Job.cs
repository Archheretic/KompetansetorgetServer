using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Razor.Text;

namespace KompetansetorgetServer.Models
{
    [Table("Job")]
    public class Job
    {
        public Job()
        {
            Study_groups = new HashSet<Study_group>();
        }

        [Key]
        public string Uuid { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Webpage { get; set; }
        public string LinkedIn_profile { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Expiry_date { get; set; }

        public string Steps_to_apply { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Published { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        public virtual ICollection<Study_group> Study_groups { get; set; }

        [Column("IdContact")]
        [ForeignKey("Contact")]
        public int IdContact { get; set; }
        public Contact Contact { get; set; }

        [Column("IdLocation")]
        [ForeignKey("Location")]
        public string IdLocation { get; set; }
        public Location Location { get; set; }

        [Column("IdJobType")]
        [ForeignKey("JobType")]
        public string IdJobType { get; set; }
        public JobType JobType { get; set; }

        [Column("IdCompany")]
        [ForeignKey("Company")]
        public string IdCompany { get; set; }
        public Company Company { get; set; }
    }
}

/*
public ActionResult TestPushToViktor()
{
    Push p = new Push();
    p.PushToAndroid();
    return RedirectToAction("About", "Home");
}

public ActionResult TestPushToAll()
{
    PushAll p = new PushAll();
    p.SendMessageToAllAndroid("Hei alle sammen");
    return RedirectToAction("About", "Home");
}


// POST: Students/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
public ActionResult InsertEnJob()
{
    Job job = new Job()
    {
        Title = "Database ansvarlig",
        Description = "Database ansvarlig for Snekkern",
        Webpage = "http://snekkern.no/",
        Steps_to_apply = "Send mail",
        Expiry_date = DateTime.Now.AddDays(20),
        Created = DateTime.Now,
        Published = DateTime.Now,
        Modified = DateTime.Now
    };

    Contact contact = db.Contacts.First(x => x.IdContact == 1);
    Location location = db.Locations.First(x => x.IdLocation.Equals("Vest-Agder"));
    JobType jobType = db.JobTypes.First(x => x.IdJobType.Equals("Heltid"));
    Company company = db.Companies.First(x => x.IdCompany.Equals("uia"));

    Study_group data = db.Study_group.First(x => x.IdStudy_group.Equals("datateknologi"));
    //Study_group idrett = db.Study_group.First(x => x.IdStudy_group.Equals("idrettsfag"));


    job.Contact = contact;
    job.Study_groups.Add(data);
    //job.Study_groups.Add(idrett);
    job.Location = location;
    job.JobType = jobType;
    job.Company = company;

    db.Jobs.Add(job);
    //htc.Student = student;
    db.SaveChanges();
    return RedirectToAction("About", "Home");
}
*/

/*
        // GET: api/Jobs
        //public IQueryable<Job> GetJobs()
        public IQueryable GetJobs()
        {
            //return db.Jobs;
            return db.Jobs.Select(s => new
            {
                s.Uuid,
                s.Description,
                s.Webpage,
                s.Expiry_date,
                s.Steps_to_apply,
                s.Created,
                s.Published,
                s.Modified,
                s.IdContact,
                s.IdJobType,
                s.IdCompany,
                Study_groups = s.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }

        // GET: api/Jobs/5
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> GetJob(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            //return Ok(job);
            return Ok (new
            {
                job.Uuid,
                job.Description,
                job.Webpage,
                job.Expiry_date,
                job.Steps_to_apply,
                job.Created,
                job.Published,
                job.Modified,
                job.IdContact,
                job.IdJobType,
                job.IdCompany,
                Study_groups = job.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }

    */
