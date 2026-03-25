using System;
using System.Collections.Generic;
using Back_EndAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRole1> AspNetRoles1 { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetRoleClaim1> AspNetRoleClaims1 { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUser1> AspNetUsers1 { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserClaim1> AspNetUserClaims1 { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserLogin1> AspNetUserLogins1 { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<AspNetUserToken1> AspNetUserTokens1 { get; set; }

    public virtual DbSet<Audience> Audiences { get; set; }

    public virtual DbSet<Audiencecategory> Audiencecategories { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Ballot> Ballots { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Categorizedaudience> Categorizedaudiences { get; set; }

    public virtual DbSet<Categorizedjoke> Categorizedjokes { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Commitlog> Commitlogs { get; set; }

    public virtual DbSet<CskElection> CskElections { get; set; }

    public virtual DbSet<Currentinventory> Currentinventories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deliveredjoke> Deliveredjokes { get; set; }

    public virtual DbSet<DumpClassSharedRo> DumpClassSharedRos { get; set; }

    public virtual DbSet<Election> Elections { get; set; }

    public virtual DbSet<ElectionTest> ElectionTests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Female> Females { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<HarryJidapaTesting> HarryJidapaTestings { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Invoiceline> Invoicelines { get; set; }

    public virtual DbSet<Joke> Jokes { get; set; }

    public virtual DbSet<Jokecategory> Jokecategories { get; set; }

    public virtual DbSet<Jokereactioncategory> Jokereactioncategories { get; set; }

    public virtual DbSet<Male> Males { get; set; }

    public virtual DbSet<Mediatype> Mediatypes { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonHj> PersonHjs { get; set; }

    public virtual DbSet<PersonRegistered> PersonRegistereds { get; set; }

    public virtual DbSet<PersonRegisteredRoundGroup> PersonRegisteredRoundGroups { get; set; }

    public virtual DbSet<PersonRegisteredRoundGroupTest> PersonRegisteredRoundGroupTests { get; set; }

    public virtual DbSet<PersonRegisteredTest> PersonRegisteredTests { get; set; }

    public virtual DbSet<PersonTest> PersonTests { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Profitperitem> Profitperitems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<RoundGroup> RoundGroups { get; set; }

    public virtual DbSet<RoundGroupTest> RoundGroupTests { get; set; }

    public virtual DbSet<StoreCheckout> StoreCheckouts { get; set; }

    public virtual DbSet<StoreCheckoutItem> StoreCheckoutItems { get; set; }

    public virtual DbSet<StoreCustomer> StoreCustomers { get; set; }

    public virtual DbSet<StoreEmployee> StoreEmployees { get; set; }

    public virtual DbSet<StoreItem> StoreItems { get; set; }

    public virtual DbSet<StoreOrder> StoreOrders { get; set; }

    public virtual DbSet<StoreOrderItem> StoreOrderItems { get; set; }

    public virtual DbSet<StoreSupplier> StoreSuppliers { get; set; }

    public virtual DbSet<Surname> Surnames { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<UserElectionRole> UserElectionRoles { get; set; }

    public virtual DbSet<VoteRank> VoteRanks { get; set; }

    public virtual DbSet<VoteSubmission> VoteSubmissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Albumid).HasName("idx_16944_ipk_album");

            entity.Property(e => e.Albumid).ValueGeneratedNever();

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums).HasConstraintName("album_artistid_fkey");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("announcement_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Visibility).HasDefaultValueSql("'public'::character varying");

            entity.HasOne(d => d.Election).WithMany(p => p.Announcements).HasConstraintName("announcement_election_id_fkey");

            entity.HasOne(d => d.PostedByUser).WithMany(p => p.Announcements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("announcement_posted_by_user_id_fkey");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Artistid).HasName("idx_16950_ipk_artist");

            entity.Property(e => e.Artistid).ValueGeneratedNever();
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.BirthDate).HasDefaultValueSql("'-infinity'::date");
            entity.Property(e => e.PostalCode).HasDefaultValueSql("''::text");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUser1>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole1",
                    r => r.HasOne<AspNetRole1>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser1>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles", "f25election");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Audience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audience_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Audiencecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audiencecategory_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audit_log_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsPublic).HasDefaultValue(true);

            entity.HasOne(d => d.Election).WithMany(p => p.AuditLogs).HasConstraintName("audit_log_election_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs).HasConstraintName("audit_log_user_id_fkey");
        });

        modelBuilder.Entity<Ballot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ballot_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasOne(d => d.ColorNavigation).WithMany().HasConstraintName("cars_color_fkey");
        });

        modelBuilder.Entity<Categorizedaudience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedaudience_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Audiencecategory).WithMany(p => p.Categorizedaudiences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audiencecategoryid_fkey");

            entity.HasOne(d => d.Audience).WithMany(p => p.Categorizedaudiences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audienceid_fkey");
        });

        modelBuilder.Entity<Categorizedjoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedjoke_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Jokecategory).WithMany(p => p.Categorizedjokes).HasConstraintName("categorizedjoke_jokecategoryid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.Categorizedjokes).HasConstraintName("categorizedjoke_jokeid_fkey");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("color_pkey");
        });

        modelBuilder.Entity<Commitlog>(entity =>
        {
            entity.HasKey(e => new { e.Project, e.Hash }).HasName("commitlog_pkey");
        });

        modelBuilder.Entity<CskElection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("csk_election_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Currentinventory>(entity =>
        {
            entity.ToView("currentinventory");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("idx_16956_ipk_customer");

            entity.Property(e => e.Customerid).ValueGeneratedNever();

            entity.HasOne(d => d.Supportrep).WithMany(p => p.Customers).HasConstraintName("customer_supportrepid_fkey");
        });

        modelBuilder.Entity<Deliveredjoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deliveredjoke_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Delivereddate).HasDefaultValueSql("CURRENT_DATE");

            entity.HasOne(d => d.Audience).WithMany(p => p.Deliveredjokes).HasConstraintName("deliveredjoke_audienceid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.Deliveredjokes).HasConstraintName("deliveredjoke_jokeid_fkey");

            entity.HasOne(d => d.Jokereaction).WithMany(p => p.Deliveredjokes).HasConstraintName("deliveredjoke_jokereactionid_fkey");
        });

        modelBuilder.Entity<Election>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("election_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<ElectionTest>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("idx_16962_ipk_employee");

            entity.Property(e => e.Employeeid).ValueGeneratedNever();

            entity.HasOne(d => d.ReportstoNavigation).WithMany(p => p.InverseReportstoNavigation).HasConstraintName("employee_reportsto_fkey");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_role_pkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeRoles).HasConstraintName("employee_role_employee_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.EmployeeRoles).HasConstraintName("employee_role_role_id_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Genreid).HasName("idx_16968_ipk_genre");

            entity.Property(e => e.Genreid).ValueGeneratedNever();
        });

        modelBuilder.Entity<HarryJidapaTesting>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Zipcode).IsFixedLength();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Invoiceid).HasName("idx_16974_ipk_invoice");

            entity.Property(e => e.Invoiceid).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices).HasConstraintName("invoice_customerid_fkey");
        });

        modelBuilder.Entity<Invoiceline>(entity =>
        {
            entity.HasKey(e => e.Invoicelineid).HasName("idx_16980_ipk_invoiceline");

            entity.Property(e => e.Invoicelineid).ValueGeneratedNever();

            entity.HasOne(d => d.Invoice).WithMany(p => p.Invoicelines).HasConstraintName("invoiceline_invoiceid_fkey");

            entity.HasOne(d => d.Track).WithMany(p => p.Invoicelines).HasConstraintName("invoiceline_trackid_fkey");
        });

        modelBuilder.Entity<Joke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("joke_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Jokecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokecategory_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Jokereactioncategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokereactioncategory_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Mediatype>(entity =>
        {
            entity.HasKey(e => e.Mediatypeid).HasName("idx_16986_ipk_mediatype");

            entity.Property(e => e.Mediatypeid).ValueGeneratedNever();
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permission_pkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Zipcode).IsFixedLength();
        });

        modelBuilder.Entity<PersonHj>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Zipcode).IsFixedLength();
        });

        modelBuilder.Entity<PersonRegistered>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_registered_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Election).WithMany(p => p.PersonRegistereds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_registered_election_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonRegistereds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_registered_person_id_fkey");
        });

        modelBuilder.Entity<PersonRegisteredRoundGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_person_reg_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.PersonReg).WithMany(p => p.PersonRegisteredRoundGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("group_person_reg_person_reg_id_fkey");

            entity.HasOne(d => d.RoundGroup).WithMany(p => p.PersonRegisteredRoundGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("group_person_reg_round_group_id_fkey");
        });

        modelBuilder.Entity<PersonRegisteredRoundGroupTest>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<PersonRegisteredTest>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<PersonTest>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Zipcode).IsFixedLength();
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.Playlistid).HasName("idx_16992_ipk_playlist");

            entity.Property(e => e.Playlistid).ValueGeneratedNever();

            entity.HasMany(d => d.Tracks).WithMany(p => p.Playlists)
                .UsingEntity<Dictionary<string, object>>(
                    "Playlisttrack",
                    r => r.HasOne<Track>().WithMany()
                        .HasForeignKey("Trackid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("playlisttrack_trackid_fkey"),
                    l => l.HasOne<Playlist>().WithMany()
                        .HasForeignKey("Playlistid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("playlisttrack_playlistid_fkey"),
                    j =>
                    {
                        j.HasKey("Playlistid", "Trackid").HasName("idx_16998_ipk_playlisttrack");
                        j.ToTable("playlisttrack", "chinook");
                        j.HasIndex(new[] { "Trackid" }, "idx_16998_ifk_playlisttracktrackid");
                        j.HasIndex(new[] { "Playlistid", "Trackid" }, "idx_16998_sqlite_autoindex_playlisttrack_1").IsUnique();
                        j.IndexerProperty<long>("Playlistid").HasColumnName("playlistid");
                        j.IndexerProperty<long>("Trackid").HasColumnName("trackid");
                    });
        });

        modelBuilder.Entity<Profitperitem>(entity =>
        {
            entity.ToView("profitperitem");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_permission_pkey");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions).HasConstraintName("role_permission_permission_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions).HasConstraintName("role_permission_role_id_fkey");
        });

        modelBuilder.Entity<RoundGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("round_group_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Election).WithMany(p => p.RoundGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("round_group_election_id_fkey");

            entity.HasOne(d => d.Observer).WithMany(p => p.RoundGroups).HasConstraintName("round_group_observer_id_fkey");
        });

        modelBuilder.Entity<RoundGroupTest>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<StoreCheckout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_checkout_pkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.StoreCheckouts).HasConstraintName("store_checkout_customerid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.StoreCheckouts).HasConstraintName("store_checkout_employeeid_fkey");
        });

        modelBuilder.Entity<StoreCheckoutItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_checkout_item_pkey");

            entity.HasOne(d => d.Checkout).WithMany(p => p.StoreCheckoutItems).HasConstraintName("store_checkout_item_checkoutid_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.StoreCheckoutItems).HasConstraintName("store_checkout_item_itemid_fkey");
        });

        modelBuilder.Entity<StoreCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_customer_pkey");
        });

        modelBuilder.Entity<StoreEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_employee_pkey");
        });

        modelBuilder.Entity<StoreItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_item_pkey");
        });

        modelBuilder.Entity<StoreOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_order_pkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StoreOrders).HasConstraintName("store_order_supplierid_fkey");
        });

        modelBuilder.Entity<StoreOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_item_order_pkey");

            entity.HasOne(d => d.Item).WithMany(p => p.StoreOrderItems).HasConstraintName("store_item_order_itemid_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.StoreOrderItems).HasConstraintName("store_item_order_orderid_fkey");
        });

        modelBuilder.Entity<StoreSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_supplier_pkey");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Trackid).HasName("idx_17001_ipk_track");

            entity.Property(e => e.Trackid).ValueGeneratedNever();

            entity.HasOne(d => d.Album).WithMany(p => p.Tracks).HasConstraintName("track_albumid_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.Tracks).HasConstraintName("track_genreid_fkey");

            entity.HasOne(d => d.Mediatype).WithMany(p => p.Tracks).HasConstraintName("track_mediatypeid_fkey");
        });

        modelBuilder.Entity<UserElectionRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_election_role_pkey");

            entity.Property(e => e.JoinedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Status).HasDefaultValueSql("'active'::character varying");

            entity.HasOne(d => d.Election).WithMany(p => p.UserElectionRoles).HasConstraintName("user_election_role_election_id_fkey");

            entity.HasOne(d => d.InvitedByUser).WithMany(p => p.UserElectionRoleInvitedByUsers).HasConstraintName("user_election_role_invited_by_user_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserElectionRoleUsers).HasConstraintName("user_election_role_user_id_fkey");
        });

        modelBuilder.Entity<VoteRank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vote_rank_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Submission).WithMany(p => p.VoteRanks).HasConstraintName("vote_rank_submission_id_fkey");

            entity.HasOne(d => d.TargetPrrg).WithMany(p => p.VoteRanks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vote_rank_target_prrg_id_fkey");
        });

        modelBuilder.Entity<VoteSubmission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vote_submission_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.SubmittedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.RoundGroup).WithMany(p => p.VoteSubmissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vote_submission_round_group_id_fkey");

            entity.HasOne(d => d.VoterPersonReg).WithMany(p => p.VoteSubmissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vote_submission_voter_person_reg_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
