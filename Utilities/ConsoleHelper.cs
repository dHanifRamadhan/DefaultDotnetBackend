namespace DefaultDotnetBackend.Helpers {
    public static class ConsoleHelper {
        private static readonly object _lock = new object();

        private static string TimeUtc() {
            DateTime today = DateTime.UtcNow;
            string time = today.ToString("HH:mm:ss");
            return time;
        }

        private static void _PrintSuccess(string message) {
            lock(_lock) {
                try {
                    var time = TimeUtc();
                    
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(time);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" OK ");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("] ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                } catch (Exception e) {
                    Console.WriteLine($"[ERROR] Failed to print message: {e.Message}");
                }
            }
        }

        private static void _PrintInfo(string message) {
            lock (_lock) {
                try {
                    var time = TimeUtc();
                    
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(time);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" INF");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("] ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                } catch (Exception e) {
                    Console.WriteLine($"[ERROR] Failed to print message: {e.Message}");
                }
            }
        }

        private static void _PrintWarning(string message) {
            lock(_lock) {
                try {
                    var time = TimeUtc();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(time);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" WRN");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("] ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                } catch (Exception e) {
                    Console.WriteLine($"[ERROR] Failed to print message: {e.Message}");
                }
            }
        }

        private static void _PrintError(string message) {
            lock (_lock) {
                 try {
                    var time = TimeUtc();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(time);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ERR");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("] ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                 } catch (Exception e) {
                    Console.WriteLine($"[ERROR] Failed to print message: {e.Message}");
                 }
            }
        }

        public static void _PrintFatal(string message) {
            lock (_lock) {
                try {
                    var time = TimeUtc();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(time);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" FTL");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("] ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                } catch (Exception e) {
                    Console.WriteLine($"[ERROR] Failed to print message: {e.Message}");
                }
            }
        }

        public static void ShowWelcomeMessage() {
            _PrintInfo("Welcome to Default Backend");
            _PrintInfo("Developed by: Hanif Ramadhan");
            _PrintInfo("Github: https://github.com/haniframadhan");
            _PrintInfo("Starting...");
        }

        public static void ShowInformation(string message) {
            _PrintInfo($"{message}");
        }

        public static void ShowSuccess(string message) {
            _PrintSuccess($"{message}");
        }

        public static void ShowWarning(string message) {
            _PrintWarning($"{message}");
        }

        public static void ShowError(string message) {
            _PrintError($"{message}");
        }

        public static void ShowFatal(string message) {
            _PrintFatal($"{message}");
        }
    }
}