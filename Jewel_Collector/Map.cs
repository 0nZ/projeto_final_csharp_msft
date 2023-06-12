/// <summary>
/// AUTOR: WILLIAN VAZ - 182845
/// Classe reponsável pelo Mapa.
/// </summary>
namespace Jewel_Collector 
{
    public class Map
    {
        
        private ItemMapa[,] mapa;
        public int h {get; private set;}
        public int w {get; private set;}
        
        /// <summary>
        /// Classe reponsável por gerar o mapa com tamanho 10x10.
        /// Posteriormente conforme avança, incrementa +1 ao tamanho do mapa, até o limite 30x30.
        /// </summary>
        public Map(int w=10, int h=10, int fase=1) 
        {
            this.w = w <= 30 ? w : 30;
            this.h = h <= 30 ? h : 30;
            mapa = new ItemMapa[w, h];

            for (int i = 0; i < mapa.GetLength(0); i++) {
                for (int j = 0; j < mapa.GetLength(1); j++) {
                    mapa[i, j] = new Empty();
                }
            }

            if (fase == 1) 
            {
                //Chama o método para gerar os obstáculos de forma fixa
                GenerateFixed();
            } else { 
                //Chama o método para gerar os obstáculos de forma dinâmica e randômica
                MapaRandomico();
            }

        }

        /// <summary>
        /// Responsável por posicionar itens no mapa dentro da matriz [mapa].
        /// </summary>
        public void inserirMap(ItemMapa Item, int x, int y)
        {
            mapa[x, y] = Item;
        }

        /// <summary>
        /// Responsável por atualizar o Status do mapa.
        /// </summary>
        public void updateMap(int x_old, int y_old, int x, int y)
        {
            if (x < 0 || y < 0 || x> this.w-1 || y> this.h-1)
                {
                    Console.WriteLine($"\nOutOfMapException:x({x}) > w({this.w-1}) ou y({y}) > h({this.w-1})");
                    throw new Exception.OutOfMapException();
                }
                if (VeirficaMapa(x, y))
                {
                    mapa[x, y] = mapa[x_old, y_old];
                    mapa[x_old, y_old] = new Empty();
                }
                else
                {
                    //Passa pela radiação!
                    String GetObstacle = mapa[x, y].ToString();
                    if(GetObstacle == " !! "){
                        mapa[x, y] = mapa[x_old, y_old];
                        mapa[x_old, y_old] = new Empty();
                        Console.WriteLine($"\n RADIAÇÃO!");
                    } else {
                        Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                        throw new Exception.OccupiedPositionException();
                    }
                }
        }

        /// <summary>
        /// Responsável por atualizar a quantidade de Jóias coletadas.
        /// </summary>
        public List<Jewel> GetJewels(int x, int y){
            List<Jewel> NearJewels = new List<Jewel>();
            int[,] Coords = GenerateCoord(x, y);
            for (int i = 0; i < Coords.GetLength(0); i++){
                Jewel? jewel = GetJewel(Coords[i, 0], Coords[i, 1]);
                if (jewel is not null) NearJewels.Add(jewel);
            }
            return NearJewels;
        }

        /// <summary>
        /// Responsável por atualizar a posição do mapa onde havia a joia para um item vazio.
        /// </summary>
        private Jewel? GetJewel(int x, int y)
        {
            if (mapa[x, y] is Jewel jewel)
            {
                mapa[x, y] = new Empty();
                return jewel;
            }
            return null;
        }

        /// <summary>
        /// Responsável por incrementar a energia do robo conforme coletados itens válidos.
        /// </summary>
        public Rechargeable? GetRechargeable(int x, int y){
            int[,] Coords = GenerateCoord(x, y);
            for (int i = 0; i < Coords.GetLength(0); i++)
                if (mapa[Coords[i, 0], Coords[i, 1]] is Rechargeable r) return r;
            return null;
        }
        /// <summary>
        /// Responsável por gerar coordenadas no mapa.
        /// </summary>
        private int[,] GenerateCoord(int x, int y)
        {
            int[,] Coords = new int[4, 2]{
                {x,  y+1 < w-1 ? y+1 : w-1},
                {x, y-1 > 0 ? y-1 : 0},
                {x+1 < h-1 ? x+1 : h-1, y},
                {x-1 > 0 ? x-1 : 0, y}
            };
            return Coords;
        }

        /// <summary>
        /// Booleana que verifica se a posição está vazia e permitida para robo transitar.
        /// </summary>
        private bool VeirficaMapa(int x, int y){
            return mapa[x, y] is Empty;
        }
        public void Print() {
            for (int i = 0; i < mapa. GetLength(0); i++){
                for (int j = 0; j < mapa.GetLength(1); j++){
                    Console.Write(mapa[i, j]);
                }
                Console.Write("\n");
            }
        }

        public bool IsDone()
        {
            for (int i = 0; i < mapa.GetLength(0); i++) {
                for (int j= 0; j < mapa.GetLength(1); j++){
                    if (mapa[i, j] is Jewel) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gera a posição inicial das Joias, água e árvores no primeiro nível.
        /// </summary>
        private void GenerateFixed()
        {
            this.inserirMap(new JewelRed(), 1, 9);
            this.inserirMap(new JewelRed(), 8, 8);
            this.inserirMap(new JewelGreen(), 9, 1);
            this.inserirMap(new JewelGreen(), 7, 6);
            this.inserirMap(new JewelBlue(), 3, 4);
            this.inserirMap(new JewelBlue(), 2, 1);

            this.inserirMap(new ObstaclesWater(), 5, 0);
            this.inserirMap(new ObstaclesWater(), 5, 1);
            this.inserirMap(new ObstaclesWater(), 5, 2);
            this.inserirMap(new ObstaclesWater(), 5, 3);
            this.inserirMap(new ObstaclesWater(), 5, 4);
            this.inserirMap(new ObstaclesWater(), 5, 5);
            this.inserirMap(new ObstaclesWater(), 5, 6);
            this.inserirMap(new ObstaclesTree(), 5, 9);
            this.inserirMap(new ObstaclesTree(), 3, 9);
            this.inserirMap(new ObstaclesTree(), 8, 3);
            this.inserirMap(new ObstaclesTree(), 2, 5);
            this.inserirMap(new ObstaclesTree(), 1, 4);
        }

        /// <summary>
        /// Gera posição aleatória dos itens do mapa na fase 2 em diante.
        /// </summary>
        public void MapaRandomico()
        {

            Random r = new Random(1);
            for(int x = 0; x < 3; x++)
            {
                int xRandom = r.Next(0, w);
                int yRandom = r.Next(0, h);
                this.inserirMap(new JewelBlue(), xRandom, yRandom);
            }
            for(int x = 0; x < 3; x++)
            {
                int xRandom = r.Next(0, w);
                int yRandom = r.Next(0, h);
                this.inserirMap(new JewelGreen(), xRandom, yRandom);
            }
            for(int x = 0; x < 3; x++)
            {
                int xRandom = r.Next(0, w);
                int yRandom = r.Next(0, h);
                this.inserirMap(new JewelRed(), xRandom, yRandom);
            }
            for(int x = 0; x < 10; x++)
            {
                int xRandom = r.Next(0, w);
                int yRandom = r.Next(0, h);
                this.inserirMap(new ObstaclesWater(), xRandom, yRandom);
            }
            for(int x = 0; x < 10; x++)
            {
                int xRandom = r.Next(0, w);
                int yRandom = r.Next(0, h);
                this.inserirMap(new ObstaclesTree(), xRandom, yRandom);
            }
            for(int x = 0; x < 10; x++)
            {
                int xRandom = r.Next(0, w);
                int yRandom = r.Next(0, h);
                this.inserirMap(new Radioactive(), xRandom, yRandom);
            }

        }
        
    }
    
}