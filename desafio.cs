public abstract class Imovel
{

    protected string Endereco { get; set; }
    protected int Numero { get; set; }
    protected bool Alugado { get; set; }
    protected Proprietario Proprietario { get; set; }

    public void SetEndereco(string endereco) => Endereco = endereco;
    public string GetEndereco() => Endereco;

    public void SetNumero(int numero) => Numero = numero;
    public int GetNumero() => Numero;

    public void SetAlugado(bool alugado) => Alugado = alugado;
    public bool GetAlugado() => Alugado;

    public void SetProprietario(Proprietario p) => Proprietario = p;
    public Proprietario GetProprietario() => Proprietario;
    public bool estaAlugado()
    {
        return Alugado ? "O imóvel está alugado." : "O imóvel está disponível.";
    }

    public string contatoProprietario()
    {
        if (Proprietario == null) return "Sem proprietário cadastrado.";
        return $"Nome: {Proprietario.Nome}, Telefone: {Proprietario.Telefone}, CPF: {Proprietario.CPF}";
    }

    public int calcularAluguel(int dias);

    public override string ToString()
    {
        var tipo = this.GetType().Name;
        return $"{tipo} - Endereço: {Endereco}, Nº: {Numero}, Status: {estaAlugado()}, Proprietário: {(Proprietario != null ? Proprietario.Nome : "Nenhum")}";
    }
}

public class Casa : Imovel
{
    private const int diaria = 200;

    public override string estaAlugado()
    {
        return Alugado ? "A casa está alugada." : "A casa está disponível.";
    }

    public override int calcularAluguel(int dias)
    {
        if (dias < 0) throw new ArgumentException("Dias deve ser >= 0");
        return diaria * dias;
    }
}

public class Apartamento : Imovel
{
    private const int diaria = 150; 

    public override string estaAlugado()
    {
        return Alugado
            ? $"O apartamento de número {GetNumero()} está alugado."
            : $"O apartamento de número {GetNumero()} está disponível.";
    }

    public override int calcularAluguel(int dias)
    {
        if (dias < 0) throw new ArgumentException("Dias deve ser >= 0");
        return diaria * dias;
    }
}

public class Proprietario
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CPF { get; set; }
}

public static class Program
{
    private static List<Imovel> lista = new List<Imovel>();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Corretora Imobiliária ---");
            Console.WriteLine("1) Cadastrar imóvel (Casa / Apartamento)");
            Console.WriteLine("2) Deletar imóvel");
            Console.WriteLine("3) Listar imóveis");
            Console.WriteLine("4) Alugar / Disponibilizar imóvel");
            Console.WriteLine("5) Calcular valor total de aluguel (período)");
            Console.WriteLine("6) Listar imóveis alugados");
            Console.WriteLine("0) Sair");
            Console.Write("Escolha: ");
            var opt = Console.ReadLine();

            switch (opt)
            {
                case "1": Cadastrar(); break;
                case "2": Deletar(); break;
                case "3": Listar(); break;
                case "4": ToggleAluguel(); break;
                case "5": CalcularTotal(); break;
                case "6": ListarAlugados(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
    }

    private static void Cadastrar()
    {
        Console.Write("Tipo (1=Casa, 2=Apartamento): ");
        var tipo = Console.ReadLine();
        Console.Write("Endereço: ");
        var endereco = Console.ReadLine();
        Console.Write("Número: ");
        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        Console.Write("Nome do proprietário: ");
        var nome = Console.ReadLine();
        Console.Write("Telefone do proprietário: ");
        var telefone = Console.ReadLine();
        Console.Write("CPF do proprietário: ");
        var cpf = Console.ReadLine();

        var proprietario = new Proprietario { Nome = nome, Telefone = telefone, CPF = cpf };

        Imovel imovel = tipo == "1" ? (Imovel)new Casa() : new Apartamento();
        imovel.SetEndereco(endereco);
        imovel.SetNumero(numero);
        imovel.SetProprietario(proprietario);
        imovel.SetAlugado(false);

        lista.Add(imovel);
        Console.WriteLine("Imóvel cadastrado com sucesso.");
    }

    private static void Deletar()
    {
        if (lista.Count == 0) { Console.WriteLine("Nenhum imóvel cadastrado."); return; }
        Listar();
        Console.Write("Informe o índice do imóvel a deletar: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 0 || idx >= lista.Count)
        {
            Console.WriteLine("Índice inválido.");
            return;
        }
        lista.RemoveAt(idx);
        Console.WriteLine("Imóvel removido.");
    }

    private static void Listar()
    {
        if (lista.Count == 0) { Console.WriteLine("Nenhum imóvel cadastrado."); return; }
        for (int i = 0; i < lista.Count; i++)
        {
            var im = lista[i];
            Console.WriteLine($"[{i}] {im}");
            Console.WriteLine($"     Contato: {im.contatoProprietario()}");
            Console.WriteLine($"     Valor por dia: {im.calcularAluguel(1)}");
        }
    }

    private static void ToggleAluguel()
    {
        if (lista.Count == 0) { Console.WriteLine("Nenhum imóvel cadastrado."); return; }
        Listar();
        Console.Write("Informe o índice do imóvel para atualizar status do imóvel (alugar / disponibilizar): ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 0 || idx >= lista.Count)
        {
            Console.WriteLine("Índice inválido.");
            return;
        }
        var im = lista[idx];
        im.SetAlugado(!im.GetAlugado());
        Console.WriteLine($"Novo status: {im.estaAlugado()}");
    }

    private static void CalcularTotal()
    {
        if (lista.Count == 0) { Console.WriteLine("Nenhum imóvel cadastrado."); return; }
        Console.Write("Número de dias: ");
        if (!int.TryParse(Console.ReadLine(), out int dias) || dias < 0)
        {
            Console.WriteLine("Dias inválidos.");
            return;
        }
        int total = 0;
        foreach (var im in lista)
        {
            if (im.GetAlugado())
            {
                total += im.calcularAluguel(dias);
            }
        }
        Console.WriteLine($"Valor total dos imóveis alugados por {dias} dias: R$ {total}");
    }

    private static void ListarAlugados()
    {
        var alugados = lista.FindAll(i => i.GetAlugado());
        if (alugados.Count == 0) { Console.WriteLine("Nenhum imóvel alugado no momento."); return; }
        for (int i = 0; i < alugados.Count; i++)
        {
            var im = alugados[i];
            Console.WriteLine($"[{i}] {im} | Contato: {im.contatoProprietario()} | Valor/dia: {im.calcularAluguel(1)}");
        }
    }
}