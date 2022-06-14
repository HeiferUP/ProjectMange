using AutoMapper;
using FreeSql;
using LDFCore.Authorized;
using LDFCore.Platform.Extensions;
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using LDFCore.Platform.Utils.Helper;
using ProjectMange.Domains.Domains.Common;
using ProjectMange.Services.CommonSvc.Dtos;
using ProjectMange.Services.CommonSvc.Query;
using ProjectMange.Services.CommonSvc.Profiles;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMange.Services.CommonSvc
{
    /// <summary>
    /// Common服务
    ///</summary>
    public class GoodsEquipmentInputServices : IGoodsEquipmentInputServices
    {
        
        private readonly IMapper _mapper;
        private readonly IBaseRepository<GoodsEquipmentInput, int> _goodsEquipmentInputRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsEquipmentInputServices(IMapper mapper, IBaseRepository<GoodsEquipmentInput, int> goodsEquipmentInputRepo)
        {
            _mapper = mapper;
            _goodsEquipmentInputRepo = goodsEquipmentInputRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<GoodsEquipmentInputListOutput>>> PageAsync(GoodsEquipmentInputQuery parms)
        {
            var list = await _goodsEquipmentInputRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<GoodsEquipmentInputListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<GoodsEquipmentInputOutput>> DetailAsync(int id)
        {
            var data = await _goodsEquipmentInputRepo.Select.Where(a => a.Id == id).FirstAsync<GoodsEquipmentInputOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(GoodsEquipmentInputInput model)
        {
            var data = _mapper.Map<GoodsEquipmentInput>(model);
            data.Id = Id.Guid();
            await _goodsEquipmentInputRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(GoodsEquipmentInputInput model)
        {
            var data = await _goodsEquipmentInputRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _goodsEquipmentInputRepo.UpdateAsync(data);
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel> RemoveAsync(RemoveModel<int> parms)
        {
            if (parms == null || parms.Id == null)
            {
                return ResultModel.Failed("无效参数");
            }
            if (!await _goodsEquipmentInputRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _goodsEquipmentInputRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
