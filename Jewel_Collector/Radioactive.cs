namespace Jewel_Collector
{
    /// <summary>
    /// Classe reponsável pelo obstáculo radioativo e sua pontuação.
    /// </summary>
    public class Radioactive : Obstacle, Rechargeable 
    {
        public Radioactive() : base(" !! ") {}
        public void Recharge(Robot r)
        {
            r.energy++;
            r.energy++;
            r.energy++;
        }
    }
}
