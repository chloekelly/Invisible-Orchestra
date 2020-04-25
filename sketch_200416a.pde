String runwayhost = "127.0.0.1";
int runwayport = 57100; 


import oscP5.*;
import netP5.*;
OscP5 oscP5; 

NetAddress myBroadcastLocation;

void setup() {
  size(600,400); 
    OscProperties properties = new OscProperties();
  properties.setRemoteAddress("127.0.0.1", 57200);
  properties.setListeningPort(57200);
  properties.setDatagramSize(99999999);
  properties.setSRSP(OscProperties.ON);
  oscP5 = new OscP5(this, properties); 
    myBroadcastLocation = new NetAddress(runwayhost, runwayport);
    connect();
    
  
    
}

void connect() {
  OscMessage m = new OscMessage("/server/connect");
  oscP5.send(m, myBroadcastLocation);
}
void draw(){ 
  background(0);
  
} 

// OSC Event: listens to data coming from Runway
void oscEvent(OscMessage message) {
  if (!message.addrPattern().equals("/data")) return;
  // The data is in a JSON string, so first we get the string value
  String dataString = message.get(0).stringValue();

  // We then parse it as a JSONObject
  JSONObject data = parseJSONObject(dataString);

  println(data);

 
}
