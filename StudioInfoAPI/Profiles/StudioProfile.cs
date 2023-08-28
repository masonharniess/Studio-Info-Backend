using AutoMapper;
using StudioInfoAPI.Entities;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.Profiles {
  public class StudioProfile : Profile {
    public StudioProfile() { 
      CreateMap<StudioEntity, StudioModel>().ReverseMap();
      //CreateMap<StudioModel, StudioEntity>();
    }
  }
}
