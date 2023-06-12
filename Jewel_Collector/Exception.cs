namespace Jewel_Collector
{
    /// <summary>
    /// Classe responsável pelas exceções tanto nos casos de o robo tentar sair do mapa, posição ocupada e sem energia.
    /// </summary>
    public class Exception  : System.Exception
    {
        public class OutOfMapException : System.Exception {}
        public class OccupiedPositionException : System.Exception {}
        public class RanOutOfEnergyException : System.Exception {}
    }
}
