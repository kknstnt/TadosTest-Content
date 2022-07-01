namespace Content.WebApi.Controllers.Country
{
    using Actions.Create;
    using Actions.Get;
    using Actions.GetList;
    using Actions.Edit;
    using Api.Requests.Abstractions;
    using AspnetCore.ApiControllers.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Api.Requests.Hierarchic.Abstractions;
    using global::Persistence.Transactions.Behaviors;
    using System;

    [ApiController]
    [Route("api/country")]
    public class CountryController : ContentApiControllerBase
    {
        public CountryController(
            IAsyncRequestBuilder asyncRequestBuilder,
            IAsyncHierarchicRequestBuilder asyncHierarchicRequestBuilder,
            IExpectCommit commitPerformer)
            : base(
                asyncRequestBuilder,
                asyncHierarchicRequestBuilder,
                commitPerformer)
        {
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(CountryCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CountryCreateRequest request) 
            => this.RequestAsync()
                .For<CountryCreateResponse>()
                .With(request);

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(CountryEditRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("get")]
        [ProducesResponseType(typeof(CountryGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CountryGetRequest request)
            => this.RequestAsync()
                .For<CountryGetResponse>()
                .With(request);

        [HttpPost]
        [Route("getList")]
        [ProducesResponseType(typeof(CountryGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CountryGetListRequest request)
            => this.RequestAsync()
                .For<CountryGetListResponse>()
                .With(request);
    }
}