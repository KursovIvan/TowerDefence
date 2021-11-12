using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    public GameObject explosionPrefab;
    public GameObject electricPrefab;
    public GameObject poisonSplashPrefab;
    public GameObject poisonDOTPrefab;
    public GameObject frozenAuraPrefab;
    public GameObject upgradePrefab;
    public GameObject buffPrefab;

    private void Start()
    {
        Instance = this;
    }
    public void ExplosionParticle(Vector3 pos)
    {
        GameObject particleInstance = Instantiate(explosionPrefab);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
    public void ElecticParticle(Vector3 pos, int sortOrder)
    {
        GameObject particleInstance = Instantiate(electricPrefab);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(0).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
    public void PoisonSplashParticle(Vector3 pos, int sortOrder)
    {
        GameObject particleInstance = Instantiate(poisonSplashPrefab);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(0).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(1).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(2).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
    public void PoisonDOTParticle(Vector3 pos, Transform parent)
    {
        GameObject particleInstance = Instantiate(poisonDOTPrefab);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
    public void FrozenParticle(Vector3 pos, Transform parent)
    {
        GameObject particleInstance = Instantiate(frozenAuraPrefab , parent);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
    public void UpgradeParticle(Vector3 pos, int sortOrder)
    {
        GameObject particleInstance = Instantiate(upgradePrefab);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(0).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(1).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(2).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(3).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
    public void BuffParticle(Vector3 pos, int sortOrder)
    {
        GameObject particleInstance = Instantiate(buffPrefab);
        particleInstance.transform.position = pos;
        particleInstance.GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(0).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(1).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.transform.GetChild(2).GetComponent<Renderer>().sortingOrder = sortOrder;
        particleInstance.GetComponent<ParticleSystem>().Play();
    }
}
