using AutoMapper;
using LDFCore.AutoMapper;
using ProjectMange.Domains.Domains.Common;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Services.CommonSvc.Profiles
{

    /// <summary>
    /// 自动生成的Mapper
    /// </summary>
    public partial class MapperConfig : IMapperConfig
    {
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="cfg"></param>
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<GoodsCategoryInput, GoodsCategory>();
            cfg.CreateMap<GoodsCategory, GoodsCategoryOutput>();
            
            cfg.CreateMap<GoodsConsumableInfoInput, GoodsConsumableInfo>();
            cfg.CreateMap<GoodsConsumableInfo, GoodsConsumableInfoOutput>();
            
            cfg.CreateMap<GoodsConsumableInputInput, GoodsConsumableInput>();
            cfg.CreateMap<GoodsConsumableInput, GoodsConsumableInputOutput>();
            
            cfg.CreateMap<GoodsEquipmentInfoInput, GoodsEquipmentInfo>();
            cfg.CreateMap<GoodsEquipmentInfo, GoodsEquipmentInfoOutput>();
            
            cfg.CreateMap<GoodsEquipmentInputInput, GoodsEquipmentInput>();
            cfg.CreateMap<GoodsEquipmentInput, GoodsEquipmentInputOutput>();
            
            cfg.CreateMap<LogInput, Log>();
            cfg.CreateMap<Log, LogOutput>();
            
            cfg.CreateMap<PowerInfoInput, PowerInfo>();
            cfg.CreateMap<PowerInfo, PowerInfoOutput>();
            
            cfg.CreateMap<RRoleInfoPowerInfoInput, RRoleInfoPowerInfo>();
            cfg.CreateMap<RRoleInfoPowerInfo, RRoleInfoPowerInfoOutput>();
            
            cfg.CreateMap<RUserInfoRoleInfoInput, RUserInfoRoleInfo>();
            cfg.CreateMap<RUserInfoRoleInfo, RUserInfoRoleInfoOutput>();
            
            cfg.CreateMap<RoleInfoInput, RoleInfo>();
            cfg.CreateMap<RoleInfo, RoleInfoOutput>();
            
            cfg.CreateMap<UserInfoInput, UserInfo>();
            cfg.CreateMap<UserInfo, UserInfoOutput>();
            
            cfg.CreateMap<WorkFlowInstanceInput, WorkFlowInstance>();
            cfg.CreateMap<WorkFlowInstance, WorkFlowInstanceOutput>();
            
            cfg.CreateMap<WorkFlowInstanceStepInput, WorkFlowInstanceStep>();
            cfg.CreateMap<WorkFlowInstanceStep, WorkFlowInstanceStepOutput>();
            
            cfg.CreateMap<WorkFlowModelInput, WorkFlowModel>();
            cfg.CreateMap<WorkFlowModel, WorkFlowModelOutput>();
            
        }
    }
}

