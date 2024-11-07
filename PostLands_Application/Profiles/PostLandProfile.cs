using AutoMapper;
using PostLands_Application.Featcure.Command.Create;
using PostLands_Application.Featcure.Command.Delete;
using PostLands_Application.Featcure.Command.Update;
using PostLands_Application.Featcure.Querry.GetAll;
using PostLands_Application.Featcure.Querry.GetByDetail;
using PostLands_Domain;

namespace PostLands_Application.Profiles
{
    internal class PostLandProfile:Profile
    {
        public PostLandProfile()
        {
          CreateMap<Post,GetPostViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetailViewModel>().ReverseMap();
            CreateMap<Category, GetCategoryViewModel>().ReverseMap();
            CreateMap<Category, GetCategoryDetailViewModel>().ReverseMap();

            CreateMap<Post,CreatePostQuerry>().ReverseMap();
            CreateMap<Post, UpdatePostQuerry>().ReverseMap();
            CreateMap<Post, DeletePostQuerry>().ReverseMap();

            CreateMap<Category, CreateCategoryQuerry>().ReverseMap();
            CreateMap<Category, UpdateCategoryQuerry>().ReverseMap();
            CreateMap<Category, DeleteCategoryQuerry>().ReverseMap();


        }
    }
}
