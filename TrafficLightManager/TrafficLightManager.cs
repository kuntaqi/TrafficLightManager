namespace TrafficLightManager;

public class TrafficLightManager
{
  private readonly List<ILight> _listLight;
  private readonly List<string> _names;
  private int _state;

  public TrafficLightManager()
  {
    _listLight = new List<ILight>();
    _names = new List<string>();
    _state = 0;
  }

  public void ManageLights()
  {
    Thread.Sleep( 2000 );
    var lightIndex = GetNextLight();
    _state = lightIndex;
    SwitchLight( lightIndex );
  }

  private void SwitchLight( int index )
  {
    foreach( var light in _listLight )
    {
      light.TurnLight( _listLight.IndexOf( light ) == index );
    }
  }

  private int GetNextLight()
  {
    return ( _state != _listLight.Count - 1 ) ? _state + 1 : 0;
  }

  public void AddLight( ILight light, string name )
  {
    _listLight.Add( light );
    _names.Add( name );
  }

  public void RemoveLight( ILight light )
  {
    var i = _listLight.IndexOf( light );
    _listLight.Remove( light );
    _names.RemoveAt( i );
    _state = 0;
  }

  public void SwapOrder( ILight lightA, ILight lightB )
  {
    var indexA = _listLight.IndexOf( lightA );
    var indexB = _listLight.IndexOf( lightB );

    ( _listLight[indexA], _listLight[indexB] ) = ( _listLight[indexB], _listLight[indexA] );
    ( _names[indexA], _names[indexB] ) = ( _names[indexB], _names[indexA] );
  }

  public int GetOrder( ILight light )
  {
    return _listLight.IndexOf( light ) >= 0 ? _listLight.IndexOf( light ) + 1 : -1;
  }

  public string GetLightState()
  {
    return _names[_state];
  }
}