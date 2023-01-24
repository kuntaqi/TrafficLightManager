namespace TrafficLightManager;

public class AdapterA : ILight
{
  private readonly VendorALight _vendorA;

  public AdapterA( VendorALight vendorA )
  {
    _vendorA = vendorA;
  }

  public void TurnLight( bool a )
  {
    if( a )
    {
      _vendorA.TurnOn();
    }
    else
    {
      _vendorA.TurnOff();
    }
  }
}