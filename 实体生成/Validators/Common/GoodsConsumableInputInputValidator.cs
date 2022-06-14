using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class GoodsConsumableInputInputValidator : AbstractValidator<GoodsConsumableInputInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public GoodsConsumableInputInputValidator()
        {
            RuleFor(x => x.AddTime).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.AddUserId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.AddUserId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.GoodsId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.GoodsId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Num).NotEmpty().WithMessage("不能为空");
        }
    }
}