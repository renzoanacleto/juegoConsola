namespace Proyecto.Clases
{
    public class Ataque 
    {
        public string Nombre { get; set; } = null!;
        public string Dragon { get; set; } = null!;
        public Elementos Elemento { get; set; }
        public int Fuerza { get; set; }
        
        public Ataque (string nombre, string dragon, Elementos elemento, int fuerza)
        {
            Nombre = nombre;
            Dragon = dragon;
            Elemento = elemento;
            Fuerza = fuerza;
        }

        public int RealizarAtaque(int precision, int esquive, Elementos elementoContrario)
        {
            int danio = 0;
            double elemental = 0;
            string mensaje = "";

            if (precision == 10)
            {
                danio = (int) (Fuerza * 1.5);
                mensaje = "¡Ataque critico! ";
            }
            else if (precision == esquive)
            {
                danio = (int) (Fuerza * 0.5);
                mensaje = "Choque de golpes. ";
            }
            else if (precision > esquive)
            {
                danio = Fuerza;
            }
            else
            {
                danio = 0;
                mensaje = "El enemigo lo esquivo. ";
            }

            elemental = Util.CalcularDanioElemental(Elemento, elementoContrario);

            danio = (int) (danio * elemental);

            if (elemental == 1.5 && danio != 0) 
                mensaje = mensaje + "¡Ataque efectivo!";
            else if (elemental == 0.5 && danio != 0)
                mensaje = mensaje + "El ataque fue debil...";

            Console.WriteLine($"{Dragon} hizo {danio} de daño. " + mensaje);
            return danio;
        }
    }
}