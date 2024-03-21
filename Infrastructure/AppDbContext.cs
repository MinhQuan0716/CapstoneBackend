using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ListNote> ListNotes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonVideo> Videos { get; set; }
        public DbSet<TheoryLesson> TheoryLessons { get; set; }
        public DbSet<PraticeLesson> PracticeLessons { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<UserQuizAttempt> UserQuizAttempts { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }  
        public DbSet<ListNoteDetail> ListNoteDetails { get; set; }  
        public DbSet<Choice> Choices { get; set; }
        public DbSet<QuestionDetail> QuestionDetails { get; set; }
        public DbSet<QuizDetail> QuizDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
