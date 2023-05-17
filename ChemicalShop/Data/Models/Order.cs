using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Имя")]
        public string CustomerName { get; set; }

        [Display(Name="Фамилия")]
        public string CustomerSurname { get; set; }

        [Display(Name="Адрес")]
        [MinLength(10, ErrorMessage = "Длина адреса не менее 10 символов ")]
        [Required(ErrorMessage = "Длина адреса не менее 10 символов ")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10, ErrorMessage = "Длина номера телефона не менее 10 символов ")]
        [Required(ErrorMessage = "Длина номера телефона не менее 10 символов ")]
        public string CustomerPhone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(10, ErrorMessage = "Длина email не менее 10 символов ")]
        [Required(ErrorMessage = "Длина email не менее 10 символов ")]
        public string CustomerEmail { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
