using System;
using System.Collections.Generic;

class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private List<string> veiculos = new List<string>(); // Essa lista vai cadastrar as placas

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        //Validação de valor por causa das horas
        this.precoInicial = precoInicial; 
        this.precoPorHora = precoPorHora;
    }


    //metodo que adiciona a placa do carro  - .Add server pra jogar dentro da lista depois de puxar da var.placa
    public void AdicionarVeiculo()
    {
        Console.Write("Digite a placa do veículo para estacionar: ");
        string placa = Console.ReadLine();
        veiculos.Add(placa);
        Console.WriteLine($"Veículo {placa} adicionado com sucesso!");
    }

    public void RemoverVeiculo()
    {
        Console.Write("Digite a placa do veículo para remover: ");
        string placa = Console.ReadLine();

        //contains é o principal na validação, ve se a placa ta la (ele é bool)
        if (veiculos.Contains(placa))
        {
            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            int horas = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal = precoInicial + (precoPorHora * horas);
            veiculos.Remove(placa);

            Console.WriteLine($"Veículo {placa} removido. Total a pagar: R$ {valorTotal:F2}");
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui.");
        }
    }

    //Metodo count conta os veiculos da lista veiculos, ent ser for igual a zero ele não falar q ta vazio
    public void ListarVeiculos()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
        else
        {
            Console.WriteLine("Veículos estacionados:");
            foreach (var v in veiculos)
            {
                Console.WriteLine(v);
            }
        }
    }
}



//Gerenciamento do MENU - Apenas variaveis 
class Program
{
    static void Main(string[] args)
    {
        //Variaveis que foram pedidas no read.me do leo 
        Console.WriteLine("Bem-vindo ao sistema de estacionamento!");

        Console.Write("Digite o preço inicial: ");
        decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite o preço por hora: ");
        decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());
        Console.Clear();

        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);


        //Aqui basicamente deixamos as clesses dentro do switch case, evitando todo aquele codigo poluido dentro
        //dos cases. Assim, puxamos os metodos pois são classes publcias.
        while (true)
        {
            Console.WriteLine(@"
1 - Cadastrar veículo
2 - Remover veículo
3 - Listar veículos
4 - Encerrar
                        ");
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    estacionamento.AdicionarVeiculo();
                    break;
                case 2:
                    estacionamento.RemoverVeiculo();
                    break;
                case 3:
                    estacionamento.ListarVeiculos();
                    break;
                case 4:
                    Console.WriteLine("Encerrando o sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }
}
