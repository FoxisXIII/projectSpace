// GENERATED AUTOMATICALLY FROM 'Assets/SimpleControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SimpleControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SimpleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SimpleControls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""265c38f5-dd18-4d34-b198-aec58e1627ff"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""50fd2809-3aa3-4a90-988e-1facf6773553"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""c60e0974-d140-4597-a40e-9862193067e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""fc04b280-e791-46b5-8171-2d71e5326524"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""run"",
                    ""type"": ""Button"",
                    ""id"": ""d25f83d4-544c-48b9-b795-62365a38be48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""attach"",
                    ""type"": ""Button"",
                    ""id"": ""b0b5af6f-17bb-42f7-a692-5bf96f8990ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""throw"",
                    ""type"": ""Button"",
                    ""id"": ""1635de8c-b097-47a6-a76d-6654c7911ec7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""inventory"",
                    ""type"": ""Button"",
                    ""id"": ""4354f61b-66f3-47ff-afd0-cf4232da993a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""saveInventory"",
                    ""type"": ""Button"",
                    ""id"": ""f45f3579-8b63-4757-8cfc-99c60cdb31b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1b8c4dd-7b3a-4db6-a93a-0889b59b1afc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""cefc16fc-557a-44b0-939f-2ad792876b07"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07244659-79df-461d-b329-defbe2fbc5f6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0ec75cb-f02c-40d2-a33f-1fd6eab2ae0b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""21fe6bfe-4721-4483-9f4a-a0031ade105c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2dd39746-c75c-4a11-838a-e59eacaf4e0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c106d6e6-2780-47ff-b318-396171bd54cc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""578caa03-6827-4797-adfc-a59770c437fe"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b339390f-605d-43b7-9a5c-ae77e46a91d4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0fdb97f-3fee-418b-9369-faaf6878ec59"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b96b80a8-d333-4ab3-a6db-ac84ea06f774"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""674467e9-8849-44c8-9e16-436ead4005ea"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ab7283e-656f-47e7-bf41-cd34ea641086"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64aaf454-ffad-49c0-9e1a-0657a6ae03fc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd775b68-140c-4807-8ed2-940ad8ee965c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e9bdf08-cb1b-498c-88c2-7504e9463ab1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d92512c-31b2-4a7c-aba9-fad2e623855b"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f84c246-c246-4b4d-a9be-d42d3d6e2e77"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""387c7069-f14c-46f2-b5a7-b684a3a19a0e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""saveInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d9fc492-1f26-4af6-bfb2-ee1757832a66"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""saveInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard + Mouse"",
            ""bindingGroup"": ""Keyboard + Mouse"",
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
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_move = m_gameplay.FindAction("move", throwIfNotFound: true);
        m_gameplay_look = m_gameplay.FindAction("look", throwIfNotFound: true);
        m_gameplay_jump = m_gameplay.FindAction("jump", throwIfNotFound: true);
        m_gameplay_run = m_gameplay.FindAction("run", throwIfNotFound: true);
        m_gameplay_attach = m_gameplay.FindAction("attach", throwIfNotFound: true);
        m_gameplay_throw = m_gameplay.FindAction("throw", throwIfNotFound: true);
        m_gameplay_inventory = m_gameplay.FindAction("inventory", throwIfNotFound: true);
        m_gameplay_saveInventory = m_gameplay.FindAction("saveInventory", throwIfNotFound: true);
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

    // gameplay
    private readonly InputActionMap m_gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_gameplay_move;
    private readonly InputAction m_gameplay_look;
    private readonly InputAction m_gameplay_jump;
    private readonly InputAction m_gameplay_run;
    private readonly InputAction m_gameplay_attach;
    private readonly InputAction m_gameplay_throw;
    private readonly InputAction m_gameplay_inventory;
    private readonly InputAction m_gameplay_saveInventory;
    public struct GameplayActions
    {
        private @SimpleControls m_Wrapper;
        public GameplayActions(@SimpleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_gameplay_move;
        public InputAction @look => m_Wrapper.m_gameplay_look;
        public InputAction @jump => m_Wrapper.m_gameplay_jump;
        public InputAction @run => m_Wrapper.m_gameplay_run;
        public InputAction @attach => m_Wrapper.m_gameplay_attach;
        public InputAction @throw => m_Wrapper.m_gameplay_throw;
        public InputAction @inventory => m_Wrapper.m_gameplay_inventory;
        public InputAction @saveInventory => m_Wrapper.m_gameplay_saveInventory;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @run.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @run.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @run.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @attach.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttach;
                @attach.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttach;
                @attach.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttach;
                @throw.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrow;
                @throw.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrow;
                @throw.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrow;
                @inventory.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventory;
                @inventory.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventory;
                @inventory.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventory;
                @saveInventory.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSaveInventory;
                @saveInventory.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSaveInventory;
                @saveInventory.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSaveInventory;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @run.started += instance.OnRun;
                @run.performed += instance.OnRun;
                @run.canceled += instance.OnRun;
                @attach.started += instance.OnAttach;
                @attach.performed += instance.OnAttach;
                @attach.canceled += instance.OnAttach;
                @throw.started += instance.OnThrow;
                @throw.performed += instance.OnThrow;
                @throw.canceled += instance.OnThrow;
                @inventory.started += instance.OnInventory;
                @inventory.performed += instance.OnInventory;
                @inventory.canceled += instance.OnInventory;
                @saveInventory.started += instance.OnSaveInventory;
                @saveInventory.performed += instance.OnSaveInventory;
                @saveInventory.canceled += instance.OnSaveInventory;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnAttach(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnSaveInventory(InputAction.CallbackContext context);
    }
}
