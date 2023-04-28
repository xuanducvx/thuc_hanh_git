using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiNetWay_v1.Models;

namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmDtController : ControllerBase
    {
        private readonly string _connectionString;
        public DmDtController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        // GET: api/DmDt
        [HttpGet]
        public async Task<IEnumerable<DmDt>> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var result = await conn.QueryAsync<DmDt>("API_DmDt_Select", null,null,null, CommandType.StoredProcedure);
                return result;
            }
        }

        // GET: api/DmDt/5
        [HttpGet("{id}", Name = "DmDtGetById")]
        public async Task<IEnumerable<DmDt>> Get(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@_Id_Dt", id);
                var result = await conn.QueryAsync<DmDt>("API_DmDt_Select", parameters, null, null, CommandType.StoredProcedure);
                return result;
            }

        }

        //// POST: api/DmDt
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/DmDt/5
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
