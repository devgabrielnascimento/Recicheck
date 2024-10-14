using System.Runtime.InteropServices;

namespace APIRecicheck.Models
{
    public class ColetaModel
    {
        public int coletaId { get; set; }
        public string? tipoResiduo{ get; set; }
        public DateTime? dataColeta { get; set; }
        public string? quantidade { get; set; }

    }
}
