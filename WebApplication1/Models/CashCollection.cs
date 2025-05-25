using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CashCollection
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string CollectionName { get; set; } = string.Empty;

        [DisplayName("Сумма")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
        public decimal Amount { get; set; }

        [DisplayName("Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [DisplayName("Телефон")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Phone { get; set; } = string.Empty;

        [DisplayName("Статус")]
        public bool IsCompleted { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; } = string.Empty;
    }
}