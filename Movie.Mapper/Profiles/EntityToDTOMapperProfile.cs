using AutoMapper;
using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Film;
using Movie.Business.Manager.Model.Genre;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Mapper.Profiles
{
    public class EntityToDTOMapperProfile : Profile
    {
        public EntityToDTOMapperProfile()
        {
            //Genre Map Profile
            CreateMap<CreateGenreDTO, Genre>();

            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<Genre, GenreDTO>()
                .ForMember(x => x.GenreOfFilm, opt => opt.MapFrom(x => x.GenreOfFilm));
            //1
            CreateMap<Genre, ListGenreDTO>()
                .ForMember(x=>x.Films,opt=>opt.MapFrom(x=>x.Films));
            //Film Map Profile
            CreateMap<Film, FilmDTO>()
                .ForMember(x => x.Genres, opt => opt.MapFrom(x => x.Genres));
            CreateMap<Film, FilmForGenreDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<FilmDTO, Film>();

            //Actor Map Profile
            CreateMap<Actor, ListActorDTO>()
                .ForMember(x => x.Films,opt=>opt.MapFrom(x=>x.Films));
            CreateMap<Film, FilmForActorDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<CreateActorDTO, Actor>().ReverseMap();
        }
    }
}
