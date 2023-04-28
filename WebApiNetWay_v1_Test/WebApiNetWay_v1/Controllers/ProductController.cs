using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiNetWay_v1.Models;
using System.Data;
using Dapper;
using WebApiNetWay_v1.Dtos;
using WebApiNetWay_v1.Filters;
using Microsoft.Extensions.Logging;

namespace WebApiNetWay_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly string _connectionString;
        //private readonly ILogger<ProductController> _logger;

        public ProductController(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
            //_logger = logger;
        }

        //// GET: api/Product
        //[HttpGet]
        //public async Task<IEnumerable<Product>> Get()
        //{
            
        //    using (var conn = new SqlConnection(_connectionString)) {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var result = await conn.QueryAsync<Product>("App_Product_Select", null, null, null, CommandType.StoredProcedure );
        //        return result;
        //    }
        //}

        //// GET: api/Product/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<Product> Get(int id)
        //{
        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Id", id);
        //        var result = await conn.QueryAsync<Product>("App_Product_SelectById", parameters, null, null, CommandType.StoredProcedure);
        //        return result.Single();

        //    }
        //}
        //[HttpGet("paging", Name ="GetPaging")]
        //public async Task<PagedResult<Product>> GetPaging (string keyword, int categoryId, int pageIndex, int pageSize)
        //{
        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var paramaters = new DynamicParameters();
        //        paramaters.Add("@keyword", keyword);
        //        paramaters.Add("@categoryId", categoryId);
        //        paramaters.Add("@pageIndex", pageIndex);
        //        paramaters.Add("@pageSize", pageSize);
        //        paramaters.Add("@totalRow", DbType.Int32, direction: ParameterDirection.Output);
        //        var result = await conn.QueryAsync<Product>("Get_Product_AllPaging", paramaters, null, null, CommandType.StoredProcedure);
        //        int totalRow = paramaters.Get<int>("totalRow");

        //        var pagedResult = new PagedResult<Product>()
        //        {
        //            Items = result.ToList(),
        //            TotalRow = totalRow,
        //            PageIndex = pageIndex,
        //            PageSize = pageSize
        //        };
        //        return pagedResult;

        //    }
        //}


        //// POST: api/Product
        //[HttpPost]
        //[ValidateModel]
        //public async Task<IActionResult> Post([FromBody] Product product)
        //{
        //    int newId = 0;
        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var paramaters = new DynamicParameters();
        //        paramaters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);
        //        paramaters.Add("@Name", product.Name);
        //        paramaters.Add("@Name2", product.Name2);
        //        paramaters.Add("@Price", product.Price);
        //        paramaters.Add("@Wait_Time", product.Wait_Time);
        //        paramaters.Add("@Image", product.Image);
        //        paramaters.Add("@Id_Category", product.Id_Category);
        //        paramaters.Add("@IsParent", product.IsParent);

        //        var result = await conn.ExecuteAsync("Create_Product", paramaters, null, null, CommandType.StoredProcedure);
        //        newId = paramaters.Get<int>("@Id");
        //        return Ok(newId);
        //    }
        //}

        //// PUT: api/Product/5
        //[HttpPut("{id}")]
        //[ValidateModel]
        //public async Task<IActionResult> Put(int id, [FromBody] Product product)
        //{
        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var paramaters = new DynamicParameters();
        //        paramaters.Add("", product.Id);
        //        paramaters.Add("", product.Name);
        //        paramaters.Add("", product.Name2);
        //        paramaters.Add("", product.Price);
        //        paramaters.Add("", product.Wait_Time);
        //        paramaters.Add("", product.Image);
        //        paramaters.Add("", product.Id_Category);
        //        paramaters.Add("", product.IsParent);

        //        await conn.ExecuteAsync("Update_Product", paramaters, null, null, CommandType.StoredProcedure);

        //        return Ok();
        //    }
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public async Task<int> Delete(int id)
        //{
        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var paramaters = new DynamicParameters();
        //        paramaters.Add("@Id", id);
        //        var result = await conn.ExecuteAsync("Delete_Product", paramaters, null, null, CommandType.StoredProcedure);
        //        return result;
        //    }
        //}
    }
}
