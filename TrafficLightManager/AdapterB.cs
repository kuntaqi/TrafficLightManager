namespace TrafficLightManager;

public class AdapterB : ILight
{
  private readonly VendorBLight _vendorB;

  public AdapterB( VendorBLight vendorB )
  {
    _vendorB = vendorB;
  }

  public void TurnLight( bool a )
  {
    _vendorB.TurnLight( a );
  }
}