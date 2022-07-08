namespace Content.WebApi.Controllers.User.Dto
{
    public class UserListItemDto
    {
        public long Id { get; init; }

        public string Email { get; init; }

        // Свойство должно содержать значение вида "Страна, Город"
        public string CityFullName { get; init; }
    }
}