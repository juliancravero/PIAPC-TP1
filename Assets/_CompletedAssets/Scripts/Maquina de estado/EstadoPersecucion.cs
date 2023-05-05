using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : MonoBehaviour
{
    public Color ColorEstado = Color.red;

    private MaquindaDeEstado maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

	void Awake () {
        maquinaDeEstados = GetComponent<MaquindaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
	}

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
    }
	
	void Update () {
        RaycastHit hit;
        if(!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(controladorNavMesh.perseguirObjetivo.position);    
	}
}
