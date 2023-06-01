using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using AssessmentMangement.Infrastructure.Exceptions;
using AssessmentMangement.Infrastructure.Filters;
using AssessmentMangement.Models;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Controllers
{
    [ServiceFilter(typeof(UnitOfWorkFilter))]
    [ApiController]
    [ApplicationExceptionFilter]
    public class BaseApiController : Controller
    {
        protected IActionResult Success(dynamic data = null)
        {
            var responseValue = BuildSuccessResponse(data);
            return Ok(responseValue);
        }

        public IActionResult Success<T>(IPagedList<T> model)
        {
            dynamic obj = new ExpandoObject();
            obj.pageData = model;
            obj.count = model.Count;
            obj.hasNextPage = model.HasNextPage;
            obj.hasPreviousPage = model.HasPreviousPage;
            obj.pageIndex = model.PageIndex;
            obj.pageSize = model.PageSize;
            obj.totalCount = model.TotalCount;
            obj.totalPages = model.TotalPages;
            return Success(obj);
        }
        /// <summary>
        /// Return Created Success response 201 created 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="segment"></param>
        /// <param name="baseApi"></param>
        /// <param name="showUri"></param>
        /// <returns></returns>
        protected IActionResult CreatedWithId(string id, string segment, string baseApi = "api", bool showUri = true)
        {
            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var uri = showUri ? $"{baseUrl}/{baseApi}/{segment}" : "";
            //var responseValue = BuildSuccessResponse(new { id = id });
            return Success(new { id = id });
            //return Created(uri, responseValue);
        }

        protected IActionResult CreatedWithIds(List<string> ids, string segment, string baseApi = "api", bool showUri = true)
        {
            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var uri = showUri ? $"{baseUrl}/{baseApi}/{segment}" : "";
            //var responseValue = BuildSuccessResponse(new { id = id });

            List<dynamic> json = new List<dynamic>();
            foreach (var value in ids)
            {
                json.Add(new { id = value });

            }
            return Success(json);
        }

        private JsonResponse BuildSuccessResponse(dynamic data)
        {
            JsonResponse model = new JsonResponse();
            model.success = true;
            model.data = data;
            MetaData objmetadata = new MetaData();
            model.metadata = objmetadata;
            return model;
        }
    }


}
