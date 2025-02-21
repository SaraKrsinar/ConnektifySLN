using AutoMapper;
using Connektify.Domain.Entities;
using Connektify.DTOs;

namespace Connektify
{
    public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Map from Contact to ContactDto
                CreateMap<Contact, ContactDto>()
                    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                    .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName));

                // Map from Country to CountryDto
                CreateMap<Country, CountryDto>()
                    .ForMember(dest => dest.ContactNames, opt => opt.MapFrom(src => src.Contacts.Select(c => c.ContactName).ToList()));

                // Map from Company to CompanyDto
                CreateMap<Company, CompanyDto>()
                    .ForMember(dest => dest.ContactNames, opt => opt.MapFrom(src => src.Contacts.Select(c => c.ContactName).ToList()));
            }
        }
    }
