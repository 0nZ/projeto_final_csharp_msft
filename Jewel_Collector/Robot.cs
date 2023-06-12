namespace Jewel_Collector
{
    /// <summary>
    /// Classe responsável pelo robo, sua interação com o mapa e os itens.
    /// </summary>
    public class Robot : ItemMapa {

        public Map map {get; private set;}
        private int x, y;
        private List<Jewel> Bag = new List<Jewel>();
        public int energy {get; set;}
        
        /// <summary>
        /// Responsável por colocar o robo em sua posição inicial, atribuir energia que inicia o nível.
        /// </summary>
        public Robot(Map map, int x=0, int y=0, int energy=5) : base(" ME "){
            this.map = map;
            this.x = x;
            this.y = y;
            this.energy = energy;
            this.map.inserirMap(this, x, y);
        }


        /// <summary>
        /// MoveNorth()
        /// Responsável pela movimentação.
        /// </summary>
        public void MoveNorth(){
            try
            {
                map.updateMap(this.x, this.y, this.x-1, this.y);
                this.x--;
                this.energy--;
            }
            catch (Exception.OccupiedPositionException)
            {
                Console.WriteLine($"\nPosição {this.x-1}, {this.y} ocupada");
            }
            catch (Exception.OutOfMapException)
            {
                Console.WriteLine($"\nPosição {this.x-1}, {this.y} fora do mapa");
            }
            catch (Exception)
            {
                Console.WriteLine($"\nPosição é proíbida");
            }
        }

        /// <summary>
        /// MoveSouth()
        /// Responsável pela movimentação.
        /// </summary>
        public void MoveSouth(){
            try
            {
                map.updateMap(this.x, this.y, this.x+1, this.y);
                this.x++;
                this.energy--;
            }
            catch (Exception.OccupiedPositionException)
            {
                Console.WriteLine($"\nPosição {this.x+1}, {this.y} ocupada");
            }
            catch (Exception.OutOfMapException)
            {
                Console.WriteLine($"\nPosição {this.x+1}, {this.y} fora do mapa");
            }
            catch (Exception)
            {
                Console.WriteLine($"\nPosição é proíbida");
            }
        }

        /// <summary>
        /// MoveEast()
        /// Responsável pela movimentação.
        /// </summary>
        public void MoveEast(){
            try
            {
                map.updateMap(this.x, this.y, this.x, this.y+1);
                this.y++;
                this.energy--;
            }
            catch (Exception.OccupiedPositionException)
            {
                Console.WriteLine($"\nPosição {this.x}, {this.y+1} ocupada");
            }
            catch (Exception.OutOfMapException)
            {
                Console.WriteLine($"\nPosição {this.x}, {this.y+1} fora do mapa");
            }
            catch (Exception)
            {
                Console.WriteLine($"\nPosição é proíbida");
            }
        }

        /// <summary>
        /// MoveWest()
        /// Responsável pela movimentação.
        /// </summary>
        public void MoveWest(){
            try
            {
                map.updateMap(this.x, this.y, this.x, this.y-1);
                this.y--;
                this.energy--;
            }
            catch (Exception.OccupiedPositionException)
            {
                Console.WriteLine($"\nPosição {this.x}, {this.y-1} ocupada");
            }
            catch (Exception.OutOfMapException)
            {
                Console.WriteLine($"\nPosição {this.x}, {this.y-1} fora do mapa");
            }
            catch (Exception)
            {
                Console.WriteLine($"\nPosição é proíbida");
            }
        }

        /// <summary>
        /// Responsável por recarregar a energia do robo.
        /// </summary>
        public void Get(){
            //Console.Clear();
            Rechargeable? RechargeEnergy = map.GetRechargeable(this.x, this.y);
            RechargeEnergy?.Recharge(this);
            List<Jewel> NearJewels = map.GetJewels(this.x, this.y);
            foreach (Jewel j in NearJewels)
                Bag.Add(j);
        }

        /// <summary>
        /// Responsável por contar a quantidade de pontos.
        /// </summary>
        private (int, int) GetBagInfo()
        {
            int Points = 0;
            foreach (Jewel j in this.Bag)
                Points += j.Points;
            return (this.Bag.Count, Points);
        }
        
        /// <summary>
        /// Responsável por imprimir a quantidade de itens, pontos e energia.
        /// </summary>
        public void Print()
        {
            map.Print();
            (int ItensBag, int TotalPoints) = this.GetBagInfo();
            Console.WriteLine($"\nItens na mochila: {ItensBag} - Total de pontos: {TotalPoints} - Energia: {this.energy} - x:{this.x}, y: {this.y}\n\n");
        }
        public bool HasEnergy()
        {
            return this.energy > 0;
        }
    }
}