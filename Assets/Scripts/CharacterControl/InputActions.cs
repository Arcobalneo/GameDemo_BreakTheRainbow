// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControlMap"",
            ""id"": ""6c889c92-b8c2-4850-b4bd-165d73b1fc77"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2fb52056-bda4-47ea-bf81-f1e14722af1d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""204f16d4-98b0-403d-803f-85b514f9630c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""468368d9-7e26-4a6a-bf88-d6cfd7b21fa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea470da5-e0d0-424e-9641-31f7825cb52e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dc0fe07-a135-42ad-a9a0-ad039de9ffa0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard2D Vector"",
                    ""id"": ""95ffc1d0-ce3c-4ff9-aae7-a0c71adbf138"",
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
                    ""id"": ""bc7b7f83-cded-45d0-af65-0983dfd32012"",
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
                    ""id"": ""12a86f56-54da-4190-936d-f9dcd0a9fff0"",
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
                    ""id"": ""7b258a29-3de8-4338-ad69-29582cb1313d"",
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
                    ""id"": ""e0c11408-3841-410e-a13b-c1a138387e37"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow 2D Vector"",
                    ""id"": ""a25cff7f-f259-4578-be5d-4c9d1cba6bf6"",
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
                    ""id"": ""5d72bb91-79bf-4446-b852-1e90f2270cbe"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""48fec9f3-564a-4acc-a217-b9e648c3319a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f8ccf541-d9b3-4ca2-8a23-ff2505edbd69"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cbd89522-491a-4ac2-b1f8-c7b4d4094280"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""37a0137e-fd49-4482-9dad-3e9904d977ee"",
                    ""path"": ""<AndroidGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9112dcc3-f613-41b3-a259-016d83fc495c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f89e5f8-66a2-4972-aae8-664c989bdbe7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bda8e220-67d0-4ed5-bcd1-aa2e79f02bf9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecbdffab-d9ba-4633-ae89-fb1d0d8d8ea8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC_Android"",
            ""bindingGroup"": ""PC_Android"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<AndroidGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControlMap
        m_PlayerControlMap = asset.FindActionMap("PlayerControlMap", throwIfNotFound: true);
        m_PlayerControlMap_Move = m_PlayerControlMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerControlMap_Fire = m_PlayerControlMap.FindAction("Fire", throwIfNotFound: true);
        m_PlayerControlMap_Dodge = m_PlayerControlMap.FindAction("Dodge", throwIfNotFound: true);
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

    // PlayerControlMap
    private readonly InputActionMap m_PlayerControlMap;
    private IPlayerControlMapActions m_PlayerControlMapActionsCallbackInterface;
    private readonly InputAction m_PlayerControlMap_Move;
    private readonly InputAction m_PlayerControlMap_Fire;
    private readonly InputAction m_PlayerControlMap_Dodge;
    public struct PlayerControlMapActions
    {
        private @InputActions m_Wrapper;
        public PlayerControlMapActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControlMap_Move;
        public InputAction @Fire => m_Wrapper.m_PlayerControlMap_Fire;
        public InputAction @Dodge => m_Wrapper.m_PlayerControlMap_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControlMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlMapActions instance)
        {
            if (m_Wrapper.m_PlayerControlMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnFire;
                @Dodge.started -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerControlMapActionsCallbackInterface.OnDodge;
            }
            m_Wrapper.m_PlayerControlMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
            }
        }
    }
    public PlayerControlMapActions @PlayerControlMap => new PlayerControlMapActions(this);
    private int m_PC_AndroidSchemeIndex = -1;
    public InputControlScheme PC_AndroidScheme
    {
        get
        {
            if (m_PC_AndroidSchemeIndex == -1) m_PC_AndroidSchemeIndex = asset.FindControlSchemeIndex("PC_Android");
            return asset.controlSchemes[m_PC_AndroidSchemeIndex];
        }
    }
    public interface IPlayerControlMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
    }
}
