// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LibFs.Say.hello("F#");

// You don't necessarily use namespace.
var (rw, rh) = CameraModule.getBaseRatio(1920, 1080);
Console.WriteLine($"width : height = {rw} : {rh}");
