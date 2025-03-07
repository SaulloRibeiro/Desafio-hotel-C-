using System.Text;

namespace SistemaResavaDeHotel.Entities {
    public class Reserva {

        public Hospede Hospede { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int NumeroReserva { get; private set; } = 99;

        public Reserva() { }
        public Reserva(Hospede hospede, Quarto quarto, DateTime dataEntrada, DateTime dataSaida) {
            Hospede = hospede;
            Quarto = quarto;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            NumeroReserva += 1;
        }

        public double CalcularValorTotalDaHospedagem() {
            TimeSpan diferencaDeDias = DataSaida - DataEntrada;
            return Quarto.PrecoDiaria * diferencaDeDias.Days;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=========================================================");
            sb.AppendLine($"Numero da reserva: {NumeroReserva}");
            sb.Append(Hospede.ToString());
            sb.AppendLine();
            sb.Append(Quarto.ToString());
            sb.AppendLine($"Data de entrada: {DataEntrada.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Data de Saida: {DataSaida.ToString("dd/MM/yyyy")}");
            sb.AppendLine("=========================================================");
            return sb.ToString();
        }

    }
}
