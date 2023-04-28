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
    public class Rpt_BangKeHoaDonBanHangDetailController : ControllerBase
    {
        private readonly string _connectionString;
        public Rpt_BangKeHoaDonBanHangDetailController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
                     

        // GET: api/Rpt_BangKeHoaDonBanHangDetail/5
        [HttpGet("{Stt}", Name = "Rpt_BangKeHoaDonBanHangDetailGet")]
        public async Task<IEnumerable<Rpt_BangKeHoaDonBanHangDetail>> Get(string Stt)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@_Stt", Stt);
                var result = await conn.QueryAsync<Rpt_BangKeHoaDonBanHangDetail>("API_Rpt_F0001Detail", parameters, null, null, CommandType.StoredProcedure);
                return result;
            }
        }

        //// GET: api/Rpt_BangKeHoaDonBanHangDetail
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //// POST: api/Rpt_BangKeHoaDonBanHangDetail
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Rpt_BangKeHoaDonBanHangDetail/5
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
