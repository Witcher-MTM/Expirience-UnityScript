using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Expirience
{
    public class Expirience
    {
        public int Level { get; private set; }
        public int LevelPoint { get; private set; }
        public int ExpirienceForNextLevel { get; private set; }
        public int CurrentExpirience { get; private set; }
        public int NewExpirience { get; private set; }
        public int ExtraExpirience { get; private set; }
        public int HpFactor { get; private set; }
        public int MpFactor { get; private set; }
        public string FileName { get; private set; }

        public string jsonExpirience { get; private set; }


        public Expirience()
        {
            Level = 0;
            LevelPoint = 0;
            HpFactor = 10;
            MpFactor = 15;
            ExpirienceForNextLevel = 1000;
            CurrentExpirience = 0;
            NewExpirience = 0;
            ExtraExpirience = 0;
            FileName = "Expirience.json";
            if (!File.Exists(FileName))
            {
                File.Create(FileName).Close();

            }
        }
        public Expirience(Expirience exp)
        {
            Level = exp.Level;
            LevelPoint = exp.LevelPoint;
            HpFactor = exp.HpFactor;
            MpFactor = exp.MpFactor;
            CurrentExpirience = exp.CurrentExpirience;
            ExpirienceForNextLevel = exp.ExpirienceForNextLevel;
            ExtraExpirience = exp.ExtraExpirience;
            NewExpirience = exp.NewExpirience;
            FileName = exp.FileName;
        }
        public Expirience(int Level, int LevelPoint, int ExpirienceForNextLevel, int CurrentExpirience, int NewExpirience, int ExtraExpirience, int HpFactor, int MpFactor, string FileName,string jsonExpirience)
        {
            Console.WriteLine(Level);
        }
        public void GetExp(int expirience)
        {
            CurrentExpirience += expirience;
            Task.Factory.StartNew(() =>
            {
                while (CurrentExpirience >= ExpirienceForNextLevel)
                {
                    UpLevel();
                    Console.WriteLine($"------------------------------LEVEL-{Level}" );
                }
            });
            
        }

        private void UpLevel()
        {
            ExtraExpirience = CurrentExpirience - ExpirienceForNextLevel;
            CurrentExpirience = ExtraExpirience;

            Level += 1;
            LevelPoint += 1;
            HpFactor += 10 * Level;
            MpFactor += 15 * Level;
            ExpirienceForNextLevel = ExpirienceForNextLevel + 150 * Level;
            //ExpirienceForNextLevel = ExpirienceForNextLevel * Math.Pow(1.1, Level);
        }
        public override string ToString()
        {
            return $"{Level},{ExpirienceForNextLevel}";
        }
    }
}
