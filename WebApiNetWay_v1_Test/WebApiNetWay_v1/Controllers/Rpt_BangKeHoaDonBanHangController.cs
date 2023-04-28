using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Sql;
using Dapper;
using WebApiNetWay_v1.Models;
using System.Data.SqlClient;
using WebApiNetWay_v1.Adapter;


namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rpt_BangKeHoaDonBanHangController : ControllerBase
    {
        private readonly string _connectionString;
        public Rpt_BangKeHoaDonBanHangController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        // GET: api/Rpt_BangKeHoaDonBanHang
        [HttpGet]
        public async Task<IEnumerable<Rpt_BangKeHoaDonBanHang>> Get(DateTime Ngay_Ct1, DateTime Ngay_Ct2, string Id_Dt, string Id_Kho, string Id_Vt, string Id_Hd)
        {         
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                List<Rpt_BangKeHoaDonBanHang> lstRpt_BangKeHoaDonBanHang = new List<Rpt_BangKeHoaDonBanHang>();
                //string sql = "EXECUTE API_Rpt_F0001 '" + CONVERT._DTOC(Ngay_Ct1) + "','" + CONVERT._DTOC(Ngay_Ct2) + "','" + Id_Dt + "','" + Id_Kho + "','" + Id_Vt + "','" + Id_Hd + "'";
                string sql = "EXECUTE API_Rpt_F0001 '" + Ngay_Ct1.ToString("dd/MM/yyyy") + "','" + Ngay_Ct2.ToString("dd/MM/yyyy") + "','" + Id_Dt + "','" + Id_Kho + "','" + Id_Vt + "','" + Id_Hd + "'";

                DataSet ds = NWSQL._GetDataSetQuery(sql, _connectionString);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Rpt_BangKeHoaDonBanHang objRpt = new Models.Rpt_BangKeHoaDonBanHang();
                        objRpt.Stt = ds.Tables[0].Rows[i]["Stt"].ToString();
                        objRpt.Ngay_Ct = (DateTime)ds.Tables[0].Rows[i]["Ngay_Ct"];
                        objRpt.So_Ct = ds.Tables[0].Rows[i]["So_Ct"].ToString();
                        objRpt.Ma_Dt = ds.Tables[0].Rows[i]["Ma_Dt"].ToString();
                        objRpt.Ten_Dt = ds.Tables[0].Rows[i]["Ten_Dt"].ToString();
                        objRpt.So_Luong = Convert.ToDecimal(ds.Tables[0].Rows[i]["So_Luong"]);
                        objRpt.Tien2 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Tien2"]);
                        objRpt.Tien3 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Tien3"]);
                        objRpt.TTong_Tien = Convert.ToDecimal(ds.Tables[0].Rows[i]["TTong_Tien"]);                   
                        lstRpt_BangKeHoaDonBanHang.Add(objRpt);
                    }
                }

                return lstRpt_BangKeHoaDonBanHang;
            }

        }


        //// GET: api/Rpt_BangKeHoaDonBanHang
        //[HttpGet]
        //public async Task<IEnumerable<Rpt_BangKeHoaDonBanHang>> Get(DateTime Ngay_Ct1, DateTime Ngay_Ct2, string Id_Dt, string Id_Kho, string Id_Vt, string Id_Hd)
        //{

        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@_Ngay_Ct1", Ngay_Ct1);
        //        parameters.Add("@_Ngay_Ct2", Ngay_Ct2);
        //        parameters.Add("@_Id_Dt", Id_Dt);
        //        parameters.Add("@_Id_Kho", Id_Kho);
        //        parameters.Add("@_Id_Vt", Id_Vt);
        //        parameters.Add("@_Id_Hd", Id_Hd);
        //        var result = await conn.QueryAsync<Rpt_BangKeHoaDonBanHang>("API_Rpt_F0001", parameters, null, null, CommandType.StoredProcedure);
        //        return result;

        //    }
        //}


        //// GET: api/Rpt_BangKeHoaDonBanHang/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Rpt_BangKeHoaDonBanHang
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Rpt_BangKeHoaDonBanHang/5
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
