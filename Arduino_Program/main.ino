#include <Servo.h>

Servo servo;
char num;
int time = 10000;

void setup() {
  servo.write(90);
  Serial.begin(115200);
  servo.attach(10, 700, 2300);
  pinMode(13,OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(8,OUTPUT);
  digitalWrite(8,LOW);
}

int part=1;
void loop() {

  if(Serial.available()){
    num = Serial.read();

    

  if(num == '1'){
    servo.write(90);
    
  } 

  if(num == '2'){
    servo.write(110);
  }

  if(num == '3'){
    servo.write(130);
  } 

  if(num == '4'){
    servo.write(150);
  }
  
  if(num == '5'){
    servo.write(170);
  } 

  if(num == '6'){
    servo.write(10);
  }
  
  if(num == '7'){
    servo.write(30);
  } 

  if(num == '8'){
    servo.write(50);
  }

  if(num == '9'){
    servo.write(70);
  }

  if(num == '0'){//正面
      digitalWrite(8,HIGH);
      delay(500);
      digitalWrite(8,LOW);
  }
  }

   

}