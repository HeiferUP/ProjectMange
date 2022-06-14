using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMange.Services.Query;
using ProjectMange.Services.Dtos;
using ProjectMange.Services;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    public class GoodsEquipmentInfoController
    {

        private readonly IGoodsEquipmentInfoServices _goodsEquipmentInfoServices;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsEquipmentInfoController(IGoodsEquipmentInfoServices goodsEquipmentInfoServices)
        {
            _goodsEquipmentInfoServices = goodsEquipmentInfoServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<GoodsEquipmentInfoListOutput>>> Page([FromQuery] GoodsEquipmentInfoQuery parms)
        {
            return await _goodsEquipmentInfoServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<GoodsEquipmentInfoOutput>> Detail(int id)
        {
            return await _goodsEquipmentInfoServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(GoodsEquipmentInfoInput model)
        {
            return await _goodsEquipmentInfoServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(GoodsEquipmentInfoInput model)
        {
            return await _goodsEquipmentInfoServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _goodsEquipmentInfoServices.RemoveAsync(parms);
        }

    }
}


