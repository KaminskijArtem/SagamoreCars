using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SagamoreCarsDAL
{
    public class SagamoreCarsDBContext : DbContext
    {
        public SagamoreCarsDBContext(DbContextOptions<SagamoreCarsDBContext> options)
            : base(options)
        {
        }

        public DbSet<CarAd> CarAd { get; set; }
    }
}
