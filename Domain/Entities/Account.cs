namespace Domain.Entities
{
    public class Account:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime BirthDay { get; set; }
/*        public string? RefreshToken { get; set; }
        public DateTime? ExpireTokenTime { get; set; }*/
         public string? FirstName { get; set; }
         public string? LastName { get; set; }
         public string? ImageUrl { get; set; }
         public string? PhoneNumber {  get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<UserQuizAttempt> QuizAttempts { get; set; }  
        public ICollection<UserProgress> Progresses { get; set; }
        public ICollection<Payment> ListPayment { get; set; }
    }
}
