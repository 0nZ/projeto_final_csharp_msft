namespace Jewel_Collector
{
    /// <summary>
    /// Classe responsável pelo itens do mapa, em específico os obstáculos.
    /// </summary>
    public abstract class Obstacle : ItemMapa 
    {
        public Obstacle(string Symbol) : base(Symbol) {}
    }
}
