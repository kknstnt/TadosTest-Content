namespace Content.WebApi.Controllers.User.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using Domain.Entities;
    using Domain.Services.Users;
    using global::Content.Domain.Criteria;
    using Queries.Abstractions;
    using Exceptions;

    public class UserCreateRequestHandler : IAsyncRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IUserService _userService;

        public UserCreateRequestHandler(IUserService userService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<UserCreateResponse> ExecuteAsync(UserCreateRequest request)
        {
            City city = await _asyncQueryBuilder.FindByIdAsync<City>(request.CityId);

            if (city == null)
                throw new IncorrectRequestParameters();

            User user = await _userService.CreateUserAsync(
                email: request.Email.Trim(),
                city: city
            );

            return new UserCreateResponse(
                Id: user.Id);
        }
    }
}
