using Application.Common.Model;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Payments
{
    public class PaymentModel : BaseModel
    {
        public int InterviewId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}
