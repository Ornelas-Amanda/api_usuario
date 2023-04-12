using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {

    public  DbSet<Usuario> Usuarios{ get;set;} 

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder){
      //validações para alguns campos
        builder.Entity<Usuario>()
          .Property(p => p.Nome).HasMaxLength(30);
        builder.Entity<Usuario>()
          .Property(p => p.Sobrenome).HasMaxLength(30);
        builder.Entity<Usuario>()
          .Property(p => p.Email).HasMaxLength(80).IsRequired();
        
    }

   }