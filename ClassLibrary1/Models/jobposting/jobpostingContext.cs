﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary1.Models.jobposting
{
    public partial class jobpostingContext : DbContext
    {
        public jobpostingContext()
        {
        }

        public jobpostingContext(DbContextOptions<jobpostingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobPosting> JobPostings { get; set; }
        public virtual DbSet<JobPostingCandidature> JobPostingCandidatures { get; set; }
        public virtual DbSet<JobPostingFiltroProvince> JobPostingFiltroProvinces { get; set; }
        public virtual DbSet<JobPostingRequisiti> JobPostingRequisitis { get; set; }
        public virtual DbSet<JobPostingRequisitiComuni> JobPostingRequisitiComunis { get; set; }
        public virtual DbSet<JobPostingRequisitiContratti> JobPostingRequisitiContrattis { get; set; }
        public virtual DbSet<JobPostingRequisitiLivelli> JobPostingRequisitiLivellis { get; set; }
        public virtual DbSet<JobPostingRequisitiProvince> JobPostingRequisitiProvinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=;User ID=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPosting>(entity =>
            {
                entity.ToTable("JobPosting");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataFine).HasColumnType("datetime");

                entity.Property(e => e.DataFineGestori).HasColumnType("datetime");

                entity.Property(e => e.DataInizio).HasColumnType("datetime");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Idfunzione)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("IDFunzione");

                entity.Property(e => e.Idsocieta).HasColumnName("IDSocieta");

                entity.Property(e => e.IdtipoProgetto).HasColumnName("IDTipoProgetto");

                entity.Property(e => e.Pdfannuncio).HasColumnName("PDFAnnuncio");

                entity.Property(e => e.Riferimento).HasMaxLength(50);
            });

            modelBuilder.Entity<JobPostingCandidature>(entity =>
            {
                entity.HasKey(e => new { e.IdjobPosting, e.Idpersonale });

                entity.ToTable("JobPostingCandidature");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idpersonale).HasColumnName("IDPersonale");

                entity.Property(e => e.DataCandidatura).HasColumnType("datetime");

                entity.Property(e => e.DataColloquioRu)
                    .HasColumnType("datetime")
                    .HasColumnName("DataColloquioRU");

                entity.Property(e => e.DataColloquioTecnico).HasColumnType("datetime");

                entity.Property(e => e.DataDecorrenzaTrasferimento).HasColumnType("date");

                entity.Property(e => e.DataUltimaModifica).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmailRinuncia).HasMaxLength(50);

                entity.Property(e => e.Idcomune)
                    .HasMaxLength(4)
                    .HasColumnName("IDComune");

                entity.Property(e => e.IdesitoColloquio).HasColumnName("IDEsitoColloquio");

                entity.Property(e => e.IdesitoColloquioTecnico).HasColumnName("IDEsitoColloquioTecnico");

                entity.Property(e => e.IdesitoJobPosting).HasColumnName("IDEsitoJobPosting");

                entity.Property(e => e.IdesitoSelezione).HasColumnName("IDEsitoSelezione");

                entity.Property(e => e.Idfabbisogno).HasColumnName("IDFabbisogno");

                entity.Property(e => e.Idprovincia)
                    .HasMaxLength(2)
                    .HasColumnName("IDProvincia");

                entity.Property(e => e.IdsysUtenteUltimaModifica)
                    .HasMaxLength(20)
                    .HasColumnName("IDSysUtenteUltimaModifica");

                entity.Property(e => e.IdtitoloStudio)
                    .HasMaxLength(20)
                    .HasColumnName("IDTitoloStudio");

                entity.Property(e => e.NoteColloquioRu).HasColumnName("NoteColloquioRU");

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<JobPostingFiltroProvince>(entity =>
            {
                entity.HasKey(e => new { e.IdjobPosting, e.Idprovincia });

                entity.ToTable("JobPostingFiltroProvince");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idprovincia)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IDProvincia");
            });

            modelBuilder.Entity<JobPostingRequisiti>(entity =>
            {
                entity.ToTable("JobPostingRequisiti");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdcampoBypass).HasColumnName("IDCampoBypass");

                entity.Property(e => e.IdcategoriaPunteggio).HasColumnName("IDCategoriaPunteggio");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idrequisito).HasColumnName("IDRequisito");

                entity.Property(e => e.MsgMancatoReq).IsUnicode(false);

                entity.Property(e => e.RequisitoAl).HasColumnType("date");

                entity.Property(e => e.Valore).IsUnicode(false);
            });

            modelBuilder.Entity<JobPostingRequisitiComuni>(entity =>
            {
                entity.HasKey(e => new { e.IdjobPosting, e.Idcomune });

                entity.ToTable("JobPostingRequisitiComuni");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idcomune)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDComune");
            });

            modelBuilder.Entity<JobPostingRequisitiContratti>(entity =>
            {
                entity.HasKey(e => new { e.IdjobPosting, e.Idcontratto, e.IdtipoPersonale })
                    .HasName("PK_JobPostingRequisitiContratto");

                entity.ToTable("JobPostingRequisitiContratti");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idcontratto).HasColumnName("IDContratto");

                entity.Property(e => e.IdtipoPersonale)
                    .HasMaxLength(20)
                    .HasColumnName("IDTipoPersonale");
            });

            modelBuilder.Entity<JobPostingRequisitiLivelli>(entity =>
            {
                entity.HasKey(e => new { e.IdjobPosting, e.Idcontratto, e.Idlivello });

                entity.ToTable("JobPostingRequisitiLivelli");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idcontratto).HasColumnName("IDContratto");

                entity.Property(e => e.Idlivello).HasColumnName("IDLivello");
            });

            modelBuilder.Entity<JobPostingRequisitiProvince>(entity =>
            {
                entity.HasKey(e => new { e.IdjobPosting, e.Idprovincia });

                entity.ToTable("JobPostingRequisitiProvince");

                entity.Property(e => e.IdjobPosting).HasColumnName("IDJobPosting");

                entity.Property(e => e.Idprovincia)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IDProvincia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}