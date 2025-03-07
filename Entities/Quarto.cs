using SistemaResavaDeHotel.Entities.Enums;
using System.Text;
using System.Globalization;

namespace SistemaResavaDeHotel.Entities {
    public class Quarto {
        public int Numero { get; set; }
        public TiposQuarto Tipo { get; set; }
        public double PrecoDiaria { get; set; }
        public bool Disponivel { get; set; } = true;
        public Quarto() { }
        public Quarto(int numero, TiposQuarto tipo, double precoDiaria) {
            Numero = numero;
            Tipo = tipo;
            PrecoDiaria = precoDiaria;
        }

        public void AlterarStatusDisponibilidade() {
            Disponivel = !Disponivel;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Numero do Quarto: {Numero}");
            sb.AppendLine($"Tipo do quarto: {Tipo}");
            sb.AppendLine($"Preco da diaria: R${PrecoDiaria.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
