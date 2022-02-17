using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    string productPassword = "ancient";
    public GameObject store;
    public GameObject storeProduct;
    public GameObject passwordProduct;

    public void OpenStore() 
    {
        store.SetActive(true);
    }

    public void SetStoreProduct(GameObject product){
        storeProduct=product;
    }
    public void VerifyPassword(Text password)
    {
        if(productPassword == password.text) 
        {
            storeProduct.SetActive(true);
            passwordProduct.SetActive(false);
            Debug.Log("Great! New product in my store!");
        }
        //show product if password is correct
    }
}
