using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        //precisa de dependencia para a DB context
        //readonly boa prática para que a dependencia não seja alterada
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        //public List<Department> FindAll()
       // {
        //   return _context.Department.OrderBy(x => x.Name).ToList();
       // }

        //Transformando o método acima em assincrono
        public  async Task<List<Department>> FindAllAsync()
        {
            return await  _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
