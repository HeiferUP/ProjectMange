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
    public class RoleInfoServices : IRoleInfoServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<RoleInfo, int> _roleInfoRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public RoleInfoServices(IMapper mapper, IBaseRepository<RoleInfo, int> roleInfoRepo)
        {
            _mapper = mapper;
            _roleInfoRepo = roleInfoRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<RoleInfoListOutput>>> PageAsync(RoleInfoQuery parms)
        {
            var list = await _roleInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<RoleInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<RoleInfoOutput>> DetailAsync(int id)
        {
            var data = await _roleInfoRepo.Select.Where(a => a.Id == id).FirstAsync<RoleInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(RoleInfoInput model)
        {
            var data = _mapper.Map<RoleInfo>(model);
            await _roleInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(RoleInfoInput model)
        {
            var data = await _roleInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _roleInfoRepo.UpdateAsync(data);
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
            if (!await _roleInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _roleInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
