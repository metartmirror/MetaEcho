using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomNameButton : MonoBehaviour
{
    public TMP_InputField nameText;

    private string[] names =
    {
        "Reimu", "Marisa", "Lily", "Patchouli", "Remilia", "Flandre", "Sakuya", "Sakuya", "Chen",
        "Lunasa", "Koishi", "Fujiwara", "Reisen", "Reisen", "Reisen", "Youmu",
        "Yukari", "Marisa", "Sanae", "Shizuha", "Minoriko", "Reiuji", "Natori", "Shou", "Mystia", "Kogasa",
        "Yukari", "Eiki", "Merlin", "Shou", "Lyrica", "Toyosatomimi", "Star", "Byakuren", "Kagerou", "Rinnosuke",
        "Kosuzu", "Shinmyoumaru", "Higan", "Kyouko", "Hata", "Toyosatomimi", "Shou", "Fujiwara", "Kasen", "Sumireko",
        "Momiji", "Wriggle", "Inaba", "Keine", "Tewi", "Akyuu", "Aunn", "Marisa", "Mai", "Momiji",
        "Tenshi", "Alicia", "Kiritani", "Yasaka", "Komeiji", "Ichirin", "Reimu", "Kanako", "Mima", "Flandre",
        "Reimu", "Keine", "Cirno", "Asuna", "Kazuto", "Byakuren", "Elizabeth", "Artoria", "Rin", "Himura",
        "Arslan", "Rachel", "Edward", "Set", "Osman", "Ellie", "Gerald", "Kolohe", "Sakura", "Yukino", "Alberto", "Chiba", "Emma", "Yahiko",
        "Tohsaka", "Hikari", "Yuna", "Izumo", "Rafi", "Lisbon", "Elizabeth", "Elsa", "Elizabeth", "Sam", "Yukulele", "Vegeta", "Feliz", "Kiki", "Marl", "Saka", "Kirigaya",
        "Mikoto", "Aria", "Ryoko", "Ves", "Yamanaka", "Leif", "Brenda", "Raven", "Chris", "Chloe", "Herman", "Jackie", "Chloe", "Ellen", "Yugi", "Ellie", "Hill", "Archie",
        "Irina", "Robin", "Al", "Alcadeias", "Koi", "Belgrieral", "Youvier", "Harry", "Ilya", "Lanpo", "Alteria", "Kael", "Aria", "Lorenzo", "Reinhardt", "Roma", "Marcus",
        "Lisa", "Sophia", "Lucia", "Marco", "Jonathan", "Christine", "Ver", "Oz", "Jugen", "Lufus", "Renee", "Rebecca", "Arnold", "Jacob", "Annie", "Lydia", "Emily",
        "Maria", "Clair", "Julius", "Ardi", "Lilith", "Helen", "Lysa"
    };
    
    public void RandomName()
    {
        var randomIndex = Random.Range(0, names.Length);
        var randomName = names[randomIndex];
        Debug.Log(randomName);
        nameText.text = randomName;
    }
}
