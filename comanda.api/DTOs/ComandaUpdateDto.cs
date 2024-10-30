namespace comanda.api.DTOs
{
    public class ComandaUpdateDto
    {
        public int Id { get; set; } 
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; }

        // propriedade Array(vetor)int \\
        public ComandaItemUpdateDto[] ComandaItems { get; set; } = [];
    }

    public class ComandaItemUpdateDto
    {
        public int cardapioItemId { get; set; }
        public int Id { get; set; }
        public bool excluir { get; set; } = false;
        public bool incluir { get; set; } = false;
    }
}