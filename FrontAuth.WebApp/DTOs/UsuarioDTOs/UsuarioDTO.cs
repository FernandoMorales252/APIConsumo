using System.ComponentModel.DataAnnotations;

namespace FrontAuth.WebApp.DTOs.UsuarioDTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [StringLength(100, ErrorMessage = "El Email no puede tener mas de 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 4 y 100 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Rol { get; set; }
    }
}
