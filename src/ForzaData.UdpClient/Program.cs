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

            Task consoleUpdater = Task.Run(async () =>
            {
                while (true)
                {
                    if (toDisplay != null)
                    {
                        //Console.Clear();
                        Console.SetCursorPosition(0, 2);

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
                    await client.ReceiveAsync().ContinueWith((receive) =>
                    {
                        var resultBuffer = receive.Result.Buffer;
                        if (resultBuffer.Length != 311 || toDisplay != null)
                        {
                            return;
                        }

                        var stuff = new byte[resultBuffer.Length];
                        resultBuffer.CopyTo(stuff,0);
                        toDisplay = stuff;
                    });
                }
            });


            Task.WaitAll(senderTask, receiverTask);
        }


        private static string StatusScreen(byte[] packet)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Timestamp: {packet.TimestampMs()}".PadRight(50));
            sb.AppendLine($"Dist: {packet.Distance()}                                             ");
            sb.AppendLine($"Current Lap: {packet.CurrentLapTime()}, Race: {packet.CurrentRaceTime()}");
            sb.AppendLine($"Pos: {packet.PositionX()}, {packet.PositionY()}, {packet.PositionZ()}     ");
            sb.AppendLine($"Gear: {packet.Gear()}                                                 ");
            sb.AppendLine($"Brake: {packet.Brake()} Accel: {packet.Accelerator()}                   ");
            sb.AppendLine($"Speed: {packet.Speed()}    Steering:  {packet.Steer()} {BitConverter.ToString(packet, 308,1)}                 ");
            sb.AppendLine($"Race position: {packet.RacePosition()}                                ");
            sb.AppendLine($"Racing: {packet.IsRaceOn()}                                           ");
            return sb.ToString();
        }
    }
}