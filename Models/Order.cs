using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppForDiplom.Models
{
    public class Order
    {
        public Guest? Guest { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Номер заявки
        /// </summary>
        public int NumberOfOrder { get; set; } //Proveritb
        /// <summary>
        /// Описание проблемы
        /// </summary>
        public string DescriptionOfProblem { get; set; }
        /// <summary>
        /// Начало выполнения
        /// </summary>
        public DateTime BeginOfWork { get; set; }
        /// <summary>
        /// Конец выполнения работы
        /// </summary>
        public DateTime EndOfWork { get; set; }             
        /// <summary>
        /// Статус заявки
        /// </summary>
        public string Status { get; set; }

        public Order(string Name)
        {
            this.Name = Name;            
        }
    }
}
