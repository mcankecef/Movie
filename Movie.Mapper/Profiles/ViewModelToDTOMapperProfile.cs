using AutoMapper;
using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Film;
using Movie.Business.Manager.Model.Genre;
using Movie.UI.Model.ViewModel.Actor;
using Movie.UI.Model.ViewModel.Film;
using Movie.UI.Model.ViewModel.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Mapper.Profiles
{
    public class ViewModelToDTOMapperProfile : Profile
    {
        public ViewModelToDTOMapperProfile()
        {
            //Genre Map Profile
            CreateMap<CreateGenreVM, CreateGenreDTO>();

            CreateMap<UpdateGenreVM, CreateGenreVM>();

            CreateMap<UpdateGenreVM, UpdateGenreDTO>();

            CreateMap<GenreDTO, GenreVM>()
                .ForMember(x => x.GenreOfFilm, opt => opt.MapFrom(x => x.GenreOfFilm));
            //1
            CreateMap<ListGenreDTO, ListGenreVM>()
                .ForMember(x=>x.Films,opt =>opt.MapFrom(x=>x.Films));

            //Film Map Profile

            CreateMap<FilmDTO, FilmVM>()
                                .ForMember(x => x.Genres, opt => opt.MapFrom(x => x.Genres))
                                .ForMember(x=>x.Actors, opt => opt.MapFrom(x=>x.Actors));

            CreateMap<FilmForGenreDTO, ListFilmVM>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<FilmVM,FilmDTO>();
            CreateMap<CreateFilmVM, FilmDTO>();

            //Actor Map Profile
            CreateMap<ListActorDTO, ListActorVM>()
                .ForMember(x => x.Films, opt => opt.MapFrom(x => x.Films));
            CreateMap<FilmForActorDTO, ListFilmVM>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
            CreateMap<CreateActorVM, CreateActorDTO>();
            CreateMap<CreateActorDTO, ActorVM>();
            CreateMap<ActorForFilmDTO, ActorForFilmVM>();
            CreateMap<ActorDTO, ActorVM>();
            CreateMap<UpdateActorVM, CreateActorVM>();
            CreateMap<UpdateActorVM, UpdateActorDTO>();



        }
    }
}
