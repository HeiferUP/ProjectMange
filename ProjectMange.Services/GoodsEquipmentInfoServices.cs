using AutoMapper;
using FreeSql;
using LDFCore.Platform.Extensions;
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using LDFCore.Platform.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using ProjectMange.Services.Query;
using ProjectMange.Services.Dtos;
using ProjectMange.Domains.Entity;

namespace ProjectMange.Services
{
    /// <summary>
    /// Common服务
    ///</summary>
    public class GoodsEquipmentInfoServices : IGoodsEquipmentInfoServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<GoodsEquipmentInfo, int> _goodsEquipmentInfoRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsEquipmentInfoServices(IMapper mapper, IBaseRepository<GoodsEquipmentInfo, int> goodsEquipmentInfoRepo)
        {
            _mapper = mapper;
            _goodsEquipmentInfoRepo = goodsEquipmentInfoRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<GoodsEquipmentInfoListOutput>>> PageAsync(GoodsEquipmentInfoQuery parms)
        {
            var list = await _goodsEquipmentInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<GoodsEquipmentInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<GoodsEquipmentInfoOutput>> DetailAsync(int id)
        {
            var data = await _goodsEquipmentInfoRepo.Select.Where(a => a.Id == id).FirstAsync<GoodsEquipmentInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(GoodsEquipmentInfoInput model)
        {
            var data = _mapper.Map<GoodsEquipmentInfo>(model);
            await _goodsEquipmentInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(GoodsEquipmentInfoInput model)
        {
            var data = await _goodsEquipmentInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _goodsEquipmentInfoRepo.UpdateAsync(data);
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
            if (!await _goodsEquipmentInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _goodsEquipmentInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
