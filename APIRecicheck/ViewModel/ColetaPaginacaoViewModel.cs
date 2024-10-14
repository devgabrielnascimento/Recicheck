namespace APIRecicheck.ViewModel
{
    public class ColetaPaginacaoViewModel
    {
        public  IEnumerable<ColetaViewModel> Coletas { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Coletas.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/api/coleta?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/api/coleta?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }
}
