// Copyright (c) OEENG 2025 - All rights reserved.

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.DatabaseService;
public class TestDbContext : DbContext
{
    public DbSet<UserDto> Users { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
}
