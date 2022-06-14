using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class WorkFlowModelInputValidator : AbstractValidator<WorkFlowModelInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public WorkFlowModelInputValidator()
        {
            RuleFor(x => x.AddTime).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.DelFlag).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Description).MaximumLength(64).WithMessage("长度不能超过64个字符");
            RuleFor(x => x.Title).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.Title).NotEmpty().WithMessage("不能为空");
        }
    }
}