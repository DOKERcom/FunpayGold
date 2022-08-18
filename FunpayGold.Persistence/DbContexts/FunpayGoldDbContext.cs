﻿using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FunpayGold.Persistence.DbContexts;

public sealed class FunpayGoldDbContext : IdentityDbContext<UserEntity>
{
    public new DbSet<UserEntity> Users { get; set; }

    public DbSet<TaskEntity> Tasks { get; set; }

    public FunpayGoldDbContext(
        DbContextOptions<FunpayGoldDbContext> options, 
        DbSet<UserEntity> users,
        DbSet<TaskEntity> tasks
        ) : base(options)
    {
        Users = users;

        Tasks = tasks;

        Database.EnsureCreated();
    }
}