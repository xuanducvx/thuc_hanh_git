using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using WebApiNetWay_v1.Models;
using Dapper;

namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmKhoController : ControllerBase
    {
        private readonly string _connectionString;
        public DmKhoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        // GET: api/DmKho
        [HttpGet]
        public async Task<IEnumerable<DmKho>> Get()
        {
            using(var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var result = await conn.QueryAsync<DmKho>("API_DmKho_Select", null, null, null, CommandType.StoredProcedure);
                return result;
            }
        }

        // GET: api/DmKho/5
        [HttpGet("{id}", Name = "DmKhoGetById")]
        public async Task<IEnumerable<DmKho>> Get(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@_Id_Kho", id);
                var result = await conn.QueryAsync<DmKho>("API_DmKho_Select", parameters, null, null,CommandType.StoredProcedure);
                return result;
            }
        }

        //// POST: api/DmKho
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/DmKho/5
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
