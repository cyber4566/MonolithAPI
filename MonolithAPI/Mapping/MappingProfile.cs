using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MonolithAPI.DTO;
using MonolithAPI.Models;
using MonolithAPI.Repository.Interface;

namespace MonolithAPI.Mapping
{
    public class MappingProfile:Profile
    {
        


        public MappingProfile()
        {
            



            var passwordHasher = new PasswordHasher<string>();

            CreateMap<UserDTO, User>().
            ForMember(dest=> dest.HashedPassword ,opt => opt.MapFrom(src => passwordHasher.HashPassword(src.Username,src.Password)));
            
        }


        


    }
}
