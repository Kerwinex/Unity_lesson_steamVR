using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("進球區域")]
    public Vector3 positionBallIn;
    public Color colorBallIn = new Color(1, 0.2f, 0.3f, 0.3f);
    [Range(0, 10)]
    public float rangeBallIn = 3;
    [Header("三分區域")]
    public Vector3 positionThreePoint;
    public Color colorThreePoint = new Color(0.2f, 0.2f, 1, 0.3f);
    public Vector3 sizeThreePoint = new Vector3(5, 3, 10);

    [Header("進球資料")]
    public int scoreAdd = 1;
    public int score;
    public Text textScore;

    private void Update()
    {
        CheckBallIn();
        TargetInThreePoint();
    }

    private void CheckBallIn()
    {
        Collider[] hits = Physics.OverlapSphere(positionBallIn, rangeBallIn, 1 << 3);
        if (hits.Length > 0) {
            score += scoreAdd;
            textScore.text = "分數：" + score;
            hits[0].gameObject.layer = 0;
        }
    }

    private void TargetInThreePoint()
    {
        Collider[] hits = Physics.OverlapBox(positionThreePoint, sizeThreePoint / 2, Quaternion.identity, 1 << 6);
        if (hits.Length > 0) scoreAdd = 3;
        else scoreAdd = 1;
    } 
    private void OnDrawGizmos()
    {
        Gizmos.color = colorBallIn;
        Gizmos.DrawSphere(positionBallIn, rangeBallIn);
        Gizmos.color = colorThreePoint;
        Gizmos.DrawCube(positionThreePoint, sizeThreePoint); ;
    }
}
