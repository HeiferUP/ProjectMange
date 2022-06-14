using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class GoodsCategoryInputValidator : AbstractValidator<GoodsCategoryInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public GoodsCategoryInputValidator()
        {
            RuleFor(x => x.CategoryName).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Description).MaximumLength(32).WithMessage("长度不能超过32个字符");
        }
    }
}