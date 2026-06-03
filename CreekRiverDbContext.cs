using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 1, Nickname = "Cumberland Mountain State Park", ImageUrl="https://tnstateparks.com/sites/default/files/styles/portrait_2_3_320x480_1x/public/2025-08/cumberland-mountain-bridge-fall.webp?itok=wlxiIIin"},
        new Campsite {Id = 3, CampsiteTypeId = 2, Nickname = "Fall Creek Falls", ImageUrl="https://tnstateparks.com/sites/default/files/styles/hero/public/2025-11/fall-creek-falls-waterfall-hero.jpg?itok=qZ0JbTEr"},
        new Campsite {Id = 4, CampsiteTypeId = 2, Nickname = "Bledsoe Creek State Park", ImageUrl="https://tnstateparks.com/sites/default/files/styles/hero/public/2025-09/Bledsoe-Highlight-Lake-Sunset_0.webp?itok=pzkozplk"},
        new Campsite {Id = 5, CampsiteTypeId = 3, Nickname = "Mousetail Landing State Park", ImageUrl="https://cdn.crowdriff.com/in-use/a8a71c64-c0da-6f2d-22cc-a8efdc53b76b/1080.jpg"},
        new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "Henry Horton State Park", ImageUrl="https://cdn.crowdriff.com/in-use/79fcb82a-04e3-60ed-b3d4-18e3569bcddb/1080.jpg"}
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
        new UserProfile {Id = 1, FirstName = "Brian", LastName = "Fuzzell", Email = "hibrian@aol.com"},    
        });
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
        new Reservation {Id = 1, CampsiteId = 3, UserProfileId = 1, CheckinDate = new DateTime(2026, 07, 03), CheckoutDate = new DateTime(2026, 07, 05)},
        new Reservation {Id = 2, CampsiteId = 4, UserProfileId = 1, CheckinDate = new DateTime(2026, 08, 01), CheckoutDate = new DateTime(2026, 08, 03)}   
        });
    }
}