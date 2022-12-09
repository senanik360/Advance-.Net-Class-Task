using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DonorService
    {
        public static List<DonorDTO> Get()
        {
            var data = DataAccessFactory.DonorDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Donor, DonorDTO>());
            var mapper = new Mapper(config);
            var groups = mapper.Map<List<DonorDTO>>(data);
            return groups;
        }
        public static DonorDTO Get(int id)
        {
            var data = DataAccessFactory.DonorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Donor, DonorDTO>()); //donor to dontoDto
            var mapper = new Mapper(config);
            var groups = mapper.Map<DonorDTO>(data);
            return groups;
        }
        public static DonorDTO Add(DonorDTO dto)
        {
            //var data = DataAccessFactory.GroupDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DonorDTO, Donor>();
                cfg.CreateMap<Donor, DonorDTO>();
            }); // groupdto to group
            var mapper = new Mapper(config);
            var data = mapper.Map<Donor>(dto);
            var results = DataAccessFactory.DonorDataAccess().Add(data);
            return mapper.Map<DonorDTO>(results); 
        }
    }
}
