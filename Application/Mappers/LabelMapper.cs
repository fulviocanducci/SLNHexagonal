using Application.DTOs.Label;
using Domain.Entities;
using Mapster;

namespace Application.Mappers
{
   public class LabelMapper: IRegister
   {
      public void Register(TypeAdapterConfig config)
      {
         config
            .NewConfig<LabelCreateRequest, Label>()
            .Map(dest => dest.Id, src => 0)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.CreatedAt, src => System.DateTime.UtcNow)
            .Map(dest => dest.UpdatedAt, src => System.DateTime.UtcNow)
            .MapToConstructor(true);

         config
            .NewConfig<LabelUpdateRequest, Label>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.CreatedAt, src => System.DateTime.UtcNow)
            .Map(dest => dest.UpdatedAt, src => System.DateTime.UtcNow)
            .MapToConstructor(true);

         config.NewConfig<Label, LabelResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .MapToConstructor(true);
      }
   }
}
