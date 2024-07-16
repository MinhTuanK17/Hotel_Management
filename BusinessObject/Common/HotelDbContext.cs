using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Common
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<BookingReservation> BookingReservations { get; set; }
        public DbSet<RoomInformation> RoomInformations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HotelManagement"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.CustomerStatus).HasMaxLength(20);

            modelBuilder.Entity<Customer>().HasCheckConstraint("CK_Customer_Status", "[CustomerStatus] = 'Active' OR [CustomerStatus] = 'Deleted'");


            //Du lieu cua Customer
            modelBuilder.Entity<Customer>().HasData(
                 new Customer
                 {
                     CustomerID = 1,
                     CustomerFullName = "Nguyễn Minh Tuấn",
                     Telephone = "0941673660",
                     EmailAddress = "tuannm.dev@gmail.com",
                     CustomerBirthday = new DateOnly(2003, 11, 23),
                     CustomerStatus = "Active",
                     Password = "password123"
                 },
                   new Customer
                   {
                       CustomerID = 2,
                       CustomerFullName = "Trần Văn A",
                       Telephone = "0912345678",
                       EmailAddress = "vana.tran@example.com",
                       CustomerBirthday = new DateOnly(2000, 5, 20),
                       CustomerStatus = "Active",
                       Password = "password456"
                   },
                   new Customer
                   {
                       CustomerID = 3,
                       CustomerFullName = "Lê Thị B",
                       Telephone = "0934567890",
                       EmailAddress = "lethib@example.com",
                       CustomerBirthday = new DateOnly(1998, 8, 15),
                       CustomerStatus = "Deleted",
                       Password = "password789"
                   },
                    new Customer
                    {
                        CustomerID = 4,
                        CustomerFullName = "Phạm Quốc C",
                        Telephone = "0908765432",
                        EmailAddress = "quocc.pham@example.com",
                        CustomerBirthday = new DateOnly(1995, 12, 5),
                        CustomerStatus = "Active",
                        Password = "password321"
                    }
              );

            // Du lieu BookingReservation
            modelBuilder.Entity<BookingReservation>().Property(b => b.BookingReservationID).HasMaxLength(10);
            modelBuilder.Entity<BookingReservation>().Property(b => b.BookingStatus).HasMaxLength(20);
            modelBuilder.Entity<BookingReservation>()
                .HasCheckConstraint("CK_BookingReservation_Status", "[BookingStatus] = 'Pending' OR [BookingStatus] = 'Confirmed' OR [BookingStatus] = 'Cancelled'");


            modelBuilder.Entity<BookingReservation>().HasData(
                 new BookingReservation
                 {
                     BookingReservationID = "BOOK00001",
                     BookingDate = new DateTime(2024, 7, 1),
                     TotalPrice = 150.50m,
                     BookingStatus = "Confirmed",
                     CustomerID = 1
                 },
                 new BookingReservation
                 {
                     BookingReservationID = "BOOK00002",
                     BookingDate = new DateTime(2024, 7, 2),
                     TotalPrice = 200.00m,
                     BookingStatus = "Confirmed",
                     CustomerID = 1
                 },
                new BookingReservation
                {
                    BookingReservationID = "BOOK00003",
                    BookingDate = new DateTime(2024, 7, 3),
                    TotalPrice = 250.75m,
                    BookingStatus = "Pending",
                    CustomerID = 2
                }
            );

            //Du lieu cua RoomType
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    RoomTypeID = 1,
                    RoomTypeName = "Single",
                    TypeDescription = "A single room with one bed.",
                    TypeNote = "Ideal for solo travelers."
                },
                new RoomType
                {
                    RoomTypeID = 2,
                    RoomTypeName = "Double",
                    TypeDescription = "A double room with two beds.",
                    TypeNote = "Perfect for couples or friends."
                },
                new RoomType
                {
                    RoomTypeID = 3,
                    RoomTypeName = "Suite",
                    TypeDescription = "A luxurious suite with multiple amenities.",
                    TypeNote = "Suitable for a lavish stay."
                },
                new RoomType
                {
                    RoomTypeID = 4,
                    RoomTypeName = "Family",
                    TypeDescription = "A spacious room for families.",
                    TypeNote = "Comfortable for family stays."
                }
            );

            //Du lieu cua RoomInformation
            modelBuilder.Entity<RoomInformation>().Property(r => r.RoomID).HasMaxLength(10);
            modelBuilder.Entity<RoomInformation>().Property(r => r.RoomStatus).HasMaxLength(20);
            modelBuilder.Entity<RoomInformation>()
                .HasCheckConstraint("CK_Room_Status", "[RoomStatus] = 'Active' OR [RoomStatus] = 'Rented' OR [RoomStatus] = 'Disable'");

            modelBuilder.Entity<RoomInformation>().HasData(
                new RoomInformation
                {
                    RoomID = "ROOM1001",
                    RoomNumber = 101,
                    RoomDetailDescription = "A cozy single room with all basic amenities.",
                    RoomMaxCapacity = 1,
                    RoomPricePerDay = 250.00m,
                    RoomStatus = "Rented",
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = "ROOM1002",
                    RoomNumber = 102,
                    RoomDetailDescription = "",
                    RoomMaxCapacity = 2,
                    RoomPricePerDay = 400.00m,
                    RoomStatus = "Active",
                    RoomTypeID = 1
                }, new RoomInformation
                {
                    RoomID = "ROOM1003",
                    RoomNumber = 103,
                    RoomDetailDescription = "",
                    RoomMaxCapacity = 1,
                    RoomPricePerDay = 320.00m,
                    RoomStatus = "Active",
                    RoomTypeID = 1
                }, new RoomInformation
                {
                    RoomID = "ROOM1004",
                    RoomNumber = 104,
                    RoomDetailDescription = "",
                    RoomMaxCapacity = 5,
                    RoomPricePerDay = 500.00m,
                    RoomStatus = "Active",
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = "ROOM1005",
                    RoomNumber = 105,
                    RoomDetailDescription = "",
                    RoomMaxCapacity = 4,
                    RoomPricePerDay = 470.00m,
                    RoomStatus = "Active",
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = "ROOM2001",
                    RoomNumber = 201,
                    RoomDetailDescription = "A spacious double room with a beautiful view.",
                    RoomMaxCapacity = 3,
                    RoomPricePerDay = 550.00m,
                    RoomStatus = "Active",
                    RoomTypeID = 2
                },
                 new RoomInformation
                 {
                     RoomID = "ROOM2002",
                     RoomNumber = 202,
                     RoomDetailDescription = "",
                     RoomMaxCapacity = 1,
                     RoomPricePerDay = 250.00m,
                     RoomStatus = "Rented",
                     RoomTypeID = 2
                 },
                 new RoomInformation
                 {
                     RoomID = "ROOM2003",
                     RoomNumber = 203,
                     RoomDetailDescription = "",
                     RoomMaxCapacity = 3,
                     RoomPricePerDay = 385.00m,
                     RoomStatus = "Active",
                     RoomTypeID = 2
                 },
                new RoomInformation
                {
                    RoomID = "ROOM3001",
                    RoomNumber = 301,
                    RoomDetailDescription = "A luxurious suite with a separate living area.",
                    RoomMaxCapacity = 4,
                    RoomPricePerDay = 492.00m,
                    RoomStatus = "Active",
                    RoomTypeID = 3
                },
                  new RoomInformation
                  {
                      RoomID = "ROOM3002",
                      RoomNumber = 302,
                      RoomDetailDescription = "",
                      RoomMaxCapacity = 1,
                      RoomPricePerDay = 200.00m,
                      RoomStatus = "Rented",
                      RoomTypeID = 3
                  },
                  new RoomInformation
                  {
                      RoomID = "ROOM3003",
                      RoomNumber = 303,
                      RoomDetailDescription = "",
                      RoomMaxCapacity = 1,
                      RoomPricePerDay = 180.00m,
                      RoomStatus = "Active",
                      RoomTypeID = 3
                  },
                   new RoomInformation
                   {
                       RoomID = "ROOM4001",
                       RoomNumber = 401,
                       RoomDetailDescription = "A family room with multiple beds and a kitchenette.",
                       RoomMaxCapacity = 7,
                       RoomPricePerDay = 700.00m,
                       RoomStatus = "Active",
                       RoomTypeID = 4
                   },
                    new RoomInformation
                    {
                        RoomID = "ROOM4002",
                        RoomNumber = 402,
                        RoomDetailDescription = "",
                        RoomMaxCapacity = 3,
                        RoomPricePerDay = 580.00m,
                        RoomStatus = "Active",
                        RoomTypeID = 4
                    },
                     new RoomInformation
                     {
                         RoomID = "ROOM4003",
                         RoomNumber = 403,
                         RoomDetailDescription = "",
                         RoomMaxCapacity = 4,
                         RoomPricePerDay = 620.00m,
                         RoomStatus = "Active",
                         RoomTypeID = 4
                     }
            );

            //Du lieu BookingDetail
            modelBuilder.Entity<BookingDetail>().HasData(
               new BookingDetail
               {
                   BookingReservationID = "BOOK00001",
                   RoomID = "ROOM1001",
                   StartDate = new DateTime(2024, 7, 1),
                   EndDate = new DateTime(2024, 7, 3),
                   ActualPrice = 875.00m
               },
               new BookingDetail
                {
                    BookingReservationID = "BOOK00002",
                    RoomID = "ROOM2002",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 5),
                    ActualPrice = 1290.00m
                },
               new BookingDetail
                {
                     BookingReservationID = "BOOK00003",
                     RoomID = "ROOM3002",
                     StartDate = new DateTime(2024, 7, 1),
                     EndDate = new DateTime(2024, 7, 10),
                     ActualPrice = 1800.00m
                }
            );
        }
    }
}
