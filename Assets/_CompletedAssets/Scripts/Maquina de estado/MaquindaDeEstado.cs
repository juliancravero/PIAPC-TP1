using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquindaDeEstado : MonoBehaviour
{
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour Estado1;
    public MonoBehaviour EstadoInicial;
    public MonoBehaviour EstadoParalizado;
    public MonoBehaviour EstadoAsustado;

    public MeshRenderer MeshRendererIndicador;

    private MonoBehaviour estadoActual;


    void Start()
    {
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if(estadoActual != null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;

    }

}
