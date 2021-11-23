using AutoMapper;
using IsGorevTakip.DTO.DTos.AppUserDtos;
using IsGorevTakip.DTO.DTos.DeclaretionnDtos;
using IsGorevTakip.DTO.DTos.JobWorkDtos;
using IsGorevTakip.DTO.DTos.ReportDtos;
using IsGorevTakip.DTO.DTos.UrgencyDtos;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Mapping.AutoMapperProf_le
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency-UrgencyDto
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Declarationn-DeclaretionnListDto
            CreateMap<DeclaretionnListDto, Declarationn>();
            CreateMap<Declarationn, DeclaretionnListDto>();
            #endregion

            #region JobWork-JobWorkAddDto
            CreateMap<JobWorkAddDto, JobWork>();
            CreateMap<JobWork, JobWorkAddDto>();
            CreateMap<JobWorkListDto, JobWork>();
            CreateMap<JobWork, JobWorkListDto>();
            CreateMap<JobWorkUpdateDto, JobWork>();
            CreateMap<JobWork, JobWorkUpdateDto>();
            CreateMap<JobWork, JobWorkListAllDto>();
            CreateMap<JobWorkListAllDto, JobWork>();
            #endregion

            #region Report-ReportAddDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
            #endregion

        }
    }
}
