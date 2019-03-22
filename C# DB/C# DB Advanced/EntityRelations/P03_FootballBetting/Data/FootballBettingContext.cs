namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Team>(entity =>
                {
                    entity
                        .HasKey(e => e.TeamId);

                    entity
                        .HasOne(e => e.PrimaryKitColor)
                        .WithMany(pk => pk.PrimaryKitTeams)
                        .HasForeignKey(e => e.PrimaryKitColorId);

                    entity
                        .HasOne(e => e.SecondaryKitColor)
                        .WithMany(sk => sk.SecondaryKitTeams)
                        .HasForeignKey(e => e.SecondaryKitColorId);

                    entity
                        .HasOne(e => e.Town)
                        .WithMany(t => t.Teams);
                });

            builder
                .Entity<Town>(entity =>
                {
                    entity
                        .HasKey(e => e.TownId);

                    entity
                        .HasOne(e => e.Country)
                        .WithMany(c => c.Towns);
                });

            builder
                .Entity<Game>(entity =>
                {
                    entity
                        .HasKey(e => e.GameId);

                    entity
                        .HasOne(e => e.HomeTeam)
                        .WithMany(h => h.HomeGames)
                        .HasForeignKey(h => h.HomeTeamId);

                    entity
                        .HasOne(e => e.AwayTeam)
                        .WithMany(a => a.AwayGames)
                        .HasForeignKey(e => e.AwayTeamId);
                });

            builder
                .Entity<PlayerStatistic>(entity =>
                {
                    entity
                        .HasKey(e => new { e.GameId, e.PlayerId });

                    entity
                        .HasOne(e => e.Player)
                        .WithMany(p => p.PlayerStatistics)
                        .HasForeignKey(e => e.PlayerId);

                    entity
                        .HasOne(e => e.Game)
                        .WithMany(g => g.PlayerStatistics)
                        .HasForeignKey(e => e.GameId);
                });

            builder
                .Entity<Bet>()
                .Property(b => b.Prediction)
                .IsRequired();
        }
    }
}
