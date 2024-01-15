using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;

    [SerializeField] private float _interactionPointRadius = 0.7f;

    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider2D[] _colliders = new Collider2D[3];

    [SerializeField] private int _numFound;

    public IInteractable _interactable;

    public InputAction InteractionKey;

    private void Start()
    {
        InteractionKey = InputManager.instance.playerInput.Movement.Interaction;
        InteractionKey.Enable();
    }

    private void OnDisable()
    {
        InteractionKey.Disable();
    }

    private void Update()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();
            if (_interactable == null) return;

            if (!_interactionPromptUI.IsDisplayed)
            {
                _interactionPromptUI.SetUp();
            }

            if (InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
            {
                _interactable.OnInteract(this, out bool interactSuccessful);
            }
        }
        else
        {
            _interactable = (_interactable != null) ? null : _interactable;

            if (_interactionPromptUI.IsDisplayed)
            {
                _interactionPromptUI.Close();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
