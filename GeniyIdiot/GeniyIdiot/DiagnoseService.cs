using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class DiagnoseService
    {

        private List<Diagnose> diagnoses = new List<Diagnose>
        { 
            new Diagnose("Идиот"),
            new Diagnose("Кретин"),
            new Diagnose("Дурак"),
            new Diagnose("Нормальный"),
            new Diagnose("Талант"),
            new Diagnose("Гений")
        };
       
        public string GetDiagnose(User result, int question)
        {
            if (result.Result >= 0 && result.Result < (double)question / diagnoses.Count)
                return "Идиот";
            else if (result.Result >= (double)question / diagnoses.Count 
                && result.Result < 2 * (double)question / diagnoses.Count)
                return "Кретин";
            else if (result.Result >= 2 * (double)question / diagnoses.Count 
                && result.Result < 3 * (double)question / diagnoses.Count)
                return "Дурак";
            else if (result.Result >= 3 * (double)question / diagnoses.Count
                && result.Result < 4 * (double)question / diagnoses.Count)
                return "Нормальный";
            else if (result.Result >= 4 * (double)question / diagnoses.Count
                && result.Result < 5 * (double)question / diagnoses.Count)
                return "Талант";
            else 
                return "Гений";
        }
        
    }
}
