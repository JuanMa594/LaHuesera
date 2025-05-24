using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Conector;


namespace LaHuesera.Controllers
{
   
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<Usuarios> Get()
        {
            using (LA_HUESERAEntities objEntidad = new LA_HUESERAEntities())
            {
                return objEntidad.Usuarios.ToList();
            }
        }

        // GET: api/Usuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuarios
        public HttpResponseMessage Post([FromBody] Usuarios objUsuario)
        {
            EntityState operacion = EntityState.Added;
            return opercion(objUsuario, operacion);
        }

        // PUT: api/Usuarios/5
        public HttpResponseMessage Put([FromBody] Usuarios objUsuario)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objUsuario, operacion);
        }

        // DELETE: api/Usuarios/5
        public HttpResponseMessage Delete([FromBody] Usuarios objUsuario)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objUsuario, operacion);
        }


        private HttpResponseMessage opercion([FromBody] Usuarios objUsuario, EntityState operacion)
        {
            int resp = 0;
            HttpResponseMessage objMenRespuesta = null;
            try
            {
                using (LA_HUESERAEntities objEntidad = new LA_HUESERAEntities())
                {
                    objEntidad.Entry(objUsuario).State = operacion;
                    resp = objEntidad.SaveChanges();
                    objMenRespuesta = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception er)
            {
                objMenRespuesta = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
            return objMenRespuesta;
        }
    }
}
