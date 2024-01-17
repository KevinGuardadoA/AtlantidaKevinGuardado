namespace ApiTarjeta.Entidades
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarjeta { get; set; }
        public int IdTipoTransaccion { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
