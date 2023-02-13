﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Seller> FindAll()
        {
            //vai acessar a tabela de vendedores na base e converter os dados para uma lista
            return _context.Seller.ToList();

        }

        public Seller FindById(int id)
        {
            //Include(obj => obj.Department) inclui o departamento do vendedor para exibição
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);

        }

        public void Remove(int id)
        {
            //procura o objeto por id
            var obj = _context.Seller.Find(id);
            //remove obj de acordo com id
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Insert(Seller obj)
        {
            //Associa o primeiro departamento ao vendedor adicionado para resolver provisioriamente problema de ForeingKey
            //Após ser implentado o DepartmentId na classe Seller a linha abaixo não é mais necessária, pois o objeto Seller já vai estar estanciado com o departamento
           // obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
