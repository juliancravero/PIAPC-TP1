using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoParalizado : MonoBehaviour
{
    public float duracionParalisis = 5f;
    public Color ColorEstado = Color.white;

    private MaquindaDeEstado maquindaDeEstado;
    private ControladorNavMesh controladorNavMesh;
   void Awake()
    {
        maquindaDeEstado = GetComponent<MaquindaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();

    }

    void OnEnable()
    {
        maquindaDeEstado.MeshRendererIndicador.material.color = ColorEstado;
        controladorNavMesh.DetenerNavMeshAgent();
    }

    // Update is called once per frame
    void Update()
    {

        duracionParalisis -= Time.deltaTime;
        if(duracionParalisis <= 0)
        {
            maquindaDeEstado.ActivarEstado(maquindaDeEstado.EstadoAlerta);
            duracionParalisis = 3f;
            return;
        }
    }
}

