using System;
using UnityEngine;

public class HorizontalArranger : MonoBehaviour
{
  
    public float spacing = 0.5f; // khoảng cách thêm giữa các sprite

    private void Start()
    {
        Arrange();
    }

    void Arrange()
    {
        float currentX = -8.5f;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Lấy kích thước sprite (theo local scale)
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                float width = sr.bounds.size.x;

                // Đặt vị trí cho sprite hiện tại
                child.localPosition = new Vector3(currentX + width / 2f, 0, 0);

                // Cập nhật vị trí X cho sprite tiếp theo
                currentX += width + spacing;
            }
            else
            {
                // Nếu không có SpriteRenderer thì vẫn đặt theo spacing
                child.localPosition = new Vector3(currentX, 0, 0);
                currentX += spacing;
            }
        }
    }
}
