using System.Threading.Tasks;
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using ProjectMange.Services.Dtos;
using ProjectMange.Services.Query;

namespace ProjectMange.Services
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    public interface IWorkFlowModelServices
    {

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        Task<IResultModel<PageList<WorkFlowModelListOutput>>> PageAsync(WorkFlowModelQuery parms);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel<WorkFlowModelOutput>> DetailAsync(int id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> AddAsync(WorkFlowModelInput model);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> EditAsync(WorkFlowModelInput model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        Task<IResultModel> RemoveAsync(RemoveModel<int> parms);

    }
}


