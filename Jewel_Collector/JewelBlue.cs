namespace Jewel_Collector
{
    /// <summary>
    /// Classe reponsável pela Jóia Azul, pontuação e recarregar energia (5 pontos)
    /// </summary>
    public class JewelBlue : Jewel, Rechargeable {

        public void Recharge(Robot r)
        {
            r.energy++;
            r.energy++;
            r.energy++;
            r.energy++;
            r.energy++;
        }

        public JewelBlue() : base(" JB ", 10) {}
        
    }
}
