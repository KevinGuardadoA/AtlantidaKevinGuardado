namespace ApiTarjeta.Entidades
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public decimal Disponible { get; set; }
        public decimal TasaInteres { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CCV { get; set; }
        public string Expedicion { get; set; }
        public string Vencimiento { get; set;}
        public List<Usuario> Usuarios { get; set;}
    }
}
