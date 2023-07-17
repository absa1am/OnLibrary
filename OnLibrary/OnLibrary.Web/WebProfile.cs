using AutoMapper;
using OnLibrary.Domain.Entities;
using OnLibrary.Web.Areas.Admin.Models.Books;

namespace OnLibrary.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<UpdateBookModel, Book>().ReverseMap();
        }
    }
}
