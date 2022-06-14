using FluentValidation;
using ProjectMange.Services.CommonSvc.Dtos;

namespace ProjectMange.Api.Validators.Common
{
    /// <summary>
    /// Common验证器
    /// </summary>
    public class UserInfoInputValidator : AbstractValidator<UserInfoInput>
    {
        /// <summary>
        /// Validator
        /// </summary>
        public UserInfoInputValidator()
        {
            RuleFor(x => x.AddTime).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.DelFlag).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.DepartmentId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.Email).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.PassWord).MaximumLength(32).WithMessage("长度不能超过32个字符");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.PhoneNum).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.Sex).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.UserId).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("不能为空");
            RuleFor(x => x.UserName).MaximumLength(16).WithMessage("长度不能超过16个字符");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("不能为空");
        }
    }
}