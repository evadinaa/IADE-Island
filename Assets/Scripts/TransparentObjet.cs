using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObjet : MonoBehaviour
{
    [Range(0, 1)]
    public float transparencia = 1.0f;

    private Renderer rendererObjeto;
    private Color corOriginal;

    void Start()
    {
        rendererObjeto = GetComponent<Renderer>();

        if (rendererObjeto != null)
        {
            corOriginal = rendererObjeto.material.color;
        }
    }

    void Update()
    {
        if (rendererObjeto != null)
        {
            // Atualiza o valor de transparência (alfa)
            Color corAtual = corOriginal;
            corAtual.a = transparencia;
            rendererObjeto.material.SetColor("_Opacity", corAtual);

            // Ativa a renderização alfa se necessário
            rendererObjeto.material.SetOverrideTag("RenderType", "Transparent");
            rendererObjeto.material.renderQueue = 3000; // Garante que o objeto seja renderizado depois de objetos opacos
        }
    }
}

