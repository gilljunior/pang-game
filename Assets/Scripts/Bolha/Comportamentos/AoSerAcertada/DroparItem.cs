using UnityEngine;

public class DroparItem : IAoSerAcertada
{
    private readonly Bolha _bolha;
    private readonly GameObject _drop;
    private readonly int _probabilidadeDrop;

    public DroparItem(Bolha bolha, GameObject drop, int probabilidadeDrop)
    {
        _bolha = bolha;
        _drop = drop;
        _probabilidadeDrop = probabilidadeDrop;
    }

    public void Executar()
    {
        var rd = new System.Random();
        int result = rd.Next(1, _probabilidadeDrop);

        //if(result == 1)
        //{
            Object.Instantiate(_drop, new Vector2(_bolha.transform.position.x, _bolha.transform.position.y), Quaternion.identity);
        //}
    }
}
