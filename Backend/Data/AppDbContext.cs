using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
               
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskModel>()
            .HasOne(t => t.CreatedBy) // Uma tarefa tem um usuário criador
            .WithMany(u => u.Tasks)   // Um usuário pode ter várias tarefas
            .HasForeignKey(t => t.CreatedByUserId) // Chave estrangeira em Task
            .OnDelete(DeleteBehavior.Cascade);     // Exclusão em cascata
        
        base.OnModelCreating(modelBuilder);
    }
}