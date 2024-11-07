namespace SistemaCelular
{
    public class Iphone : Celular
    {
        public Iphone(string modelo)
            : base("Apple", modelo, "iOS") { }

        public override void TirarFoto()
        {
            Console.WriteLine($"{Modelo} está tirando uma foto com a câmera de 12MP.");
        }

        public override void Ligar()
        {
            Console.WriteLine($"{Modelo} está ligando via FaceTime...");
        }
    }
}
