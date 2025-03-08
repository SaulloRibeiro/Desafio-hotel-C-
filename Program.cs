using SistemaResavaDeHotel.Entities.Enums;
using SistemaResavaDeHotel.Entities;
using System.Globalization;
using SistemaResavaDeHotel;


public class Program {
    public static void Main(string[] args) {
        string msg1 = "Defina a quantidade de quartos simples: ";
        string msg2 = "Defina a quantidade de quartos duplos: ";
        string msg3 = "Defina a quantidade de quartos suites: ";

        int qtdQuartosSimples = ValidarEntradaDeDados.DefinirCapacidade(msg1);
        int qtdQuartosDuplos = ValidarEntradaDeDados.DefinirCapacidade(msg2) ;
        int qtdQuartosSuites = ValidarEntradaDeDados.DefinirCapacidade(msg3);

        Hotel hotel = new Hotel(qtdQuartosSimples, qtdQuartosDuplos, qtdQuartosSuites);
        
        Console.Clear();

        bool flag = true;
        int numeroReserva = 99;
        while (flag) {

            int opcao = ValidarEntradaDeDados.MenuOpcoes();
            Console.Clear();

            switch (opcao){
                case 1:
                    numeroReserva++;
                    Console.WriteLine(hotel.ExibirDisponibilidade());
                    Quarto quarto = ValidarEntradaDeDados.ValidarEscolhaDoQuarto(hotel);
                    if(quarto != null) {
                        Hospede hospede = ValidarEntradaDeDados.DadosUsuarioParaReserva();
                        DateTime dataEntrada = ValidarEntradaDeDados.DataEntrada();
                        DateTime dataSaida = ValidarEntradaDeDados.DataSaida(dataEntrada);
                        Reserva reserva = new Reserva(hospede, quarto, dataEntrada, dataSaida, numeroReserva);
                        hotel.ReservarQuarto(reserva);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Reserva feita com sucesso! :)");
                        Console.ResetColor();
                        Console.WriteLine("Precione enter para continuar: ");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    break;

                case 2:
                    Console.WriteLine(hotel.ExibirReservas());
                    Reserva reservaParaCancelar = ValidarEntradaDeDados.ReservaParaCancelar(hotel);
                    if(reservaParaCancelar != null) {
                        Console.WriteLine($"Hospede: {reservaParaCancelar.Hospede.Nome}");
                        Console.WriteLine($"Valor a pagar: R${reservaParaCancelar.CalcularValorTotalDaHospedagem().ToString("F2", CultureInfo.InvariantCulture)}");
                        hotel.CancelarReserva(reservaParaCancelar);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Reserva cancelada! Pagamento recebido!");
                        Console.ResetColor();
                        Console.WriteLine("Precione enter para continuar: ");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    break;

                case 3:
                    flag = false;
                    break;
                    
            }
    
        }
    }
}