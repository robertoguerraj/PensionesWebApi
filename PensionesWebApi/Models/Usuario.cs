using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("apellidos")]
        public string Apellidos { get; set; }

        [EmailAddress]
        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("user_name")]
        public string UserName { get; set; }

        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }

        [Column("temporal_password")]
        public bool TemporalPassword { get; set; }

        [Required]
        [Column("activo")]
        public bool Activo { get; set; }

        [Column("rol_id")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        [Column("ubicacion_id")]
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }
    }
}
