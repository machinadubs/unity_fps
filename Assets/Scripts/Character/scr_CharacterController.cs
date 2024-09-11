using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static src_Models;

public class scr_CharacterController : MonoBehaviour
{
    private DefaultInput default_input;
    public Vector2 input_movement;
    public Vector2 input_view;

    private Vector3 new_camera_rotation;

    [Header("References")]
    public Transform camera_holder;

    [Header("Settings")]
    public PlayerSettingsModel player_settings;
    public float view_X_clamp_min = -70;
    public float view_X_clamp_max = 80;

    private void Awake()
    {
        default_input = new DefaultInput();

        default_input.Character.Movememt.performed += e => input_movement = e.ReadValue<Vector2>();
        default_input.Character.View.performed += e => input_view = e.ReadValue<Vector2>();

        default_input.Enable();

        new_camera_rotation = camera_holder.localRotation.eulerAngles;
    }

    private void Update()
    {
        calculateView();
        calculatedMovement();
    }

    private void calculateView()
    {
        new_camera_rotation.x += player_settings.view_Y_sensitivity * input_view.y * Time.deltaTime;
        new_camera_rotation.y += player_settings.view_X_sensitivity * input_view.x * Time.deltaTime;

        new_camera_rotation.x = Mathf.Clamp(new_camera_rotation.x, view_X_clamp_min, view_X_clamp_max);

        camera_holder.localRotation = Quaternion.Euler(new_camera_rotation);
    }
    private void calculatedMovement()
    {

    }
}