public class BolhaSimples : Bolha
{
    void Awake()
    {
        aoSerAcertada = new SubdividirAoSerAcertada(this, 2, 1);
    }
}
