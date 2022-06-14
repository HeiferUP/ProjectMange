using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class GoodsConsumableInfoInputValidator : AbstractValidator<GoodsConsumableInfoInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public GoodsConsumableInfoInputValidator()
        {
            RuleFor(x => x.AddTime).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.DelFlag).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.GoodsId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.GoodsId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Name).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.Name).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Num).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Specification).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.Unit).MaximumLength(8).WithMessage("长度不能超过8个字符");
            RuleFor(x => x.Unit).NotEmpty().WithMessage("不能为空");
        }
    }
}