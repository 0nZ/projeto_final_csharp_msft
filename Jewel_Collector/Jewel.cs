namespace Jewel_Collector
{
    /// <summary>
    /// Classe responsável pelas Jóias e contabilizar pontuação.
    /// </summary>
    public class Jewel : ItemMapa
    {

        public int Points {get; private set;}
        public Jewel(string Symbol, int Points) : base(Symbol)
        {
            this.Points = Points;
        }
        
    }
}
