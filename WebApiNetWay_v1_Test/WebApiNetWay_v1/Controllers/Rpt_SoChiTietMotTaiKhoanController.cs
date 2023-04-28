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
using WebApiNetWay_v1.Adapter;

namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rpt_SoChiTietMotTaiKhoanController : ControllerBase
    {
        private readonly string _connectionString;
        public Rpt_SoChiTietMotTaiKhoanController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }


        // GET: api/Rpt_SoChiTietMotTaiKhoan
        [HttpGet]
        public async Task<IEnumerable<Rpt_SoChiTietMotTaiKhoan>> Get(DateTime Ngay_Ct1, DateTime Ngay_Ct2, string Id_Tk, string Id_Dt, string Id_Hd)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                List<Rpt_SoChiTietMotTaiKhoan> lstRpt_SoChiTietMotTaiKhoan = new List<Rpt_SoChiTietMotTaiKhoan>();
                //string sql = "EXECUTE API_Rpt_F0001 '" + CONVERT._DTOC(Ngay_Ct1) + "','" + CONVERT._DTOC(Ngay_Ct2) + "','" + Id_Dt + "','" + Id_Kho + "','" + Id_Vt + "','" + Id_Hd + "'";
                string sql = "EXECUTE APi_Rpt_K0005 '" + Ngay_Ct1.ToString("dd/MM/yyyy") + "','" + Ngay_Ct2.ToString("dd/MM/yyyy") + "','" + Id_Tk + "','" + Id_Dt + "','" + Id_Hd + "'";

                DataSet ds = NWSQL._GetDataSetQuery(sql, _connectionString);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Rpt_SoChiTietMotTaiKhoan objRpt = new Models.Rpt_SoChiTietMotTaiKhoan();
                        objRpt.Tk = ds.Tables[0].Rows[i]["Tk"].ToString();
                        objRpt.Tk_Du = ds.Tables[0].Rows[i]["Tk_Du"].ToString();
                        objRpt.Stt = ds.Tables[0].Rows[i]["Stt"].ToString();
                        objRpt.Stt0 = Convert.ToInt32(ds.Tables[0].Rows[i]["Stt0"]);
                        objRpt.Ngay_Ct = (DateTime)ds.Tables[0].Rows[i]["Ngay_Ct"];
                        objRpt.So_Ct = ds.Tables[0].Rows[i]["So_Ct"].ToString();
                        objRpt.Dien_Giai = ds.Tables[0].Rows[i]["Dien_Giai"].ToString();
                        objRpt.Ps_No = Convert.ToDecimal(ds.Tables[0].Rows[i]["Ps_No"]);
                        objRpt.Ps_Co = Convert.ToDecimal(ds.Tables[0].Rows[i]["Ps_Co"]);
                        objRpt.Ma_Dt = ds.Tables[0].Rows[i]["Ma_Dt"].ToString();
                        objRpt.Ten_Dt = ds.Tables[0].Rows[i]["Ten_Dt"].ToString();
                        objRpt.Bold = Convert.ToInt32(ds.Tables[0].Rows[i]["Bold"]);                    
                        lstRpt_SoChiTietMotTaiKhoan.Add(objRpt);
                    }
                }

                return lstRpt_SoChiTietMotTaiKhoan;
            }

        }

        //// GET: api/Rpt_SoChiTietMotTaiKhoan/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Rpt_SoChiTietMotTaiKhoan
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Rpt_SoChiTietMotTaiKhoan/5
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
