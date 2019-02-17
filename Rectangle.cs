using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winsb
{
    public class Rectangle : MonoBehaviour
    {
        const float RECTANGLE_SCALE_Z = 0.001f;

        // 矩形オブジェクト
        [SerializeField]
        private GameObject _objRectangle = null;

        // 矩形オブジェクトのコンポーネント
        private Transform _transformRectObj;
        private Renderer _rendererRectObj;

        public void Awake()
        {
            _transformRectObj = _objRectangle.GetComponent<Transform>();
            _rendererRectObj = _objRectangle.GetComponent<Renderer>();
        }

        /// <summary>
        /// サイズ設定
        /// </summary>
        /// <param name="size">サイズ</param>
        /// <remarks>原点が左下になるように</remarks>
        public void SetSize(Vector2 size)
        {
            _transformRectObj.localScale = new Vector3(size.x, size.y, RECTANGLE_SCALE_Z);
            _transformRectObj.localPosition = size / 2.0f;  // scaleの半分の値を設定することで左下原点に
        }

        /// <summary>
        /// 色設定
        /// </summary>
        /// <param name="color">色</param>
        public void SetColor(Color color)
        {
            _rendererRectObj.material.SetColor("_Color", color);
        }

        /// <summary>
        /// 座標指定
        /// </summary>
        /// <param name="pos">座標</param>
        public void SetPosition(Vector2 pos)
        {
            this.transform.localPosition = pos;
        }
    }
}

