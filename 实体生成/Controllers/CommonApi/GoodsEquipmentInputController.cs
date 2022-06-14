using LDFCore.Authorized.Web;
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using ProjectMange.Services.CommonSvc;
using ProjectMange.Services.CommonSvc.Dtos;
using ProjectMange.Services.CommonSvc.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectMange.Api.Controllers.CommonApi
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    public class GoodsEquipmentInputController : ControllerAbstract
    {

        private readonly IGoodsEquipmentInputServices _goodsEquipmentInputServices;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsEquipmentInputController(IGoodsEquipmentInputServices goodsEquipmentInputServices)
        {
            _goodsEquipmentInputServices = goodsEquipmentInputServices;
        }
        
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<GoodsEquipmentInputListOutput>>> Page([FromQuery] GoodsEquipmentInputQuery parms)
        {
            return await _goodsEquipmentInputServices.PageAsync(parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<GoodsEquipmentInputOutput>> Detail(int id)
        {
            return await _goodsEquipmentInputServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Add(GoodsEquipmentInputInput model)
        {
            return await _goodsEquipmentInputServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(GoodsEquipmentInputInput model)
        {
            return await _goodsEquipmentInputServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _goodsEquipmentInputServices.RemoveAsync(parms);
        }
    
    }
}


