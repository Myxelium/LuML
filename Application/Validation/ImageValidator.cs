using Contract;
using FluentValidation;

namespace Api.Validation;

public class ImageValidator : AbstractValidator<Image>
{
    public ImageValidator()
    {
        RuleFor(image => image.File)
            .NotNull()
            .WithMessage("Image file is required.")
            .Must(BeAValidImage)
            .WithMessage("Invalid image format. Allowed formats are .jpg, .jpeg, .png, .gif");
    }

    private bool BeAValidImage(IFormFile file)
    {
        var validImageFormats = new[] { ".png", ".jpg", ".jpeg", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        return validImageFormats.Contains(fileExtension);
    }
}