using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MyWebApp.Models;

namespace MyWebApp.Migrations.People
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20160217224404_PersonCountry")]
    partial class PersonCountry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Country");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");
                });
        }
    }
}
