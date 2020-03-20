const int inX = A0; // analog input for x-axis
const int inY = A1; // analog input for y-axis

int xValue = 0; // variable to store x value
int yValue = 0; // variable to store y value

void setup() {
  pinMode(inX, INPUT); // setup x input
  pinMode(inY, INPUT); // setup y input
  
  Serial.begin(9600); // Setup serial connection for print out to console
}
void loop() {
  xValue = analogRead(inX); // reading x value [range 0 -> 1023]
  yValue = analogRead(inY); // reading y value [range 0 -> 1023]
  if(xValue == 1023)
  {
    Serial.write("A");
    Serial.flush();
    delay(20);
  }
  if(xValue == 0)
  {
    Serial.write("D");
    Serial.flush();
    delay(20);
  }

  if(yValue == 1023)
  {
    Serial.write("W");
    Serial.flush();
    delay(20);
  }
  if(yValue == 0)
  {
    Serial.write("S");
    Serial.flush();
    delay(20);
  }
  else
  {
    Serial.write("1");
    Serial.flush();
    delay(20);
  } 
}


/*
x = 0 -> right
x = 1023 -> left

y = 1023 -> forward
y = 0 -> backward
 */
