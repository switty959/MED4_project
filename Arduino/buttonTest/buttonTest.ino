const int btnStateLength = 6;
int delayTime = 20;

int digitalPin[] ={2,3,4,5,6,7};
int btnState[btnStateLength];

String commands[] = {"W","S","A","D","O","x"};


void setup() {
  // put your setup code here, to run once:
pinMode(digitalPin,INPUT);
Serial.begin(9600);
}

void loop() {
  for(int i =0; i<btnStateLength;i++)
  {
    btnState[i] = digitalRead(digitalPin[i]);
  }
  
  for(int i =0; i<btnStateLength;i++)
  {
    if(btnState[i] == HIGH)
    {
      Serial.println(commands[i]);
      Serial.flush();
      delay(delayTime);
    }
  }
}
