using System.ComponentModel.DataAnnotations;

namespace FrontAuth.WebApp.DTOs.UsuarioDTOs
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El Email no es correcto")]
        [StringLength(100, ErrorMessage = "El Email no puede contener mas de 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 4 y 100 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
