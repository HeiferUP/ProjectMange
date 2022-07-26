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
using Microsoft.Extensions.Caching.Memory;

namespace ProjectMange.Services
{
    /// <summary>
    /// Common服务
    ///</summary>
    public class UserInfoServices : IUserInfoServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<UserInfo, int> _userInfoRepo;
        private readonly IMemoryCache _memoryCache;
        /// <summary>
        /// INIT
        /// </summary>
        public UserInfoServices(IMapper mapper, IBaseRepository<UserInfo, int> userInfoRepo, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _userInfoRepo = userInfoRepo;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<UserInfoListOutput>>> PageAsync(UserInfoQuery parms)
        {
            var list = await _userInfoRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<UserInfoListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<UserInfoOutput>> DetailAsync(int id)
        {
            var cache = _memoryCache.Get("UserName");
            var data = await _userInfoRepo.Select.Where(a => a.Id == id).FirstAsync<UserInfoOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(UserInfoInput model)
        {
            var data = _mapper.Map<UserInfo>(model);
            await _userInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(UserInfoInput model)
        {
            var data = await _userInfoRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _userInfoRepo.UpdateAsync(data);
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
            if (!await _userInfoRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _userInfoRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }

        /// <summary>
        /// 角色启用/禁用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<IResultModel> UpdateUserDelFlagAsync(UserInfoInput input)
        {
            var data = await _userInfoRepo.FindAsync(input.Id);
            if (data==null) return ResultModel.Failed("角色信息不存在");
            if (data.DelFlag == 0)
            {
                data.DelFlag = 1;
            }
            else
            {
                data.DelFlag = 0;
            }
            return ResultModel.Success();

        }
    }
}
