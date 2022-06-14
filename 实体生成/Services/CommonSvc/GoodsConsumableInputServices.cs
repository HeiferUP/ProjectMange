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
    public class GoodsConsumableInputServices : IGoodsConsumableInputServices
    {
        
        private readonly IMapper _mapper;
        private readonly IBaseRepository<GoodsConsumableInput, int> _goodsConsumableInputRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsConsumableInputServices(IMapper mapper, IBaseRepository<GoodsConsumableInput, int> goodsConsumableInputRepo)
        {
            _mapper = mapper;
            _goodsConsumableInputRepo = goodsConsumableInputRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<GoodsConsumableInputListOutput>>> PageAsync(GoodsConsumableInputQuery parms)
        {
            var list = await _goodsConsumableInputRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<GoodsConsumableInputListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<GoodsConsumableInputOutput>> DetailAsync(int id)
        {
            var data = await _goodsConsumableInputRepo.Select.Where(a => a.Id == id).FirstAsync<GoodsConsumableInputOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(GoodsConsumableInputInput model)
        {
            var data = _mapper.Map<GoodsConsumableInput>(model);
            data.Id = Id.Guid();
            await _goodsConsumableInputRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(GoodsConsumableInputInput model)
        {
            var data = await _goodsConsumableInputRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _goodsConsumableInputRepo.UpdateAsync(data);
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
            if (!await _goodsConsumableInputRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _goodsConsumableInputRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
