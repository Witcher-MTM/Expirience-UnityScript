using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.M


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
        private string FileName;

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

        }

        public void GetExp(int expirience)
        {
            CurrentExpirience += expirience;
            if (CurrentExpirience >= ExpirienceForNextLevel)
            {

                UpLevel();

            }
        }

        public void UpLevel()
        {
            ExtraExpirience = CurrentExpirience - ExpirienceForNextLevel;
            CurrentExpirience = ExtraExpirience;

            Level += 1;
            LevelPoint += 1;
            HpFactor += 10 * Level;
            MpFactor += 15 * Level;

            ExpirienceForNextLevel = ExpirienceForNextLevel * (int)Math.Pow(1.1, Level);


        }
    }
}
