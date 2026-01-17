using CourseService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseService.Models
{
    public class CourseScheduleService : ICourseScheduleService
    {
        private readonly ICourseScheduleRepository _csRepo;
        public CourseScheduleService(ICourseScheduleRepository csRepo)
        {
            _csRepo = csRepo;
        }

        public async Task<IEnumerable<CourseScheduleModel>> QueryAsync()
        {
            return await _csRepo.QueryAsync();
        }
    }
}
