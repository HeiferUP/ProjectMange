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
    public class LogServices : ILogServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<Log, int> _logRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public LogServices(IMapper mapper, IBaseRepository<Log, int> logRepo)
        {
            _mapper = mapper;
            _logRepo = logRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<LogListOutput>>> PageAsync(LogQuery parms)
        {
            var list = await _logRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<LogListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<LogOutput>> DetailAsync(int id)
        {
            var data = await _logRepo.Select.Where(a => a.Id == id).FirstAsync<LogOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(LogInput model)
        {
            var data = _mapper.Map<Log>(model);
            await _logRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(LogInput model)
        {
            var data = await _logRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _logRepo.UpdateAsync(data);
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
            if (!await _logRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _logRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
