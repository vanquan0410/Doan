namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// OnlineShopDbContext
    /// </summary>
    public partial class OnlineShopDbContext : DbContext
    {
        /// <summary>
        /// OnlineShopDbContext
        /// </summary>
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        /// <summary>
        /// bang Abouts
        /// </summary>
        public virtual DbSet<About> Abouts { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Contacts
        /// </summary>
        public virtual DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Contents
        /// </summary>
        public virtual DbSet<Content> Contents { get; set; }

        /// <summary>
        /// ContentTags
        /// </summary>
        public virtual DbSet<ContentTag> ContentTags { get; set; }

        /// <summary>
        /// Credentials
        /// </summary>
        public virtual DbSet<Credential> Credentials { get; set; }

        /// <summary>
        /// Feedbacks
        /// </summary>
        public virtual DbSet<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Footers
        /// </summary>
        public virtual DbSet<Footer> Footers { get; set; }

        /// <summary>
        /// Languages
        /// </summary>
        public virtual DbSet<Language> Languages { get; set; }

        /// <summary>
        /// Menus
        /// </summary>
        public virtual DbSet<Menu> Menus { get; set; }

        /// <summary>
        /// MenuTypes
        /// </summary>
        public virtual DbSet<MenuType> MenuTypes { get; set; }

        /// <summary>
        /// Orders
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// OrderDetails
        /// </summary>
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// ProductCategories
        /// </summary>
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Slides
        /// </summary>
        public virtual DbSet<Slide> Slides { get; set; }

        /// <summary>
        /// SystemConfigs
        /// </summary>
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        public virtual DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// UserGroups
        /// </summary>
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);
            

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);
        }
    }
}
