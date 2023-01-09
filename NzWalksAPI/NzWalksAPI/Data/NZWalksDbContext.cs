using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Data
{
    public class NZWalksDbContext:DbContext
    {

        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options): base (options) 
        {


        }



        /// <summary>
        /// Tabele imena
        /// </summary>
        /// 
        public DbSet<Region> Regions { get; set; }   

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }


    }
}
