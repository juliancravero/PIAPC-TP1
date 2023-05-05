using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado1 : MonoBehaviour
{
    public Transform[] Waypoints;
    public Color colorEstado = Color.green;

    private MaquindaDeEstado maquindaDeEstado;
    private ControladorNavMesh controladorNavMesh;
    private int siguienteWayPoint;
    private ControladorVision controladorVision;

    void Awake()
    {
        maquindaDeEstado = GetComponent<MaquindaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
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


        if (controladorNavMesh.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint + 1) % Waypoints.Length;
            ActualizarWaypointDestino();
        }
    }

    void OnEnable()
    {
        maquindaDeEstado.MeshRendererIndicador.material.color = colorEstado;
        ActualizarWaypointDestino();
    }

    void ActualizarWaypointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(Waypoints[siguienteWayPoint].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled)
        {
            maquindaDeEstado.ActivarEstado(maquindaDeEstado.EstadoAlerta);
        }
    }
}
