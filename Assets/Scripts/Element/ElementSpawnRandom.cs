using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawnRandom : DucHienMonoBehaviour
{
    [SerializeField] protected float spawnInterval = 0.2f; // Thời gian chờ giữa việc tạo 
    [SerializeField] protected float fallSpeed = 3f; // Tốc độ di chuyển
    [SerializeField] protected float spawnHeight = 1.5f; // Độ cao tạo 
    [SerializeField] protected float spawnWidth = 1.5f; // Độ rộng tạo
    [SerializeField] protected int spawnVerticalCount = 5; // Số lượng
    [SerializeField] protected int spawnHorizontalCount = 10; // Số lượng
    protected override void Start()
    {
        base.Start();
        StartCoroutine(SpawnGems());
    }

    private IEnumerator SpawnGems()
    {
        for (int i = 0; i < spawnVerticalCount; i++) // Tạo 10 viên
        {
            for (int j = 0; j < spawnHorizontalCount; j++)
            {
                string elementPrefab = ElementSpawner.elementsInRound[this.RandomElementIndex()];
                Vector2 spawnPosition = new Vector2(j * spawnWidth - ((spawnHorizontalCount-1f)/2f * spawnWidth), i * spawnHeight - ((spawnVerticalCount - 1f) / 2f * spawnWidth)); // Tạo vị trí tạo viên kim cương
                Transform elementObj = ElementSpawner.Instance.Spawn(elementPrefab, spawnPosition, Quaternion.identity); // Tạo viên kim cương từ Prefab
                elementObj.gameObject.SetActive(true); // Kích hoạt viên kim cương
                //StartCoroutine(MoveGemDown(elementObj)); // Bắt đầu coroutine di chuyển viên kim cương xuống
                
            }
            yield return new WaitForSeconds(spawnInterval); // Chờ một khoảng thời gian trước khi tạo viên kim cương tiếp theo
        }
    }

    private IEnumerator MoveGemDown(Transform gem)
    {
        while (gem.position.y > 0) // Kiểm tra nếu viên kim cương chưa đến vị trí cuối cùng
        {
            gem.Translate(Vector3.down * fallSpeed * Time.deltaTime); // Di chuyển viên kim cương xuống

            yield return null; // Chờ một frame trước khi tiếp tục
        }
    }

    protected virtual int RandomElementIndex()
    {
        return Random.Range(0, ElementSpawner.elementsInRound.Count);
    }


}
