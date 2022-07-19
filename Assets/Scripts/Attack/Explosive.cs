using UnityEngine;

namespace MRD
{
    public class Explosive : Attack
    {
        [SerializeField]
        private Sprite[] sprite;

        //폭발 공격
        //폭발의 경우 탄환 데미지는 받지 않고 폭발 데미지만 받음
        //폭발 반경: (0.5 + 패 개수 *0.1)m
        //피해는 데미지만큼
        //폭발 색상 있음 백:하양, 발: 초록, 중: 빨강

        public ExplosiveInfo ExplosiveInfo => (ExplosiveInfo)attackInfo;

        //color 0: 백, 1: 발, 2: 중
        protected override void OnInit()
        {
            var targets = Physics2D.OverlapCircleAll(ExplosiveInfo.Target.transform.position, ExplosiveInfo.Radius, 1 << 3);

            for (int i = 0; i < targets.Length; i++)
            {
                Debug.Log(targets[i].name);

                if (targets[i].gameObject != ExplosiveInfo.Target.gameObject)
                    targets[i].gameObject.GetComponent<EnemyController>().OnHit(ExplosiveInfo);
            }

            // GetComponent<SpriteRenderer>().sprite = Sprite[Color];

            transform.position = ExplosiveInfo.Target.transform.position;
            transform.localScale = Vector2.one * ExplosiveInfo.Radius;

            Destroy(gameObject, 1);
        }
    }
}