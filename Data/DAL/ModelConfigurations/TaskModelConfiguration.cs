using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Todo.Data.DAL.ModelConfigurations
{
    public class TaskModelConfiguration : IEntityTypeConfiguration<Domain.Models.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            builder.HasKey(task => task.Id);
            builder.HasIndex(task => task.Id);
        }
    }

}