using System;

namespace SistemaCelular
{
    class Program
    {
        static void Main(string[] args)
        {
            Celular iphone = new Iphone("iPhone 15");
            Celular samsung = new Samsung("Galaxy S24");

            iphone.ExibirInformacoes();
            iphone.Ligar();
            iphone.TirarFoto();

            Console.WriteLine();

            samsung.ExibirInformacoes();
            samsung.Ligar();
            samsung.TirarFoto();
        }
    }
}
