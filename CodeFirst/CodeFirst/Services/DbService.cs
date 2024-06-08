using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class DbService : IDbService
{
    
    private readonly ApplicationContext _context;
    
    public DbService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetPatient(int id)
    {
        return await _context.Patients.Where(e => e.IdPatient == id).ToListAsync();
    }
}