using System.Threading.Tasks;
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using ProjectMange.Domains.Domains.Common;
using ProjectMange.Services.CommonSvc.Dtos;
using ProjectMange.Services.CommonSvc.Query;

namespace ProjectMange.Services.CommonSvc
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    public interface IRRoleInfoPowerInfoServices
    {
        
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        Task<IResultModel<PageList<RRoleInfoPowerInfoListOutput>>> PageAsync(RRoleInfoPowerInfoQuery parms); 
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel<RRoleInfoPowerInfoOutput>> DetailAsync(int id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> AddAsync(RRoleInfoPowerInfoInput model);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> EditAsync(RRoleInfoPowerInfoInput model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        Task<IResultModel> RemoveAsync(RemoveModel<int> parms);
    
    }
}


