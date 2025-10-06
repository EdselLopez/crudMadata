using System.ComponentModel.DataAnnotations;
namespace crudMadata.Models;
public class ContactoModel
{
    public int Id { get; set; }

    [Required]
    public string NombreCompleto { get; set; }

    public string Direccion { get; set; }

    [Phone]
    public string Telefono { get; set; }

    [EmailAddress]
    public string CorreoElectronico { get; set; }
}