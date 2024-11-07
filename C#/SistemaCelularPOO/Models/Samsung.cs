namespace SistemaCelular
{
    public class Samsung : Celular
    {
        public Samsung(string modelo)
            : base("Samsung", modelo, "Android") { }

        public override void TirarFoto()
        {
            Console.WriteLine($"{Modelo} está tirando uma foto com a câmera de 108MP.");
        }

        public override void Ligar()
        {
            Console.WriteLine($"{Modelo} está ligando via rede 5G...");
        }
    }
}
