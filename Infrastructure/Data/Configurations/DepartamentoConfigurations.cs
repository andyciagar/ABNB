namespace Infrastructure.Data.Configurations;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartamentoConfigurations : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");
        builder.HasKey(d => d.Id);
        builder
            .Property(d => d.Nombre)
            .HasConversion(n => n.Value, s => new Nombre(s))
            .HasColumnName("NombreDepartamento")
            .HasMaxLength(100)
            .IsRequired(); 
        builder.OwnsOne(
            d => d.Precio,
            p =>
            {
                p.Property(p => p.Value)
                    .HasConversion( v=> v, d => new Dinero(d, Moneda.USD))
                    .HasColumnName("PrecioValor")
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                p.Property(p => p.Moneda)
                    .HasColumnName("PrecioMoneda")
                    .HasMaxLength(3)
                    .IsRequired();
            }
    )

}
