using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class RUserInfoRoleInfoInputValidator : AbstractValidator<RUserInfoRoleInfoInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public RUserInfoRoleInfoInputValidator()
        {
            RuleFor(x => x.RoleId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.UserId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("不能为空");
        }
    }
}