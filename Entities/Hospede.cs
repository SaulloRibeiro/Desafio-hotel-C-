using System.Text;

namespace SistemaResavaDeHotel.Entities {
    public class Hospede {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string NumeroTelefone { get; set; }

        public Hospede() { }
        public Hospede(string nome, string documento, string numeroTelefone) {
            Nome = nome;
            Documento = documento;
            NumeroTelefone = numeroTelefone;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome hospede: {Nome}");
            sb.AppendLine($"Documento: {Documento}");
            return sb.ToString();
        }

    }
}
