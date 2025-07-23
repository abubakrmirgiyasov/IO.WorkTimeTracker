using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class Image : Entity
{
    public string FullPath { get; private set; }

    public int Size { get; private set; }

    public List<User> Users { get; private set; } = default!;

    public Image(string fullPath, int size)
    {
        FullPath = fullPath;
        Size = size;
    }

    public void SetFullPath(string fullPath)
    {
        if (string.IsNullOrWhiteSpace(fullPath))
            throw new BussinessLogicException(ImageErrors.FullPathCantBeNull);

        FullPath = fullPath;
    }

    public void SetSize(int size)
    {
        if (size <= 0)
            throw new BussinessLogicException(ImageErrors.SizeCantBeNull);

        if (size > 5 * 1024 * 1024)
            throw new BussinessLogicException(ImageErrors.SizeTooLarge);

        Size = size;
    }

    public class ImageErrors
    {
        public static readonly Error FullPathCantBeNull = new(
            "Image.FullPathCantBeNull",
            "Путь к изображению не может быть пустым."
        );

        public static readonly Error SizeCantBeNull = new(
            "Image.SizeCantBeNull",
            "Размер изображения не может быть пустым."
        );

        public static readonly Error SizeTooLarge = new(
            "Image.SizeTooLarge",
            "Размер изображения не должен превышать 5 МБ."
        );
    }
}
