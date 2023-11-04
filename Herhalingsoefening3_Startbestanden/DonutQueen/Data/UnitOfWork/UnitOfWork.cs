using DonutQueen.Data.Repository;
using DonutQueen.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DonutQueen.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DonutQueenContext _context;
        public IRepository<Donut> DonutRepository { get; }
        public IRepository<Winkel> WinkelRepository { get; }

        public UnitOfWork(DonutQueenContext context)
        {
            _context = context;
            DonutRepository = new Repository<Donut>(_context);
            WinkelRepository = new Repository<Winkel>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}