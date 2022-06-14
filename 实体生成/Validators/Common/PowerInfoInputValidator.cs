using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class PowerInfoInputValidator : AbstractValidator<PowerInfoInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public PowerInfoInputValidator()
        {
            RuleFor(x => x.ActionUrl).MaximumLength(128).WithMessage("长度不能超过128个字符");
            RuleFor(x => x.ActionUrl).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Description).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.HttpMethod).MaximumLength(4).WithMessage("长度不能超过4个字符");
            RuleFor(x => x.MenuIconUrl).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.Name).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.Name).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.ParentId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.PowerId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.PowerId).NotEmpty().WithMessage("不能为空");
        }
    }
}