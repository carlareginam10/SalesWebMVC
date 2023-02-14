using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;



namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required] //define o campo como obrigatorio
        [StringLength (60, MinimumLength =3, ErrorMessage = "{0} size shoud be between {1} and {2}")]  //define máximo e mínimo de caracteres {0} pega o nome do atributo para exibir msg de erro
        //{1}  pega o primeiro parametro informado (60) e {2) peaga o segundo parametro (3) para exibir na msg de erro
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)] //email vira link pra chamar app de envio de email
        public string Email { get; set; }
        [Display(Name = "Birth Date")] //altera o nome de exibição
        [DataType(DataType.Date)] //para parar de aparecer a data com hora
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//exibir data com dia/mes/ano
        public DateTime BirthDate { get; set; }

          [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")] // define formatação com duas casas decimais
        [Range(100.0, 50000.0, ErrorMessage="{0} muste be from {1} to {2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;

            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSaler(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSaler(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //Soma total de vendas de um vendedor num determindado intervalo de datas usando o Linq
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
