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
    public class WorkFlowInstanceStepServices : IWorkFlowInstanceStepServices
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<WorkFlowInstanceStep, int> _workFlowInstanceStepRepo;
        /// <summary>
        /// INIT
        /// </summary>
        public WorkFlowInstanceStepServices(IMapper mapper, IBaseRepository<WorkFlowInstanceStep, int> workFlowInstanceStepRepo)
        {
            _mapper = mapper;
            _workFlowInstanceStepRepo = workFlowInstanceStepRepo;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IResultModel<PageList<WorkFlowInstanceStepListOutput>>> PageAsync(WorkFlowInstanceStepQuery parms)
        {
            var list = await _workFlowInstanceStepRepo.Select
                //TODO 这里补充筛选条件
                .Count(out var count)
                .OrderBy(a => a.Id)
                .Page(parms.Page, parms.PageSize)
                .ToListAsync<WorkFlowInstanceStepListOutput>();

            parms.TotalCount = count;
            return PageResult.PageList(list, parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel<WorkFlowInstanceStepOutput>> DetailAsync(int id)
        {
            var data = await _workFlowInstanceStepRepo.Select.Where(a => a.Id == id).FirstAsync<WorkFlowInstanceStepOutput>();
            return ResultModel.Success(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> AddAsync(WorkFlowInstanceStepInput model)
        {
            var data = _mapper.Map<WorkFlowInstanceStep>(model);
            await _workFlowInstanceStepRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public async Task<IResultModel> EditAsync(WorkFlowInstanceStepInput model)
        {
            var data = await _workFlowInstanceStepRepo.FindAsync(model.Id);
            _mapper.Map(model, data);
            await _workFlowInstanceStepRepo.UpdateAsync(data);
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
            if (!await _workFlowInstanceStepRepo.Select.AnyAsync(a => a.Id == parms.Id))
            {
                return ResultModel.Failed("数据不存在");
            }
            await _workFlowInstanceStepRepo.DeleteAsync(parms.Id);
            return ResultModel.Success();
        }
    }
}
