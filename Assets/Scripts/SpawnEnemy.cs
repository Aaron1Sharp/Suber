using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject _enemy;
    public float _spawnRate = 2.0f;
    
    private float _randomX,_randomY, _nextSpawn = 0.0f;
    private Vector2 _whereToSpawn;

    [SerializeField]
    private Camera _camera;
   
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyFly").Length < 3)
        {
            Spawn(_enemy, 16, 20);
        }
    }

    public void Spawn(GameObject gameObject, float _positionX, float _positionY)
    {

        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            _randomX = Random.Range(_camera.transform.position.x - _positionX, _camera.transform.position.x + _positionX);
            //_randomY = Random.Range(_camera.transform.position.y - _positionY, _camera.transform.position.x + _positionY);
            _whereToSpawn = new Vector2(_randomX, _camera.transform.position.y + _positionY);
            Instantiate(gameObject, _whereToSpawn, Quaternion.identity);
        }

    }
}
