using Microsoft.AspNetCore.Mvc.Filters;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Infrastructure.Filters
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _unitOfWork.BeginTransaction();
            // execute any code before the action executes
            var result = await next();
            // execute any code after the action executes
            if (result.Exception == null)
            {
                _unitOfWork.CommitTransaction();
                return;
            }
            else
            {
                _unitOfWork.RollbackTransaction();
                return;
            }
        }
    }
}

