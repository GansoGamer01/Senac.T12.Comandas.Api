namespace comanda.api.DTOs
{
    public class UsuarioRequest
    {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}
