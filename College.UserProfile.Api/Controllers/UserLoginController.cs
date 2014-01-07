using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using College.UserProfile.Entities;

namespace College.UserProfile.Api.Controllers
{
    public class UserLoginController : ApiController
    {
        private UserProfilesContext db = new UserProfilesContext();

        // GET api/UserLogin
        public IQueryable<UserLogin> GetUserLogins()
        {
            return db.UserLogins;
        }

        // GET api/UserLogin/5
        [ResponseType(typeof(UserLogin))]
        public IHttpActionResult GetUserLogin(int id)
        {
            UserLogin userlogin = db.UserLogins.Find(id);
            if (userlogin == null)
            {
                return NotFound();
            }

            return Ok(userlogin);
        }


        // GET api/UserLogin/5
        [ResponseType(typeof(UserLogin))]
        [HttpPost]
        [ActionName("ValidateUserLogin")]
        public IHttpActionResult ValidateUserLogin(UserLogin userLogin)
        {
            UserLogin userlogin = db.UserLogins.SingleOrDefault(usr => usr.EmailAddress.Equals(userLogin.EmailAddress, StringComparison.OrdinalIgnoreCase)
                && usr.Password == userLogin.Password);
            if (userlogin == null)
            {
                return NotFound();
            }

            return Ok(userlogin);
        }

        // PUT api/UserLogin/5
        public IHttpActionResult PutUserLogin(int id, UserLogin userlogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userlogin.UserLoginID)
            {
                return BadRequest();
            }

            db.Entry(userlogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(userlogin.EmailAddress))
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

        // POST api/UserLogin
        [ResponseType(typeof(UserLogin))]
        [ActionName("PostUserLogin")]
        public HttpResponseMessage PostUserLogin(UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!UserLoginExists(userlogin.EmailAddress))
                    {
                        db.UserLogins.Add(userlogin);
                        db.SaveChanges();

                        // todo: Authorize User


                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, userlogin);
                        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { UserLoginID = userlogin.UserLoginID }));
                        return response;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, string.Format("User with email address '{0}' already registered.", userlogin.EmailAddress));
                    }
                }
                catch (Exception ex)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/UserLogin/5
        [ResponseType(typeof(UserLogin))]
        public IHttpActionResult DeleteUserLogin(int id)
        {
            UserLogin userlogin = db.UserLogins.Find(id);
            if (userlogin == null)
            {
                return NotFound();
            }

            db.UserLogins.Remove(userlogin);
            db.SaveChanges();

            return Ok(userlogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserLoginExists(string emailAddress)
        {
            return db.UserLogins.Count(e => e.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase)) > 0;
        }

    }
}