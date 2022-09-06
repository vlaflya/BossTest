using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Transform toolParent;
    [SerializeField] private Transform gunParent;
    public GunEvent tookGun = new GunEvent();
    public ToolEvent tookTool = new ToolEvent();

    public void PickObject(PickUp pick) {
        switch (pick.type) {
            case (PickUp.PickUpType.gun): {
                    GameObject gun = Instantiate(Resources.Load(pick.objectPath) as GameObject, gunParent);
                    PlayerGunController gunController = gun.GetComponent<PlayerGunController>();
                    controller.onShoot.AddListener(gunController.PullTrigger);
                    tookGun.Invoke(gunController);
                    break;
            }
            case (PickUp.PickUpType.tool):
                {
                    GameObject tool = Instantiate(Resources.Load(pick.objectPath) as GameObject, toolParent);
                    ToolController toolController = tool.GetComponent<ToolController>();
                    controller.onUseTool.AddListener(toolController.UseTool);
                    tookTool.Invoke(toolController);
                    break;
                }
        }
    }
    public class GunEvent : UnityEvent<PlayerGunController> { }
    public class ToolEvent : UnityEvent<ToolController> { }
}
