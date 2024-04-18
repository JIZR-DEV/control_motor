using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string Estado { get; set; } = "Estado del motor: Detenido";
    public string ImagenUrl { get; set; } = "/detenido.gif";  // Inicializa con la imagen de estado detenido

    public void OnGet()
    {
    }

    public IActionResult OnGetIzquierda()
    {
        Estado = "Estado del motor: Girando en sentido antihorario";
        ImagenUrl = "/izquierda.gif";  // Cambia la imagen al girar a la izquierda
        return Page();
    }

    public IActionResult OnGetDetener()
    {
        Estado = "Estado del motor: Detenido";
        ImagenUrl = "/detenido.gif";  // Vuelve a la imagen de detenido
        return Page();
    }

    public IActionResult OnGetDerecha()
    {
        Estado = "Estado del motor: Girando en sentido horario";
        ImagenUrl = "/derecha.gif";  // Cambia la imagen al girar a la derecha
        return Page();
    }
}
