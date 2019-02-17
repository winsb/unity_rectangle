using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winsb
{
    public class RectanglesController : MonoBehaviour
    {
        // 矩形プレハブ
        [SerializeField]
        private GameObject _rectanglePrefab = null;

        public void OnClickGenerate()
        {
            GenerateRectangle();
        }

        public void OnClickClear()
        {
            Clear();
        }

        /// <summary>
        /// 矩形ランダム生成
        /// </summary>
        private void GenerateRectangle()
        {
            // ランダム値生成
            Vector2 size = new Vector2(Random.Range(1.0f, 3.0f), Random.Range(1.0f, 3.0f));
            Vector2 pos = new Vector2(Random.Range(0.0f, 20.0f), Random.Range(0.0f, 10.0f));
            Color color;
            switch(Random.Range((int)0, (int)6))
            {
                case 0:
                    color = Color.red;
                    break;
                case 1:
                    color = Color.blue;
                    break;
                case 2:
                    color = Color.green;
                    break;
                case 3:
                    color = Color.cyan;
                    break;
                case 4:
                    color = Color.yellow;
                    break;
                case 5:
                    color = Color.magenta;
                    break;
                default:
                    color = Color.black;
                    break;
            }

            // 生成
            Create(size, pos, color);
        }

        /// <summary>
        /// 矩形生成
        /// </summary>
        /// <param name="size">サイズ</param>
        /// <param name="pos">座標</param>
        /// <param name="color">色</param>
        private void Create(Vector2 size, Vector2 pos, Color color)
        {
            Rectangle rect = Instantiate(_rectanglePrefab).GetComponent<Rectangle>();

            // 親をこのGameObjectに設定
            rect.gameObject.transform.parent = this.transform;

            // 各パラメータ設定
            rect.SetSize(size);
            rect.SetPosition(pos);
            rect.SetColor(color);
        }

        /// <summary>
        /// 矩形全削除
        /// </summary>
        private void Clear()
        {
            foreach(Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}

