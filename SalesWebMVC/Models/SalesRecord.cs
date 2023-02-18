
using SalesWebMVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//exibir data com dia/mes/ano
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")] // define formatação com duas casas decimais
        public double Amount { get; set; }
        public SalesStatus SaleStatus { get; set; }
        public Seller Seller { get; set; }


        public SalesRecord()
        {
          
        }
        public SalesRecord(int id, DateTime date, double amount, SalesStatus saleStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SaleStatus = saleStatus;
            Seller = seller;
        }
    }

    
}
