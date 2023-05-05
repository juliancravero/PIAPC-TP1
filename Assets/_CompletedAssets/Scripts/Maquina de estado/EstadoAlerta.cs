using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
    public float velocidadGiroBusqueda = 120f;
    public float duracionBusqueda = 4f;
    public Color ColorEstado = Color.yellow;

    private float tiempoBuscando;
    private MaquindaDeEstado maquindaDeEstado;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    void Awake()
    {
        maquindaDeEstado = GetComponent<MaquindaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();

    }

    void OnEnable()
    {
        maquindaDeEstado.MeshRendererIndicador.material.color = ColorEstado;
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
    }

    // Update is called once per frame
    void Update()
    {
         RaycastHit hit;
        if(controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquindaDeEstado.ActivarEstado(maquindaDeEstado.EstadoPersecucion);
            return;
        }

        transform.Rotate(0f, velocidadGiroBusqueda + Time.deltaTime , 0f);
        tiempoBuscando += Time.deltaTime;
        if(tiempoBuscando >= duracionBusqueda)
        {
            maquindaDeEstado.ActivarEstado(maquindaDeEstado.Estado1);
            return;
        }
    }
}
