using SistemaResavaDeHotel.Entities.Enums;
using SistemaResavaDeHotel.Entities;
using System.Globalization;

namespace SistemaResavaDeHotel {
    public class ValidarEntradaDeDados {


        private static void MsgInvalida() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Use apenas valores validos!");
            Console.ResetColor();
        }

        public static int DefinirCapacidade(string msg) {
            int qtdQuartos = 0;
            bool flag = true;

            while (flag) {
                try {
                    Console.Write(msg);
                    qtdQuartos = int.Parse(Console.ReadLine());
                    if (qtdQuartos >= 0)
                        flag = false;
                    else {
                        MsgInvalida();
                    }
                }
                catch {
                    MsgInvalida();
                }
            }
            return qtdQuartos;
        }

        public static int MenuOpcoes() {
            int opcaoUsuario = 0;
            bool flag = true;
            while (flag) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Digite 1 para fazer uma reserva");
                Console.WriteLine("Digite 2 para cancelar uma reserva");
                Console.WriteLine("Digite 3 para sair");
                Console.ResetColor();
                Console.WriteLine("Digite uma opcao: ");
                try {
                    opcaoUsuario = int.Parse(Console.ReadLine());
                    if (opcaoUsuario <= 3 && opcaoUsuario > 0)
                        flag = false;
                    else {
                        MsgInvalida();
                    }
                }
                catch {
                    MsgInvalida();
                }    
            }
            return opcaoUsuario;     
        }

        public static Hospede DadosUsuarioParaReserva() {
            string nome;
            string documento;
            string telefone;
            //bool flag = true;

            do {
                Console.Write("Nome comleto: ");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do {
                Console.Write("Domumento: ");
                documento = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(documento));

            do {
                Console.Write("Telefone: ");
                telefone = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(telefone));

            return new Hospede(nome, documento, telefone);
        }

        public static Quarto ValidarEscolhaDoQuarto(Hotel hotel) {
            Quarto? quarto = null;
            int numeroQuarto;
            bool flag = true;
            while (flag) {
                    Console.Write("Digite o numero do quarto que deseja reservar ou zero para sair desta tela: ");
                try {
                    numeroQuarto = int.Parse(Console.ReadLine());
                    if(numeroQuarto == 0) {
                        flag = false;
                    }
                    else {
                        foreach (Quarto q in hotel.Quartos) {
                            if (q.Numero == numeroQuarto && q.Disponivel) {
                                quarto = q;
                                flag = false;
                                break;
                            }  
                        }
                        if(quarto == null) { 
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Este quarto ja esta resevardo ou ele nao existe");
                            Console.ResetColor();
                        }
                    }
                }
                catch {
                    MsgInvalida();
                }   
            }
            return quarto;
        }


        private static DateTime ValidarData(string msg) {
            DateTime dataValidada = new DateTime();
            string data;
            bool flag = true;

            while (flag) {
                Console.Write(msg);
                data = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(data)) {
                    try {
                        dataValidada = DateTime.Parse(data);
                        flag = false;
                    }
                    catch {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Data invalida! Tente novamente");
                        Console.ResetColor();
                    }
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Este campo presisa ser preenchido com valores validos");
                    Console.ResetColor();
                }
            }
            return dataValidada;

        }

        public static DateTime DataEntrada() {
            return ValidarData("Data entrada (dd/MM/yyyy): ");
        }

        public static DateTime DataSaida(DateTime dataEntrada) {
            string msg = "Data saida (dd/MM/yyyy): ";
            bool flag = true;
            DateTime dataSaida = new DateTime();

            while (flag) {
                dataSaida = ValidarData(msg);
                int valor = DateTime.Compare(dataEntrada, dataSaida);
                if (valor < 0)
                    flag = false;
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Data de saida e invalida! Pois a data saida corresponde periodo antes da data de entrada!");
                    Console.ResetColor();
                }
            }
            return dataSaida;           
        }

        public static Reserva ReservaParaCancelar(Hotel hotel) {
            bool flag = true;
            int numeroReserva;
            Reserva reserva = null;

            while (flag) {
                Console.Write("Digite o numero da reserva que deseja cancelar ou zero para sair desta tela: ");
                try{
                    numeroReserva = int.Parse(Console.ReadLine());
                    if(numeroReserva == 0) {
                        flag = false;
                    }
                    else {
                        foreach(Reserva res in hotel.Reservas) {
                            if (res.NumeroReserva == numeroReserva) {
                                reserva = res;
                                flag = false;
                                break;
                            }
                        }
                        if (reserva == null) {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Reserva nao encontrada! Tente novamente");
                            Console.ResetColor();
                        }
                    }
                }
                catch {
                    MsgInvalida();
                }        
            }
            return reserva;
        }   
    }
}
