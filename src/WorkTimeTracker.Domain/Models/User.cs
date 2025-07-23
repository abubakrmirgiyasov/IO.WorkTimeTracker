using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class User : Entity
{
    public string FirstName { get; private set; }

    public string MiddleName { get; private set; }

    public string Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string Password { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CanBeActiveAt { get; private set; }

    public long ImageId { get; private set; }

    public Image Image { get; set; } = default!;

    public User(string firstName, string middleName, string email, string password, bool isActive)
    {
        FirstName = firstName;
        MiddleName = middleName;
        Email = email;
        Password = password;
        IsActive = isActive;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new BussinessLogicException(UsersErrors.FirstNameCantBeNull);

        FirstName = firstName;
    }

    public void SetMiddleName(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
            throw new BussinessLogicException(UsersErrors.MiddleNameCantBeNull);

        MiddleName = middleName;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new BussinessLogicException(UsersErrors.EmailCantBeNull);

        Email = email;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new BussinessLogicException(UsersErrors.PhoneNumberCantBeNull);

        PhoneNumber = phoneNumber;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new BussinessLogicException(UsersErrors.PasswordCantBeNull);

        Password = password;
    }

    public void SetIsActive(bool isActive)
    {
        if (!isActive)
            throw new BussinessLogicException(UsersErrors.IsActiveCantBeNull);

        IsActive = isActive;
    }

    public void SetCanBeActiveAt(DateTime canBeActiveAt)
    {
        if (canBeActiveAt == DateTime.MinValue)
            throw new BussinessLogicException(UsersErrors.CanBeActiveAtCantBeNull);

        CanBeActiveAt = canBeActiveAt;
    }

    public void SetImageId(long imageId)
    {
        if (imageId <= 0)
            throw new BussinessLogicException(UsersErrors.ImageIdCantBeNull);

        ImageId = imageId;
    }

    public class UsersErrors
    {
        public static readonly Error FirstNameCantBeNull = new(
            "User.FirstNameCantBeNull",
            "Имя не может быть пустым."
        );

        public static readonly Error MiddleNameCantBeNull = new(
            "User.MiddleNameCantBeNull",
            "Отчество не может быть пустым."
        );

        public static readonly Error EmailCantBeNull = new(
            "User.EmailCantBeNull",
            "Электронная почта не может быть пустой."
        );

        public static readonly Error PhoneNumberCantBeNull = new(
            "User.PhoneNumberCantBeNull",
            "Номер телефона не может быть пустым."
        );

        public static readonly Error PasswordCantBeNull = new(
            "User.PasswordCantBeNull",
            "Пароль не может быть пустым."
        );

        public static readonly Error IsActiveCantBeNull = new(
            "User.IsActiveCantBeNull",
            "Статус активности не может быть пустым."
        );

        public static readonly Error CanBeActiveAtCantBeNull = new(
            "User.CanBeActiveAtCantBeNull",
            "Дата возможной активности не может быть пустой."
        );

        public static readonly Error ImageIdCantBeNull = new(
            "User.ImageIdCantBeNull",
            "Идентификатор изображения не может быть пустым."
        );
    }
}
