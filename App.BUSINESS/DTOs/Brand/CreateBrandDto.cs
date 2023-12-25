using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.DTOs.Brand
{
    public record CreateBrandDto
    {
        public string? Name { get; set; }

    }
    public class CreateBrandDtoValidation : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Marka adı bos ola bilmez.")
                .MinimumLength(3).WithMessage("Marka adı en az 3 herf olmalıdır.")
                .MaximumLength(55).WithMessage("Marka adı en fazla 55 herf olmalıdır.");

        }
    }
}
