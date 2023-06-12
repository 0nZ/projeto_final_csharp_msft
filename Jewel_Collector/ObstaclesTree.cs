namespace Jewel_Collector
{
    /// <summary>
    /// Classe responsável pelo item do mapa árvore
    /// </summary>
    public class ObstaclesTree : Obstacle, Rechargeable 
    {

        public ObstaclesTree() : base(" $$ ") {}
        public void Recharge(Robot r)
        {
            r.energy++;
            r.energy++;
            r.energy++;
        }

    }

}
