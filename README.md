# ForzaData
Forza Motorsport 7 (and possibly other Forza titles) UDP packet grabbing example for Sled or Dash

## To run this example

Within Forza Motorsport 
 - Go to _Options_
 - Go to _HUD_
 - Change _Data Out_ ->  ON
 - Change _Data Out IP Address_ -> `127.0.0.1`
 - Change _Data Out Port_ -> `5300`
 - Change _Data Out Packet Format_ -> `Car Dash`

From the root of the solution

`dotnet run --project .\src\ForzaData.UdpClient\ForzaData.UdpClient.csproj`

Thanks to @nettrom for his python code, which I used to decipher things https://github.com/nettrom/forza_motorsport/