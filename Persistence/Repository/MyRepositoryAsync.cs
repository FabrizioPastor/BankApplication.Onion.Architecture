using Application.Interface;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository;

public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    
    public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}