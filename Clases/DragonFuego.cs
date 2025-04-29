namespace Proyecto.Clases
{
    public class DragonFuego : IDragon
    {
        public string Nombre { get; private set; } = null!;
        public Elementos Elemento { get; } = Elementos.Fuego;
        public int Nivel { get; private set;} = 1;
        public int MaxHp { get; private set; } = 100;
        public int Hp { get; set; } = 100;
        public int Atk { get; private set; } = 15;
        public List<Ataque> Ataques { get; private set; }

        public DragonFuego (string nombre, int nivel)
        {
            Nombre = nombre;
            Nivel = nivel;
            // Dragon de fuego tiene bastante ataque
            Hp = 100 + (15 * Nivel);
            MaxHp = Hp;
            Atk = 15 + (10 * (Nivel / 2));
            Ataques = new List<Ataque> 
            {
                new Ataque("Golpe básico", Nombre, Elementos.Neutral, Atk),
                new Ataque("Bolas de fuego", Nombre, Elementos.Fuego, Atk+5)
            };
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Dragon de Fuego [{Nombre}]");
            Console.WriteLine($"NIVEL {Nivel}");
            Console.WriteLine($"ATK: {Atk} | HP: {Hp}/{MaxHp}");
            Console.WriteLine();
        }

        public void MostrarEstatus()
        {
            Console.WriteLine($" => {Nombre} [{Hp}/{MaxHp} HP]");
        }

        public int Atacar(int precision, int esquive, Elementos elementoContrario, int numAtaque)
        {
            return Ataques[numAtaque].RealizarAtaque(precision, esquive, elementoContrario);
        }

        public void Curar(int curacion)
        {

        }
    }
}