using AutoMapper;
using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Directory;
using Movie.Business.Manager.Model.Film;
using Movie.Business.Manager.Model.Genre;
using Movie.Business.Manager.Model.User;
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
            //Film tablosuna ilişki get'lerken kullandığım map
            CreateMap<Film, FilmDTO>()
                .ForMember(x => x.Genres, opt => opt.MapFrom(x => x.Genres))
                .ForMember(x => x.Actors, opt=>opt.MapFrom(x=>x.Actors))
                .ForMember(x=>x.Directories,opt=>opt.MapFrom(x=>x.Directories));
            CreateMap<FilmDTO, Film>();
            CreateMap<Film, FilmForGenreDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
                

            CreateMap<FilmDTO, Film>();

            //Actor Map Profile
            CreateMap<Actor, ListActorDTO>()
                .ForMember(x => x.Films,opt=>opt.MapFrom(x=>x.Films));
            CreateMap<Film, FilmForActorDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<Actor, ActorForFilmDTO>().ReverseMap();

            CreateMap<CreateActorDTO, Actor>().ReverseMap();
            CreateMap<Actor, ActorDTO>();

            CreateMap<UpdateActorDTO, Actor>();


            //Film Create
            CreateMap<Film, CreateFilmDTO>().ReverseMap();
            //Directory Map Profile

            //Get
            CreateMap<Directory, ListDirectoryDTO>()
                .ForMember(x=>x.Films,opt=>opt.MapFrom(x=>x.Films));
            CreateMap<Film, FilmForDirectoryDTO>()
                .ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.Name));
            //0
            CreateMap<DirectoryForFilmDTO, Directory>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<DirectoryDTO,Directory>();
            CreateMap<Directory, DirectoryForFilmDTO>();

            //Insert
            CreateMap<CreateDirectoryDTO, Directory>().ReverseMap();

            //GetById
            CreateMap<Directory, DirectoryDTO>();

            //Update
            CreateMap<UpdateDirectoryDTO, Directory>();


            //User Map Profiles

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserProfileDTO>();
            CreateMap<UserLoginDTO, User>();
        }
    }
}
