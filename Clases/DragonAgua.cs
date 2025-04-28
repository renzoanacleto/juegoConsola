namespace Proyecto.Clases
{
    public class DragonAgua : IDragon
    {
        public string Nombre { get; private set; } = null!;
        public Elementos Elemento { get; } = Elementos.Agua;
        public int Nivel { get; private set;} = 1;
        public int MaxHp { get; private set; } = 100;
        public int Hp { get; set; } = 100;
        public int Atk { get; private set; } = 15;
        public List<Ataque> Ataques { get; private set; }

        public DragonAgua (string nombre, int nivel)
        {
            Nombre = nombre;
            Nivel = nivel;
            // Dragon de agua incrementa bastante su vida al subir de nivel
            Hp = 100 + (20 * Nivel);
            MaxHp = Hp;
            Atk = 15 + (10 * (Nivel / 2));
            Ataques = new List<Ataque> 
            {
                new Ataque("Golpe básico", Nombre, Elementos.Neutral, Atk),
                new Ataque("Burbujas a velocidad", Nombre, Elementos.Agua, Atk)
            };
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Dragon de Agua [{Nombre}]");
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