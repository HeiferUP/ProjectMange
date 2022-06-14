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
    public class RUserInfoRoleInfoServices : IRUserInfoRoleInfoServices
    {
        
        private readonly IMapper _mapper;
        private readonly IBaseRepository<RUserInfoRoleInfo, int> _rUserInfoRoleInfoRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public RUserInfoRoleInfoServices(IMapper mapper, IBaseRepository<RUserInfoRoleInfo, int> rUserInfoRoleInfoRepo)
        {
            _mapper = mapper;
            _rUserInfoRoleInfoRepo = rUserInfoRoleInfoRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<RUserInfoRoleInfoListOutput>>> PageAsync(RUserInfoRoleInfoQuery parms)
        {
            var list = await _rUserInfoRoleInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<RUserInfoRoleInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<RUserInfoRoleInfoOutput>> DetailAsync(int id)
        {
            var data = await _rUserInfoRoleInfoRepo.Select.Where(a => a.Id == id).FirstAsync<RUserInfoRoleInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(RUserInfoRoleInfoInput model)
        {
            var data = _mapper.Map<RUserInfoRoleInfo>(model);
            data.Id = Id.Guid();
            await _rUserInfoRoleInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(RUserInfoRoleInfoInput model)
        {
            var data = await _rUserInfoRoleInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _rUserInfoRoleInfoRepo.UpdateAsync(data);
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
            if (!await _rUserInfoRoleInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _rUserInfoRoleInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
