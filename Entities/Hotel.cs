using SistemaResavaDeHotel.Entities.Enums;
using System.Text;

namespace SistemaResavaDeHotel.Entities {
    public class Hotel {
        private const double _precoDiariaQuartoSimples = 100;
        private const double _precoDiariaQuartoDuplo = 350;
        private const double _precoDiariaQuartoSuite = 900;
        public List<Quarto> Quartos { get; set; } = new List<Quarto>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
        
        public int Capacidade { get; set; }
        public Hotel(int qtdQuartosSimples, int qtdQuartosDuplos, int qtdQuartosSuites) {
            for(int index = 0; index < qtdQuartosSimples; index++) {
                Quartos.Add(new Quarto(index + 1, TiposQuarto.Simples, _precoDiariaQuartoSimples));
            }
            for(int index = 0; index < qtdQuartosDuplos; index++) {
                Quartos.Add(new Quarto(Quartos.Count + 1, TiposQuarto.Duplo, _precoDiariaQuartoDuplo));
            }
            for(int index = 0; index < qtdQuartosSuites; index++) {
                Quartos.Add(new Quarto(Quartos.Count + 1, TiposQuarto.Suite, _precoDiariaQuartoSuite));
            }
            Capacidade = qtdQuartosSimples + qtdQuartosDuplos + qtdQuartosSuites;
        }
        public bool ReservarQuarto(Reserva reserva) {
            if (Capacidade > 0 && reserva.Quarto.Disponivel) {
                Reservas.Add(reserva);
                reserva.Quarto.AlterarStatusDisponibilidade();
                Capacidade -= 1;
                return true;
            }
            return false;
        }

        public void CancelarReserva(Reserva reserva) {
            Reservas.Remove(reserva);
            reserva.Quarto.AlterarStatusDisponibilidade();

        }

        public string ExibirReservas() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\t\tReservas realizadas:");
            foreach (Reserva r in Reservas)
                sb.Append(r);

            return sb.ToString();
        }

        public string ExibirDisponibilidade() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\t\tQuartos disponiveis");
            foreach(Quarto q in Quartos) {
                if (q.Disponivel) {
                    sb.Append(q);
                }
            }
            return sb.ToString();
        }


    }
}
