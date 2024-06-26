﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.EFCoreTransactionSample.DbService.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("Tbl_Order");

            entity.Property(e => e.OrderId).HasMaxLength(50);
            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId);

            entity.ToTable("Tbl_Order_Detail");

            entity.Property(e => e.OrderDetailId).HasMaxLength(50);
            entity.Property(e => e.OrderId).HasMaxLength(50);
            entity.Property(e => e.PricePerItem).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductCode).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
