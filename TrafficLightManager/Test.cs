namespace TrafficLightManager;

public class Test
{
  public static void Main()
  {
    var lightManager = new TrafficLightManager();
    var vendorALight = new VendorALight();
    var vendorBLight = new VendorBLight();
    ILight redLight = new AdapterA( vendorALight );
    ILight greenLight = new AdapterB( vendorBLight );
    ILight yellowLight = new AdapterA( vendorALight );

    //Test Add, Manage, GetLight State
    lightManager.AddLight( redLight, "RED" );
    lightManager.AddLight( greenLight, "GREEN" );
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    lightManager.AddLight( yellowLight, "YELLOW" );
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );

    //Test Change Order
    lightManager.SwapOrder( yellowLight, greenLight );
    lightManager.ManageLights();
    Console.WriteLine( "\nTest Swap Order" );
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );

    //Test Remove Order
    lightManager.RemoveLight( greenLight );
    Console.WriteLine( "\nTest Remove Light" );
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );
    lightManager.ManageLights();
    Console.WriteLine( lightManager.GetLightState() );

    //Test Get Order
    Console.WriteLine( "\nTest Get Order" );
    Console.WriteLine( lightManager.GetOrder( yellowLight ) );
    Console.WriteLine( lightManager.GetOrder( greenLight ) );
    Console.WriteLine( lightManager.GetOrder( redLight ) );
  }
}