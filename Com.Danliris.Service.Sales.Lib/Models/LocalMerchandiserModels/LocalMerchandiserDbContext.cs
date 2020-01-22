using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Com.Danliris.Service.Sales.Lib.Models.LocalMerchandiserModels
{
    public partial class LocalMerchandiserDbContext : DbContext
    {
        public LocalMerchandiserDbContext(DbContextOptions<LocalMerchandiserDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Horder> Horder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horder>(entity =>
            {
                entity.ToTable("HOrder");

                entity.HasIndex(e => new { e.No, e.Tgl })
                    .HasName("_dta_index_HOrder_15_94623380__K2_K7");

                entity.HasIndex(e => new { e.Konf, e.Seksi, e.Codeby, e.Article, e.Tgl, e.Kode, e.Qty, e.Sat, e.Price, e.Valas, e.Amount, e.Kurs, e.Pcs, e.SatPcs, e.Otlk, e.Otlu, e.OrdDate, e.MtUang, e.Ship, e.Post, e.Complete, e.Salesman, e.ShCut, e.ShSew, e.ShFin, e.Sh, e.Ws, e.Valid, e.Eff, e.PpicDate, e.PlanDate, e.ShipDate, e.Deadline, e.Userin, e.Tglin, e.Jamin, e.Usered, e.Tgled, e.Jamed, e.No, e.Id })
                    .HasName("_dta_index_HOrder_15_94623380__K2_K1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32_33_34_");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Article).HasMaxLength(25);

                entity.Property(e => e.Codeby).HasMaxLength(3);

                entity.Property(e => e.Complete).HasMaxLength(1);

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Eff).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.EngPost)
                    .HasColumnName("ENG_Post")
                    .HasMaxLength(1);

                entity.Property(e => e.Jamed).HasMaxLength(8);

                entity.Property(e => e.Jamin).HasMaxLength(8);

                entity.Property(e => e.Kode).HasMaxLength(2);

                entity.Property(e => e.Konf)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Kurs).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Lt).HasColumnName("LT");

                entity.Property(e => e.MdPost)
                    .HasColumnName("MD_Post")
                    .HasMaxLength(1);

                entity.Property(e => e.MtUang)
                    .HasColumnName("Mt_Uang")
                    .HasMaxLength(3);

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.OrdDate)
                    .HasColumnName("Ord_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Otlk).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Otlu).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PblPost)
                    .HasColumnName("PBL_Post")
                    .HasMaxLength(1);

                entity.Property(e => e.Pcs).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PlanDate)
                    .HasColumnName("Plan_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Post).HasMaxLength(1);

                entity.Property(e => e.Ppic1Post)
                    .HasColumnName("PPIC1_Post")
                    .HasMaxLength(1);

                entity.Property(e => e.Ppic2Post)
                    .HasColumnName("PPIC2_Post")
                    .HasMaxLength(1);

                entity.Property(e => e.PpicDate)
                    .HasColumnName("Ppic_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Qty).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Repeat).HasMaxLength(1);

                entity.Property(e => e.Salesman).HasMaxLength(1);

                entity.Property(e => e.Sat).HasMaxLength(10);

                entity.Property(e => e.SatPcs).HasMaxLength(10);

                entity.Property(e => e.Seksi).HasMaxLength(1);

                entity.Property(e => e.Sh).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.ShCut)
                    .HasColumnName("Sh_Cut")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.ShFin)
                    .HasColumnName("Sh_Fin")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.ShSew)
                    .HasColumnName("Sh_Sew")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Ship).HasColumnType("datetime");

                entity.Property(e => e.ShipDate)
                    .HasColumnName("Ship_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmpPost)
                    .HasColumnName("SMP_Post")
                    .HasMaxLength(1);

                entity.Property(e => e.Tgl).HasColumnType("datetime");

                entity.Property(e => e.Tgled).HasColumnType("datetime");

                entity.Property(e => e.Tglin).HasColumnType("datetime");

                entity.Property(e => e.Usered).HasMaxLength(30);

                entity.Property(e => e.Userin).HasMaxLength(30);

                entity.Property(e => e.Valas).HasMaxLength(3);

                entity.Property(e => e.Valid).HasMaxLength(1);

                entity.Property(e => e.Ws).HasColumnType("decimal(12, 2)");
            });
        }
    }
}
