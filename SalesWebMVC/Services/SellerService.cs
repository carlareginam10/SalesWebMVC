using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        //precisa de dependencia para a DB context
        //readonly boa prática para que a dependencia não seja alterada
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }


        //public List<Seller> FindAll()
        //{
        //    //vai acessar a tabela de vendedores na base e converter os dados para uma lista
        //    return _context.Seller.ToList();

        //}

        //transformando o método em assincrono
        public async Task<List<Seller>> FindAllAsync()
        {
            //vai acessar a tabela de vendedores na base e converter os dados para uma lista
            return await _context.Seller.ToListAsync();

        }

        //public Seller FindById(int id)
        //{
        //    //Include(obj => obj.Department) inclui o departamento do vendedor para exibição
        //    return _context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);

        //}

        public async Task<Seller> FindByIdAsync(int id)
        {
            
             return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(s => s.Id == id);

        }

        //public void Remove(int id)
        //{
        //    //procura o objeto por id
        //    var obj = _context.Seller.Find(id);
        //    //remove obj de acordo com id
        //    _context.Seller.Remove(obj);
        //    _context.SaveChanges();
        //}

        public async Task RemoveAsync(int id)
        {

            try
            {
                //procura o objeto por id
                var obj = await _context.Seller.FindAsync(id);
                //remove obj de acordo com id
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e )
            {

                throw new IntegretyException("Can't delete seller because he/she has sales");
            }
           
        }

        public async Task UpdateAsyn(Seller obj)
        {    //Any = se não tiver algum vendedor na condição informada dentro do parentese
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            //interceptando uma exceção do nível de acesso a dados e relançando a exceção no nível de serviços
            catch (DbUpdateConcurrencyException e)
            {
                //lança minha exceção criada na camada de serviços
                throw new DbConcurrencyException(e.Message);
            }


        }

        //public void Insert(Seller obj)
        //{
        //    //Associa o primeiro departamento ao vendedor adicionado para resolver provisioriamente problema de ForeingKey
        //    //Após ser implentado o DepartmentId na classe Seller a linha abaixo não é mais necessária, pois o objeto Seller já vai estar estanciado com o departamento
        //   // obj.Department = _context.Department.First();
        //    _context.Add(obj);
        //    _context.SaveChanges();
        //}

        //transformando o método em assincrono
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
