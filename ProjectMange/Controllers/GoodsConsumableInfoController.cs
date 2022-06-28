
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
    [Authorize]
    public class GoodsConsumableInfoController
    {

        private readonly IGoodsConsumableInfoServices _goodsConsumableInfoServices;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsConsumableInfoController(IGoodsConsumableInfoServices goodsConsumableInfoServices)
        {
            _goodsConsumableInfoServices = goodsConsumableInfoServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<GoodsConsumableInfoListOutput>>> Page([FromQuery] GoodsConsumableInfoQuery parms)
        {
            return await _goodsConsumableInfoServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<GoodsConsumableInfoOutput>> Detail(int id)
        {
            return await _goodsConsumableInfoServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(GoodsConsumableInfoInput model)
        {
            return await _goodsConsumableInfoServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(GoodsConsumableInfoInput model)
        {
            return await _goodsConsumableInfoServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _goodsConsumableInfoServices.RemoveAsync(parms);
        }

    }
}


