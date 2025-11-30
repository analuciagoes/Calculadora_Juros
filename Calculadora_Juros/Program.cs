using System.Globalization;

Console.WriteLine("=== Calculadora de Juros ===");
Console.WriteLine();

try
{
    Console.Write("Digite o valor principal: R$ ");
    string? valorInput = Console.ReadLine();
    
    if (!decimal.TryParse(valorInput, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out decimal valorPrincipal) && 
        !decimal.TryParse(valorInput, out valorPrincipal))
    {
        Console.WriteLine("Erro: Valor inválido!");
        return;
    }

    if (valorPrincipal <= 0)
    {
        Console.WriteLine("Erro: O valor deve ser maior que zero!");
        return;
    }

    Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
    string? dataInput = Console.ReadLine();
    
    if (!DateTime.TryParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataVencimento))
    {
        Console.WriteLine("Erro: Data inválida! Use o formato dd/MM/yyyy");
        return;
    }

    DateTime dataAtual = DateTime.Now.Date;
    int diasAtraso = (dataAtual - dataVencimento.Date).Days;

    Console.WriteLine();
    Console.WriteLine("=== Resultado ===");
    Console.WriteLine($"Valor Principal: {valorPrincipal:C}");
    Console.WriteLine($"Data de Vencimento: {dataVencimento:dd/MM/yyyy}");
    Console.WriteLine($"Data Atual: {dataAtual:dd/MM/yyyy}");

    if (diasAtraso <= 0)
    {
        Console.WriteLine("O pagamento não está em atraso.");
        Console.WriteLine($"Valor a pagar: {valorPrincipal:C}");
    }
    else
    {
        decimal taxaJurosDiaria = 0.025m;
        decimal valorJuros = valorPrincipal * taxaJurosDiaria * diasAtraso;
        decimal valorTotal = valorPrincipal + valorJuros;

        Console.WriteLine($"Dias de atraso: {diasAtraso}");
        Console.WriteLine($"Taxa de juros: {taxaJurosDiaria:P} ao dia");
        Console.WriteLine($"Valor dos juros: {valorJuros:C}");
        Console.WriteLine($"Valor total a pagar: {valorTotal:C}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();
