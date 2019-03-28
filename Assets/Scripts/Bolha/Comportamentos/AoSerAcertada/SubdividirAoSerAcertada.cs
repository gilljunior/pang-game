using UnityEngine;

public class SubdividirAoSerAcertada : IAoSerAcertada
{
    private readonly Bolha _bolha;
    private readonly int _qtdFilhos;
    private readonly int _perdaDeTamanho;

    public SubdividirAoSerAcertada(Bolha bolha, int qtdFilhos, int perdaDeTamanho)
    {
        _bolha = bolha;
        _qtdFilhos = qtdFilhos;
        _perdaDeTamanho = perdaDeTamanho;
    }

    public void Executar()
    {
        _bolha.gameObject.SetActive(false);
        var novoTamanho = _bolha.tamanho - _perdaDeTamanho;

        //destruir ultima bola
        if (novoTamanho <= 0)
            return;


        for (int i = 0; i < _qtdFilhos; i++)
        {
            var posX = _bolha.transform.position.x;
            var posY = _bolha.transform.position.y;

            if (i % 2 == 0)
            {
                //posX += novoTamanho * .5f;
                _bolha.forcaHorInicial = Mathf.Abs(_bolha.forcaHorInicial);
            }
            else
            {
                //posX -= novoTamanho * .5f;
                _bolha.forcaHorInicial = Mathf.Abs(_bolha.forcaHorInicial) * -1;
            }

            _bolha.transform.position = new Vector2(posX, posY);
            var novaBolha = Object.Instantiate(_bolha);

            novaBolha.tamanho = novoTamanho;
            novaBolha.gameObject.SetActive(true);
        }
    }
}
