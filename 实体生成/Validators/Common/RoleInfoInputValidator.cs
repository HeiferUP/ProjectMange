using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class RoleInfoInputValidator : AbstractValidator<RoleInfoInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public RoleInfoInputValidator()
        {
            RuleFor(x => x.AddTime).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.DelFlag).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Description).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.Description).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.RoleId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.RoleName).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("不能为空");
        }
    }
}