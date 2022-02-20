using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAppForDiplom.Models
{
    public class Order
    {
        public User User { get; set; } 
        public int Id { get; set; }
        /// <summary>
        /// Имя отправителя
        /// </summary>
        [AllowNull]
        public string Name { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [AllowNull]
        public string WorkerName { get; set; }
        
        /// <summary>
        /// Номер заявки
        /// </summary>
        [AllowNull]
        public int NumberOfOrder { get; set; } //Proveritb
        /// <summary>
        /// Описание проблемы
        /// </summary>
        [AllowNull]
        public string DescriptionOfProblem { get; set; }
        /// <summary>
        /// Время отклика
        /// </summary>
        [AllowNull]
        public DateTime ResponceTime { get; set; }
        /// <summary>
        /// Начало выполнения
        /// </summary>
        [AllowNull]
        public DateTime BeginOfWork { get; set; }
        /// <summary>
        /// Конец выполнения работы
        /// </summary>
        [AllowNull]
        public DateTime EndOfWork { get; set; }
        /// <summary>
        /// Статус заявки
        /// </summary>
        [AllowNull]
        public string Status { get; set; }
        /// <summary>
        /// Оценка начала работы(начальник)
        /// </summary>
        [AllowNull]
        public int ValueBeginOfWork { get; set; }
        /// <summary>
        /// Оценка конца работы(начальник)
        /// </summary>
        [AllowNull]
        public int ValueEndOfWork { get; set; }
        /// <summary>
        /// Оценка работы
        /// </summary>
        [AllowNull]
        public int Feedback { get; set; }
        /// <summary>
        /// Оценка лояльности(порекомендует ли)
        /// </summary>
        [AllowNull]
        public int Recommend { get; set; }
        /// <summary>
        /// устная оценка работы
        /// </summary>
        [AllowNull]
        public string OrderStatement { get; set; }

    }
}
