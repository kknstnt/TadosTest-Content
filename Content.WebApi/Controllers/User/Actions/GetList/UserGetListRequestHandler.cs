namespace Content.WebApi.Controllers.User.Actions.GetList
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using AutoMapper;
    using Domain.Criteria;
    using Domain.Entities;
    using Dto;
    using Queries.Abstractions;
    using Domain.Filters;
    using System.Linq;

    public class UserGetListRequestHandler : IAsyncRequestHandler<UserGetListRequest, UserGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public UserGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserGetListResponse> ExecuteAsync(UserGetListRequest request)
        {
            var users = await _asyncQueryBuilder
                .For<PaginatedList<User>>()
                .WithAsync(new FindByFilterAndPagination<UserGetListFilter>(
                    request.Filter,
                    request.Pagination));

            var usersDto = _mapper.Map<IEnumerable<UserListItemDto>>(users.Items);

            return new UserGetListResponse(
                Page: new PaginatedList<UserListItemDto>(users.TotalCount, usersDto));
        }
    }
}
