#region Usings

using System;
using UI;

#endregion

namespace Start {
    internal static class Program {
        [STAThread]
        private static void Main() {
            Bootstrapper.Run();
        }
    }
}