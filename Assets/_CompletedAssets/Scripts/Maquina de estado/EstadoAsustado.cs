using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAsustado : MonoBehaviour
{
    public Color ColorEstado = Color.magenta;

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
        if(Vector3.Distance(controladorNavMesh.perseguirObjetivo.position, transform.position) > 5f)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoParalizado);
            return;
        }
        Vector3 irA = transform.position + ((transform.position - controladorNavMesh.perseguirObjetivo.position) * 2);
        float distance = Vector3.Distance(transform.position, controladorNavMesh.perseguirObjetivo.position);
        if (distance < 100) controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(irA);
	}
}
