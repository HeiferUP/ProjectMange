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
    public class GoodsConsumableInfoServices : IGoodsConsumableInfoServices
    {
        
        private readonly IMapper _mapper;
        private readonly IBaseRepository<GoodsConsumableInfo, int> _goodsConsumableInfoRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsConsumableInfoServices(IMapper mapper, IBaseRepository<GoodsConsumableInfo, int> goodsConsumableInfoRepo)
        {
            _mapper = mapper;
            _goodsConsumableInfoRepo = goodsConsumableInfoRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<GoodsConsumableInfoListOutput>>> PageAsync(GoodsConsumableInfoQuery parms)
        {
            var list = await _goodsConsumableInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<GoodsConsumableInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<GoodsConsumableInfoOutput>> DetailAsync(int id)
        {
            var data = await _goodsConsumableInfoRepo.Select.Where(a => a.Id == id).FirstAsync<GoodsConsumableInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(GoodsConsumableInfoInput model)
        {
            var data = _mapper.Map<GoodsConsumableInfo>(model);
            data.Id = Id.Guid();
            await _goodsConsumableInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(GoodsConsumableInfoInput model)
        {
            var data = await _goodsConsumableInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _goodsConsumableInfoRepo.UpdateAsync(data);
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
            if (!await _goodsConsumableInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _goodsConsumableInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
