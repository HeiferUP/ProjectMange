using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class RRoleInfoPowerInfoInputValidator : AbstractValidator<RRoleInfoPowerInfoInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public RRoleInfoPowerInfoInputValidator()
        {
            RuleFor(x => x.PowerId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.PowerId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.RoleId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("不能为空");
        }
    }
}