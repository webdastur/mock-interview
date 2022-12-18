using Application.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Projects
{
    public class ProjectCreateModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? ImageId { get; set; }
        public int UserId { get; set; }
    }
}
