using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    internal interface IInterface
    {
        List<String> ReadText(string route);
        void WriteText(List<String> nameList);
        List<String> Sorter(List<String> nameList);

        void NameDisplay(List<String> nameList);

    }
}
