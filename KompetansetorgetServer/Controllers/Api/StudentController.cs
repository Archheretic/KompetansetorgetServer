using System;
using System.Web.Http;
using KompetansetorgetServer.ContextDbs;
using KompetansetorgetServer.Models;
using System.Linq;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;

namespace KompetansetorgetServer
{
	public class StudentController : ApiController
	{
		private KompetanseContext db;

		public StudentController ()
		{
			this.db = new KompetanseContext();
		}

		public IQueryable<Student> GetStudents()
		{
			return db.Students;
		}

		// GET: api/Students/5
		[ResponseType(typeof(Student))]
		public IHttpActionResult GetStudent(string id)
		{
			Student student = db.Students.Find(id);
			if (student == null)
			{
				return NotFound();
			}

			return Ok(student);
		}

		// PUT: api/Students/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutStudent(string id, Student student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != student.Username)
			{
				return BadRequest();
			}

			db.Entry(student).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		private bool StudentExists(string id)
		{
			return db.Students.Count(e => e.Username == id) > 0;
		}
	}
}
/*
private IRepository<Beer> _beerRepository;

public BeersController()
{
	_beerRepository = WebApiApplication.BeerRepository;
}

public IEnumerable<Beer> Get()
{
	return _beerRepository.Items.ToArray();
}

public Beer Get(Guid id)
{
	Beer entity = _beerRepository.Get(id);
	if (entity == null)
	{
		throw new HttpResponseException(HttpStatusCode.NotFound);
	}
	return entity;
}

public HttpResponseMessage Post([FromBody] Beer value)
{
	var result = _beerRepository.Add(value);
	if (result == null)
	{
		// the entity with this key already exists
		throw new HttpResponseException(HttpStatusCode.Conflict);
	}
	var response = Request.CreateResponse<Beer>(HttpStatusCode.Created, value);
	string uri = Url.Link("DefaultApi", new { id = value.Id });
	response.Headers.Location = new Uri(uri);
	return response;
}

public HttpResponseMessage Put(Guid id, Beer value)
{
	value.Id = id;
	var result = _beerRepository.Update(value);
	if (result == null)
	{
		// entity does not exist
		throw new HttpResponseException(HttpStatusCode.NotFound);
	}
	return Request.CreateResponse(HttpStatusCode.NoContent);
}

public HttpResponseMessage Delete(Guid id)
{
	var result = _beerRepository.Delete(id);
	if (result == null)
	{
		throw new HttpResponseException(HttpStatusCode.NotFound);
	}
	return Request.CreateResponse(HttpStatusCode.NoContent);
}
}

*/