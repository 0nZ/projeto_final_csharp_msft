namespace Jewel_Collector 
{
    /// <summary>
    /// Classe responsável pelos itens Jewels e espaços vazios.
    /// </summary>
    public abstract class ItemMapa 
    {
        private string Symbol;
        public ItemMapa(string Symbol)
        {
            this.Symbol = Symbol;
        }
        public sealed override string ToString()
        {
            return Symbol;
        }
    }
}
