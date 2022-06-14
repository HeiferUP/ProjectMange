using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class WorkFlowInstanceStepInputValidator : AbstractValidator<WorkFlowInstanceStepInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public WorkFlowInstanceStepInputValidator()
        {
            RuleFor(x => x.InstanceId).MaximumLength(64).WithMessage("长度不能超过64个字符");
            RuleFor(x => x.InstanceId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.NextReviewerId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.NextReviewerId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.ReviewerId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.ReviewerId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.ReviewReason).MaximumLength(64).WithMessage("长度不能超过64个字符");
            RuleFor(x => x.ReviewStatus).NotEmpty().WithMessage("不能为空");
        }
    }
}