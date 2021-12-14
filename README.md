# DistanceUnits

### Usage


#### Initialize:

Distance\<IMetrics> a = new Distance\<IMetrics>(new Meter(10));
<br>
Distance\<IMetrics> aaa = Distance\<IMetrics>.FromMeters(100);

#### Example: 

Distance\<IMetrics> a = Distance\<IMetrics>.FromMeters(150);
<br>
Distance\<IMetrics> b = Distance\<IMetrics>.FromMeters(70);
<br>
Console.WriteLine((a + b).AsMeters());
<br><br>
var m = Distance\<IMetrics>.FromMeters(100);
<br>
var km = m.AsKilometers();
