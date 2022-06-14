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
    public class RRoleInfoPowerInfoServices : IRRoleInfoPowerInfoServices
    {
        
        private readonly IMapper _mapper;
        private readonly IBaseRepository<RRoleInfoPowerInfo, int> _rRoleInfoPowerInfoRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public RRoleInfoPowerInfoServices(IMapper mapper, IBaseRepository<RRoleInfoPowerInfo, int> rRoleInfoPowerInfoRepo)
        {
            _mapper = mapper;
            _rRoleInfoPowerInfoRepo = rRoleInfoPowerInfoRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<RRoleInfoPowerInfoListOutput>>> PageAsync(RRoleInfoPowerInfoQuery parms)
        {
            var list = await _rRoleInfoPowerInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<RRoleInfoPowerInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<RRoleInfoPowerInfoOutput>> DetailAsync(int id)
        {
            var data = await _rRoleInfoPowerInfoRepo.Select.Where(a => a.Id == id).FirstAsync<RRoleInfoPowerInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(RRoleInfoPowerInfoInput model)
        {
            var data = _mapper.Map<RRoleInfoPowerInfo>(model);
            data.Id = Id.Guid();
            await _rRoleInfoPowerInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(RRoleInfoPowerInfoInput model)
        {
            var data = await _rRoleInfoPowerInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _rRoleInfoPowerInfoRepo.UpdateAsync(data);
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
            if (!await _rRoleInfoPowerInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _rRoleInfoPowerInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
