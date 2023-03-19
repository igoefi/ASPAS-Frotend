using ASPAS.Classes.BetaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAS.Classes
{
    public interface ISetModels
    {
        List<BetaModel> Models { get; set; }
    }
}
