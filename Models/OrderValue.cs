namespace WebAppForDiplom.Models
{
    public class OrderValue
    {
        public int Id { get; set; }
        /// <summary>
        /// Оценка начала работы(начальник)
        /// </summary>
        public int ValueBeginOfWork { get; set; }
        /// <summary>
        /// Оценка конца работы(начальник)
        /// </summary>
        public int ValueEndOfWork { get; set; }
        /// <summary>
        /// Оценка работы
        /// </summary>
        public int Feedback { get; set; }
        /// <summary>
        /// Оценка лояльности(порекомендует ли)
        /// </summary>
        public int Recommend { get; set; }
        public Order? Order { get; set; }
    }
}
