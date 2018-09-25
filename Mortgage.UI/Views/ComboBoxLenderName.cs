using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Views
{
    public class ComboBoxLenderName
    {
        public ComboBoxLenderName(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static ComboBoxLenderName None() => new ComboBoxLenderName(Guid.Empty, "None");
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
