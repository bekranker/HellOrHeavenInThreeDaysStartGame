using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

public static class SwipeDictionaries
{
  public static void SwapRandomItems(ref Dictionary<int, string> dict1, ref Dictionary<int, string> dict2)
  {
    // Random sınıfının bir örneğini oluşturuyoruz.
    Random random = new Random();

    // Rastgele bir anahtar seçmek için Dictionary'nin anahtarlarını bir listeye dönüştürüyoruz.
    var dict1Keys = dict1.Keys.ToList();
    var dict2Keys = dict2.Keys.ToList();

    // Random.Next ile rastgele bir index seçiyoruz.
    int randomKey1 = dict1Keys[random.Next(dict1Keys.Count)];
    int randomKey2 = dict2Keys[random.Next(dict2Keys.Count)];

    // Anahtarlara karşılık gelen değerleri alıyoruz ve değiş tokuş yapıyoruz.
    string temp = dict1[randomKey1];
    dict1[randomKey1] = dict2[randomKey2];
    dict2[randomKey2] = temp;

    Debug.Log("sa");
    Debug.Log(dict1[randomKey1]);
    Debug.Log(dict2[randomKey2]);

  }
}