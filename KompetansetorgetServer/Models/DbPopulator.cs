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
            PopulateStudent2();
            /*
            PopulateLocation();
            PopulateStudy_group();
            PopulateDevice();
            PopulateStudent();
            PopulateJobType();
            PopulateContact();
            PopulateCompany();
            PopulateJob();
            */
            //temp();
        }
    
        //Populates the Location table
        private void PopulateLocation()
        {
            Location va = new Location()
            {
                id = "vestagder",
                name = "Vest-Agder"
            };

            Location aa = new Location()
            {
                id = "austagder",
                name = "Aust-Agder"
            };
            db.locations.Add(aa);
            db.locations.Add(va);
            db.SaveChanges();

        }

        //Populates the StudyGroup table
        private void PopulateStudy_group()
        {
            StudyGroup idrett = new StudyGroup()
            {
                id = "idrettsfag",
                name = "Idrettsfag"
            };

            StudyGroup data = new StudyGroup()
            {
                id = "datateknologi",
                name = "Datateknologi"
            };

            StudyGroup ped = new StudyGroup()
            {
                id = "lærerutdanning",
                name = "Lærerutdanning og pedagogikk"
            };

            db.studyGroup.Add(idrett);
            db.studyGroup.Add(data);
            db.studyGroup.Add(ped);

            db.SaveChanges();

        }

        //Populates the Device table
        private void PopulateDevice()
        {
            Device htc = new Device()
            {
               id = "HT451WM08832",
               deviceType = "android",
               token = "fMXJqM0z0FQ:APA91bHHp_TLeg3Z3ES3qc1Kdt25KUFdX5G5gZLgVqrdjSA3uQZkmuR9V-b78X48T9ZGCGJkdyqvBeFrpoYyCbgnw5_7dslTjbR4E9SEm74uh-e4pOqeJjcrA5smhcQUuP_YQoNwVNvY"

            };
            db.devices.Add(htc);
            db.SaveChanges();

        }

        // Populates the Student table
        private void PopulateStudent()
        {
            Student student = new Student()
            {
                username = "viktos08",
                name = "Viktor Setervang",
                email = "viktos08@uia.no"

            };   
            StudyGroup data = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            StudyGroup idrett = db.studyGroup.First(x => x.id.Equals("idrettsfag"));
            Device htc = db.devices.First(x => x.id.Equals("HT451WM08832"));
            student.Devices.Add(htc);
            student.studyGroups.Add(data);
            student.studyGroups.Add(idrett);
            db.students.Add(student);
            //htc.Student = student;
            db.SaveChanges();
        }

        private void PopulateStudent2()
        {
            Student student = new Student()
            {
                username = "test14",
                name = "Test tester",
                email = "test14@uia.no"

            };
            StudyGroup idrett = db.studyGroup.First(x => x.id.Equals("idrettsfag"));
           // Device htc = db.devices.First(x => x.id.Equals("HT451WM08832"));
           // student.Devices.Add(htc);
            student.studyGroups.Add(idrett);
            db.students.Add(student);
            //htc.Student = student;
            db.SaveChanges();
        }

        //Populates the JobType table
        private void PopulateJobType()
        {
            JobType heltid = new JobType()
            {
                id = "heltid",
                name = "Heltid"
            };

            JobType deltid = new JobType()
            {
                id = "deltid",
                name = "Deltid"
            };

            db.jobTypes.Add(heltid);
            db.jobTypes.Add(deltid);
            db.SaveChanges();

        }

        //Populates the Contact table
        private void PopulateContact()
        {
            Contact andersen = new Contact()
            {
                id = 1,
                name = "Snekker Andersen",
                position = "Avdelingsjef",
                phone = "45124367",
                email = "andersen@hotmail.com"

            };

            Contact mikkelsen = new Contact()
            {
                id = 2,
                name = "Susanne mikkelsen",
                position = "Avdelingsjef",
                phone = "75224367",
                email = "mikkelsen@hotmail.com"

            };

            Contact syvertsen = new Contact()
            {
                id = 3,
                name = "Andre Syvertsen",
                position = "Avdelingsjef",
                phone = "23224367",
                email = "syvertsen@hotmail.com"

            };

            Contact nilsen = new Contact()
            {
                id = 4,
                name = "Nils Nilsen",
                position = "Avdelingsjef",
                phone = "67224367",
                email = "nilsen@hotmail.com"

            };

            db.contacts.Add(andersen);
            db.contacts.Add(mikkelsen);
            db.contacts.Add(syvertsen);
            db.contacts.Add(nilsen);
            db.SaveChanges();

        }


        //Populates the Company table
        private void PopulateCompany()
        {
            Company snekkern = new Company()
            {
                id = "snekkern",
                name = "Snekkern",
                adress = "Industrigata 3",
                url = "http://snekkern.no/",
                facebook = "",
                linkedIn = "",
                description = "Snekkrer ting",
                logo = "http://w267110-www.php5.dittdomene.no/wp-content/uploads/2014/11/Snekkern_top_tag_straight.png"

            };

            Company spicheren = new Company()
            {
                id = "spicheren",
                name = "Spicheren",
                adress = "Gimlemoen 1",
                url = "http://spicheren.no/",
                facebook = "",
                linkedIn = "",
                description = "Treningssenter",
                logo = "http://www.sia.no/~/media/Images/Spicheren/logo/Spicheren_500.png?h=98&la=nb-NO&w=499"

            };

            Company nav = new Company()
            {
                id = "nav",
                name = "Nav",
                adress = "Gyldenløves gate 23, 4611 Kristiansand S",
                url = "http://nav.no/",
                facebook = "",
                linkedIn = "",
                description = "Arbeids- og velferdsforvaltning",
                logo = "https://appres.nav.no/_public/beta.nav.no/images/logo.png?_ts=1512923c9b0"

            };

            Company stamina = new Company()
            {
                id = "stamina",
                name = "Stamina Hot",
                adress = "Storgaten 90, 4877 Grimstad",
                url = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad/",
                facebook = "",
                linkedIn = "",
                description = "Treningssenter",
                logo = "https://www.staminagroup.no/UI/logo.png"

            };

            db.companies.Add(stamina);
            db.companies.Add(snekkern);
            db.companies.Add(spicheren);
            db.companies.Add(nav);
            db.SaveChanges();

        }

        //Populates the Job table
        private void PopulateJob()
        {
            DateTime now = DateTime.Now;


            Job job = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Database ansvarlig",
                description = "Database ansvarlig for Snekkern",
                webpage = "http://snekkern.no/",
                stepsToApply = "Send email",
                expiryDate = now.AddDays(20),
                created = now,
                published = now,
                modified = now
            };

            Contact contact = db.contacts.First(x => x.id == 1);
            Location location = db.locations.First(x => x.id.Equals("vestagder"));
            JobType heltid = db.jobTypes.First(x => x.id.Equals("heltid"));
            JobType deltid = db.jobTypes.First(x => x.id.Equals("deltid"));

            Company company = db.companies.First(x => x.id.Equals("snekkern"));

            StudyGroup data = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            //StudyGroup idrett = db.StudyGroup.First(x => x.id.Equals("idrettsfag"));


            job.contacts.Add(contact);
            job.studyGroups.Add(data);
            //job.studyGroups.Add(idrett);
            job.locations.Add(location);
            job.jobTypes.Add(heltid);
            job.companies.Add(company);

            db.jobs.Add(job);
            db.SaveChanges();
  


            Job job2 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "PT",
                description = "Er du vår nye mest selgende PT?!?!1",
                webpage = "http://spicheren.no/",
                stepsToApply = "Send email",
                expiryDate = now.AddDays(21),
                created = now.AddDays(1),
                published = now.AddDays(1),
                modified = now.AddDays(1)
            };

            Contact contact2 = db.contacts.First(x => x.id == 2);
            Company company2 = db.companies.First(x => x.id.Equals("spicheren"));

            StudyGroup idrett = db.studyGroup.First(x => x.id.Equals("idrettsfag"));


            job2.contacts.Add(contact2);
            job2.studyGroups.Add(idrett);
            job2.locations.Add(location);
            job2.jobTypes.Add(heltid);
            job2.companies.Add(company2);

            db.jobs.Add(job2);
            db.SaveChanges();



            //htc.Student = student;
            Job job3 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "IT og kursanvarlig",
                description = "IT og opplæring",
                webpage = "http://nav.no/",
                stepsToApply = "Send email",
                expiryDate = now.AddDays(22),
                created = now.AddDays(2),
                published = now.AddDays(2),
                modified = now.AddDays(2)
            };

            Contact contact3 = db.contacts.First(x => x.id == 3);
            Company company3 = db.companies.First(x => x.id.Equals("nav"));
            StudyGroup ped = db.studyGroup.First(x => x.id.Equals("lærerutdanning"));

            job3.contacts.Add(contact3);
            job3.studyGroups.Add(data);
            job3.studyGroups.Add(ped);

            job3.locations.Add(location);
            job3.jobTypes.Add(deltid);
            job3.companies.Add(company3);

            db.jobs.Add(job3);
            db.SaveChanges();

            Job job4 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "IT PT",
                description = "Er du vår nye høyteknologiske IT PT?!",
                webpage = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad",
                stepsToApply = "Send email",
                expiryDate = now.AddDays(23),
                created = now.AddDays(3),
                published = now.AddDays(3),
                modified = now.AddDays(3)
            };

            Contact contact4 = db.contacts.First(x => x.id == 4);
            Company company4 = db.companies.First(x => x.id.Equals("stamina"));
            Location aa = db.locations.First(x => x.id.Equals("austagder"));

            job4.contacts.Add(contact4);
            job4.studyGroups.Add(data);
            job4.studyGroups.Add(idrett);

            job4.locations.Add(aa);
            job4.jobTypes.Add(deltid);
            job4.companies.Add(company4);





            db.jobs.Add(job4);
            db.SaveChanges();
            //return RedirectToAction("About", "Home");
        }

        private void temp()
        {
            
            Contact nilsen = new Contact()
            {
                id = 4,
                name = "Nils Nilsen",
                position = "Avdelingsjef",
                phone = "67224367",
                email = "nilsen@hotmail.com"

            };

            db.contacts.Add(nilsen);
            db.SaveChanges();

            Company stamina = new Company()
            {
                id = "stamina",
                name = "Stamina Hot",
                adress = "Storgaten 90, 4877 Grimstad",
                url = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad/",
                facebook = "",
                linkedIn = "",
                description = "Treningssenter",
                logo = "https://www.staminagroup.no/UI/logo.png"

            };
            db.companies.Add(stamina);
            db.SaveChanges();
            
            Location location = db.locations.First(x => x.id.Equals("austagder"));
            StudyGroup data = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            StudyGroup idrett = db.studyGroup.First(x => x.id.Equals("idrettsfag"));

            JobType deltid = db.jobTypes.First(x => x.id.Equals("deltid"));

            DateTime now = DateTime.Now;

            Job job4 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "IT PT",
                description = "Er du vår nye høyteknologiske IT PT?!",
                webpage = "https://www.staminagroup.no/finnoss/grimstad/stamina-grimstad",
                stepsToApply = "Send email",
                expiryDate = now.AddDays(24),
                created = now.AddDays(4),
                published = now.AddDays(4),
                modified = now.AddDays(4)
            };

            Contact contact4 = db.contacts.First(x => x.id == 4);
            Company company4 = db.companies.First(x => x.id.Equals("stamina"));


            job4.contacts.Add(contact4);
            job4.studyGroups.Add(data);
            job4.studyGroups.Add(idrett);

            job4.locations.Add(location);
            job4.jobTypes.Add(deltid);
            job4.companies.Add(company4);

            db.jobs.Add(job4);
            db.SaveChanges();
        }
    }
}