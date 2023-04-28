using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiNetWay_v1.Models;
using Dapper;

namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmVtController : ControllerBase
    {
        private readonly string _connectionString;
        public DmVtController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }


        // GET: api/DmVt
        [HttpGet]
        public async Task<IEnumerable<DmVt>> Get()
        {
            using(var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var result = await conn.QueryAsync<DmVt>("API_DmVt_Select", null, null, null, CommandType.StoredProcedure);
                return result;

            }
            
        }

        // GET: api/DmVt/5
        [HttpGet("{id}", Name = "DmVtGetById")]
        public async Task<IEnumerable<DmVt>> Get(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@_Id_Vt", id);
                var result = await conn.QueryAsync<DmVt>("API_DmVt_Select", parameters, null, null, CommandType.StoredProcedure);
                return result;

            }
        }

        //// POST: api/DmVt
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/DmVt/5
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
