using AutoMapper;
using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Directory;
using Movie.Business.Manager.Model.Film;
using Movie.Business.Manager.Model.Genre;
using Movie.UI.Model.ViewModel.Actor;
using Movie.UI.Model.ViewModel.Directory;
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

            CreateMap<FilmForGenreDTO, ListFilmVM>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            //Film Map Profile

            CreateMap<FilmDTO, FilmVM>()
                                .ForMember(x => x.Genres, opt => opt.MapFrom(x => x.Genres))
                                .ForMember(x=>x.Actors, opt => opt.MapFrom(x=>x.Actors))
                                .ForMember(x=>x.Directories ,opt=>opt.MapFrom(x=>x.Directories));

            CreateMap<DirectoryForFilmVM, DirectoryForFilmDTO>();


            CreateMap<FilmVM,FilmDTO>().ReverseMap();
            //CreateMap<FilmDTO, FilmVM>();
            CreateMap<CreateFilmVM, FilmDTO>();
            CreateMap<CreateFilmVM, CreateFilmDTO>();
            CreateMap<CreateFilmDTO,FilmVM>();
            //0
            CreateMap<DirectoryForFilmDTO,DirectoryForFilmVM >();
            CreateMap<GenreVM, GenreDTO>();
            CreateMap<DirectoryVM, DirectoryDTO>();
            CreateMap<DirectoryForFilmDTO, DirectoryVM>();

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

            //Directory Map Profile

            //Get
            CreateMap<ListDirectoryDTO, ListDirectoryVM>()
                .ForMember(x => x.Films, opt => opt.MapFrom(x => x.Films));
            CreateMap<FilmForDirectoryDTO, ListFilmVM>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            //Insert
            CreateMap<CreateDirectoryVM, CreateDirectoryDTO>();
            CreateMap<CreateDirectoryDTO, DirectoryVM>();

            //GetById
            CreateMap<DirectoryDTO, DirectoryVM>();

            //Update
            CreateMap<UpdateDirectoryVM, CreateDirectoryDTO>();
            CreateMap<UpdateDirectoryVM, UpdateDirectoryDTO>();


   




        }
    }
}
