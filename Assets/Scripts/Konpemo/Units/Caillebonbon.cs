using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caillebonbon : Konpemo
{
    [SerializeField] private Transform pointDeTir;

    private List<Konpemo> enemyKonpemos;
    private IAStateManager iaStateManager;
    private float flyTime = 5f;
    private float healingStrenght = 25f;
    private float healingBuff = 75f;
    private float limitToCheckBeatowtron = 3f;
    private bool isBeatowtronHere = false;
    //private float flyOffset;
    //private float pastPositionY;

    [SerializeField] private ParticleSystem flyParticles;

    public override void SetBaseStats()
    {
        health.BaseValue = 200f;
        health.SetCurrentHealth(200f);
        strength.BaseValue = 40f;
        defense.BaseValue = 3f;
        speed.BaseValue = 7f;
        attackSpeed.BaseValue = 1/0.75f;

        cooldown.BaseValue = 20f;

        rangeAttack.BaseValue = 7.5f;
        rangeCapacity.BaseValue = 0f;
        rangeView.BaseValue = 10f;
        flyTime = 5f;
        healingStrenght = 25f;
        healingBuff = 75f;
        limitToCheckBeatowtron = 3f;
        isBeatowtronHere = false;
    }

    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.NoClick;
        this.nameKonpemo = KonpemoSpecies.Caillebonbon.ToString();
        enemyUnitManager = GameObject.Find("EnemyUnitManager").GetComponent<EnemyUnitManager>();
    }

    public override void Attack() // Coupe Vent
    {
        Projectile windBlade = ProjectilePool.SharedInstance.GetPooledObject(ProjectileType.CoupeVent);
        if (windBlade != null)
        {
            windBlade.transform.SetPositionAndRotation(pointDeTir.position, pointDeTir.rotation);
            windBlade.gameObject.layer = this.gameObject.layer;
            windBlade.gameObject.SetActive(true);
            Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
            windBlade.Setup(dirProj, this.strength.Value);
        }
    }

    public override void Capacity(Vector3? localisation = null)  // Atterrissage
    {
        enemyKonpemos = enemyUnitManager.GetEnemyKonpemos();
        foreach (Konpemo enemyKonpemo in enemyKonpemos)
        {
            if (iaStateManager = enemyKonpemo.GetComponentInChildren<IAStateManager>())
            {
                StartCoroutine(FlyCoroutine(iaStateManager, this));
            }
        }
    }
    public override void Passive()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, limitToCheckBeatowtron, this.gameObject.layer);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<Beatowtron>() != null)
            {
                isBeatowtronHere = true;
                break;
            }
        }
        if (isBeatowtronHere)
        {
            Healing(healingStrenght + healingBuff);
        }
        else
        {
            Healing(healingStrenght);
        }
    }
    public IEnumerator FlyCoroutine(IAStateManager iAStateManager, Konpemo konpemo)
    {
        iAStateManager.invisbleKonpemos.Add(konpemo);
        flyParticles.Play();
        //pastPositionY = skin.transform.position.y;
        //skin.transform.position = new Vector3(skin.transform.position.x, skin.transform.position.y + flyOffset, skin.transform.position.z);
        yield return new WaitForSeconds(flyTime);
        //skin.transform.position = new Vector3(skin.transform.position.x, pastPositionY, skin.transform.position.z);
        flyParticles.Stop();
        iAStateManager.invisbleKonpemos.Remove(konpemo);
        Passive(); //Atterissage
    }

}
