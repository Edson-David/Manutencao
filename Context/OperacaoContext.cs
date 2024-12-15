using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manutencao.Entities;
using Microsoft.EntityFrameworkCore;

namespace Operacao.Context
{
    public class OperacaoContext : DbContext
    {
        public OperacaoContext(DbContextOptions<OperacaoContext> options) : base(options)
        {

        }

        public DbSet<Reparo> Reparos { get; set; }
    }
}