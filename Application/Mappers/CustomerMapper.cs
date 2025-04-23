using Application.DTOs.Customer;
using Domain.Entities;
using Domain.ValueObjects;
using Mapster;

namespace Application.Mappers
{
   public class CustomerMapper : IRegister
   {
      public void Register(TypeAdapterConfig config)
      {
         config
            .NewConfig<CustomerCreateRequest, Customer>()
            .Map(dest => dest.Id, src => 0)
            .Map(dest => dest.CreatedAt, src => System.DateTime.UtcNow)
            .Map(dest => dest.Status, src => true)
            .Map(dest => dest.Name, src => new Name(src.Name))
            .Map(dest => dest.Email, src => new Email(src.Email))
            .MapToConstructor(true);

         config
            .NewConfig<CustomerUpdateRequest, Customer>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreatedAt, src => System.DateTime.UtcNow)
            .Map(dest => dest.Status, src => true)
            .Map(dest => dest.Name, src => new Name(src.Name))
            .Map(dest => dest.Email, src => new Email(src.Email))
            .MapToConstructor(true);

         config.NewConfig<Customer, CustomerResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Email, src => src.Email.Value)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Status, src => src.Status);

      }
   }
}
