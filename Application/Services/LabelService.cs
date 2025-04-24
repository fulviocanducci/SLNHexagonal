using Application.DTOs.Label;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
   public class LabelService : ILabelService
   {
      private readonly ILabelRepository _labelRepository;
      public LabelService(ILabelRepository labelRepository)
      {
         _labelRepository = labelRepository;
      }

      public async Task<Label> AddAsync(LabelCreateRequest label)
      {
         Label data = label.Adapt<Label>();
         await _labelRepository.AddAsync(data);
         return data;
      }

      public async Task<Label> UpdateAsync(LabelUpdateRequest label)
      {
         Label data = label.Adapt<Label>();
         await _labelRepository.UpdateAsync(data);
         return data;
      }

      public async Task DeleteAsync(long id)
      {
         await _labelRepository.DeleteAsync(id);
      }
      
      public async Task<LabelResponse> GetAsync(long id)
      {
         var data = await _labelRepository.GetAsync(id);
         return data.Adapt<LabelResponse>();
      }

      public async Task<LabelResponse> GetAsync(Expression<Func<Label, bool>> where)
      {
         var data = await _labelRepository.GetAsync(where);
         return data.Adapt<LabelResponse>();
      }

      public LabelResponse Get(long id)
      {
         var data = _labelRepository.Get(id);
         return data.Adapt<LabelResponse>();
      }

      public LabelResponse Get(Expression<Func<Label, bool>> where)
      {
         var data = _labelRepository.Get(where);
         return data.Adapt<LabelResponse>();
      }

      public async Task<IEnumerable<LabelResponse>> GetAllAsync<TKey>(Expression<Func<Label, TKey>> orderBy)
      {
         var data = await _labelRepository.GetAllAsync(orderBy);
         return data.Adapt<IEnumerable<LabelResponse>>();
      }
      
      public async Task<bool> AnyAsync(Expression<Func<Label, bool>> where)
      {
         return await _labelRepository.AnyAsync(where);
      }

      public bool Any(Expression<Func<Label, bool>> where)
      {
         return _labelRepository.Any(where);
      }
      public async Task<bool> AnyAsync(long id)
      {
         return await _labelRepository.AnyAsync(x => x.Id == id);
      }
      public bool Any(long id)
      {
         return _labelRepository.Any(x => x.Id == id);
      }
   }
}