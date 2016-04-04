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
            companies = new HashSet<Company>();
            contacts = new HashSet<Contact>();
            locations = new HashSet<Location>();
            studyGroups = new HashSet<StudyGroup>();
            jobTypes = new HashSet<JobType>();
        }

        [Key]
        public string uuid { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public string webpage { get; set; }
        public string linkedInProfile { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime expiryDate { get; set; }

        public string stepsToApply { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime published { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime modified { get; set; }

        public virtual ICollection<Company> companies { get; set; }

        public virtual ICollection<Contact> contacts { get; set; }

        public virtual ICollection<Location> locations { get; set; }

        public virtual ICollection<JobType> jobTypes { get; set; }

        public virtual ICollection<StudyGroup> studyGroups { get; set; }
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
        title = "Database ansvarlig",
        description = "Database ansvarlig for Snekkern",
        webpage = "http://snekkern.no/",
        stepsToApply = "Send email",
        expiryDate = DateTime.Now.AddDays(20),
        created = DateTime.Now,
        published = DateTime.Now,
        modified = DateTime.Now
    };

    Contact contact = db.contacts.First(x => x.id == 1);
    Location location = db.locations.First(x => x.id.Equals("Vest-Agder"));
    JobType jobType = db.jobTypes.First(x => x.id.Equals("Heltid"));
    Company company = db.companies.First(x => x.id.Equals("uia"));

    StudyGroup data = db.StudyGroup.First(x => x.id.Equals("datateknologi"));
    //StudyGroup idrett = db.StudyGroup.First(x => x.id.Equals("idrettsfag"));


    job.Contact = contact;
    job.studyGroups.Add(data);
    //job.studyGroups.Add(idrett);
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
                s.uuid,
                s.description,
                s.webpage,
                s.expiryDate,
                s.stepsToApply,
                s.created,
                s.published,
                s.modified,
                s.id,
                s.id,
                s.id,
                studyGroups = s.studyGroups.Select(st => new { st.id })
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
                job.uuid,
                job.description,
                job.webpage,
                job.expiryDate,
                job.stepsToApply,
                job.created,
                job.published,
                job.modified,
                job.id,
                job.id,
                job.id,
                studyGroups = job.studyGroups.Select(st => new { st.id })
            });
        }

    */
