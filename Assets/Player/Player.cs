using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerAbstract
{
    public Player(Transform transform, Rigidbody rigidbody, Animator animator, UIPlayer uiPlayer, Transform transformPlayerCamera, List<Vector3> spawnpoints, int totalPoints, GameObject miniMap) : base(transform, rigidbody, animator, uiPlayer, transformPlayerCamera, spawnpoints, totalPoints, miniMap)
    {
    }
    
    public override void CameraMove(Vector2 inputMovement)
    {
        if(Time.timeScale == 0) return;
        
        var mouseActualSpeed = (MouseSensibility * MouseBaseSpeed) / 10;
        var rotation = new Vector3(0.0f, mouseActualSpeed * inputMovement.x, 0.0f);
        Transform.Rotate(rotation);

        rotation = new Vector3(-(mouseActualSpeed * inputMovement.y), 0.0f, 0.0f);

        var isAxisYAtLimit = rotation.x + MouseAxisY > 90 || rotation.x + MouseAxisY < -90;
        if (isAxisYAtLimit) return;
        
        MouseAxisY += rotation.x;
        TransformPlayerCamera.Rotate(rotation);
    }
    
    public override void Move(Vector2 moveAxis)
    {
        var adjustedSpeed = Speed * MoveSpeed;
        
        // Forward movement (W, S)
        Rigidbody.AddForce(Transform.forward * (adjustedSpeed * moveAxis.y * Time.deltaTime * 350));
        
        // Sideways movement (A, D)
        var directionRad = (Transform.eulerAngles.y - 90.0f) * Mathf.Deg2Rad;
        var spdTemp = new Vector3(Mathf.Sin(directionRad), 0, Mathf.Cos(directionRad));
        Rigidbody.AddForce(-spdTemp * (adjustedSpeed * moveAxis.x * Time.deltaTime * 350));
    }

    public override void AddPoint()
    {
        PointsLeft--;
        UIPlayer.SetPointsText(PointsLeft);
        
        if(PointsLeft > 0) return;

        UIPlayer.ShowVictoryMenu();
    }
    
    public override void Die()
    {
        Lifes--;
        if(Lifes == 0)
        {
            UIPlayer.ShowLostMenu();
            return;
        }
        UIPlayer.StartDeadMenuAnimation(Lifes);
        Spawn();
    }
    
    public override void OnPause(bool isPausing)
    {
        if(!isPausing) return;
        IsPausing = !IsPausing;
        Cursor.visible = IsPausing;
        Time.timeScale = IsPausing ? 0 : 1;
        UIPlayer.menuPause.SetActive(IsPausing);
    }

    public override IEnumerator SpeedPowerUp()
    {
        MoveSpeed *= 2;
        yield return new WaitForSeconds(5);
        MoveSpeed /= 2;
    }

    public override IEnumerator MiniMapPowerUp()
    {
        UIPlayer.SetPositionText(true);
        MiniMap.SetActive(true);
        yield return new WaitForSeconds(10);
        UIPlayer.SetPositionText(false);
        MiniMap.SetActive(false);
    }
}