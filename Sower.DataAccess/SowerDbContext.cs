using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Sower.Model;

namespace Sower.DataAccess
{
    /// <summary>
    /// 数据上下文
    /// <remarks>创建：2015.09.18</remarks>
    /// </summary>
    public class SowerDbContext : DbContext
    {
        public DbSet<T_AverageUser> AverageUsers { get; set; }
        public DbSet<T_LearnCard> LearnCards { get; set; }
        public DbSet<T_ActionLog> ActionLog { get; set; }

        public SowerDbContext()
            : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }
    }
}
