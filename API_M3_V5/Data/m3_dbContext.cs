using Microsoft.EntityFrameworkCore;
using API_M3_V5.Models;

namespace API_M3_V5.Data
{
    public partial class m3_dbContext : DbContext
    {
        public m3_dbContext()
        {
        }

        public m3_dbContext(DbContextOptions<m3_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Budget> Budgets { get; set; } = null!;
        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientView> ClientViews { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeView> EmployeeViews { get; set; } = null!;
        public virtual DbSet<Entity> Entities { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceOrder> ServiceOrders { get; set; } = null!;
        public virtual DbSet<ServiceTypeDetail> ServiceTypeDetails { get; set; } = null!;
        public virtual DbSet<ServiceView> ServiceViews { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierView> SupplierViews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        
                optionsBuilder.UseSqlServer("Server=tcp:m3-server.database.windows.net,1433;Initial Catalog=m3_db;Persist Security Info=False;User ID=UserExample;Password=passwordExample;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK_admin");

                entity.ToTable("administrator");

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_ad");
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("budget");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BudgetReport)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("budget_report");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SBudget");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("business");

                entity.HasIndex(e => e.BusinessId, "idx_business");

                entity.HasIndex(e => e.LocationId, "idx_business_location");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.Addressline)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("addressline");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("business_name");

                entity.Property(e => e.BusinessType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("business_type");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entity_b");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_location_b");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.HasIndex(e => e.ClientId, "idx_client");

                entity.HasIndex(e => e.PersonId, "idx_client_person");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_c");
            });

            modelBuilder.Entity<ClientView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("client_view");

                entity.Property(e => e.Addressline)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("addressline");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.District)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.EmployeeId, "idx_employee");

                entity.HasIndex(e => e.PersonId, "idx_employee_person");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_e");
            });

            modelBuilder.Entity<EmployeeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("employee_view");

                entity.Property(e => e.Addressline)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("addressline");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.District)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("entity");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.EntityType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("entity_type");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.HistoryId).HasColumnName("history_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Report)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("report");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.TimeConsumption).HasColumnName("time_consumption");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_h");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_h");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.HasIndex(e => e.ItemId, "idx_item");

                entity.HasIndex(e => e.SupplierId, "idx_item_supplier");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemQty).HasColumnName("item_qty");

                entity.Property(e => e.ItemRef)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("item_ref");

                entity.Property(e => e.PartNumber)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("part_number");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("date")
                    .HasColumnName("received_date");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("date")
                    .HasColumnName("ship_date");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_supplier_i");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.HasIndex(e => e.LocationId, "idx_location");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.District)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("district");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.PersonId, "idx_person");

                entity.HasIndex(e => e.LocationId, "idx_person_location");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Addressline)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("addressline");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entity");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_location");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.HasIndex(e => e.ServiceId, "idx_service");

                entity.HasIndex(e => e.ClientId, "idx_service_client");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Observations)
                    .HasMaxLength(256)
                    .HasColumnName("observations")
                    .IsFixedLength();

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_type");
            });

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_order");

                entity.ToTable("service_order");

                entity.HasIndex(e => e.ServiceId, "idx_oder_service");

                entity.HasIndex(e => e.OrderId, "idx_order");

                entity.HasIndex(e => e.ItemId, "idx_order_item");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.OrderAmount).HasColumnName("order_amount");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderQty).HasColumnName("order_qty");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.ReceptionDate)
                    .HasColumnType("date")
                    .HasColumnName("reception_date");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ServiceOrders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_item_o");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceOrders)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_o");
            });

            modelBuilder.Entity<ServiceTypeDetail>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_type");

                entity.ToTable("service_type_detail");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Type)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<ServiceView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("service_view");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Observations)
                    .HasMaxLength(256)
                    .HasColumnName("observations")
                    .IsFixedLength();

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.HasIndex(e => e.SupplierId, "idx_supplier");

                entity.HasIndex(e => e.BusinessId, "idx_supplier_business");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.DeliveryAverage).HasColumnName("delivery_average");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bussiness_s");
            });

            modelBuilder.Entity<SupplierView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("supplier_view");

                entity.Property(e => e.Addressline)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("addressline");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("business_name");

                entity.Property(e => e.BusinessType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("business_type");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.DeliveryAverage).HasColumnName("delivery_average");

                entity.Property(e => e.District)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("zipcode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
