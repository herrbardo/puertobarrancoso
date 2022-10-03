//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Game/User.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @User : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @User()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""User"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""f8221a28-8a46-49fc-bf55-dc7e2c6b7a17"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""ec5e63f0-9f69-4a2f-a19e-2dde93f3c5a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectUp"",
                    ""type"": ""Button"",
                    ""id"": ""1e1c5037-6600-41e4-ac3f-08efda6712bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectDown"",
                    ""type"": ""Button"",
                    ""id"": ""21b3a50f-0c6d-4da8-964a-31d4756e19df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""89d07dd0-1cf2-4f86-96ce-e3577b8f1949"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""8d89ca2c-d6aa-423f-a266-7169c25eac68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""a3c893f5-9f20-4bf3-8128-f4f475356d30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1cb98174-4963-4d75-bf60-19f645dd65d2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c647cf20-7c2b-4deb-8ce5-3db926039257"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af685c3b-ccb4-4612-87c6-7dca73f5d587"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecc405e6-596d-461c-aa0e-be00f404f39d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a1f8e2-22fe-4049-9bc3-6b27a7001a67"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ea97c4f-cee1-44a5-b070-848d830409be"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""03bb07b7-4cb3-4df4-af2d-66e9c9c14469"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cd6b9496-4a1c-47bf-abac-63137642918b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f96f0f5b-64bb-473d-9eba-357a533de125"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""6e618b19-ee30-4b32-a9f5-87218bd2db32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""afd10e6c-a841-498c-b4f9-361b9a124b12"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20392b2c-c8ab-451e-94a1-d834c4992d8a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d629a64b-6649-4946-ae48-9378e0901767"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""dda6ce60-5623-4404-ae52-5f7b9ab25d7a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6b1bf543-fd25-4b28-86db-b8a938a3a838"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Move"",
                    ""id"": ""a8a7ef69-75b4-4858-81f4-44419c1aea6f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3688607b-ea0f-4047-b214-26d2775519ef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""de768d3c-b1c3-4934-8f93-40ce9b0189a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""54aabc28-65f3-41ad-b935-41a156f4c551"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8ba58e6c-2e86-408c-bf17-ccc3c5621921"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Forward = m_Keyboard.FindAction("Forward", throwIfNotFound: true);
        m_Keyboard_SelectUp = m_Keyboard.FindAction("SelectUp", throwIfNotFound: true);
        m_Keyboard_SelectDown = m_Keyboard.FindAction("SelectDown", throwIfNotFound: true);
        m_Keyboard_Use = m_Keyboard.FindAction("Use", throwIfNotFound: true);
        m_Keyboard_Cancel = m_Keyboard.FindAction("Cancel", throwIfNotFound: true);
        m_Keyboard_Back = m_Keyboard.FindAction("Back", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Pan = m_Mouse.FindAction("Pan", throwIfNotFound: true);
        m_Mouse_Zoom = m_Mouse.FindAction("Zoom", throwIfNotFound: true);
        m_Mouse_LeftClick = m_Mouse.FindAction("LeftClick", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Forward;
    private readonly InputAction m_Keyboard_SelectUp;
    private readonly InputAction m_Keyboard_SelectDown;
    private readonly InputAction m_Keyboard_Use;
    private readonly InputAction m_Keyboard_Cancel;
    private readonly InputAction m_Keyboard_Back;
    public struct KeyboardActions
    {
        private @User m_Wrapper;
        public KeyboardActions(@User wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Keyboard_Forward;
        public InputAction @SelectUp => m_Wrapper.m_Keyboard_SelectUp;
        public InputAction @SelectDown => m_Wrapper.m_Keyboard_SelectDown;
        public InputAction @Use => m_Wrapper.m_Keyboard_Use;
        public InputAction @Cancel => m_Wrapper.m_Keyboard_Cancel;
        public InputAction @Back => m_Wrapper.m_Keyboard_Back;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnForward;
                @SelectUp.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelectUp;
                @SelectUp.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelectUp;
                @SelectUp.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelectUp;
                @SelectDown.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelectDown;
                @SelectDown.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelectDown;
                @SelectDown.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelectDown;
                @Use.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUse;
                @Cancel.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCancel;
                @Back.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @SelectUp.started += instance.OnSelectUp;
                @SelectUp.performed += instance.OnSelectUp;
                @SelectUp.canceled += instance.OnSelectUp;
                @SelectDown.started += instance.OnSelectDown;
                @SelectDown.performed += instance.OnSelectDown;
                @SelectDown.canceled += instance.OnSelectDown;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Pan;
    private readonly InputAction m_Mouse_Zoom;
    private readonly InputAction m_Mouse_LeftClick;
    public struct MouseActions
    {
        private @User m_Wrapper;
        public MouseActions(@User wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_Mouse_Pan;
        public InputAction @Zoom => m_Wrapper.m_Mouse_Zoom;
        public InputAction @LeftClick => m_Wrapper.m_Mouse_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Pan.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnPan;
                @Zoom.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnZoom;
                @LeftClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    public struct MovementActions
    {
        private @User m_Wrapper;
        public MovementActions(@User wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IKeyboardActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnSelectUp(InputAction.CallbackContext context);
        void OnSelectDown(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
