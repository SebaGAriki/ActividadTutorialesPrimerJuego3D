using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

/// <summary>
/// Permite el comportamiento del movimiento del jugador
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    #region Atributos
    /// <summary>
    /// Fuerza Utilizada para aplicar movimiento
    /// </summary>
    private Vector3 fuerzaPorAplicar;
    /// <summary>
    /// Representa el tiempo que ha transcurrido
    /// desde la ultima aplicacion de fuerza
    /// </summary>
    private float tiempoDesdeUltimaFuerza;
    /// <summary>
    /// Indica cada cuanto tiempo debe aplicarse la fuerza
    /// </summary>
    private float intervaloTiempo;
    /// <summary>
    /// Indica la velocidad aplicada en el movimiento lateral
    /// </summary>

    /// <summary>
    /// Representa la estrategia de movimento
    /// </summary>
    private IMovementStrategy movementStrategy;

    private Player player;
    #endregion

    #region Ciclo de vida del script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 6f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;

        player = new Player(5f, 5f);

        //SetMovementStrategy(new SmoothMovement());
        SetMovementStrategy(new AcelerateMovement());
    }

    private void Update()
    {
        MovePlayer();
    }

    // Logica para la aplicacion de fuerzas 
    private void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }
    #endregion

    #region Logica del script

    #endregion
    public void MovePlayer()
    {
        movementStrategy.Move(transform, player);
    }
    public void SetMovementStrategy(IMovementStrategy movementStrategy)
    {
        this.movementStrategy = movementStrategy;
    }
}