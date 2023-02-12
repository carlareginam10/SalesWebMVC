﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

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
    }
}