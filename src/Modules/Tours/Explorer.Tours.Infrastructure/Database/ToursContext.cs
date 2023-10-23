using Explorer.Tours.Core.Domain;
﻿using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<MapObject> MapObjects { get; set; }
    public DbSet<Checkpoint> Checkpoints { get; set; }
    public DbSet<Tour> Tours {  get; set; }
    public DbSet<TourEquipment> TourEquipment { get; set; }
    public DbSet<TourPreference> TourPreference { get; set; }
    public DbSet<ReportedIssue> ReportedIssues { get; set; }

    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
    }
}