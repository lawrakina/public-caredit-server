﻿// <auto-generated />
using System;
using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240618083935_add_categories")]
    partial class add_categories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarEdit_Server.BusinessLogic.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("CarEdit_Server.BusinessLogic.Test1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests1");
                });

            modelBuilder.Entity("CarEdit_Server.Models.Catalog.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CarEdit_Server.Models.Catalog.CategoryItem", b =>
                {
                    b.Property<int>("CategoryItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryItemId");

                    b.ToTable("CategoryItems");
                });

            modelBuilder.Entity("CarEdit_Server.Models.Clients.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActivity")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarEdit_Server.Models.Payments.TelegramInvoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<long>("chat_id")
                        .HasColumnType("bigint");

                    b.Property<string>("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("date_checkout")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_completed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_create")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_checkout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<string>("provider_payment_charge_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("telegram_payment_charge_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("total_amount")
                        .HasColumnType("int");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("TelegramInvoices");
                });

            modelBuilder.Entity("CarEdit_Server.Payments.Lot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Files")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long>("TariffId")
                        .HasColumnType("bigint");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CarEdit_server.DataBase.AuthError", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("ListErrors");
                });

            modelBuilder.Entity("CarEdit_server.DataBase.Models.VipUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PhoneId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserRights")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("VipUsers");
                });

            modelBuilder.Entity("CategoryCategoryItem", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryItemsCategoryItemId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryId", "CategoryItemsCategoryItemId");

                    b.HasIndex("CategoryItemsCategoryItemId");

                    b.ToTable("CategoryCategoryItem");
                });

            modelBuilder.Entity("Shared.Models.Clients.CeFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileType")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<string>("PathName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerializeData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Shared.Models.Clients.FileStatistic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<int>("OperationType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDataTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FileStatistics");
                });

            modelBuilder.Entity("Shared.Models.Clients.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Shared.Models.Clients.TelegramUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TelegramUsers");
                });

            modelBuilder.Entity("Shared.Models.Clients.TimeCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ActivatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TimeCodes");
                });

            modelBuilder.Entity("Shared.Models.Clients.UserLastFileOperation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("LastFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OperationCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("OperationCount")
                        .HasColumnType("int");

                    b.Property<string>("Plugin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LastFiles");
                });

            modelBuilder.Entity("Shared.Models.Sales.KeySale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ActivatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpireTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LotId")
                        .HasColumnType("bigint");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.HasIndex("UserId");

                    b.ToTable("KeySales");
                });

            modelBuilder.Entity("Shared.Models.Sales.KeySaleInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<long>("KeyId")
                        .HasColumnType("bigint");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("KeyId");

                    b.HasIndex("UserId");

                    b.ToTable("KeySaleInvoices");
                });

            modelBuilder.Entity("Shared.Models.Sales.KeySaleTemplate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LotId")
                        .HasColumnType("bigint");

                    b.Property<int>("RecommendedPrice")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.ToTable("KeySaleTemplates");
                });

            modelBuilder.Entity("Shared.Models.Sales.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LotFiles")
                        .HasColumnType("int");

                    b.Property<int?>("LotTime")
                        .HasColumnType("int");

                    b.Property<string>("LotTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LotType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TariffEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TariffName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TariffPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TariffResources")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Shared.Models.Sales.Tariff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxFilesPerDay")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("Shared.Models.Sales.UpdateResourceItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CountUpdateUsers")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UpdateResourceItems");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersCategories");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersFiles");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserResources", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Days")
                        .HasColumnType("float");

                    b.Property<int>("OperationCount")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserResources");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserTariff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("TariffId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersTariffs");
                });

            modelBuilder.Entity("CarEdit_Server.Payments.Lot", b =>
                {
                    b.HasOne("Shared.Models.Sales.Tariff", "Tariff")
                        .WithMany()
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tariff");
                });

            modelBuilder.Entity("CarEdit_server.DataBase.AuthError", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarEdit_server.DataBase.Models.VipUser", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CategoryCategoryItem", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Catalog.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarEdit_Server.Models.Catalog.CategoryItem", null)
                        .WithMany()
                        .HasForeignKey("CategoryItemsCategoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Models.Clients.CeFile", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany("FilesList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Clients.FileStatistic", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Clients.Session", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Clients.TelegramUser", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Clients.TimeCode", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Clients.UserLastFileOperation", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.KeySale", b =>
                {
                    b.HasOne("CarEdit_Server.Payments.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Lot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.KeySaleInvoice", b =>
                {
                    b.HasOne("Shared.Models.Sales.KeySale", "Key")
                        .WithMany()
                        .HasForeignKey("KeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Key");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.KeySaleTemplate", b =>
                {
                    b.HasOne("CarEdit_Server.Payments.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("Shared.Models.Sales.Sale", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserCategory", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Catalog.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserFile", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserResources", b =>
                {
                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Models.Sales.UserTariff", b =>
                {
                    b.HasOne("Shared.Models.Sales.Tariff", "Tariff")
                        .WithMany()
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarEdit_Server.Models.Clients.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tariff");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarEdit_Server.Models.Clients.User", b =>
                {
                    b.Navigation("FilesList");
                });
#pragma warning restore 612, 618
        }
    }
}
