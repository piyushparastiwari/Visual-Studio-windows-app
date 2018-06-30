using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGINME
{
    public partial class scene : Windows.UI.Xaml.Controls.Page
    {
        public const string FEATURE_NAME = "PDF Document C# Sample";

        List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title="Render document", ClassType=typeof(scene)},
        };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
