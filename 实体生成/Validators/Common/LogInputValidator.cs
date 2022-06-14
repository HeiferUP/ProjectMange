using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class LogInputValidator : AbstractValidator<LogInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public LogInputValidator()
        {
            RuleFor(x => x.Decription).MaximumLength(128).WithMessage("长度不能超过128个字符");
        }
    }
}