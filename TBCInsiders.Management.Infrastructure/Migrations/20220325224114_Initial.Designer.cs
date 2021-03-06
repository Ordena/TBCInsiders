// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBCInsiders.Management.Infrastructure.Persistence.Data;

namespace TBCInsiders.Management.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220325224114_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kutaisi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Batumi"
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.ConnectedUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConnectedUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "lasha",
                            LastName = "Lejava",
                            PersonalNumber = "12345687910",
                            Phone = "555900001"
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Female"
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeID");

                    b.HasIndex("UserId");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Phone = "555900563",
                            TypeID = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.PhoneNumberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumberTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "Mobile"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Home"
                        },
                        new
                        {
                            Id = 3,
                            Value = "Office"
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ImageId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            DateOfBirth = new DateTime(1996, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "irakli",
                            GenderId = 1,
                            LastName = "ordenidze",
                            PersonalNumber = "01008042010"
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.UserConnectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserConnectionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Colegue"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Relative"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Acquaintance"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.UserConnections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConnectedUserId")
                        .HasColumnType("int");

                    b.Property<int>("ConnectionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConnectedUserId");

                    b.HasIndex("ConnectionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserConnections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConnectedUserId = 1,
                            ConnectionTypeId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("TBCInsiders.Management.Domain.Entities.PhoneNumberType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBCInsiders.Management.Domain.Entities.User", "User")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.User", b =>
                {
                    b.HasOne("TBCInsiders.Management.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("TBCInsiders.Management.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("TBCInsiders.Management.Domain.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("City");

                    b.Navigation("Gender");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.UserConnections", b =>
                {
                    b.HasOne("TBCInsiders.Management.Domain.Entities.ConnectedUser", "ConnectedUser")
                        .WithMany()
                        .HasForeignKey("ConnectedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBCInsiders.Management.Domain.Entities.UserConnectionType", "ConnectionType")
                        .WithMany()
                        .HasForeignKey("ConnectionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBCInsiders.Management.Domain.Entities.User", "User")
                        .WithMany("UserConnections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ConnectedUser");

                    b.Navigation("ConnectionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TBCInsiders.Management.Domain.Entities.User", b =>
                {
                    b.Navigation("PhoneNumbers");

                    b.Navigation("UserConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
