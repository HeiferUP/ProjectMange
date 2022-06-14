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
    public class PowerInfoServices : IPowerInfoServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<PowerInfo, int> _powerInfoRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public PowerInfoServices(IMapper mapper, IBaseRepository<PowerInfo, int> powerInfoRepo)
        {
            _mapper = mapper;
            _powerInfoRepo = powerInfoRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<PowerInfoListOutput>>> PageAsync(PowerInfoQuery parms)
        {
            var list = await _powerInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<PowerInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<PowerInfoOutput>> DetailAsync(int id)
        {
            var data = await _powerInfoRepo.Select.Where(a => a.Id == id).FirstAsync<PowerInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(PowerInfoInput model)
        {
            var data = _mapper.Map<PowerInfo>(model);;
            await _powerInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(PowerInfoInput model)
        {
            var data = await _powerInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _powerInfoRepo.UpdateAsync(data);
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
            if (!await _powerInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _powerInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
