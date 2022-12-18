using Application.Common.Model;
using Application.Services.InterviewCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ReservedInterviews
{
    public interface IReservedInterviewService
    {
        ReservedInterviewModel Create(ReservedInterviewCreateModel reservedInterviewCreateModel);
        ValueTask<ReservedInterviewModel> GetById(int reservedInterviewId);
        ValueTask<PaginatedList<ReservedInterviewModel>> GetReservedInterviews(PaginatedRequestModel paginatedRequestModel);
    }
}
