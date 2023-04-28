using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using WebApiNetWay_v1.Models;
using System.Data.SqlClient;


namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmHdController : ControllerBase
    {
        private readonly string _connectionString;
        public DmHdController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }


        // GET: api/DmHd
        [HttpGet]
        public async Task<IEnumerable<DmHd>> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var result = await conn.QueryAsync<DmHd>("API_DmHd_Select",null,null,null,CommandType.StoredProcedure);
                return result;                
            }
        }

        // GET: api/DmHd/5
        [HttpGet("{id}", Name = "DmHdGetById")]
        public async Task<IEnumerable<DmHd>> Get(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@_Id_Hd", id);
                var result = await conn.QueryAsync<DmHd>("API_DmHd_Select", parameters, null, null, CommandType.StoredProcedure);
                return result;
            }

        }

        //// POST: api/DmHd
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/DmHd/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
