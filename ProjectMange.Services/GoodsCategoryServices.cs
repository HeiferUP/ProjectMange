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
using ProjectMange.Services.Dtos;
using ProjectMange.Services.Query;
using ProjectMange.Domains.Entity;

namespace ProjectMange.Services
{
    /// <summary>
    /// Common服务
    ///</summary>
    public class GoodsCategoryServices : IGoodsCategoryServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<GoodsCategory, int> _goodsCategoryRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsCategoryServices(IMapper mapper, IBaseRepository<GoodsCategory, int> goodsCategoryRepo)
        {
            _mapper = mapper;
            _goodsCategoryRepo = goodsCategoryRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<GoodsCategoryListOutput>>> PageAsync(GoodsCategoryQuery parms)
        {
            var list = await _goodsCategoryRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<GoodsCategoryListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<GoodsCategoryOutput>> DetailAsync(int id)
        {
            var data = await _goodsCategoryRepo.Select.Where(a => a.Id == id).FirstAsync<GoodsCategoryOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(GoodsCategoryInput model)
        {
            var data = _mapper.Map<GoodsCategory>(model);
            await _goodsCategoryRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(GoodsCategoryInput model)
        {
            var data = await _goodsCategoryRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _goodsCategoryRepo.UpdateAsync(data);
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
            if (!await _goodsCategoryRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _goodsCategoryRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
