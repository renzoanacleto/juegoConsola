namespace Proyecto.Clases
{
    public interface IDragon
    {
        string Nombre { get; }
        Elementos Elemento { get; }
        int Nivel { get; }
        int MaxHp { get; }
        int Hp { get; set; }
        int Atk { get; }
        List<Ataque> Ataques { get; }
        void MostrarDatos();
        void MostrarEstatus();
        int Atacar(int precision, int esquive, Elementos elementoContrario, int numAtaque);
        void Curar(int curacion);
    }
}