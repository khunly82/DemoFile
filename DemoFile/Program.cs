using DemoFile;
using Newtonsoft.Json;

const string filePath = @"C:\Users\K\source\repos\DemoFile\DemoFile\save.txt"; 

List<Tache> taches = ChargerLesTaches();


while (true)
{
    Console.Clear();
    Console.WriteLine("Menu");
    Console.WriteLine("1. Ajouter une Tâche");
    Console.WriteLine("2. Voir toutes les tâches");
    Console.WriteLine("S. Sauver");
    ConsoleKey key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.NumPad1:
            AjouterUneTache();
            break;
        case ConsoleKey.NumPad2:
            VoirLesTaches();
            break;
        case ConsoleKey.S:
            SauverLesTaches();
            break;
        default:
            break;
    }
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}

List<Tache> ChargerLesTaches()
{
    List<Tache> result = new List<Tache>();
    List<string> Lines = File.ReadAllLines(filePath).ToList();
    foreach (string line in Lines)
    {
        result.Add(JsonConvert.DeserializeObject<Tache>(line));
    }
    return result;
}

void SauverLesTaches()
{
    List<string> result = new List<string>();
    foreach (Tache tache in taches)
    {
        result.Add(JsonConvert.SerializeObject(tache));
    }
    File.WriteAllLines(filePath, result);
}

void VoirLesTaches()
{
    foreach (var tache in taches)
    {
        Console.WriteLine($"{tache.Name}, {tache.Description}, {tache.DeadLine}, {tache.Status}");
        if(tache.UserName != null) 
        {
            Console.WriteLine($"Assignée à {tache.UserName}");
        }
        Console.WriteLine("__________________________________________________________________________");
    }
}

void AjouterUneTache()
{
    Tache t = new Tache(
        Question("Quel est le nom de la tache ?"),
        Question("Quel est la description de la tache?"),
        DateTime.Parse(Question("Quand doit-elle se terminer ?"))
    );
    taches.Add(t);
}

string Question(string message)
{
    Console.WriteLine($"{message}");
    return Console.ReadLine();
}