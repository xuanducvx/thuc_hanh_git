using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApiNetWay_v1.Models;


namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmTkController : ControllerBase
    {
        private readonly string _connectionString;
        public DmTkController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }


        // GET: api/DmTk
        [HttpGet]
        public async Task<IEnumerable<DmTk>> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var result = await conn.QueryAsync<DmTk>("API_DmTk_Select", null, null, null, CommandType.StoredProcedure);
                return result;
            }
        }

        // GET: api/DmTk/5
        [HttpGet("{id}", Name = "DmTkGetById")]
        public async Task<IEnumerable<DmTk>> Get(string id)
        {
            using(var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@_Id_Tk", id);
                var result = await conn.QueryAsync<DmTk>("API_DmTk_Select", parameters, null, null, CommandType.StoredProcedure);
                return result;

            }
        }

        //// POST: api/DmTk
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/DmTk/5
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
