﻿using System;
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
            
            //temp();
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

            Contact mikkelsen = new Contact()
            {
                IdContact = 2,
                Name = "Susanne mikkelsen",
                Position = "Avdelingsjef",
                Phone = "75224367",
                Mail = "mikkelsen@hotmail.com"

            };

            Contact syvertsen = new Contact()
            {
                IdContact = 3,
                Name = "Andre Syvertsen",
                Position = "Avdelingsjef",
                Phone = "23224367",
                Mail = "syvertsen@hotmail.com"

            };

            Contact nilsen = new Contact()
            {
                IdContact = 4,
                Name = "Nils Nilsen",
                Position = "Avdelingsjef",
                Phone = "67224367",
                Mail = "nilsen@hotmail.com"

            };

            db.Contacts.Add(andersen);
            db.Contacts.Add(mikkelsen);
            db.Contacts.Add(syvertsen);
            db.Contacts.Add(nilsen);
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

            Company spicheren = new Company()
            {
                IdCompany = "spicheren",
                Name = "Spicheren",
                Adress = "Gimlemoen 1",
                Url = "http://spicheren.no/",
                Facebook = "",
                LinkedIn = "",
                Description = "Treningssenter",
                Logo = "http://www.sia.no/~/media/Images/Spicheren/Logo/Spicheren_500.png?h=98&la=nb-NO&w=499"

            };

            Company nav = new Company()
            {
                IdCompany = "nav",
                Name = "Nav",
                Adress = "Gyldenløves gate 23, 4611 Kristiansand S",
                Url = "http://nav.no/",
                Facebook = "",
                LinkedIn = "",
                Description = "Arbeids- og velferdsforvaltning",
                Logo = "https://appres.nav.no/_public/beta.nav.no/images/logo.png?_ts=1512923c9b0"

            };

            Company stamina = new Company()
            {
                IdCompany = "stamina",
                Name = "Stamina Hot",
                Adress = "Storgaten 90, 4877 Grimstad",
                Url = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad/",
                Facebook = "",
                LinkedIn = "",
                Description = "Treningssenter",
                Logo = "https://www.staminagroup.no/UI/logo.png"

            };

            db.Companies.Add(stamina);
            db.Companies.Add(snekkern);
            db.Companies.Add(spicheren);
            db.Companies.Add(nav);
            db.SaveChanges();

        }

        //Populates the Job table
        private void PopulateJob()
        {
            DateTime now = DateTime.Now;


            Job job = new Job()
            {
                Uuid = Guid.NewGuid().ToString(),
                Title = "Database ansvarlig",
                Description = "Database ansvarlig for Snekkern",
                Webpage = "http://snekkern.no/",
                Steps_to_apply = "Send mail",
                Expiry_date = now.AddDays(20),
                Created = now,
                Published = now,
                Modified = now
            };

            Contact contact = db.Contacts.First(x => x.IdContact == 1);
            Location location = db.Locations.First(x => x.IdLocation.Equals("vestagder"));
            JobType heltid = db.JobTypes.First(x => x.IdJobType.Equals("heltid"));
            JobType deltid = db.JobTypes.First(x => x.IdJobType.Equals("deltid"));

            Company company = db.Companies.First(x => x.IdCompany.Equals("snekkern"));

            Study_group data = db.Study_group.First(x => x.IdStudy_group.Equals("datateknologi"));
            //Study_group idrett = db.Study_group.First(x => x.IdStudy_group.Equals("idrettsfag"));


            job.Contact = contact;
            job.Study_groups.Add(data);
            //job.Study_groups.Add(idrett);
            job.Location = location;
            job.JobType = heltid;
            job.Company = company;



            Job job2 = new Job()
            {
                Uuid = Guid.NewGuid().ToString(),
                Title = "PT",
                Description = "Er du vår nye mest selgende PT?!?!1",
                Webpage = "http://spicheren.no/",
                Steps_to_apply = "Send mail",
                Expiry_date = now.AddDays(20),
                Created = now,
                Published = now,
                Modified = now
            };

            Contact contact2 = db.Contacts.First(x => x.IdContact == 2);
            Company company2 = db.Companies.First(x => x.IdCompany.Equals("spicheren"));

            Study_group idrett = db.Study_group.First(x => x.IdStudy_group.Equals("idrettsfag"));


            job2.Contact = contact2;
            job2.Study_groups.Add(idrett);
            job2.Location = location;
            job2.JobType = heltid;
            job2.Company = company2;


            //htc.Student = student;
            Job job3 = new Job()
            {
                Uuid = Guid.NewGuid().ToString(),
                Title = "IT og kursanvarlig",
                Description = "IT og opplæring",
                Webpage = "http://nav.no/",
                Steps_to_apply = "Send mail",
                Expiry_date = now.AddDays(20),
                Created = now,
                Published = now,
                Modified = now
            };

            Contact contact3 = db.Contacts.First(x => x.IdContact == 3);
            Company company3 = db.Companies.First(x => x.IdCompany.Equals("nav"));
            Study_group ped = db.Study_group.First(x => x.IdStudy_group.Equals("lærer"));

            job3.Contact = contact3;
            job3.Study_groups.Add(data);
            job3.Study_groups.Add(ped);

            job3.Location = location;
            job3.JobType = deltid;
            job3.Company = company3;

            Job job4 = new Job()
            {
                Uuid = Guid.NewGuid().ToString(),
                Title = "IT PT",
                Description = "Er du vår nye høyteknologiske IT PT?!",
                Webpage = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad",
                Steps_to_apply = "Send mail",
                Expiry_date = now.AddDays(20),
                Created = now,
                Published = now,
                Modified = now
            };

            Contact contact4 = db.Contacts.First(x => x.IdContact == 4);
            Company company4 = db.Companies.First(x => x.IdCompany.Equals("stamina"));


            job4.Contact = contact4;
            job4.Study_groups.Add(data);
            job4.Study_groups.Add(idrett);

            job4.Location = location;
            job4.JobType = deltid;
            job4.Company = company4;




            db.Jobs.Add(job);
            db.Jobs.Add(job2);
            db.Jobs.Add(job3);
            db.Jobs.Add(job4);
            db.SaveChanges();
            //return RedirectToAction("About", "Home");
        }

        private void temp()
        {
            
            Contact nilsen = new Contact()
            {
                IdContact = 4,
                Name = "Nils Nilsen",
                Position = "Avdelingsjef",
                Phone = "67224367",
                Mail = "nilsen@hotmail.com"

            };

            db.Contacts.Add(nilsen);
            db.SaveChanges();

            Company stamina = new Company()
            {
                IdCompany = "stamina",
                Name = "Stamina Hot",
                Adress = "Storgaten 90, 4877 Grimstad",
                Url = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad/",
                Facebook = "",
                LinkedIn = "",
                Description = "Treningssenter",
                Logo = "https://www.staminagroup.no/UI/logo.png"

            };
            db.Companies.Add(stamina);
            db.SaveChanges();
            
            Location location = db.Locations.First(x => x.IdLocation.Equals("austagder"));
            Study_group data = db.Study_group.First(x => x.IdStudy_group.Equals("datateknologi"));
            Study_group idrett = db.Study_group.First(x => x.IdStudy_group.Equals("idrettsfag"));

            JobType deltid = db.JobTypes.First(x => x.IdJobType.Equals("deltid"));

            DateTime now = DateTime.Now;

            Job job4 = new Job()
            {
                Uuid = Guid.NewGuid().ToString(),
                Title = "IT PT",
                Description = "Er du vår nye høyteknologiske IT PT?!",
                Webpage = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad",
                Steps_to_apply = "Send mail",
                Expiry_date = now.AddDays(20),
                Created = now,
                Published = now,
                Modified = now
            };

            Contact contact4 = db.Contacts.First(x => x.IdContact == 4);
            Company company4 = db.Companies.First(x => x.IdCompany.Equals("stamina"));


            job4.Contact = contact4;
            job4.Study_groups.Add(data);
            job4.Study_groups.Add(idrett);

            job4.Location = location;
            job4.JobType = deltid;
            job4.Company = company4;

            db.Jobs.Add(job4);
            db.SaveChanges();
        }
    }
}