using DAL.Repositories;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDeveloperRepository Developers { get; }
        IProjectRepository Projects { get; }
        int Complete();
    }
}