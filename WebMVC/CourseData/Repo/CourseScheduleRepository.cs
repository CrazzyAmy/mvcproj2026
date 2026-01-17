using CourseData.Models;
using CourseService.Interface;
using CourseService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseData.Repo
{
    public class CourseScheduleRepository: ICourseScheduleRepository
    {
        private readonly KhNetCourseContext _dbContext;
        public CourseScheduleRepository(KhNetCourseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CourseScheduleModel>> QueryAsync()
        {
            var query = from cs in _dbContext.Courseschedules
                        join c in _dbContext.Courses on cs.Courseid equals c.Id
                        join t in _dbContext.Teachers on cs.Teacherid equals t.Id
                        select new CourseScheduleModel
                        {
                            Id = cs.Id,
                            Code = c.Code,
                            Name = c.Name,
                            TeacherName = t.Name,
                            Times = c.Times,
                            Desc = c.Description,
                            Sdate = cs.Sdate,
                            Edate = cs.Edate,
                            Location = cs.Location
                        };
            return await Task.FromResult(query.ToList());
        }
    }
}
