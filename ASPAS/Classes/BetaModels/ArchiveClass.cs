using ASPAS.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAS.Classes.BetaModels
{
    public class ArchiveClass
    {
        public string Date { get; set; }
        public List<BetaModel> Errors { get; set; }
    }
}
