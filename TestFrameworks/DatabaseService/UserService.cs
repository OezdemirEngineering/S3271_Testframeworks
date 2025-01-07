// Copyright (c) OEENG 2025 - All rights reserved.

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.DatabaseService;

public class UserService
{
    private readonly TestDbContext _context;
    public UserService(TestDbContext context)
    {
        _context = context;
    }
    public void AddUser(UserDto user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public UserDto GetUser(int id)
    {
        return _context.Users.SingleOrDefault(u => u.Id == id);
    }
}
