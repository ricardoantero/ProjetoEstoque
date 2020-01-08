namespace Business
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BLEstoque : DbContext
    {
        public BLEstoque()
            : base("name=BLEstoque")
        {
        }

        public virtual DbSet<PRO_PRO_PRODUTO> PRO_PRO_PRODUTO { get; set; }
        public virtual DbSet<PRO_USU_USUARIO> PRO_USU_USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRO_PRO_PRODUTO>()
                .Property(e => e.PRO_C_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_PRO_PRODUTO>()
                .Property(e => e.PRO_C_DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_PRO_PRODUTO>()
                .Property(e => e.PRO_C_MARCA)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_PRO_PRODUTO>()
                .Property(e => e.PRO_C_COR)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_PRO_PRODUTO>()
                .Property(e => e.PRO_C_TAMANHO)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_PRO_PRODUTO>()
                .Property(e => e.PRO_C_IMAGEM)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_USU_USUARIO>()
                .Property(e => e.USU_C_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<PRO_USU_USUARIO>()
                .Property(e => e.USU_C_SENHA)
                .IsUnicode(false);
        }
    }
}
