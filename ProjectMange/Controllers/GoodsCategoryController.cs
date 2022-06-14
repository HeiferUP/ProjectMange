using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMange.Services;
using ProjectMange.Services.Dtos;
using ProjectMange.Services.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    public class GoodsCategoryController
    {

        private readonly IGoodsCategoryServices _goodsCategoryServices;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsCategoryController(IGoodsCategoryServices goodsCategoryServices)
        {
            _goodsCategoryServices = goodsCategoryServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<GoodsCategoryListOutput>>> Page([FromQuery] GoodsCategoryQuery parms)
        {
            return await _goodsCategoryServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<GoodsCategoryOutput>> Detail(int id)
        {
            return await _goodsCategoryServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(GoodsCategoryInput model)
        {
            return await _goodsCategoryServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(GoodsCategoryInput model)
        {
            return await _goodsCategoryServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _goodsCategoryServices.RemoveAsync(parms);
        }

    }
}


