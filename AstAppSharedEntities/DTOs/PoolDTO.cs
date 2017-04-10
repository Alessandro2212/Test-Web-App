using AstAppSharedEntities.EntityModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities.DTOs
{
    public class PoolDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public static implicit operator PoolDTO(Pool from)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Pool, PoolDTO>();
            });
            return AutoMapper.Mapper.Map<Pool, PoolDTO>(from);
        }

        public static implicit operator Pool(PoolDTO from)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PoolDTO, Pool>();
            });
            return AutoMapper.Mapper.Map<PoolDTO, Pool>(from);
        }


    }
}
