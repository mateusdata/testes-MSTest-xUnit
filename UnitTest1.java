using Xunit;
using Xunit.Abstractions;

namespace TestesMSTestxUnit // Verifique se este é o namespace correto do seu projeto
{
    public class CalculatorTests
    {
        private readonly ITestOutputHelper _output;

        public CalculatorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 2;
            int b = 3;

            // Log com ITestOutputHelper (para a janela de saída de teste)
            _output.WriteLine($"Tentando adicionar {a} e {b}");

            // Log com Console.WriteLine (para o terminal)
            Console.WriteLine($"Tentando adicionar {a} e {b} - log para terminal");

            // Act
            int result = calculator.Add(a, b);

            // Log de resultado
            _output.WriteLine($"Resultado da soma: {result}");
            Console.WriteLine($"Resultado da soma: {result} - log para terminal");

            // Assert
            Assert.Equal(5, result);
        }
    }
}
