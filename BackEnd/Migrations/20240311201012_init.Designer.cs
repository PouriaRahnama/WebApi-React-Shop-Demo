﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.Catalog.API.Infrustructure.Persistence;

#nullable disable

namespace Service.Catalog.API.Migrations
{
    [DbContext(typeof(SqlServerApplicationDB))]
    [Migration("20240311201012_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Service.Catalog.API.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Title = "Phone"
                        },
                        new
                        {
                            CategoryId = 2,
                            Title = "Watch"
                        },
                        new
                        {
                            CategoryId = 3,
                            Title = "AirPod"
                        },
                        new
                        {
                            CategoryId = 4,
                            Title = "Laptop"
                        },
                        new
                        {
                            CategoryId = 5,
                            Title = "Mouse"
                        });
                });

            modelBuilder.Entity("Service.Catalog.API.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "The 14- and 16-inch MacBook Pro models offer the M3, M3 Pro, and M3 Max chips for a high level of performance, with mini-LED displays, MagSafe fast charging, a range of ports, and more. Announced in October 2023, the MacBook Pro Models are still new, so now is the best possible time to buy a new MacBook Pro.",
                            ImageURL = "MacBook Pro.jpg",
                            Name = "MacBook",
                            Price = 999.99000000000001
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "The iPhone 12 mini display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 5.42 inches diagonally (actual viewable area is less).",
                            ImageURL = "iPhone 12.jpg",
                            Name = "IPhone 12",
                            Price = 1000.99
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "\r\nRebuilt from the sound up\r\nAirPods Pro (2nd generation) with MagSafe Charging Case (USB-C) deliver up to 2x more Active Noise Cancellation than the previous generation,¹ with Transparency mode that enables you to hear the world around you. All-new Adaptive Audio that dynamically tailors noise control to your environment.¹⁶ Conversation Awareness helps lower media volume and enhance the voices in front of you while you’re interacting with others.¹⁶ A single charge delivers up to 6 hours of battery life.⁷ And Touch control lets you easily adjust volume with a swipe. The MagSafe Charging Case¹⁷ is a marvel on its own with Precision Finding,¹⁵ built-in speaker, and lanyard loop.",
                            ImageURL = "Airpods.jpg",
                            Name = "Airpods",
                            Price = 899.99000000000001
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "CARBON NEUTRAL — Apple Watch Ultra 2 paired with the latest Alpine Loop or Trail Loop is carbon neutral. Learn more about Apple’s commitment to the environment at apple.com/2030.\r\nWHY APPLE WATCH ULTRA 2 — Rugged, capable, and built to meet the demands of endurance athletes, outdoor adventurers, and water sport enthusiasts — with a specialized band for each. The S9 SiP enables a superbright display and a magical new way to quickly and easily interact with your Apple Watch without touching the display. Up to 36 hours of battery life and 72 hours in Low Power Mode.\r\nEXTREMELY RUGGED, INCREDIBLY CAPABLE — 49mm corrosion-resistant titanium case. Large Digital Crown and Customizable Action button for instant control over a variety of functions. 100m water resistance.",
                            ImageURL = "Apple Watch.jpg",
                            Name = "Apple Watch",
                            Price = 899.99000000000001
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "4.7-inch Retina HD display. 5G capable\r\nAdvanced single-camera system with 12MP Wide camera; Smart HDR 4, Photographic Styles, Portrait mode, and 4K video up to 60 fps\r\n7MP FaceTime HD camera with Smart HDR 4, Photographic Styles, Portrait mode, and 1080p video recording. Home button with Touch ID for secure authentication\r\nA15 Bionic chip for lightning-fast performance. Durable design and IP67 water resistance\r\nUp to 15 hours of video playback\r\nManufacturerApple Computer",
                            ImageURL = "iPhone SE.jpg",
                            Name = "IPhone SE",
                            Price = 899.99000000000001
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "Unique thumb wheel: For horizontal navigation and advanced gestures\r\nEasy connections for multiple computers: Use with up to three Windows or Mac computers via included Unifying receiver or Bluetooth Smart wireless technology\r\nEasy switching between computers with the touch of the button\r\nTracks virtually anywhere - even on glass: The Dark field Laser sensor tracks flawlessly even on glass and high-gloss surfaces (4mm minimum thickness)\r\nAdvanced power management: Up to 40 days of power on single charge. You can get enough power for a full day of usage in only 4 minutes, with no downtime while recharging. ( Battery life may vary based on user and computer conditions)",
                            ImageURL = "Logitech MX Master.jpg",
                            Name = "Logitech MX Master",
                            Price = 899.99000000000001
                        });
                });

            modelBuilder.Entity("Service.Catalog.API.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 5
                        });
                });

            modelBuilder.Entity("Service.Catalog.API.Models.ProductCategory", b =>
                {
                    b.HasOne("Service.Catalog.API.Models.Category", "Category")
                        .WithMany("productCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Service.Catalog.API.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Service.Catalog.API.Models.Category", b =>
                {
                    b.Navigation("productCategories");
                });

            modelBuilder.Entity("Service.Catalog.API.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
