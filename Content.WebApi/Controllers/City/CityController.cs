﻿namespace Content.WebApi.Controllers.City
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

    [ApiController]
    [Route("api/city")]
    public class CityController : ContentApiControllerBase
    {
        public CityController(
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
        [ProducesResponseType(typeof(CityCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CityCreateRequest request)
            => this.RequestAsync()
                .For<CityCreateResponse>()
                .With(request);

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(CityEditRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("get")]
        [ProducesResponseType(typeof(CityGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CityGetRequest request)
            => this.RequestAsync()
                .For<CityGetResponse>()
                .With(request);

        [HttpPost]
        [Route("getList")]
        [ProducesResponseType(typeof(CityGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CityGetListRequest request)
            => this.RequestAsync()
                .For<CityGetListResponse>()
                .With(request);
    }
}