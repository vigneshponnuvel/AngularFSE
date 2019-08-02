using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Outreach_WebAPI.Models
{
    public partial class FMS_OUTREACHContext : DbContext
    {
        public FMS_OUTREACHContext()
        {
        }

        public FMS_OUTREACHContext(DbContextOptions<FMS_OUTREACHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TEventInformation> TEventInformation { get; set; }
        public virtual DbSet<TEventSummary> TEventSummary { get; set; }
        public virtual DbSet<TMstrRole> TMstrRole { get; set; }
        public virtual DbSet<TMstrUser> TMstrUser { get; set; }
        public virtual DbSet<TRegNotattend> TRegNotattend { get; set; }
        public virtual DbSet<TRegUnreg> TRegUnreg { get; set; }
        public virtual DbSet<TTtrnFeedback> TTtrnFeedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:172.18.3.194,1433;Database=FMS_OUTREACH;User ID=sa;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEventInformation>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("T_EVENT_INFORMATION");

                entity.Property(e => e.Sno).HasColumnName("SNO");

                entity.Property(e => e.Baselocation)
                    .HasColumnName("BASELOCATION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Beneficiaryname)
                    .HasColumnName("BENEFICIARYNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Businessunit)
                    .HasColumnName("BUSINESSUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Councilname)
                    .HasColumnName("COUNCILNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid).HasColumnName("EMPLOYEEID");

                entity.Property(e => e.Employeename)
                    .HasColumnName("EMPLOYEENAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Eventdate)
                    .HasColumnName("EVENTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventdescription)
                    .HasColumnName("EVENTDESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Eventid)
                    .IsRequired()
                    .HasColumnName("EVENTID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Eventname)
                    .HasColumnName("EVENTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iiepcategory)
                    .HasColumnName("IIEPCATEGORY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Livesimpacted).HasColumnName("LIVESIMPACTED");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Travelhours).HasColumnName("TRAVELHOURS");

                entity.Property(e => e.Volunteerhours).HasColumnName("VOLUNTEERHOURS");
            });

            modelBuilder.Entity<TEventSummary>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("T_EVENT_SUMMARY");

                entity.Property(e => e.Sno).HasColumnName("SNO");

                entity.Property(e => e.Activitytype).HasColumnName("ACTIVITYTYPE");

                entity.Property(e => e.Baselocation)
                    .HasColumnName("BASELOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Beneficiaryname)
                    .HasColumnName("BENEFICIARYNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Councilname)
                    .HasColumnName("COUNCILNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Eventdate)
                    .HasColumnName("EVENTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventdescription)
                    .HasColumnName("EVENTDESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Eventid)
                    .IsRequired()
                    .HasColumnName("EVENTID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Eventname)
                    .HasColumnName("EVENTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Livesimpacted).HasColumnName("LIVESIMPACTED");

                entity.Property(e => e.Month)
                    .HasColumnName("MONTH")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Overallvolunteeringhours).HasColumnName("OVERALLVOLUNTEERINGHOURS");

                entity.Property(e => e.Poccontactnumber).HasColumnName("POCCONTACTNUMBER");

                entity.Property(e => e.Pocid).HasColumnName("POCID");

                entity.Property(e => e.Pocname)
                    .HasColumnName("POCNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Totalnoofvolunteers).HasColumnName("TOTALNOOFVOLUNTEERS");

                entity.Property(e => e.Totaltravelhours).HasColumnName("TOTALTRAVELHOURS");

                entity.Property(e => e.Totalvolunteerhours).HasColumnName("TOTALVOLUNTEERHOURS");

                entity.Property(e => e.Venueaddress)
                    .HasColumnName("VENUEADDRESS")
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMstrRole>(entity =>
            {
                entity.HasKey(e => e.Roleid);

                entity.ToTable("T_MSTR_ROLE");

                entity.Property(e => e.Roleid).HasColumnName("ROLEID");

                entity.Property(e => e.Createddt)
                    .HasColumnName("CREATEDDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("ROLENAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMstrUser>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("T_MSTR_USER");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Createddt)
                    .HasColumnName("CREATEDDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Roleid).HasColumnName("ROLEID");

                entity.Property(e => e.Useremail)
                    .HasColumnName("USEREMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRegNotattend>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("T_REG_NOTATTEND");

                entity.Property(e => e.Sno).HasColumnName("SNO");

                entity.Property(e => e.Baselocation)
                    .HasColumnName("BASELOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Beneficiaryname)
                    .HasColumnName("BENEFICIARYNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid).HasColumnName("EMPLOYEEID");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("EVENTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventid)
                    .IsRequired()
                    .HasColumnName("EVENTID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Eventname)
                    .HasColumnName("EVENTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRegUnreg>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("T_REG_UNREG");

                entity.Property(e => e.Sno).HasColumnName("SNO");

                entity.Property(e => e.Baselocation)
                    .HasColumnName("BASELOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Beneficiaryname)
                    .HasColumnName("BENEFICIARYNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid).HasColumnName("EMPLOYEEID");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("EVENTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventid)
                    .IsRequired()
                    .HasColumnName("EVENTID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Eventname)
                    .HasColumnName("EVENTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TTtrnFeedback>(entity =>
            {
                entity.HasKey(e => e.Feedbackid);

                entity.ToTable("T_TTRN_FEEDBACK");

                entity.Property(e => e.Feedbackid).HasColumnName("FEEDBACKID");

                entity.Property(e => e.Associateid).HasColumnName("ASSOCIATEID");

                entity.Property(e => e.Associatestatus)
                    .IsRequired()
                    .HasColumnName("ASSOCIATESTATUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createddt)
                    .HasColumnName("CREATEDDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventid)
                    .IsRequired()
                    .HasColumnName("EVENTID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Feedbackcategory)
                    .IsRequired()
                    .HasColumnName("FEEDBACKCATEGORY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mainfeedback)
                    .IsRequired()
                    .HasColumnName("MAINFEEDBACK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Optionalfeedback1)
                    .HasColumnName("OPTIONALFEEDBACK1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Optionalfeedback2)
                    .HasColumnName("OPTIONALFEEDBACK2")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
