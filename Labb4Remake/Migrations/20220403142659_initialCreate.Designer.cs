// <auto-generated />
using Labb4Remake.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb4Remake.Migrations
{
    [DbContext(typeof(WebAppDbContext))]
    [Migration("20220403142659_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb4RemakeModels.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.ToTable("TblInterests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            InterestTitle = "Nature"
                        },
                        new
                        {
                            InterestId = 2,
                            InterestTitle = "Knowledge"
                        },
                        new
                        {
                            InterestId = 3,
                            InterestTitle = "Music"
                        });
                });

            modelBuilder.Entity("Labb4RemakeModels.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("TblPersons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            FirstName = "Harald",
                            LastName = "Nybord",
                            PersonalNumber = "000912-2131"
                        },
                        new
                        {
                            PersonId = 2,
                            FirstName = "Laban",
                            LastName = "Hansson",
                            PersonalNumber = "19941209-2331"
                        },
                        new
                        {
                            PersonId = 3,
                            FirstName = "Karl",
                            LastName = "Svahn",
                            PersonalNumber = "19880808-2333"
                        });
                });

            modelBuilder.Entity("Labb4RemakeModels.PersonInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("TblPersonInterests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestId = 1,
                            PersonId = 1,
                            WebsiteId = 1
                        },
                        new
                        {
                            Id = 2,
                            InterestId = 2,
                            PersonId = 1,
                            WebsiteId = 2
                        },
                        new
                        {
                            Id = 3,
                            InterestId = 3,
                            PersonId = 3,
                            WebsiteId = 3
                        });
                });

            modelBuilder.Entity("Labb4RemakeModels.Website", b =>
                {
                    b.Property<int>("WebsiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WebsiteId");

                    b.ToTable("TblWebsites");

                    b.HasData(
                        new
                        {
                            WebsiteId = 1,
                            Link = "https://www.youtube.com/channel/UCAL3JXZSzSm8AlZyD3nQdBA"
                        },
                        new
                        {
                            WebsiteId = 2,
                            Link = "https://sv.wikipedia.org/wiki/Portal:Huvudsida"
                        },
                        new
                        {
                            WebsiteId = 3,
                            Link = "https://www.spotify.com/se/"
                        });
                });

            modelBuilder.Entity("Labb4RemakeModels.PersonInterest", b =>
                {
                    b.HasOne("Labb4RemakeModels.Interest", "Interest")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4RemakeModels.Person", "Person")
                        .WithMany("PersonInterest")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4RemakeModels.Website", "Website")
                        .WithMany("PersonInterests")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
