namespace comanda.api.DTOs
{
    public class ComandaUpdateDto
    {
        public int Id { get; set; } 
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; }

        // propriedade Array(vetor)int \\
        public int[] CardapioItems { get; set; } = [];
    }

}