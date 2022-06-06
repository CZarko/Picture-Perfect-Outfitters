using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour  {

    public GameObject SCamera;

    [SerializeField]
    private int happiness = 0;

    [SerializeField]
    private string top_wanted, bottom_wanted, feet_wanted;

    public GameObject[] reactions;
    public static bool top_submission = false, bottom_submission = false, feet_submission= false;

    // Update is called once per frame
    void Update() {
        if(top_submission && bottom_submission && feet_submission) {
            NewCustomer();
        }
    }

    public void SetWantedTop(string top) {
        top_wanted = top;

    }

    public void SetWantedBottom(string bottom){
        bottom_wanted = bottom;
    }

    public void SetWantedFeet(string feet){
        feet_wanted = feet;
    }
    
    public void NewCustomer() {
        top_submission = false;
        bottom_submission = false;
        feet_submission = false;
        if(happiness > 0) {
            Animator anim = GameObject.Find("Customer").GetComponent<Animator>();
            anim.SetTrigger("leave");

            StartCoroutine(ResetCustomer(anim));
            happiness = 0;
        } else {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator ResetCustomer(Animator anim) {
        yield return new WaitForSeconds(1.5f);
        SpriteController[] customer = FindObjectsOfType(typeof(SpriteController)) as SpriteController[];
        foreach(SpriteController sprite in customer) {
            sprite.Reset();
        }
        FindObjectOfType<DialogueGenerator>().IncreaseVagueness();
        FindObjectOfType<Speaker>().Reset();
        anim.SetTrigger("enter");
        yield return new WaitForSeconds(2f);
        Button[] buttons = FindObjectsOfType(typeof(Button)) as Button[];
        foreach(Button button in buttons) {
            button.interactable = true;
        }
    }

    IEnumerator EndGame() {
        Destroy(GameObject.Find("SpeakerManager")); Destroy(GameObject.Find("Canvas"));
        Animator anim = GameObject.Find("FlashPanel").GetComponent<Animator>();
        anim.SetTrigger("flash");
        yield return new WaitForSeconds(2.0f);
        // camera 1 "Main Camera" set active to false
        GameObject.Find("Main Camera").SetActive(false);
        // camera 2 "Secondary Camera" set active to true
        SCamera.SetActive(true);

        anim.SetTrigger("fade");
        yield return new WaitForSeconds(2.0f);
        GetComponent<SceneLoader>().Load();
    }

    public void SubmitTop() {
        //compare keyName to equippedName
        top_submission = true;
        string equipped = GameObject.Find("top").GetComponent<SpriteRenderer>().sprite.name;
        happiness = (top_wanted.Equals(equipped)) ? happiness + 1 : happiness - 1;
        Reaction();
    }

    public void SubmitBottom(){
        bottom_submission = true;
        string equipped = GameObject.Find("bottom").GetComponent<SpriteRenderer>().sprite.name;
        happiness = (bottom_wanted.Equals(equipped)) ? happiness + 1 : happiness - 1;
        Reaction();
    }

    public void SubmitFeet(){
        feet_submission = true;
        string equipped = GameObject.Find("feet").GetComponent<SpriteRenderer>().sprite.name;
        happiness = (feet_wanted.Equals(equipped)) ? happiness + 1 : happiness - 1;
        Reaction();
    }

    private void Reaction() {
        int index = happiness + 1;
        if(index < 0) index = 0; if(index > 3) index = 3;
        GameObject clone = Instantiate(reactions[index], GameObject.Find("Customer").transform.position, Quaternion.identity);
        clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -8);
        clone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10.0f;
        Destroy(clone, 5.0f);
    }
}