using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool activShild; // false

    void Start()
    {
        Activ(activShild);     // при создании щита он сразу выключается, так как выключенный не находит
    }
    public void Activ(bool trigger) //выкл
    {
        gameObject.SetActive(trigger);
    }
}
