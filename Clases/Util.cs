namespace Proyecto.Clases
{
    public static class Util
    {
        public static double CalcularDanioElemental(Elementos e1, Elementos e2)
        {
            if (e1 == Elementos.Fuego)
            {
                if (e2 == Elementos.Planta) return 1.5;
                else if (e2 == Elementos.Agua) return 0.5;
                else return 1;
            }
            else if (e1 == Elementos.Planta)
            {
                if (e2 == Elementos.Tierra) return 1.5;
                else if (e2 == Elementos.Fuego) return 0.5;
                else return 1;
            }
            else if (e1 == Elementos.Tierra)
            {
                if (e2 == Elementos.Electrico) return 1.5;
                else if (e2 == Elementos.Planta) return 0.5;
                else return 1;
            }
            else if (e1 == Elementos.Electrico)
            {
                if (e2 == Elementos.Agua) return 1.5;
                else if (e2 == Elementos.Tierra) return 0.5;
                else return 1;
            }
            else if (e1 == Elementos.Agua)
            {
                if (e2 == Elementos.Fuego) return 1.5;
                else if (e2 == Elementos.Electrico) return 0.5;
                else return 1;
            }
            else
            {
                return 1;
            }
        }
    }
}