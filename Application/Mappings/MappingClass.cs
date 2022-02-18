using Application.Features.Commands.ItemCommand;
using Application.Features.Commands.ListaCommand;
using Application.Features.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingClass : Profile
    {
        public MappingClass()
        {
            #region Commands
            CreateMap<CreateListaCommand, Lista>();
            CreateMap<UpdateListaCommand, Lista>();

            CreateMap<CreateItemCommand, Item>();
            CreateMap<UpdateItemCommand, Item>();

            #endregion

            #region Queries
            CreateMap<Lista, ListaDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            #endregion
        }
    }
}
