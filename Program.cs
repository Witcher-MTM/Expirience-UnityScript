// See https://aka.ms/new-console-template for more information


using Expirience;
using System.Text.Json;
string json = File.ReadAllText("Expirience.json");
Expirience.Expirience exp = new Expirience.Expirience(JsonSerializer.Deserialize<Expirience.Expirience>(json));


Console.WriteLine(exp.Level);
Console.WriteLine();

