using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PensionesWebApi.Models;
using PensionesWebApi.DTOs;

namespace PensionesWebApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Expediente, ExpedienteDTO>();
            CreateMap<ExpedientePostDTO, Expediente>();
            CreateMap<DomicilioComprobante, DomicilioComprobanteDTO>();
            CreateMap<DomicilioIFE, DomicilioIFEDTO>();
            CreateMap<DomicilioComprobanteDTO, DomicilioComprobante>();
            CreateMap<DomicilioIFEDTO, DomicilioIFE>();
            CreateMap<Comentario, ComentarioDTO>();
            CreateMap<ComentarioDTO, Comentario>();
            CreateMap<UsuarioRegisterDTO, Usuario>();
            CreateMap<Usuario, UsuarioTokenDTO>();
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
