using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public static PoolController instance = null;
    void Awake(){
        if(instance==null)
            instance = this;
        if(instance!=this)
            Destroy(this);

        CreatePools();
        E_PoolInitialized.Raise();
    }

    public GameEvent E_PoolInitialized;
    public List<Pool> pools;

    GameObject tempObje;
    public void CreatePools(){
        for(int i=0;i<pools.Count;i++){
            CreatePoolObje(pools[i], pools[i].defaultNumber);
        }
    }

    public void CreatePoolObje(Pool pool, int count){
        for(int i=0;i<count;i++){
            tempObje = Instantiate(pool.poolObje, pool.parentObje) as GameObject;
            tempObje.tag = pool.poolName;
            tempObje.SetActive(false);
            pool.pasiveObjects.Add(tempObje);
            tempObje = null;
        }
    }

    #region Pool IO

    Pool tempPool;
    public GameObject GetPoolObje(string objeType){
        tempPool = FindPool(objeType);
        if(tempPool.pasiveObjects.Count == 0)
            CreatePoolObje(tempPool, 1);

        tempObje = tempPool.pasiveObjects[0];
        tempPool.pasiveObjects.RemoveAt(0);
        tempPool.activeObjects.Add(tempObje);
        tempObje.SetActive(true);
        return tempObje;
    }

    public GameObject GetPoolObje(string objeType, Vector3 position){
        tempObje = GetPoolObje(objeType);
        tempObje.transform.position = position;
        return tempObje;
    }

    public void ReturnObjeToPool(GameObject obje){
        tempPool = FindPool(obje.tag);

        tempPool.activeObjects.Remove(obje);
        tempPool.pasiveObjects.Add(obje);
        obje.SetActive(false);
    }

    #endregion

    private Pool FindPool(string objeType){
        for(int i=0;i<pools.Count;i++){
            if(pools[i].poolName.value == objeType)
                return pools[i];
        }

        Debug.Log("<color=red>Pool doesn't exists!");
        return null;
    }

}
