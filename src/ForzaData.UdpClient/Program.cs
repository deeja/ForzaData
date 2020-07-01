using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ForzaData.UdpClient
{
    internal class Program
    {
        private const int FORZA_DATA_OUT_PORT = 5300;
        private const int FORZA_HOST_PORT = 5200;

        private static void Main(string[] args)
        {
            byte[] toDisplay = null;

            var consoleUpdater = Task.Run(async () =>
            {
                while (true)
                {
                    if (toDisplay != null)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(StatusScreen(toDisplay));
                        toDisplay = null;
                    }

                    await Task.Delay(300);
                }
            });


            var ipEndPoint = new IPEndPoint(IPAddress.Loopback, FORZA_DATA_OUT_PORT);
            var senderClient = new System.Net.Sockets.UdpClient(FORZA_HOST_PORT);
            var senderTask = Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("Sending heartbeat");
                    await senderClient.SendAsync(new byte[1], 1, ipEndPoint);
                    await Task.Delay(5000);
                }
            });

            var receiverTask = Task.Run(async () =>
            {
                Console.Clear();
                var client = new System.Net.Sockets.UdpClient(FORZA_DATA_OUT_PORT);
                Console.WriteLine("Listening... ");
                while (true)
                {
                    await client.ReceiveAsync().ContinueWith(receive =>
                    {
                        var resultBuffer = receive.Result.Buffer;
                        if (resultBuffer.Length != 311 || toDisplay != null)
                        {
                            return;
                        }

                        var stuff = new byte[resultBuffer.Length];
                        resultBuffer.CopyTo(stuff, 0);
                        toDisplay = stuff;
                    });
                }
            });


            Task.WaitAll(senderTask, receiverTask, consoleUpdater);
        }


        private static string StatusScreen(byte[] packet)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"In Race: {packet.IsRaceOn()}      Timestamp: {packet.TimestampMs()} ");
            sb.AppendLine($"Distance: {packet.Distance()}m                                      ");
            sb.AppendLine($"Current Lap: {packet.CurrentLapTime()}, Race: {packet.CurrentRaceTime()}");
            sb.AppendLine($"Coords: {packet.PositionX()}, {packet.PositionY()}, {packet.PositionZ()}     ");
            sb.AppendLine($"Gear: {packet.Gear()}  Speed: {packet.Speed()}                                               ");
            sb.AppendLine($"Brake: {packet.Brake()} Accel: {packet.Accelerator()} Steering:  {packet.Steer()}                   ");
            sb.AppendLine($"Race position: {packet.RacePosition()}                               ");
            sb.AppendLine("                                                                      ");
            sb.AppendLine("                                                                      ");
            sb.AppendLine("                                                                      ");
            sb.AppendLine("                                                                      ");
            sb.AppendLine("                                                                      ");
            sb.AppendLine("                                                                      ");
            return sb.ToString();
        }
    }
}