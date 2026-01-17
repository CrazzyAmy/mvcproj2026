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
    public class MemberRepository: IMemberRepository
    {
        private readonly KhNetCourseContext _dbContext;
        public MemberRepository(KhNetCourseContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public Task<bool> CreateAsync(MemberModel member)
        {
            throw new NotImplementedException();
        }
    }
}
