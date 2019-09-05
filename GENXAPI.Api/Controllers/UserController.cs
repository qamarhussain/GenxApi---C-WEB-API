using GENXAPI.Api.Attributes;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    [Authorize]
    [CustomExceptionFilter]
    public class UserController : ApiController
    {
        protected readonly UserRepo _userRepo = new UserRepo();
        // GET: api/user
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var result = _userRepo.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET: api/user/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var user = _userRepo.Get(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/User
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]User user)
        {
            try
            {
                _userRepo.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, [FromBody]User user)
        {
            try
            {
                var userModel = _userRepo.Get(id);
                if (userModel == null)
                {
                    return NotFound();
                }
                //userModel.FirstName = user.FirstName;
                //userModel.LastName = user.LastName;
                //userModel.Phone = user.Phone;
                _userRepo.Update(userModel);
                return Ok(userModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/user/5
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {

            try
            {
                var userModel = _userRepo.Get(id);
                if (userModel == null)
                {
                    return NotFound();
                }

                _userRepo.Delete(id);
                return Ok(userModel);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetKeyPair()
        {
            try
            {
                var keyPairValues = _userRepo.GetKeyPairValue();
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
