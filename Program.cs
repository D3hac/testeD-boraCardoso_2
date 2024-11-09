using System;

public class Produto{

    private int idProd;
    private string designacao;
    private int qtdStock;
    private int stockSeg;

    // Construtor que inicializa Designacao
    public Produto()
    {
        Designacao = "Produto XPTO";
    }

    // Construtor que inicializa QtdStock com 100
    public Produto(int qtdStock)
    {
        QtdStock = qtdStock;
    }

    // Construtor que permite a inicialização simultânea de Designacao e a QtdStock
    public Produto(string designacao, int qtdStock)
    {
        Designacao = designacao;
        QtdStock = qtdStock;
    }

    public int IdProd{
        get { return idProd; }
        set { idProd = value > 0 ? value : throw new ArgumentException("O IdProd deve ser maior que zero."); }
    }

    public string Designacao{
        get { return designacao; }
        set { designacao = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("A Designacao não pode ser nula ou vazia."); }
    }

    public int QtdStock{
        get { return qtdStock; }
        set
        {
            if (value >= 0)
            {
                qtdStock = value;
            }
            else
            {
                throw new ArgumentException("A quantidade de stock não pode ser negativa!");
            }
        }
    }

    public int StockSeg{
        get { return stockSeg; }
        set
        {
            if (value >= 0)
            {
                stockSeg = value;
            }
            else
            {
                throw new ArgumentException("O stock de segurança não pode ser negativo!");
            }
        }
    }

    // Método calcular a quantidade disponível
    public int CalcularQuantidadeDisponivel()
    {
        return QtdStock - StockSeg;
    }

    // Método levantar produto
    public bool LevantarProduto(int quantidade)
    {
        if (quantidade > 0)
        {
            if (QtdStock >= quantidade)
            {
                QtdStock -= quantidade;

                Console.WriteLine($"OK! {quantidade} levantada. Stock restante: {QtdStock}");

                if (QtdStock < StockSeg)
                {
                    Console.WriteLine("Solicitar reposição ao fornecedor!");
                }

                return true;
            }
            else
            {
                Console.WriteLine("Stock insuficiente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("A quantidade deve ser maior que zero!");
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        // Instanciar um objeto da classe Produto utilizando o segundo construtor
        Produto produto2 = new Produto(120);

        try
        {
            // preencher os atributos do objeto com valores inseridos pelo user
            Console.Write("Insira o ID do produto: ");
            produto2.IdProd = int.Parse(Console.ReadLine());

            Console.Write("Insira a designacão: ");
            produto2.Designacao = Console.ReadLine();

            Console.Write("Insira a quantidade do stock de segurança: ");
            produto2.StockSeg = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return;
        }

        Console.WriteLine("\nInformações do Produto:");
        Console.WriteLine($"IdProd: {produto2.IdProd}");
        Console.WriteLine($"Designacao: {produto2.Designacao}");
        Console.WriteLine($"QtdStock: {produto2.QtdStock}");
        Console.WriteLine($"StockSeg: {produto2.StockSeg}");
        Console.WriteLine($"Quantidade Disponível: {produto2.CalcularQuantidadeDisponivel()}");

        // Método LevantarProduto
        Console.Write("\nInsira a quantidade a levantar do produto: ");
        int quantidadeLevantar;
        if (int.TryParse(Console.ReadLine(), out quantidadeLevantar))
        {
            produto2.LevantarProduto(quantidadeLevantar);
        }
        else
        {
            Console.WriteLine("A quantidade inserida não é válida!");
        }
    }
}

