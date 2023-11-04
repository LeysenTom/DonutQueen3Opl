using DonutQueen.Data.Repository;
using DonutQueen.Models;
using System.Numerics;

namespace DonutQueen.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Donut> DonutRepository { get; }
        IRepository<Winkel> WinkelRepository { get; }

        public void SaveChanges();
    }
}