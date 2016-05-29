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
            //PopulateStudent2();

            PopulateLocation();
            PopulateStudy_group();
            //PopulateDevice();
            //PopulateStudent();
            PopulateJobType();
            PopulateContact();
            PopulateCompany();
            PopulateJob();


            PopulateDegree();
            PopulateCourse();
            PopulateProject();
            temp();
            Extra();
            ExtraData2();
        }

        //Populates the Location table
        private void PopulateLocation()
        {
            Location va = new Location()
            {
                id = "vestagder",
                name = "Vest-Agder"
            };

            Location ut = new Location()
            {
                id = "utlandet",
                name = "Utlandet"
            };

            Location aa = new Location()
            {
                id = "austagder",
                name = "Aust-Agder"
            };

            Location aker = new Location()
            {
                id = "akershus",
                name = "Akershus"
            };


            Location busk = new Location()
            {
                id = "buskerud",
                name = "Buskerud"
            };
            Location finn = new Location()
            {
                id = "finnmark",
                name = "Finnmark"
            };

            Location hed = new Location()
            {
                id = "hedmark",
                name = "Hedmark"
            };

            Location hord = new Location()
            {
                id = "hordaland",
                name = "Hordaland"
            };
            Location møre = new Location()
            {
                id = "møreogromsdal",
                name = "Møre og Romsdal"
            };
            Location nordl = new Location()
            {
                id = "nordland",
                name = "Nordland"
            };
            Location nordt = new Location()
            {
                id = "nordtrøndelag",
                name = "Nord-Trøndelag"
            };
            Location opp = new Location()
            {
                id = "oppland",
                name = "Oppland"
            };
            Location oslo = new Location()
            {
                id = "oslo",
                name = "Oslo"
            };
            Location roga = new Location()
            {
                id = "rogaland",
                name = "Rogaland"
            };
            Location sogn = new Location()
            {
                id = "sognogfjordane",
                name = "Sogn og Fjordane"
            };
            Location sørt = new Location()
            {
                id = "sørtrøndelag",
                name = "Sør-Trøndelag"
            };
            Location tele = new Location()
            {
                id = "telemark",
                name = "Telemark"
            };
            Location troms = new Location()
            {
                id = "troms",
                name = "Troms"
            };
            Location østf = new Location()
            {
                id = "østfold",
                name = "Østfold"
            };
            Location vestf = new Location()
            {
                id = "vestfold",
                name = "Vestfold"
            };
            Location svalb = new Location()
            {
                id = "svalbard",
                name = "Svalbard"
            };
            db.locations.Add(ut);
            db.locations.Add(aa);
            db.locations.Add(va);
            db.locations.Add(aker);
            db.locations.Add(busk);
            db.locations.Add(finn);
            db.locations.Add(hed);
            db.locations.Add(hord);
            db.locations.Add(møre);
            db.locations.Add(nordl);
            db.locations.Add(nordt);
            db.locations.Add(opp);
            db.locations.Add(oslo);
            db.locations.Add(roga);
            db.locations.Add(sogn);
            db.locations.Add(sørt);
            db.locations.Add(tele);
            db.locations.Add(troms);
            db.locations.Add(vestf);
            db.locations.Add(østf);
            db.locations.Add(svalb);
            db.SaveChanges();

        }

        //Populates the StudyGroup table
        private void PopulateStudy_group()
        {
            StudyGroup idrett = new StudyGroup()
            {
                id = "idrett",
                name = "Idrettsfag"
            };

            StudyGroup uspesifisert = new StudyGroup()
            {
                id = "uspesifisert",
                name = "Uspesifisert"
            };
            StudyGroup data = new StudyGroup()
            {
                id = "datateknologi",
                name = "Datateknologi"
            };

            StudyGroup ped = new StudyGroup()
            {
                id = "ped",
                name = "Lærerutdanning og pedagogikk"
            };

            StudyGroup helse = new StudyGroup()
            {
                id = "helse",
                name = "Helse- og sosialfag"
            };

            StudyGroup ingeniør = new StudyGroup()
            {
                id = "ingeniør",
                name = "Ingeniør og teknologiske fag"
            };

            StudyGroup samfunnsfag = new StudyGroup()
            {
                id = "samfunnsfag",
                name = "Samfunnsfag"
            };

            StudyGroup realfag = new StudyGroup()
            {
                id = "realfag",
                name = "Realfag"
            };

            StudyGroup språk = new StudyGroup()
            {
                id = "språk",
                name = "Språk og litteratur"
            };

            StudyGroup økonomi = new StudyGroup()
            {
                id = "økonomi",
                name = "Økonomi og juss"
            };

            StudyGroup administrasjon = new StudyGroup()
            {
                id = "administrasjon",
                name = "Administrasjon og ledelse"
            };
            StudyGroup musikk = new StudyGroup()
            {
                id = "musikk",
                name = "Musikk"
            };
            StudyGroup historie = new StudyGroup()
            {
                id = "historie",
                name = "Historie, filosofi og religion"
            };
            StudyGroup medie = new StudyGroup()
            {
                id = "medie",
                name = "Medie og kommunikasjonsfag"
            };

            StudyGroup kunstfag = new StudyGroup()
            {
                id = "kunstfag",
                name = "Kunstfag"
            };
            db.studyGroup.Add(idrett);
            db.studyGroup.Add(data);
            db.studyGroup.Add(ped);
            db.studyGroup.Add(helse);
            db.studyGroup.Add(ingeniør);
            db.studyGroup.Add(samfunnsfag);
            db.studyGroup.Add(realfag);
            db.studyGroup.Add(uspesifisert);
            db.studyGroup.Add(språk);
            db.studyGroup.Add(økonomi);
            db.studyGroup.Add(administrasjon);
            db.studyGroup.Add(medie);
            db.studyGroup.Add(historie);
            db.studyGroup.Add(musikk);
            db.studyGroup.Add(kunstfag);
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
                name = "Heltid",
                type = "job"
            };

            JobType praksis = new JobType()
            {
                id = "praksis",
                name = "Praksis/Internship",
                type = "job"
            };


            JobType deltid = new JobType()
            {
                id = "deltid",
                name = "Deltid",
                type = "job"
            };

            JobType sommerjobb = new JobType()
            {
                id = "sommerjobb",
                name = "Sommerjobb",
                type = "job"
            };

            JobType stipend = new JobType()
            {
                id = "stipend",
                name = "Stipend",
                type = "job"
            };

            JobType trainee = new JobType()
            {
                id = "trainee",
                name = "Trainee",
                type = "job"
            };

            JobType fagl = new JobType()
            {
                id = "faglærer",
                name = "Fra faglærer",
                type = "project",
            };

            JobType stud = new JobType()
            {
                id = "student",
                name = "Fra student",
                type = "project",
            };
            

            JobType virksomhet = new JobType()
            {
                id = "virksomhet",
                name = "Fra virksomhet",
                type = "project",
            };


            db.jobTypes.Add(heltid);
            db.jobTypes.Add(deltid);
            db.jobTypes.Add(fagl);
            db.jobTypes.Add(virksomhet);
            db.jobTypes.Add(praksis);
            db.jobTypes.Add(trainee);
            db.jobTypes.Add(stipend);
            db.jobTypes.Add(sommerjobb);
            db.jobTypes.Add(stud);
            db.SaveChanges();

        }

        //Populates the Contact table
        private void PopulateContact()
        {
            Contact sarina = new Contact()
            {
                id = 1,
                name = "Sarina",
                position = "",
                phone = "0031 20 30 80 749",
                email = "sarina@travelbird.nl"

            };

            Contact andreas = new Contact()
            {
                id = 2,
                name = "Andreas Köck",
                position = "",
                phone = "",
                email = "a.koeck@testbirds.de"

            };

            Contact mads = new Contact()
            {
                id = 3,
                name = "Mads Bukholt",
                position = "",
                phone = "",
                email = "mads.bukholt@cuponation.com"

            };

            Contact beconnected = new Contact()
            {
                id = 4,
                name = "",
                position = "",
                phone = "",
                email = ""

            };

            Contact emil = new Contact()
            {
                id = 5,
                name = "Emil Sebastian Pete",
                position = "",
                phone = "922 93 831",
                email = "emil@mentornorge.no"
            };

            Contact anastasia = new Contact()
            {
                id = 6,
                name = "Mrs Anastasia Miliou",
                position = "Scientific Director",
                phone = "30 210 8253024",
                email = "admissions@archipelago.gr"
            };

            Contact thomas = new Contact()
            {
                id = 7,
                name = "Thomas Bang Torgersen",
                position = "",
                phone = "37 25 24 29",
                email = "thomas.bang.torgersen@grimstad.kommune.no"
            };

            Contact alexander = new Contact()
            {
                id = 8,
                name = "Alexander Øren",
                position = "",
                phone = "",
                email = "ALEXANDER@IKSTART.NO"
            };

            Contact svein = new Contact()
            {
                id = 9,
                name = "Svein Petter Undheim",
                position = "",
                phone = "",
                email = "spu@accurateequity.com"
            };

            Contact yvonne = new Contact()
            {
                id = 10,
                name = "Yvonne Larsson",
                position = "",
                phone = "",
                email = "jobs@rabble.se"
            };


            db.contacts.Add(sarina);
            db.contacts.Add(andreas);
            db.contacts.Add(mads);
            db.contacts.Add(beconnected);
            db.contacts.Add(emil);
            db.contacts.Add(anastasia);
            db.contacts.Add(thomas);
            db.contacts.Add(alexander);
            db.contacts.Add(svein);
            db.contacts.Add(yvonne);
            db.SaveChanges();

        }


        //Populates the Company table
        private void PopulateCompany()
        {
            Company privat = new Company()
            {
                id = "privat",
                name = "Privatperson",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo =
                    "http://kompetansetorget.uia.no/extension/kompetansetorget/design/kompetansetorget/images/logo-virksomhet.jpg"
            };

            Company husbanken = new Company()
            {
                id = "husbanken",
                name = "Husbanken",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://kompetansetorget.uia.no/extension/kompetansetorget/design/kompetansetorget/images/logo-virksomhet.jpg"
            };

            Company uia = new Company()
            {
                id = "uia",
                name = "Universitetet i Agder",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter-internt/universitetet-i-agder/18076-2-nor-NO/universitetet-i-agder_width-4.jpg"

            };
             

            Company travelbird = new Company()
            {
                id = "travelbird",
                name = "TravelBird",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/travelbird/151481-1-nor-NO/travelbird_width-4.jpg"

            };

            Company testbirds = new Company()
            {
                id = "testbirds",
                name = "Testbirds",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/testbirds/29460-2-nor-NO/testbirds_width-4.jpg"

            };

            Company testbirds2 = new Company()
            {
                id = "testbirds2",
                name = "Testbirds",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/testbirds/29460-2-nor-NO/testbirds_width-4.jpg"

            };

            Company cuponation = new Company()
            {
                id = "cuponation",
                name = "Cuponation",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/cuponation-gmbh/157932-2-nor-NO/cuponation-gmbh_width-4.png"

            };

            Company beconnected = new Company()
            {
                id = "beconnected",
                name = "BeConnected",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/beconnected/156649-1-nor-NO/beconnected_width-4.png"

            };

            Company mentornorge = new Company()
            {
                id = "mentornorge",
                name = "MentorNorge AS",
                adress = "",
                url = "www.mentornorge.no",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/mentornorge-as/13005-1-nor-NO/mentornorge-as_width-4.png"
            };

            Company archipelagos = new Company()
            {
                id = "archipelagos",
                name = "Archipelagos Institute",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/archipelagos-institute/83424-1-nor-NO/archipelagos-institute_width-4.png"
            };

            Company grimstadkommune = new Company()
            {
                id = "grimstadkommune",
                name = "Grimstad Kommune, Berge gård senter",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = ""
            };

            Company ikstart = new Company()
            {
                id = "ikstart",
                name = "IKStart",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/ik-start/47382-1-nor-NO/ik-start_width-4.gif"
            };

            Company accurateequity = new Company()
            {
                id = "accurateequity",
                name = "Accurate Equity - an Equatex Company",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/accurate-equity-an-equatex-company/35741-1-nor-NO/accurate-equity-an-equatex-company_width-4.jpg"
            };

            Company rabble = new Company()
            {
                id = "rabble",
                name = "Rabble",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "https://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/rabble/33218-2-nor-NO/rabble_width-4.png"
            };

            db.companies.Add(privat);
            db.companies.Add(husbanken);
            db.companies.Add(uia);
            db.companies.Add(archipelagos);
            db.companies.Add(beconnected);
            db.companies.Add(travelbird);
            db.companies.Add(testbirds);
            db.companies.Add(testbirds2);
            db.companies.Add(cuponation);
            db.companies.Add(mentornorge);
            db.companies.Add(grimstadkommune);
            db.companies.Add(ikstart);
            db.companies.Add(accurateequity);
            db.companies.Add(rabble);
            db.SaveChanges();

        }

        //Populates the Job table
        private void PopulateJob()
        {
            DateTime now = DateTime.Now;

            Job job = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Internship Allround Norway",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/internship-allround-norway",
                linkedInProfile = "",
                stepsToApply = "",
                expiryDate = new DateTime(2016, 08, 31),
                created = new DateTime(2016, 04, 11),
                published = new DateTime(2016, 04, 11),
                modified = new DateTime(2016, 04, 11)
            };

            Company company = db.companies.First(x => x.id.Equals("travelbird"));
            Contact contact = db.contacts.First(x => x.id == 1);

            JobType praksis = db.jobTypes.First(x => x.id.Equals("praksis"));
            JobType heltid = db.jobTypes.First(x => x.id.Equals("heltid"));
            JobType deltid = db.jobTypes.First(x => x.id.Equals("deltid"));

            StudyGroup data = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            StudyGroup idrett = db.studyGroup.First(x => x.id.Equals("idrett"));
            StudyGroup helse = db.studyGroup.First(x => x.id.Equals("helse"));
            StudyGroup historie = db.studyGroup.First(x => x.id.Equals("historie"));
            StudyGroup administrasjon = db.studyGroup.First(x => x.id.Equals("administrasjon"));
            StudyGroup ingeniør = db.studyGroup.First(x => x.id.Equals("ingeniør"));
            StudyGroup kunstfag = db.studyGroup.First(x => x.id.Equals("kunstfag"));
            StudyGroup ped = db.studyGroup.First(x => x.id.Equals("ped"));
            StudyGroup medie = db.studyGroup.First(x => x.id.Equals("medie"));
            StudyGroup musikk = db.studyGroup.First(x => x.id.Equals("musikk"));
            StudyGroup realfag = db.studyGroup.First(x => x.id.Equals("realfag"));
            StudyGroup samfunnsfag = db.studyGroup.First(x => x.id.Equals("samfunnsfag"));
            StudyGroup økonomi = db.studyGroup.First(x => x.id.Equals("økonomi"));
            StudyGroup språk = db.studyGroup.First(x => x.id.Equals("språk"));
            StudyGroup uspesifisert = db.studyGroup.First(x => x.id.Equals("uspesifisert"));

            Location va = db.locations.First(x => x.id.Equals("vestagder"));
            Location ut = db.locations.First(x => x.id.Equals("utlandet"));
            Location aker = db.locations.First(x => x.id.Equals("akershus"));
            Location aa = db.locations.First(x => x.id.Equals("austagder"));
            Location busk = db.locations.First(x => x.id.Equals("buskerud"));
            Location finn = db.locations.First(x => x.id.Equals("finnmark"));
            Location hed = db.locations.First(x => x.id.Equals("hedmark"));
            Location hord = db.locations.First(x => x.id.Equals("hordaland"));
            Location møre = db.locations.First(x => x.id.Equals("møreogromsdal"));
            Location nordl = db.locations.First(x => x.id.Equals("nordland"));
            Location nordt = db.locations.First(x => x.id.Equals("nordtrøndelag"));
            Location opp = db.locations.First(x => x.id.Equals("oppland"));
            Location oslo = db.locations.First(x => x.id.Equals("oslo"));
            Location roga = db.locations.First(x => x.id.Equals("rogaland"));
            Location sogn = db.locations.First(x => x.id.Equals("sognogfjordane"));
            Location sørt = db.locations.First(x => x.id.Equals("sørtrøndelag"));
            Location tele = db.locations.First(x => x.id.Equals("telemark"));
            Location troms = db.locations.First(x => x.id.Equals("troms"));
            Location vestf = db.locations.First(x => x.id.Equals("vestfold"));
            Location østf = db.locations.First(x => x.id.Equals("østfold"));
            Location svalb = db.locations.First(x => x.id.Equals("svalbard"));

            job.contacts.Add(contact);
            job.studyGroups.Add(uspesifisert);

            job.locations.Add(ut);
            job.jobTypes.Add(praksis);
            job.companies.Add(company);

            db.jobs.Add(job);
            db.SaveChanges();



            Job job2 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Test Users for Apps & Websites wanted!",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/test-users-for-apps-websites-wanted",
                linkedInProfile = "",
                stepsToApply = "Send email",
                expiryDate = new DateTime(2017, 01, 01, 01, 01, 01),
                created = new DateTime(2016, 04, 01, 01, 01, 01),
                published = new DateTime(2016, 04, 01, 01, 01, 01),
                modified = new DateTime(2016, 04, 01, 01, 01, 01)
            };

            Contact contact2 = db.contacts.First(x => x.id == 2);
            Company company2 = db.companies.First(x => x.id.Equals("testbirds"));

            job2.contacts.Add(contact2);

            job2.studyGroups.Add(idrett);
            job2.studyGroups.Add(data);
            job2.studyGroups.Add(medie);
            job2.studyGroups.Add(realfag);
            job2.studyGroups.Add(økonomi);
            job2.studyGroups.Add(språk);
            job2.studyGroups.Add(musikk);
            job2.studyGroups.Add(helse);
            job2.studyGroups.Add(historie);
            job2.studyGroups.Add(administrasjon);
            job2.studyGroups.Add(ingeniør);
            job2.studyGroups.Add(kunstfag);
            job2.studyGroups.Add(samfunnsfag);
            job2.studyGroups.Add(ped);
            job2.studyGroups.Add(uspesifisert);

            job2.locations.Add(va);
            job2.locations.Add(aker);
            job2.locations.Add(busk);
            job2.locations.Add(finn);
            job2.locations.Add(hed);
            job2.locations.Add(hord);
            job2.locations.Add(møre);
            job2.locations.Add(nordl);
            job2.locations.Add(opp);
            job2.locations.Add(oslo);
            job2.locations.Add(roga);
            job2.locations.Add(sogn);
            job2.locations.Add(sørt);
            job2.locations.Add(tele);
            job2.locations.Add(troms);
            job2.locations.Add(nordt);
            job2.locations.Add(aa);
            job2.locations.Add(vestf);
            job2.locations.Add(østf);
            job2.locations.Add(svalb);
            job2.locations.Add(ut);


            job2.jobTypes.Add(deltid);

            job2.companies.Add(company2);

            db.jobs.Add(job2);
            db.SaveChanges();



            //htc.Student = student;
            Job job3 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Online Marketing internship",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/online-marketing-internship",
                linkedInProfile = "",
                stepsToApply = "Send email",
                expiryDate = new DateTime(2016, 12, 16),
                created = new DateTime(2016, 03, 14),
                published = new DateTime(2016, 03, 14),
                modified = new DateTime(2016, 03, 14)
            };

            Contact contact3 = db.contacts.First(x => x.id == 3);
            Company company3 = db.companies.First(x => x.id.Equals("cuponation"));

            job3.contacts.Add(contact3);
            job3.studyGroups.Add(medie);
            job3.jobTypes.Add(praksis);
            job3.locations.Add(ut);
            job3.companies.Add(company3);

            db.jobs.Add(job3);
            db.SaveChanges();

            Job job4 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Do you love languages?",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/do-you-love-languages",
                linkedInProfile = "",
                stepsToApply = "Send email",
                expiryDate = new DateTime(2016, 09, 15),
                created = new DateTime(2016, 03, 11),
                published = new DateTime(2016, 03, 11),
                modified = new DateTime(2016, 03, 11)
            };

            Contact contact4 = db.contacts.First(x => x.id == 4);
            Company company4 = db.companies.First(x => x.id.Equals("beconnected"));

            job4.contacts.Add(contact4);
            job4.studyGroups.Add(ped);
            job4.studyGroups.Add(språk);

            job4.locations.Add(ut);
            job4.jobTypes.Add(deltid);
            job4.companies.Add(company4);





            db.jobs.Add(job4);
            db.SaveChanges();
            //return RedirectToAction("About", "Home");

            Job job5 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Testing av apper og nettsider",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/testing-av-apper-og-nettsider",
                linkedInProfile = "",
                stepsToApply = "Send email",
                expiryDate = new DateTime(2017, 01, 01),
                created = new DateTime(2016, 04, 01),
                published = new DateTime(2016, 04, 01),
                modified = new DateTime(2016, 04, 01)
            };

            Contact contact5 = db.contacts.First(x => x.id == 2);
            Company company5 = db.companies.First(x => x.id.Equals("testbirds2"));

            job5.contacts.Add(contact5);

            job5.studyGroups.Add(idrett);
            job5.studyGroups.Add(data);
            job5.studyGroups.Add(medie);
            job5.studyGroups.Add(realfag);
            job5.studyGroups.Add(økonomi);
            job5.studyGroups.Add(språk);
            job5.studyGroups.Add(musikk);
            job5.studyGroups.Add(helse);
            job5.studyGroups.Add(historie);
            job5.studyGroups.Add(administrasjon);
            job5.studyGroups.Add(ingeniør);
            job5.studyGroups.Add(kunstfag);
            job5.studyGroups.Add(samfunnsfag);
            job5.studyGroups.Add(ped);
            job5.studyGroups.Add(uspesifisert);

            job5.locations.Add(va);
            job5.locations.Add(aker);
            job5.locations.Add(busk);
            job5.locations.Add(finn);
            job5.locations.Add(hed);
            job5.locations.Add(hord);
            job5.locations.Add(møre);
            job5.locations.Add(nordl);
            job5.locations.Add(opp);
            job5.locations.Add(oslo);
            job5.locations.Add(roga);
            job5.locations.Add(sogn);
            job5.locations.Add(sørt);
            job5.locations.Add(tele);
            job5.locations.Add(troms);
            job5.locations.Add(aa);
            job5.locations.Add(vestf);
            job5.locations.Add(østf);
            job5.locations.Add(svalb);
            job5.locations.Add(ut);


            job5.jobTypes.Add(deltid);

            job5.companies.Add(company5);

            db.jobs.Add(job5);
            db.SaveChanges();

            Job job6 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Fleksibel deltidsjobb som privatunderviser",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/fleksibel-deltidsjobb-som-privatunderviser",
                linkedInProfile = "",
                stepsToApply = "Send email",
                expiryDate = new DateTime(2016, 11, 12),
                published = new DateTime(2015, 11, 12),
                created = new DateTime(2015, 11, 12),
                modified = new DateTime(2015, 11, 12)
            };

            Contact contact6 = db.contacts.First(x => x.id == 5);
            Company company6 = db.companies.First(x => x.id.Equals("mentornorge"));

            job6.contacts.Add(contact6);

            job6.studyGroups.Add(idrett);
            job6.studyGroups.Add(data);
            job6.studyGroups.Add(medie);
            job6.studyGroups.Add(realfag);
            job6.studyGroups.Add(økonomi);
            job6.studyGroups.Add(språk);
            job6.studyGroups.Add(musikk);
            job6.studyGroups.Add(helse);
            job6.studyGroups.Add(historie);
            job6.studyGroups.Add(administrasjon);
            job6.studyGroups.Add(ingeniør);
            job6.studyGroups.Add(kunstfag);
            job6.studyGroups.Add(samfunnsfag);
            job6.studyGroups.Add(ped);
            job6.studyGroups.Add(uspesifisert);

            job6.jobTypes.Add(deltid);

            job6.companies.Add(company6);

            db.jobs.Add(job6);
            db.SaveChanges();

            Job job7 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Internship",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/internship",
                linkedInProfile = "",
                stepsToApply = "Send email",
                published = new DateTime(2015, 11, 04),
                expiryDate = new DateTime(2016, 11, 04),
                created = new DateTime(2015, 11, 04),
                modified = new DateTime(2015, 11, 04),

            };

            Contact contact7 = db.contacts.First(x => x.id == 6);
            Company company7 = db.companies.First(x => x.id.Equals("archipelagos"));

            job7.contacts.Add(contact7);
            job7.locations.Add(ut);
            job7.studyGroups.Add(medie);
            job7.studyGroups.Add(realfag);
            job7.studyGroups.Add(ingeniør);
            job7.studyGroups.Add(samfunnsfag);

            job7.jobTypes.Add(deltid);

            job7.companies.Add(company7);

            db.jobs.Add(job7);
            db.SaveChanges();

            Job job8 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Tilkallingsvikarer natttjenesten - sykepleierstudenter - Berge gård",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/tilkallingsvikarer-nattjenesten-sykepleierstudenter-berge-gaard",
                linkedInProfile = "",
                stepsToApply = "Send email",
                published = new DateTime(2015, 09, 17),
                expiryDate = new DateTime(2016, 09, 17),
                created = new DateTime(2015, 09, 17),
                modified = new DateTime(2015, 09, 17)


            };

            Contact contact8 = db.contacts.First(x => x.id == 7);
            Company company8 = db.companies.First(x => x.id.Equals("grimstadkommune"));

            job8.contacts.Add(contact8);

            job8.studyGroups.Add(uspesifisert);

            job8.jobTypes.Add(deltid);

            job8.companies.Add(company8);

            db.jobs.Add(job8);
            db.SaveChanges();


            Job job9 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Fotballtrener ved Fotballfritidsordning",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/fotballtrener-ved-fotballfritidsordning",
                linkedInProfile = "",
                stepsToApply = "Send email",
                published = new DateTime(2015, 08, 17),
                expiryDate = new DateTime(2016, 08, 17),
                created = new DateTime(2015, 08, 17),
                modified = new DateTime(2015, 08, 17)

            };

            Contact contact9 = db.contacts.First(x => x.id == 8);
            Company company9 = db.companies.First(x => x.id.Equals("ikstart"));

            job9.contacts.Add(contact9);

            job9.studyGroups.Add(idrett);

            job9.jobTypes.Add(deltid);

            job9.companies.Add(company9);

            db.jobs.Add(job9);
            db.SaveChanges();

            Job job10 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Advisor / Senior Advisor, Financial Reporting Competence Center",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/advisor-senior-advisor-financial-reporting-competence-center",
                linkedInProfile = "",
                stepsToApply = "Send email",
                published = new DateTime(2015, 05, 08),
                expiryDate = new DateTime(2017, 05, 08),
                created = new DateTime(2015, 05, 08),
                modified = new DateTime(2015, 05, 08)

            };

            Contact contact10 = db.contacts.First(x => x.id == 9);
            Company company10 = db.companies.First(x => x.id.Equals("accurateequity"));

            job10.contacts.Add(contact10);

            job10.studyGroups.Add(administrasjon);
            job10.studyGroups.Add(data);
            job10.studyGroups.Add(økonomi);
            job10.studyGroups.Add(uspesifisert);

            job10.jobTypes.Add(heltid);

            job10.companies.Add(company10);

            db.jobs.Add(job10);
            db.SaveChanges();

            Job job11 = new Job()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Spennende internship innen SEO, markedsføring og digital kommunikasjon hos Rabble",
                description = "",
                webpage = "https://kompetansetorget.uia.no/stillinger/spennende-internship-innen-seo-markedsfoering-og-digital-kommunikasjon-hos-rabble",
                linkedInProfile = "",
                stepsToApply = "Send email",
                published = new DateTime(2015, 04, 15),
                expiryDate = new DateTime(2017, 06, 20),
                created = new DateTime(2015, 04, 15),
                modified = new DateTime(2015, 04, 15)

            };

            Contact contact11 = db.contacts.First(x => x.id == 10);
            Company company11 = db.companies.First(x => x.id.Equals("accurateequity"));

            job11.contacts.Add(contact11);
            job11.locations.Add(ut);
            job11.studyGroups.Add(medie);
            job11.studyGroups.Add(økonomi);
            job11.studyGroups.Add(uspesifisert);

            job11.jobTypes.Add(heltid);

            job11.companies.Add(company11);

            db.jobs.Add(job11);
            db.SaveChanges();


        }


        private void PopulateDegree()
        {
            Degree bachelor = new Degree()
            {
                id = "bachelor",
                name = "Bachelor"
            };

            Degree master = new Degree()
            {
                id = "master",
                name = "Master"
            };

            db.degrees.Add(bachelor);
            db.degrees.Add(master);
            db.SaveChanges();




        }

        private void PopulateCourse()
        {
            Course dat304 = new Course()
            {
                id = "DAT-304",
                name = "DAT-304 - Dataing., bachelor"
            };

            Course is304 = new Course()
            {
                id = "IS-304",
                name = "IS-304 - Informasjonssys., bachelor"
            };
            Course be501 = new Course()
            {
                id = "BE-501",
                name = "BE-501 - Øk.adm., master"
            };
            Course bio300 = new Course()
            {
                id = "BIO-300",
                name = "BIO-300 - Biologi, bachelor"
            };
            Course bio500 = new Course()
            {
                id = "BIO-500",
                name = "BIO-500 - Akvatisk økologi, master"
            };
            Course byg300 = new Course()
            {
                id = "BYG-300",
                name = "BYG-300 - Byggdesign, bachelor"
            };
            Course byg500 = new Course()
            {
                id = "BYG-500",
                name = "BYG-500 - Bygg, siv.ing. master"
            };

            Course dat303 = new Course()
            {
                id = "DAT-303",
                name = "DAT-303 - Multimedia, bachelor"
            };
            Course ele301 = new Course()
            {
                id = "ELE-303",
                name = "ELE-303 - Elektronikk, bachelor"
            };
            Course ene304g = new Course()
            {
                id = "ENE-304-G",
                name = "ENE-304-G - Energi hovedprosjekt, bachelor"
            };
            Course ikt590 = new Course()
            {
                id = "IKT-590",
                name = "IKT-590 - IKT, master"
            };
            Course ind590 = new Course()
            {
                id = "IND-590",
                name = "IND-590 - Ind.øk. og tek.led., master"
            };
            Course is302 = new Course()
            {
                id = "IS-302",
                name = "IS-302, Praksisprosjekt i infosys., bachelor"
            };
            Course is501 = new Course()
            {
                id = "IS-501",
                name = "IS-501 - Informasjonssys., master"
            };
            Course kom207 = new Course()
            {
                id = "KOM-207",
                name = "KOM-207 -- Kommunikasjon, bachelor"
            };
            Course kom500 = new Course()
            {
                id = "KOM-500",
                name = "KOM-500 - Samfunnskom., master"
            };
            Course ma302 = new Course()
            {
                id = "MA-302",
                name = "MA-302 - Matematikk, bachelor"
            };
            Course ma500 = new Course()
            {
                id = "MA-500",
                name = "MA-500 - Matematikkdid., master"
            };
            Course mas306 = new Course()
            {
                id = "MAS-306",
                name = "MAS-306 - Mekatronikk, bachelor"
            };
            Course mas500 = new Course()
            {
                id = "MAS-500",
                name = "MAS-500 - Mekatronikk, master"
            };
            Course me502 = new Course()
            {
                id = "ME-502",
                name = "ME-502 - Off.pol og ledelse, master"
            };
            Course me504 = new Course()
            {
                id = "ME-504",
                name = "ME-504 - Psyk. helsearbeid, master"
            };
            Course ml312 = new Course()
            {
                id = "ML-312",
                name = "ML-312 - Bioing., bachelor"
            };
            Course mm500 = new Course()
            {
                id = "MM-500",
                name = "MM-500 - Multimedia, master"
            };
            Course org500 = new Course()
            {
                id = "ORG-500",
                name = "ORG-500 - Ledelse, master"
            };
            Course ped233 = new Course()
            {
                id = "PED-233",
                name = "PED-233 - Lærer (1.-7.trinn), bachelor"
            };
            Course sv301 = new Course()
            {
                id = "SV-301",
                name = "SV-301, Samfunnsplanlegging, bachelor"
            };
            Course sv303 = new Course()
            {
                id = "SV-303",
                name = "SV-303, Sosialt arbeid, bachelor"
            };
            Course ut503 = new Course()
            {
                id = "UT-503",
                name = "UT-503 - Utvikling og samf.plan.,master"
            };
            db.courses.Add(dat304);
            db.courses.Add(be501);
            db.courses.Add(bio300);
            db.courses.Add(bio500);
            db.courses.Add(byg300);
            db.courses.Add(byg500);
            db.courses.Add(dat303);
            db.courses.Add(dat304);
            db.courses.Add(ele301);
            db.courses.Add(ene304g);
            db.courses.Add(ikt590);
            db.courses.Add(ind590);
            db.courses.Add(is302);
            db.courses.Add(is304);
            db.courses.Add(is501);
            db.courses.Add(kom207);
            db.courses.Add(kom500);
            db.courses.Add(ma302);
            db.courses.Add(ma500);
            db.courses.Add(mas306);
            db.courses.Add(mas500);
            db.courses.Add(me502);
            db.courses.Add(me504);
            db.courses.Add(ml312);
            db.courses.Add(mm500);
            db.courses.Add(org500);
            db.courses.Add(ped233);
            db.courses.Add(sv301);
            db.courses.Add(sv303);
            db.courses.Add(ut503);


            db.SaveChanges();

            ApprovedCourse dat3041 = new ApprovedCourse()
            {
                id = "DAT-304",
                name = "DAT-304 - Dataing., bachelor"
            };

            ApprovedCourse is3041 = new ApprovedCourse()
            {
                id = "IS-304",
                name = "IS-304 - Informasjonssys., bachelor"
            };

            db.approvedCourses.Add(dat3041);
            db.approvedCourses.Add(is3041);
            db.SaveChanges();
        }

        private void PopulateProject()
        {
            Project pro1 = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Morseffekter på eggstørrelse hos hummer",
                description = "En storvokst hummer vil produsere langt flere egg enn en liten hummer" +
                              " som gyter for første gang i livet. Dette gjelder også mange andre arter" +
                              " av fisk og krepsdyr i havet, noe som gjør at store individer kan være " +
                              "spesielt verdifulle å ta vare på i bestander som høstes av oss mennesker." +
                              " I tillegg kan det være slikt at store individer produserer avkom av høyere " +
                              "kvalitet, som vokser og overlever bedre enn avkom fra små individer. " +
                              "Eggstørrelse er ofte en god indikator på kvalitet hos avkom, ettersom " +
                              "store egg typisk vil resultere i store larver/yngel. Denne oppgaven " +
                              "handler om å kvantifisere slike morseffekter på eggstørrelse hos hummer," +
                              " der Havforskningsinstituttet i Flødevigen har samlet inn data gjennom flere år. " +
                              "Dataene består av merket hummer som ofte gjenfanges flere ganger, slik at man kan" +
                              " måle eggstørrelse hos den samme hunnen flere ganger i hennes liv. I tillegg til å " +
                              "benytte eksisterende data blir det mulighet for å delta på feltarbeid med merking" +
                              " og registrering av hummer høsten 2016.",
                webpage = "http://kompetansetorget.uia.no/oppgaver/morseffekter-paa-eggstoerrelse-hos-hummer",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 02, 26),
                published = new DateTime(2016, 02, 26),
                modified = new DateTime(2016, 02, 26),
                status = "Ledig"
            };

            Contact contact6 = db.contacts.First(x => x.id == 6);
            Company uia = db.companies.First(x => x.id.Equals("uia"));
            Degree bachelor = db.degrees.First(x => x.id.Equals("bachelor"));
            StudyGroup realfag = db.studyGroup.First(x => x.id.Equals("realfag"));
            JobType fagl = db.jobTypes.First(x => x.id.Equals("faglærer"));

            pro1.contacts.Add(contact6);
            pro1.studyGroups.Add(realfag);

            pro1.degrees.Add(bachelor);
            pro1.jobTypes.Add(fagl);
            pro1.companies.Add(uia);

            db.projects.Add(pro1);
            db.SaveChanges();

            Project pro2 = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Strømavleser vha gammel mobil",
                description = "Om ikke lenge vil alle boenheter få nye strømmålere " +
                              "som er digitale og kommuniserer direkte med " +
                              "strømleverandør slik at man ikke trenger rapportere " +
                              "målerstand hver måned. Teknologien vil også gjøre det " +
                              "teknisk mulig for forbrukeren å følge med på strømforbruk " +
                              "per minutt/time/dag/måned - dersom man bare får tilgang til " +
                              "avleserdata. Da kan man også tilpasse sitt forbruk til tider " +
                              "på døgnet da prisen per kWh er lavest siden strømleverandøren " +
                              "også kan vite hvor mye strøm som brukes per minutt/time.\n" +
                              "Frem til disse nye avleserne kommer, er det både a) vanskelig å" +
                              " følge med på eget forbruk og b) fortsatt nødvendig å gå til " +
                              "sikringsskapet for å lese av (ideelt sett) en gang i måneden for" +
                              " å rapportere inn forbruk.\n" + "Oppgaven går ut på å automatisere" +
                              " avlesingen vha en gammel mobil med kamera men uten SIM kort. " +
                              "Det finnes allerede APPer (i hvert fall for Android) der en " +
                              "smartphone kan strømme bilder fra kamera over WiFi. Da vil det " +
                              "f.eks. være mulig å hente bildet hvert minutt, kjøre OCR på bildet" +
                              " for å så kunne skrive det avleste forbruket til en fil. Så kan man" +
                              " analysere avlesningene over tid for å finne forbruk per " +
                              "min/time/døgn/måned/år.\n" +
                              "Oppgaven går altså ut på å sette alt dette sammen: mobil + " +
                              "WiFi + hente bilde + OCR + lagre tid+avlest verdi til fil." +
                              "\n" + "Utfordringen i oppgaven ligger nok mest i å finne en plattform (Linux?)" +
                              " der man kan få tak et OCR program/modul og da kun trenger å scripte prosessen og " +
                              "trigge den regulært (crontab?).\n" + "Oppgaven kan utvides ved å analysere (og teste?)" +
                              " mulige bruksområder som å koble avlesningen mot smarthus systemer for å styre " +
                              "f.eks. vaskemaskiner eller el-bil lader basert på svingninger i strømprisen." +
                              " El-bilen skal jo ha 100% strøm kl.08:00, så man kan ikke sette en absolutt" +
                              " grense på hvor lav strømprisen må være for å lade. Da kan historiske svingninger " +
                              "(siste x dagene) brukes for å predikere når i løpet av det neste døgnet man antar" +
                              " det vil være lurt å lade.",
                webpage = "http://kompetansetorget.uia.no/oppgaver/stroemavleser-vha-gammel-mobil",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 01, 27),
                published = new DateTime(2016, 01, 27),
                modified = new DateTime(2016, 01, 27),
                status = "Ledig"
            };

            Contact contact5 = db.contacts.First(x => x.id == 5);
            Company privat = db.companies.First(x => x.id.Equals("privat"));
            StudyGroup data = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            JobType virk = db.jobTypes.First(x => x.id.Equals("virksomhet"));
            Course dat304 = db.courses.First(x => x.id.Equals("DAT-304"));
            Course is304 = db.courses.First(x => x.id.Equals("IS-304"));

            pro2.degrees.Add(bachelor);
            pro2.contacts.Add(contact5);
            pro2.studyGroups.Add(data);
            pro2.courses.Add(dat304);
            pro2.courses.Add(is304);
            pro2.jobTypes.Add(virk);
            pro2.companies.Add(privat);

            db.projects.Add(pro2);
            db.SaveChanges();

            Project pro3 = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Husbankens stipend til masteroppgaver 2016",
                description = "<b>Ønsker du å skrive en masteroppgave innenfor tema bolig og boligsosialt arbeid?<b>\n" +
                "Husbanken deler også i 2016 ut stipender. Stipendene er aktuelle for studenter som ønsker å skrive " +
                              "en masteroppgave med tema knyttet til bolig og boligsosialt arbeid. Alle studenter som" +
                              " er tilknyttet høgskole eller universitet i Norge kan søke.\n" + "Tematikken for oppgaven" +
                              " må knyttes til enten boligsosialt arbeid, bomiljø, boligrelatert universell utforming " +
                              "og/eller boligrelatert energi/miljø.\n" + "Tildeling av stipend på opptil kr. 30 000" +
                              " vurderes på grunnlag av masteroppgavens relevans for Husbankens arbeidsfelt, studentens" +
                              " faglige kvalifikasjoner og prosjektbeskrivelse.\n" + "<b>Søknadsfrister: 1. mars 2016 og " +
                              "1. november 2016<b>\n" + "Mer informasjon om stipendet finner du " +
                              "på&nbsp;<a href=\"http://www.husbanken.no/boligsosialt-arbeid/stipendutlysning2014/\" " +
                              "target=\"_self\">Husbankens nettsider</a>",

                webpage = "http://kompetansetorget.uia.no/oppgaver/husbankens-stipend-til-masteroppgaver-2016",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 01, 22),
                published = new DateTime(2016, 01, 22),
                modified = new DateTime(2016, 01, 22),
                status = "Ledig"
            };

            Contact contact7 = db.contacts.First(x => x.id == 7);
            Company husb = db.companies.First(x => x.id.Equals("husbanken"));
            StudyGroup ing = db.studyGroup.First(x => x.id.Equals("ingeniør"));
            StudyGroup helse = db.studyGroup.First(x => x.id.Equals("helse"));
            StudyGroup samf = db.studyGroup.First(x => x.id.Equals("samfunnsfag"));


            pro3.contacts.Add(contact7);
            pro3.studyGroups.Add(ing);
            pro3.studyGroups.Add(helse);
            pro3.studyGroups.Add(samf);

            pro3.jobTypes.Add(virk);
            pro3.companies.Add(husb);

            db.projects.Add(pro3);
            db.SaveChanges();

            Contact contact8 = db.contacts.First(x => x.id == 8);
            ApprovedCourse dat3041 = db.approvedCourses.First(x => x.id.Equals("DAT-304"));

            Project pro4 = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "APP for pasienter med hjemmemåling av INR, blodfortynnende faktor",
                description = "Sørlandet Sykehus ved Kardiolog Jarle Jortveit ønsker utviklet en funksjonell" +
                              " APP basert på norske krav for samhandling mellom hjemmeboende pasient og " +
                              "helsetjenestene.\n" + "Jarle Jortveit <Jarle.Jortveit@sshf.no> skrev:\n" +
                              "Jeg er ansvarlig for opplæring av pasienter i hjemmemåling INR/egendosering " +
                              "marevan i Aust-Agder. Savner en app for mobiltelefon hvor målinger, målområde" +
                              " og dosering kan registreres. INR nivå, tid innenfor terapeutisk nivå, endring" +
                              " i dosering etc vil alltid kunne være tilgjengelig. Basert på ukedose og målområde" +
                              " kan muligens også forslag til endring i dose gis, samt anbefalinger ved lav/høy INR," +
                              " kontaktinfo til behandlingsanvarlig lege etc. Jeg har testet det som finnes av" +
                              " «utenlandske» apper, men disse er etter min oppfatning ikke gode og er heller ikke " +
                              "tilpasset norske forhold. Kan dette være en mulig studentoppgave?\n" + "Oppgaven vil" +
                              " bli løst gjennom et nært samarbeid med Senter for eHelse ved Universitetet i Agder, " +
                              "kontaktpersoner: Martin Gerdes, Arne Wiklund, Rune Fensli.\n" + "Oppgaven har klare" +
                              " synergier til pågående forskningsprosjekter ved Senter for eHelse, og det kan påregnes" +
                              " god backing fra senterets medarbeidere gjennom prosjektet.",

                webpage = "http://kompetansetorget.uia.no/oppgaver/app-for-pasienter-med-hjemmemaaling-av-inr-blodfortynnende-faktor",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016,01,03),
                published = new DateTime(2016, 01, 03),
                modified = new DateTime(2016, 01, 03),
                status = "Ledig"
            };

            pro4.contacts.Add(contact8);
            pro4.studyGroups.Add(data);
            pro4.courses.Add(dat304);
            pro4.approvedCourses.Add(dat3041);
            pro4.jobTypes.Add(fagl);
            pro4.companies.Add(uia);

            db.projects.Add(pro4);
            db.SaveChanges();


        }

        private void temp()
        {
            Company etterIsoleringAgder = new Company()
            {
                id = "etterIsoleringAgder",
                name = "Etterisolering Agder AS",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://kompetansetorget.uia.no/extension/kompetansetorget/design/kompetansetorget/images/logo-virksomhet.jpg"
            };

            Contact bjorn = new Contact()
            {
                id = 11,
                name = "Bjørn Ingebretsen",
                position = "styreleder",
                phone = "91564082",
                email = "post@poi.as"

            };

            db.companies.Add(etterIsoleringAgder);
            db.contacts.Add(bjorn);
            db.SaveChanges();

            Project isolasjon = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Blåse isolasjon bak diffusjonsperre",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/blaase-isolasjon-bak-diffusjonsperre",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 05, 23),
                published = new DateTime(2016, 05, 23),
                modified = new DateTime(2016, 05, 23),
                status = "Ledig"
            };
            //Contact contact6 = db.contacts.First(x => x.id == 6);
            //Company uia = db.companies.First(x => x.id.Equals("uia"));
            //Degree bachelor = db.degrees.First(x => x.id.Equals("bachelor"));
            //StudyGroup realfag = db.studyGroup.First(x => x.id.Equals("realfag"));
            JobType virks = db.jobTypes.First(x => x.id.Equals("virksomhet"));
     
            isolasjon.contacts.Add(bjorn);
            isolasjon.companies.Add(etterIsoleringAgder);
            isolasjon.jobTypes.Add(virks);
            //pro1.studyGroups.Add(realfag);

            //pro1.degrees.Add(bachelor);
            //pro1.jobTypes.Add(fagl);


            db.projects.Add(isolasjon);
            db.SaveChanges();


            Company fia = new Company()
            {
                id = "fia",
                name = "Farm in Action",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://kompetansetorget.uia.no/extension/kompetansetorget/design/kompetansetorget/images/logo-virksomhet.jpg"
            };

            Contact magnus = new Contact()
            {
                id = 12,
                name = "Magnus Gellein",
                position = "Faglig ansvarlig",
                phone = "94139095",
                email = "gellein@farminaction.no"

            };

            db.companies.Add(fia);
            db.contacts.Add(magnus);
            db.SaveChanges();

            Project rusrehab = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Rusrehabilitering i InnPåTunet tiltak, med faglig oppfølgning inkludert.",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/rusrehabilitering-i-innpaatunet-tiltak-med-faglig-oppfoelgning-inkludert",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 04, 16),
                published = new DateTime(2016, 04, 16),
                modified = new DateTime(2016, 04, 16),
                status = "Ledig"
            };

            Degree master = db.degrees.First(x => x.id.Equals("master"));
            StudyGroup helse = db.studyGroup.First(x => x.id.Equals("helse"));
            Course me504 = db.courses.First(x => x.id.Equals("ME-504"));


            rusrehab.contacts.Add(magnus);
            rusrehab.companies.Add(fia);
            rusrehab.jobTypes.Add(virks);
            rusrehab.degrees.Add(master);
            rusrehab.studyGroups.Add(helse);
            rusrehab.courses.Add(me504);


            //pro1.studyGroups.Add(realfag);

            //pro1.degrees.Add(bachelor);
            //pro1.jobTypes.Add(fagl);


            db.projects.Add(rusrehab);
            db.SaveChanges();
        }

        private void Extra()
        {
            Contact siri = new Contact()
            {
                id = 13,
                name = "Siri Håvås Haugland",
                position = "",
                phone = "",
                email = "siri.h.haugland@uia.no"
            };

            db.contacts.Add(siri);
            db.SaveChanges();

            Project informasjonsmateriell = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Utvikle informasjonsmateriell/pakke til forskningsseminar",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/utvikle-informasjonsmateriell-pakke-til-forskningsseminar",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 04, 15),
                published = new DateTime(2016, 04, 15),
                modified = new DateTime(2016, 04, 15),
                status = "Ledig"
            };
            Company uia = db.companies.First(x => x.id.Equals("uia"));
            JobType fagl = db.jobTypes.First(x => x.id.Equals("faglærer"));
            informasjonsmateriell.contacts.Add(siri);
            informasjonsmateriell.companies.Add(uia);
            informasjonsmateriell.jobTypes.Add(fagl);

            db.projects.Add(informasjonsmateriell);
            db.SaveChanges();

            Contact yngvar = new Contact()
            {
                id = 14,
                name = "Yngvar Asbjørn Olsen",
                position = "",
                phone = "",
                email = "yngvar.a.olsen@uia.no"
            };

            db.contacts.Add(yngvar);
            db.SaveChanges();

            Project gyrodactylus = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Utvikling av en metode for farging av Gyrodactylus spp in vitro",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/utvikling-av-en-metode-for-farging-av-gyrodactylus-spp-in-vitro",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 04, 16, 1, 1, 2),
                published = new DateTime(2016, 04, 16, 1, 1, 2),
                modified = new DateTime(2016, 04, 16, 1, 1, 2),
                status = "Ledig"
            };

            StudyGroup realfag = db.studyGroup.First(x => x.id.Equals("realfag"));
            Course bio300 = db.courses.First(x => x.id.Equals("BIO-300"));

            gyrodactylus.contacts.Add(yngvar);
            gyrodactylus.companies.Add(uia);
            gyrodactylus.jobTypes.Add(fagl);
            gyrodactylus.studyGroups.Add(realfag);
            gyrodactylus.courses.Add(bio300);

            db.projects.Add(gyrodactylus);
            db.SaveChanges();


            Contact erlend = new Contact()
            {
                id = 15,
                name = "Erlend Wangsteen",
                position = "",
                phone = "41009164",
                email = "erlendwangensteen@gmail.com"
            };

            Company abnc = new Company()
            {
                id = "abnc",
                name = "abnc",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://kompetansetorget.uia.no/extension/kompetansetorget/design/kompetansetorget/images/logo-virksomhet.jpg"
            };

            db.contacts.Add(erlend);
            db.companies.Add(abnc);
            db.SaveChanges();
            Project strategi = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Utarbeiding av strategi i forbindelse med lansering av nytt produkt.",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/utarbeiding-av-strategi-i-forbindelse-med-lansering-av-nytt-produkt",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 02, 16),
                published = new DateTime(2016, 02, 16),
                modified = new DateTime(2016, 02, 16),
                status = "Ledig"
            };

            StudyGroup admin = db.studyGroup.First(x => x.id.Equals("administrasjon"));
            JobType virk = db.jobTypes.First(x => x.id.Equals("virksomhet"));

            strategi.contacts.Add(erlend);
            strategi.companies.Add(abnc);
            strategi.jobTypes.Add(virk);
            strategi.studyGroups.Add(admin);

            db.projects.Add(strategi);
            db.SaveChanges();

            Project demohandelsplattform = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Konstruksjon av demo-handelsplattform",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/konstruksjon-av-demo-handelsplattform",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 02, 18),
                published = new DateTime(2016, 02, 18),
                modified = new DateTime(2016, 02, 18),
                status = "Ledig"
            };

            StudyGroup datateknologi = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            demohandelsplattform.contacts.Add(erlend);
            demohandelsplattform.companies.Add(abnc);
            demohandelsplattform.jobTypes.Add(virk);
            demohandelsplattform.studyGroups.Add(datateknologi);

            db.projects.Add(demohandelsplattform);
            db.SaveChanges();

            Project handelsplattform = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Konstruksjon av demo-handelsplattform",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/konstruksjon-av-demo-handelsplattform",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 02, 16, 1, 1, 1),
                published = new DateTime(2016, 02, 16, 1, 1, 1),
                modified = new DateTime(2016, 02, 16, 1, 1, 1),
                status = "Ledig"
            };

            StudyGroup oko = db.studyGroup.First(x => x.id.Equals("økonomi"));
            handelsplattform.contacts.Add(erlend);
            handelsplattform.companies.Add(abnc);
            handelsplattform.jobTypes.Add(virk);
            handelsplattform.studyGroups.Add(oko);

            db.projects.Add(handelsplattform);
            db.SaveChanges();
        }

        public void ExtraData2()
        {
            Contact kirsti = new Contact()
            {
                id = 16,
                name = "Kirsti Lie",
                position = "",
                phone = "48264770",
                email = "kirlie@ae.no"
            };

            Company agderEnergi = new Company()
            {
                id = "agderEnergi",
                name = "Agder Energi",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "",
                logo = "http://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter/agder-energi/10593-1-nor-NO/agder-energi_width-4.jpg"
            };

            db.contacts.Add(kirsti);
            db.companies.Add(agderEnergi);
            db.SaveChanges();

            Project strategi = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                title = "Fullstendig interaktiv 3D visualisering av Kraftstasjon (Tungefoss) med innlagte e-læringsressurser og dokumentasjon",
                description = "",
                webpage = "http://kompetansetorget.uia.no/oppgaver/utarbeiding-av-strategi-i-forbindelse-med-lansering-av-nytt-produkt",
                linkedInProfile = "",
                stepsToApply = "",
                tutor = "",
                created = new DateTime(2016, 02, 08),
                published = new DateTime(2016, 02, 08),
                modified = new DateTime(2016, 02, 08),
                status = "Valgt"
            };

            StudyGroup data = db.studyGroup.First(x => x.id.Equals("datateknologi"));
            JobType virk = db.jobTypes.First(x => x.id.Equals("virksomhet"));
            Degree bach = db.degrees.First(x => x.id.Equals("bachelor"));
            Course dat303 = db.courses.First(x => x.id.Equals("DAT-303"));

            strategi.contacts.Add(kirsti);
            strategi.companies.Add(agderEnergi);
            strategi.jobTypes.Add(virk);
            strategi.studyGroups.Add(data);
            strategi.degrees.Add(bach);
            strategi.courses.Add(dat303);
            db.SaveChanges();
        }
    }
}