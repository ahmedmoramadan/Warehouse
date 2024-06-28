using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading;

namespace WarehouseProject.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<AlternativeItem> AlternativeItems { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<RequiredItem> RequiredItems { get; set; }
        public DbSet<RequiredItemOffer> RequiredItemOffers { get; set; }
        public DbSet<SelectionCommittee> SelectionCommittees { get; set; }
        public DbSet<SelectionCommitteeMember> SelectionCommitteeMembers { get; set; }
        public DbSet<SpecifictionCommittee> SpecifictionCommittees { get; set; }
        public DbSet<SpecifictionCommitteeMember> SpecifictionCommitteeMembers { get; set; }
        public DbSet<TechnicalCommittee> TechnicalCommittees { get; set; }
        public DbSet<TechnicalCommitteeMember> TechnicalCommitteeMembers { get; set; }
        public DbSet<SpecifictionTechnicalCommittee> specifictionTechnicalCommittees { get; set; }
        public DbSet<SpecifictionTechnicalCommitteeMember> specifictionTechnicalCommitteeMembers { get; set; }
        public DbSet<ExpireCommittee> expireCommittees { get; set; }
        public DbSet<ExpireCommitteeMember> expireCommitteeMembers { get; set; }
        public DbSet<ReciveCommittee> reciveCommittees { get; set; }
        public DbSet<ReciveCommitteeMember> reciveCommitteeMembers { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<CovenantItem> covenantItems { get; set; }
        public DbSet<ReceivedItem> ReceivedItems { get; set; }
        public DbSet<Receiveprocces> ReceiveProcces { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<ExpiritionProcces> ExpiritionProcces { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelectionCommitteeMember>().HasKey(x => new { x.MemberId, x.SelectionCommitteeId });
            modelBuilder.Entity<SpecifictionCommitteeMember>().HasKey(x => new { x.MemberId, x.SpecifictionCommitteeId });
            modelBuilder.Entity<TechnicalCommitteeMember>().HasKey(x => new { x.MemberId, x.TechnicalCommitteeId });
            modelBuilder.Entity<SpecifictionTechnicalCommitteeMember>().HasKey(x => new { x.MemberId, x.SpecifictionTechnicalCommitteeId });
            modelBuilder.Entity<ExpireCommitteeMember>().HasKey(x => new { x.MemberId, x.ExpireCommitteeId });
            modelBuilder.Entity<ReciveCommitteeMember>().HasKey(x => new { x.MemberId, x.ReciveCommitteeId });
            modelBuilder.Entity<RequiredItemOffer>().HasKey(x => new { x.OfferId, x.RequiredItemId });
            modelBuilder.Entity<Tender>().HasKey(x => x.Id);
            modelBuilder.Entity<Entity>().HasData(new Entity[]
            {
                new Entity { Id = 1  , Name= "Faculty of Engineering, Shoubra"},
                new Entity { Id = 2  , Name= "Faculty of Medicine"},
                new Entity { Id = 3  , Name= "Faculty of Veterinary Medicine"},
                new Entity { Id = 4  , Name= "Faculty of Science"},
                new Entity { Id = 5  , Name= "Faculty of Agriculture"},
                new Entity { Id = 6  , Name= "Faculty of Commerce"},
                new Entity { Id = 7  , Name= "Faculty of Education"},
                new Entity { Id = 8  , Name= "Faculty of Law"},
                new Entity { Id = 9  , Name= "Faculty of Arts"},
                new Entity { Id = 10 , Name= "Faculty of Physical Education"},
                new Entity { Id = 11 , Name= "Faculty of Nursing"},
                new Entity { Id = 12 , Name= "Faculty of Specific Education"},
                new Entity { Id = 13 , Name= "Faculty of Computers and Artificial Intelligence"},
                new Entity { Id = 14 , Name= "Faculty of Applied Arts"},
                new Entity { Id = 15 , Name= "Faculty of Engineering, Benha"},
                new Entity { Id = 16 , Name= "Faculty of Al - Alsun(Languages)"},
                new Entity { Id = 17 , Name= "Faculty of Biotechnology"},
                new Entity { Id = 18 , Name= "Faculty of Physical Therap"}

            });
            modelBuilder.Entity<Member>().HasData(new Member[]
            {
                new Member{Id=1 , Name = "Ahmed Mohamed"       , Password="Ahmed000@111"   , PhoneNumber = "01142003939" },
                new Member{Id=2 , Name = "Ahmed Shapaan"       , Password="Ahmed000@111"   , PhoneNumber = "01252003939" },
                new Member{Id=3 , Name = "Ahmed Tamer"         , Password="Ahmed000@111"   , PhoneNumber = "01542213939" },
                new Member{Id=4 , Name = "Safwa Mohamed"       , Password="Safwa000@111"   , PhoneNumber = "01142006739" },
                new Member{Id=5 , Name = "Sohila Amr"          , Password="Sohila000@111"  , PhoneNumber = "01142003955" },
                new Member{Id=6 , Name = "Yasmine Abdelrhman"  ,Password="Yasmine000@111"  , PhoneNumber = "01142004439" },
                new Member{Id=7 , Name = "Zaid Adel"            , Password="Zaid000@111"   , PhoneNumber = "01042223939" },
                new Member{Id=8 , Name = "Amal Sabry"           , Password="Amal000@111"   , PhoneNumber = "01242003933" },
                new Member{Id=9 , Name = "Dr Tarek Elsheshtawy"    , Password="Tarek000@111"  , PhoneNumber = "01123458983" },
                new Member{Id=10 , Name = "Eng Amainy Saaed"       , Password="Amainy000@111" , PhoneNumber = "01242234939" },
                new Member{Id=11 , Name = "Dr Fady"                , Password="Fady000@111"  , PhoneNumber = "01542003939" },
                new Member{Id=12 , Name = "Dr Mohamed Abdelfataah" ,Password="Mohamed000@111" , PhoneNumber = "01142003939" },
                new Member{Id=13 , Name = "Dr Karam"               , Password="Ahmed000@111" , PhoneNumber = "01242002109" },
                new Member{Id=14 , Name = "Dr Ahmed Shalaby"       , Password="Ahmed000@111"  , PhoneNumber = "01240000039" },
                new Member{Id=15 , Name = "Dr Ahmed Taha"          , Password="Ahmed000@111"  , PhoneNumber = "01011200121" },
                new Member{Id=16 , Name = "Mahmmud Ghonam"                                 , PhoneNumber = "01241100023"},
                new Member{Id=17 , Name = "Rayan Ghonam"                                   , PhoneNumber = "01242200067"},
                new Member{Id=18 , Name = "Yousef Hiatham"                                 , PhoneNumber = "01244400000"},
                new Member{Id=19 , Name = "Ahmed Hosny"                                    , PhoneNumber = "01246700048"},
                new Member{Id=20 , Name = "Mohamed agami"                                  , PhoneNumber = "01242400000"},
                new Member{Id=21 , Name = "mahmoud roqa"                                   , PhoneNumber = "01296700048"}
            });
            modelBuilder.Entity<Vendor>().HasData(new Vendor[]
           {
                new Vendor{id=1 , Name = "microsystem"   , number = "01142003939" },
                new Vendor{id=2 , Name = "Arab Business" , number = "01252003939" },
                new Vendor{id=3 , Name = "PC Powerhouse" , number = "01542213939" },
                new Vendor{id=4 , Name = "LaptopLand"    , number = "01142006739" },
                new Vendor{id=5 , Name = "Computers Partners"     , number = "01142003955" },
                new Vendor{id=6 , Name = "ElitePC Technologies"   , number = "01142004439" },
                new Vendor{id=7 , Name = "Circuit City Computers" , number = "01042223939" },
                new Vendor{id=8 , Name = "ProPanel Partners"      , number = "01242003939" }
           });
            SeedRoles(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Warehouse_manager", NormalizedName = "WAREHOUSE_MANAGER" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Purchases_Manager", NormalizedName = "PURCHASES_MANAGER" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Specification_Head", NormalizedName = "SPECIFICATION_HEAD" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Technical_Head", NormalizedName = "TECHNICAL_HEAD" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Selection_Head", NormalizedName = "SELECTION_HEAD" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Recive_Head", NormalizedName = "RECIVE_HEAD" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "SpecificationTechnical_Head", NormalizedName = "SPECIFICATIONTECHNICAL_HEAD" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Expire_Head", NormalizedName = "EXPIRE_HEAD" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Header", NormalizedName = "HEADER" }
            ); 
        }
    }
}

