using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class SubjectGradeConfigurations : IEntityTypeConfiguration<SubjectGrade>
    {
        public void Configure(EntityTypeBuilder<SubjectGrade> entityBuilder)
        {
            entityBuilder.ToTable("tbl_SubjectGrade");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_SubjectGrade_Id");
           // entityBuilder.Property(p => p.SectionId).HasColumnName("fk_Section_SubjectGrade_SectionId");
            entityBuilder.Property(p => p.GradeId).HasColumnName("fk_Grade_SubjectGrade_GradeId").IsRequired();
            entityBuilder.Property(p => p.SubjectName).IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
          //  entityBuilder.HasOne<Section>(p => p.Section).WithMany(p => p.SubjectGrades).HasForeignKey(p => p.SectionId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Grade>(p => p.Grade).WithMany(p => p.SubjectGrades).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Answer>(p => p.Answers).WithOne(p => p.Subject).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Request>(p => p.Requests).WithOne(p => p.Subject).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<ExtraRequest>(a => a.ExtraRequests).WithOne(b => b.Subject).HasForeignKey(b => b.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Unit>(a => a.Units).WithOne(b => b.Subject).HasForeignKey(b => b.SubjectId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
