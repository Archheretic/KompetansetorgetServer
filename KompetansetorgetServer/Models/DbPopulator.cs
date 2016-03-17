using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KompetansetorgetServer.Models
{
    public class DbPopulator
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // Populates all the tables in the correct order.
        public void PopulateAll()
        {
            PopulateLocation();
            PopulateStudy_group();
            PopulateDevice();
            PopulateStudent();
            PopulateJobType();
            PopulateContact();
            PopulateCompany();
            PopulateJob();
        }

        //Populates the Location table
        private void PopulateLocation()
        {
            Location va = new Location()
            {
                IdLocation = "vestagder",
                Name = "Vest-Agder"
            };

            Location aa = new Location()
            {
                IdLocation = "austagder",
                Name = "Aust-Agder"
            };
            db.Locations.Add(aa);
            db.Locations.Add(va);
            db.SaveChanges();

        }

        //Populates the Study_group table
        private void PopulateStudy_group()
        {
            Study_group idrett = new Study_group()
            {
                IdStudy_group = "idrettsfag",
                Name = "Idrettsfag"
            };

            Study_group data = new Study_group()
            {
                IdStudy_group = "datateknologi",
                Name = "Datateknologi"
            };

            Study_group ped = new Study_group()
            {
                IdStudy_group = "lærer",
                Name = "Lærerutdanning og pedagogikk"
            };

            db.Study_group.Add(idrett);
            db.Study_group.Add(data);
            db.Study_group.Add(ped);

            db.SaveChanges();

        }

        //Populates the Device table
        private void PopulateDevice()
        {
            Device htc = new Device()
            {
               IdDevice = "HT451WM08832",
               DeviceType = "android",
               Token = "fMXJqM0z0FQ:APA91bHHp_TLeg3Z3ES3qc1Kdt25KUFdX5G5gZLgVqrdjSA3uQZkmuR9V-b78X48T9ZGCGJkdyqvBeFrpoYyCbgnw5_7dslTjbR4E9SEm74uh-e4pOqeJjcrA5smhcQUuP_YQoNwVNvY"

            };
            db.Devices.Add(htc);
            db.SaveChanges();

        }

        // Populates the Student table
        private void PopulateStudent()
        {
            Student student = new Student()
            {
                Username = "viktos08",
                Name = "Viktor Setervang",
                Email = "viktos08@uia.no"

            };
            Study_group data = db.Study_group.First(x => x.IdStudy_group.Equals("datateknologi"));
            Study_group idrett = db.Study_group.First(x => x.IdStudy_group.Equals("idrettsfag"));
            Device htc = db.Devices.First(x => x.IdDevice.Equals("HT451WM08832"));
            student.Devices.Add(htc);
            student.Study_groups.Add(data);
            student.Study_groups.Add(idrett);
            db.Students.Add(student);
            //htc.Student = student;
            db.SaveChanges();
        }

        //Populates the JobType table
        private void PopulateJobType()
        {
            JobType heltid = new JobType()
            {
                IdJobType = "heltid",
                Name = "Heltid"
            };

            JobType deltid = new JobType()
            {
                IdJobType = "deltid",
                Name = "Deltid"
            };

            db.JobTypes.Add(heltid);
            db.JobTypes.Add(deltid);
            db.SaveChanges();

        }

        //Populates the Contact table
        private void PopulateContact()
        {
            Contact andersen = new Contact()
            {
                IdContact = 1,
                Name = "Snekker Andersen",
                Position = "Avdelingsjef",
                Phone = "45124367",
                Mail = "andersen@hotmail.com"

            };

            db.Contacts.Add(andersen);
            db.SaveChanges();

        }


        //Populates the Company table
        private void PopulateCompany()
        {
            Company snekkern = new Company()
            {
                IdCompany = "snekkern",
                Name = "Snekkern",
                Adress = "Industrigata 3",
                Url = "http://snekkern.no/",
                Facebook = "",
                LinkedIn = "",
                Description = "Snekkrer ting",
                Logo = "http://w267110-www.php5.dittdomene.no/wp-content/uploads/2014/11/Snekkern_top_tag_straight.png"

            };

            db.Companies.Add(snekkern);
            db.SaveChanges();

        }

        //Populates the Job table
        private void PopulateJob()
        {
            Job job = new Job()
            {
                Uuid = Guid.NewGuid().ToString(),
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
            Location location = db.Locations.First(x => x.IdLocation.Equals("vestagder"));
            JobType jobType = db.JobTypes.First(x => x.IdJobType.Equals("heltid"));
            Company company = db.Companies.First(x => x.IdCompany.Equals("snekkern"));

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
            //return RedirectToAction("About", "Home");
        }
    }
}