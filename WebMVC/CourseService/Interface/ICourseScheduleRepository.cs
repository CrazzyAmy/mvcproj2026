using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseService.Models;

namespace CourseService.Interface
{
    public interface ICourseScheduleRepository
    {
        Task<IEnumerable<CourseScheduleModel>> QueryAsync();
    }
}
