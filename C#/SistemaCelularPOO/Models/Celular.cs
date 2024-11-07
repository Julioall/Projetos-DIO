using System;

namespace SistemaCelular
{
    public abstract class Celular
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string SistemaOperacional { get; set; }

        protected Celular(string marca, string modelo, string sistemaOperacional)
        {
            Marca = marca;
            Modelo = modelo;
            SistemaOperacional = sistemaOperacional;
        }

        public virtual void Ligar()
        {
            Console.WriteLine($"{Modelo} está ligando...");
        }

        public abstract void TirarFoto();

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Sistema Operacional: {SistemaOperacional}");
        }
    }
}
