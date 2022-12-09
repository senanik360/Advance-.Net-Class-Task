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
   public class GroupService
    {
        public static List<GroupDTO> GetGroups()
        {
            var data = DataAccessFactory.GroupDataAccess().Get();
             var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mapper = new Mapper(config);
            var groups = mapper.Map<List<GroupDTO>>(data);
            return groups;
        }
        public static GroupDTO Get(int id)
        {
            var data = DataAccessFactory.GroupDataAccess().Get(id);
             var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>()); //group to groupdto
            var mapper = new Mapper(config);
            var groups = mapper.Map<GroupDTO>(data);
            return groups;
        }
        public static bool Add(GroupDTO dto)
        {
            //var data = DataAccessFactory.GroupDataAccess().Get(id);
             var config = new MapperConfiguration(cfg => {
                 cfg.CreateMap<GroupDTO, Group>();
                 cfg.CreateMap<Group, GroupDTO>();
                 }); // groupdto to group
            var mapper = new Mapper(config);
            var group = mapper.Map<Group>(dto);
            var results = DataAccessFactory.GroupDataAccess().Add(group);
            return results;
        }
    }
}
