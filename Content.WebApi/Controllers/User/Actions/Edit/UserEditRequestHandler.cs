namespace Content.WebApi.Controllers.User.Actions.Edit
{
    using System;
    using System.Threading.Tasks;
    using Domain.Services.Users;
    using global::Content.Domain.Criteria;
    using Queries.Abstractions;
    using Domain.Entities;
    using Api.Requests.Abstractions;
    using Exceptions;

    public class UserEditRequestHandler : IAsyncRequestHandler<UserEditRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IUserService _userService;

        public UserEditRequestHandler(IUserService userService, IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task ExecuteAsync(UserEditRequest request)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.Id);
            var city = await _queryBuilder.FindByIdAsync<City>(request.CityId);

            if (user == null || city == null)
                throw new IncorrectRequestParameters();

            if (user.Email == request.Email)
                return;

            await _userService.UpdateUserAsync(user, request.Email, city);
        }
    }
}
