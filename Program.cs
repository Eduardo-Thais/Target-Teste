namespace Target_Teste
{
    using System.Text.Json;
    internal class Program
    {
        static void Main(string[] args)
        {
            // Questão 1
            int INDICE = 13;
            int SOMA = 0;
            int K = 0;
            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }
            Console.WriteLine(SOMA);
            Console.WriteLine();


            // Questão 2

            Console.Write("Informe um número: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroInformado) || numeroInformado < 0)
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            int a = 0, b = 1;
            bool pertence = false;

            while (a <= numeroInformado)
            {
                if (a == numeroInformado)
                {
                    pertence = true;
                    break;
                }

                int temp = a;
                a = b;
                b = temp + b;
            }

            if (pertence)
                Console.WriteLine($"O número {numeroInformado} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"O número {numeroInformado} NÃO pertence à sequência de Fibonacci.");

            Console.WriteLine();



            // Questão 3
            string caminho = "dados.json";
            string jsonString = File.ReadAllText(caminho);

            List<Faturamento> faturas = JsonSerializer.Deserialize<List<Faturamento>>(jsonString);
            var maiorValor = faturas.OrderByDescending(f => f.valor).First();
            var menorValor = faturas.OrderByDescending(f => f.valor).Last();
            var media = faturas.Average(f => f.valor);
            var acimaDaMedia = faturas.Where(f => f.valor > media).Count();

            Console.WriteLine($"Maior valor do mês: {maiorValor.dia}, {maiorValor.valor}");
            Console.WriteLine($"Menor valor do mês: {menorValor.dia}, {menorValor.valor}");
            Console.WriteLine($"Quantidade de mes acima da media: {acimaDaMedia}");

            // Questão 4
            var faturamentoEstado = new Dictionary<string, double>
            {
                { "SP", 67836.43 },
                { "RJ", 36678.66 },
                { "MG", 29229.88 },
                { "ES", 27165.48 },
                { "Outros", 19849.53 }
            };

            double total = 0;
            foreach (var valor in faturamentoEstado.Values)
            {
                total += valor;
            }

            Console.WriteLine("Percentual de representação por estado:");
            foreach (var estado in faturamentoEstado)
            {
                double percentual = (estado.Value / total) * 100;
                Console.WriteLine($"{estado.Key}: {percentual:F2}%");
            }
            Console.WriteLine();



            // Questão 5
            Console.Write("Informe uma palavra: ");
            var iverter = Console.ReadLine();
            if (string.IsNullOrEmpty(iverter))
            {
                Console.WriteLine("Palavra inválida.");
                return;
            }
            char[] letras = iverter.ToCharArray();
            var invertido = "";
            for (int i = letras.Length - 1; i >= 0; i--)
            {
                invertido += letras[i];
            }
            Console.WriteLine($"Palavra invertida: {invertido}");
        }
    }
}
