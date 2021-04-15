﻿using System;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Domain.Valuations
{
    internal class ValuationEntityTypeConfiguration : IEntityTypeConfiguration<Valuation>
    {
        public void Configure(EntityTypeBuilder<Valuation> builder)
        {
            builder.ToTable("Valuations", "Valuations");
            builder.HasKey("Id");
            builder.Property<ValuationId>("Id")
                .HasConversion(id => id.Value, value => new ValuationId(value));

            builder.OwnsMany<Proposal>("Proposals", ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.WithOwner("Valuation").HasForeignKey();
                ownedNavigationBuilder.ToTable("Valuations", "Proposals");
                ownedNavigationBuilder.HasKey("Id");
                ownedNavigationBuilder.Property<ProposalId>("Id")
                    .HasConversion(id => id.Value, value => new ProposalId(value));
                ownedNavigationBuilder.OwnsOne<Money>("Price", moneyValueObjectBuilder =>
                {
                    moneyValueObjectBuilder.Property<decimal?>("Value");
                    moneyValueObjectBuilder.Property<string>("Currency");
                });
                ownedNavigationBuilder.OwnsOne<ProposalDescription>("Description", valueObjectBuilder =>
                {
                    valueObjectBuilder.Property<string>("Message").HasMaxLength(512);
                });
                ownedNavigationBuilder.Property<EmployeeId>("SuggestedBy")
                    .HasConversion(id => id.Value, value => new EmployeeId(value))
                    .IsRequired();
                ownedNavigationBuilder.Property<DateTime>("Suggested")
                    .IsRequired();
                ownedNavigationBuilder.Property<EmployeeId>("CancelledBy")
                    .HasConversion(id => id.Value, value => new EmployeeId(value))
                    .IsRequired(false);
                ownedNavigationBuilder.Property<DateTime?>("Cancelled")
                    .IsRequired(false);
                ownedNavigationBuilder.OwnsOne<ProposalDecision>("Decision", decisionValueObjectBuilder =>
                {
                    decisionValueObjectBuilder.Property<DateTime?>("Date").IsRequired();
                    decisionValueObjectBuilder.Property<string>("Code").IsRequired().HasMaxLength(10);
                    decisionValueObjectBuilder.Property<string>("RejectReason").IsRequired(false);
                });
            });
            builder.Property<DateTime>("RequestedDate").IsRequired();
            builder.Property<EmployeeId>("CompletedBy")
                .HasConversion(id => id.Value, value => new EmployeeId(value))
                .IsRequired(false);
            builder.Property<DateTime?>("CompletedDate").IsRequired(false);

            builder.OwnsOne<Enquiry>("Enquiry", equiryValueObjectBuilder =>
            {
                equiryValueObjectBuilder.OwnsMany<Product>("Products", productsBuilder =>
                {
                    productsBuilder.WithOwner("Enquiry").HasForeignKey();
                    productsBuilder.ToTable("Valuations", "Products");
                    productsBuilder.HasKey("Id");
                    productsBuilder.Property<ProductId>("Id")
                        .HasConversion(id => id.Value, value => new ProductId(value));
                });
                equiryValueObjectBuilder.OwnsOne<Client>("Client", clientValueObjectBuilder =>
                {
                    clientValueObjectBuilder.Property<string>("FirstName").IsRequired();
                    clientValueObjectBuilder.Property<string>("LastName").IsRequired();
                    clientValueObjectBuilder.OwnsOne<Email>("Email", emailValueObjectBuilder =>
                    {
                        emailValueObjectBuilder.Property<string>("Value").IsRequired().HasMaxLength(255);
                    });
                    clientValueObjectBuilder.OwnsOne<Email>("Email", emailValueObjectBuilder =>
                    {
                        emailValueObjectBuilder.Property<string>("Value").IsRequired().HasMaxLength(255);
                    });
                });
            });
        }
    }
}
