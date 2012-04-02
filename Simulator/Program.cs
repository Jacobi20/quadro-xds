using System;

namespace Simulator {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SimulatorGame game = new SimulatorGame())
            {
                game.Run();
            }
        }
    }
#endif
}

