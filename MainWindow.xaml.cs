using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Estudo_de_viabilidade
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Coloque a lógica de inicialização da janela aqui, se necessário.
        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Programa de Estudo de Viabilidade Industrial");

            // Coleta de dados
            double investimentoMaquina = ObterEntradaDouble("Investimento em Máquina Modelo CP4000: $");
            double investimentoEstrutura = ObterEntradaDouble("Investimento em Estrutura: $");
            double investimentoEnergiaFotovoltaica = ObterEntradaDouble("Investimento em Energia Fotovoltaica 1MWP: $");
            double investimentoTerreno = ObterEntradaDouble("Investimento em Área de Construção (Terreno): $");
            double investimentoFundacaoTerraplanagem = ObterEntradaDouble("Investimento em Fundação e Terraplanagem: $");

            double investimentoTotal = investimentoMaquina + investimentoEstrutura + investimentoEnergiaFotovoltaica
                                        + investimentoTerreno + investimentoFundacaoTerraplanagem;

            double recursosProprios = ObterEntradaDouble("Recursos Próprios: $");
            double recursosTerceiros = ObterEntradaDouble("Recursos de Terceiros: $");
            double outrosRecursos = ObterEntradaDouble("Outros Recursos (próprios): $");

            double recursosTotal = recursosProprios + recursosTerceiros + outrosRecursos;

            // Financiamento
            double financiamento = recursosTerceiros;
            double jurosAnuais = 0.9;
            int duracaoAnos = 13;
            double jurosMensais = (1 + jurosAnuais) / 12 - 1;
            double prestacaoMensal = financiamento * (jurosMensais * Math.Pow(1 + jurosMensais, duracaoAnos * 12))
                                      / (Math.Pow(1 + jurosMensais, duracaoAnos * 12) - 1);

            // Despesas mensais
            double despesasMensais = ObterEntradaDouble("Despesas Mensais (IPTU, Água, Energia, etc.): $");

            // Outras despesas
            double outrasDespesas = ObterEntradaDouble("Outras Despesas: $");

            // Total de despesas
            double totalDespesas = despesasMensais + outrasDespesas;

            // Receitas (considerando apenas um produto/serviço)
            double quantidadeProducaoPorHora = ObterEntradaDouble("Quantidade de Produção por Hora: ");
            double precoVendaPorKG = ObterEntradaDouble("Preço de Venda por KG: $");
            double valorPorHora = quantidadeProducaoPorHora * precoVendaPorKG;

            // Cenários
            double cenarioProvavel = valorPorHora * 8 * 20 * 30;  // 8 horas por dia, 20 dias úteis, 30 dias por mês
            double cenarioPessimista = cenarioProvavel * 0.5;  // 50% de variação para baixo
            double cenarioOtimista = cenarioProvavel * 1.3;  // 30% de variação para cima

            // Apresenta os resultados
            ApresentarResultados(investimentoTotal, recursosTotal, prestacaoMensal, totalDespesas, cenarioProvavel, cenarioPessimista, cenarioOtimista);
        }

        // Métodos auxiliares para coleta de dados e cálculos podem ser adicionados aqui
        // ...

        // Exemplo de método para coletar dados do usuário
        private double ObterEntradaDouble(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Por favor, insira um valor numérico válido.");
                return ObterEntradaDouble(prompt);
            }
        }

        private void ApresentarResultados(double investimentoTotal, double recursosTotal, double prestacaoMensal,
                                         double totalDespesas, double cenarioProvavel, double cenarioPessimista, double cenarioOtimista)
        {
            Console.WriteLine("\nResultados do Estudo de Viabilidade:");
            Console.WriteLine($"Investimento Total: {investimentoTotal:C}");
            Console.WriteLine($"Recursos Total: {recursosTotal:C}");
            Console.WriteLine($"Prestação Mensal do Financiamento: {prestacaoMensal:C}");
            Console.WriteLine($"Total de Despesas Mensais: {totalDespesas:C}");
            Console.WriteLine($"Cenário Provável: {cenarioProvavel:C}");
            Console.WriteLine($"Cenário Pessimista: {cenarioPessimista:C}");
            Console.WriteLine($"Cenário Otimista: {cenarioOtimista:C}");
        }
    }
}