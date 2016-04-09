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
            PopulateDevice();
            PopulateStudent();
            PopulateJobType();
            PopulateContact();
            PopulateCompany();
            PopulateJob();

            
            PopulateDegree();
            PopulateCourse();
            PopulateProject();
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

            StudyGroup helse = new StudyGroup()
            {
                id = "helse",
                name = "Helse- og sosialfag"
            };

            StudyGroup ingenior = new StudyGroup()
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

            db.studyGroup.Add(idrett);
            db.studyGroup.Add(data);
            db.studyGroup.Add(ped);
            db.studyGroup.Add(helse);
            db.studyGroup.Add(ingenior);
            db.studyGroup.Add(samfunnsfag);
            db.studyGroup.Add(realfag);

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

            JobType fagl = new JobType()
            {
                id = "faglærer",
                name = "Fra faglærer"
            };

            JobType virksomhet = new JobType()
            {
                id = "virksomhet",
                name = "Fra virksomhet"
            };


            db.jobTypes.Add(heltid);
            db.jobTypes.Add(deltid);
            db.jobTypes.Add(fagl);
            db.jobTypes.Add(virksomhet);

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

            Contact larsen = new Contact()
            {
                id = 5,
                name = "Jarl Larsen",
                position = "privatperson",
                phone = "",
                email = "jarl.larsen@gmail.com"
            };

            Contact olsen = new Contact()
            {
                id = 6,
                name = "Esben Moland Olsen",
                position = "",
                phone = "",
                email = "esben.m.olsen@uia.no"
            };

            Contact flato = new Contact()
            {
                id = 7,
                name = "Maja Flåto",
                position = "",
                phone = "958 75 141",
                email = "maja.flato@husbanken.no"
            };

            Contact fensli = new Contact()
            {
                id = 8,
                name = "Rune Werner Fensli",
                position = "",
                phone = "",
                email = "rune.fensli@uia.no"
            };


            db.contacts.Add(andersen);
            db.contacts.Add(mikkelsen);
            db.contacts.Add(syvertsen);
            db.contacts.Add(nilsen);
            db.contacts.Add(larsen);
            db.contacts.Add(olsen);
            db.contacts.Add(flato);
            db.contacts.Add(fensli);

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

            Company privat = new Company()
            {
                id = "privat",
                name = "Privatperson",
                adress = "",
                url = "",
                facebook = "",
                linkedIn = "",
                description = "Privatperson.",
                logo = "http://kompetansetorget.uia.no/extension/kompetansetorget/design/kompetansetorget/images/logo-virksomhet.jpg"
            };

            Company husbanken = new Company()
            {
                id = "husbanken",
                name = "Husbanken",
                adress = "",
                url = "http://kompetansetorget.uia.no/virksomheter/husbanken",
                facebook = "",
                linkedIn = "",
                description = "Husbanken er statens sentrale organ for gjennomføring av norsk boligpolitikk.\n" 
                + "Økt bosetting av vanskeligstilte på boligmarkedet, herunder forebygging og bekjempelse av bostedsløshet," +
                " er en av Husbankens viktigste målsettinger. I tillegg har Husbanken ansvar for å bidra til at det bygges " +
                "flere universelt utformede og miljøvennlige boliger.\n" + "Husbanken disponerer økonomiske virkemidler, " +
                "bistår med informasjon, kompetanseoppbygging og kunnskapsutvikling innenfor by-, bolig- og områdeutvikling," +
                " samt boligsosialt arbeid.",
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
                description = "Universitetet i Agder har rundt 10.000 studenter" +
                              " og 1.100 ansatte fordelt på Campus Kristiansand" +
                              " og Campus Grimstad. Universitetet i Agder tilbyr " +
                              "mer enn 150 studier og har et aktivt og ledende " +
                              "forskermiljø. Vi vektlegger respekt, åpenhet og " +
                              "evnen til å vise engasjement og stolthet over både " +
                              "egne og andres resultater. Våre ansatte og studenter " +
                              "trives godt og har stort faglig utbytte av virksomheten " +
                              "på våre topp moderne og funksjonelle campuser.",
                logo = "http://kompetansetorget.uia.no/var/kompetansetorget/storage/images/virksomheter-internt/universitetet-i-agder/18076-2-nor-NO/universitetet-i-agder_width-4.jpg"
            };

            db.companies.Add(stamina);
            db.companies.Add(snekkern);
            db.companies.Add(spicheren);
            db.companies.Add(nav);
            db.companies.Add(privat);
            db.companies.Add(husbanken);
            db.companies.Add(uia);
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

            db.courses.Add(dat304);
            db.courses.Add(is304);
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

            
            
            DateTime now = DateTime.Now;

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
                stepsToApply = "",
                tutor = "",
                created = now,
                published = now,
                modified = now,
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
                stepsToApply = "",
                tutor = "",
                created = now.AddDays(1),
                published = now.AddDays(1),
                modified = now.AddDays(1),
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
                              "target=\"_self\">Husbankens nettsider</a>" ,
            
                webpage = "http://kompetansetorget.uia.no/oppgaver/stroemavleser-vha-gammel-mobil",
                stepsToApply = "",
                tutor = "",
                created = now.AddDays(2),
                published = now.AddDays(2),
                modified = now.AddDays(2),
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
            now = DateTime.Now;


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

                webpage = "http://kompetansetorget.uia.no/oppgaver/stroemavleser-vha-gammel-mobil",
                stepsToApply = "",
                tutor = "",
                created = now.AddDays(2),
                published = now.AddDays(2),
                modified = now.AddDays(2),
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