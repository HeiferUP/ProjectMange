using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class WorkFlowInstanceInputValidator : AbstractValidator<WorkFlowInstanceInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public WorkFlowInstanceInputValidator()
        {
            RuleFor(x => x.AddTime).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Description).MaximumLength(64).WithMessage("长度不能超过64个字符");
            RuleFor(x => x.InstanceId).MaximumLength(64).WithMessage("长度不能超过64个字符");
            RuleFor(x => x.InstanceId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.NextReviewer).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.OutGoodsId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.OutGoodsId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.OutNum).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Reason).MaximumLength(64).WithMessage("长度不能超过64个字符");
            RuleFor(x => x.Status).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.UserId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("不能为空");
        }
    }
}