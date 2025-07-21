using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class User : Entity
{
    public string FullName { get; private set; }

    public string Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string Password { get; private set; }

    public string? Image { get; private set; }

    public bool IsActive { get; private set; }

    public User(string fullName, string email, string password, bool isActive)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        IsActive = isActive;
    }

    public void SetFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new BussinessLogicException(UsersErrors.FullNameCantBeNull);

        FullName = fullName;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new BussinessLogicException(UsersErrors.EmailCantBeNull);

        Email = email;
    }

    public void SetPhoneNumberSpace(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new BussinessLogicException(UsersErrors.PhoneNumberCantBeNull);

        PhoneNumber = phoneNumber;
    }

    public void SetPasswordlSpace(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new BussinessLogicException(UsersErrors.PasswordCantBeNull);

        Password = password;
    }

    public void SetImageSpace(string image)
    {
        if(string.IsNullOrWhiteSpace(image))
            throw new BussinessLogicException(UsersErrors.ImageCantBeNull);

        Image = image;
    }

    public void SetIsActiveSpace(bool isActive)
    {
        if(!IsActive)
            throw new BussinessLogicException(UsersErrors.IsActiveCantBeNull);

        IsActive = isActive;
    }

    public class UsersErrors
    {
        public static readonly Error FullNameCantBeNull = new(
            "Users.FullNameCantBeNull",
            "Полное имя не может быть пустым."
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

        public static readonly Error ImageCantBeNull = new(
            "User.ImageCantBeNull",
            "Изображение не может быть пустым."
        );

        public static readonly Error IsActiveCantBeNull = new(
            "User.IsActiveCantBeNull",
            "Статус активности не может быть пустым."
        );
    }
}
